using AbPlcEmulator.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoPick.Logging;
using AbPlcEmulator.Models;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Docker.DotNet;
using Docker.DotNet.Models;
using CoPick.Setting;
using System.Threading;
using System.Buffers;
using libplctag;

namespace AbPlcEmulator.Presenters
{
    public class AbPlcEmulatorPresenter
    {
        private static readonly LogHelper Logger = LogHelper.Logger;

        private IAbPlcEmulatorView _view;
        private Type _typeOfView;

        private Models.Config _config;
        private Dictionary<string, TagInfo> _tags = new Dictionary<string, TagInfo>();

        private ServerInfo _serverInfo;
        private string _ip = string.Empty;
        private string _port = "44818";

        private bool _isServerOpen = false;

        private ProcessStartInfo _dockerProcessInfo;
        private Process _dockerProcess;
        private string _dockerTagPath = "/usr/libplctag/build/bin_dist/tags.txt";
        private DockerClient _dockerClient = null;
        private string _dockerContainer = string.Empty;
        private IImageOperations _image = null;

        private object _cellValue = null;

        private TagWriter _tagWriter;

        public AbPlcEmulatorPresenter(IAbPlcEmulatorView view, Models.Config config)
        {
            _view = view;
            _typeOfView = view.GetType();

            _config = config;
            SaveTagPath(Path.GetFullPath(config.TagFilePath));
            LoadTags();

            _view.ServerOpenRequested += View_ServerOpenRequested;
            _view.ServerCloseRequested += View_ServerCloseRequested;
            _view.ConfirmTagRequested += View_ConfirmTagRequested;
            _view.TagFilePathChanged += View_TagFilePathChanged;
            _view.TagChangingStarted += View_TagChangingStarted;
            _view.TagInvalidInputRequired += View_TagInvalidInputRequired;
            _view.ProgramExitRequested += View_ProgramExitRequested;
            _view.SetTagValueRequested += View_SetTagValueRequested;

            GetIpAddress();
            if (!string.IsNullOrEmpty(_ip))
            {
                _serverInfo = new ServerInfo(_ip, _port);
                _tagWriter = new TagWriter(_ip);
                InitUi();
            }
        }

        private void GetIpAddress()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                _ip = endPoint.Address.ToString();
            }

            if (string.IsNullOrEmpty(_ip))
            {
                Logger.Fatal("No network adapters with an IPv4 address exists");
            }
            else
            {
                Logger.Info($"Get IP Address {_ip}");
            }
        }

        private void InitUi()
        {
            _view.TagFilePath = Path.GetFullPath(_config.TagFilePath);
            _view.ServerInfoGridDataSource = _serverInfo;
            _view.ShowServerOpenInfo(false);
        }

        private async void View_ServerOpenRequested(object sender, EventArgs e)
        {
            Logger.Info("Open Server Requested");

            if (_dockerClient == null)
            {
                _dockerClient = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient();
            }

            if (string.IsNullOrEmpty(_dockerContainer))
            {
                _dockerContainer = await CreateNewContainer();
            }

            await Task.Run(() => StartDockerContainer());

            _isServerOpen = true;
            _view.ShowServerOpenInfo(_isServerOpen);
        }

        private async Task<string> CreateNewContainer()
        {
            await Task.Run(() => CreateDockerImage());
            Logger.Info("Create ab_server Docker Image Done");

            return await Task.Run(() => CreateDockerContainer());
        }

        private async void CreateDockerImage()
        {
            var imageParam = new ImagesCreateParameters() { FromImage = "jshan0120/ab_server", Tag = "4.0" };
            var authorConfig = new AuthConfig() { Email = "jshan@cle.vision" };
            await _dockerClient.Images.CreateImageAsync(imageParam, authorConfig, new Progress<JSONMessage>());
        }

        private async Task<string> CreateDockerContainer()
        {
            var portList = new List<PortBinding>() 
            { 
                new PortBinding 
                { 
                    HostIP = "0.0.0.0",
                    HostPort = _port 
                } 
            };
            var containerParam = new CreateContainerParameters()
            {
                Image = "jshan0120/ab_server:4.0",
                AttachStdout = true,
                ExposedPorts = new Dictionary<string, EmptyStruct>
                {
                    { _port, default(EmptyStruct) }
                },
                HostConfig = new HostConfig()
                {
                    DNS = new[] { "0.0.0.0" },
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        { _port, portList }
                    },
                    Binds = new[] { $"{_config.TagFilePath}:{_dockerTagPath}" }
                },
                AttachStderr = true
            };
            var response = await _dockerClient.Containers.CreateContainerAsync(containerParam);
            Logger.Info($"Create ab_server Docker Container Done with ID {response.ID.Substring(1, 12)}");
            return response.ID;
        }

        private async void StartDockerContainer()
        {
            await _dockerClient.Containers.StartContainerAsync(_dockerContainer, new ContainerStartParameters());
            Logger.Info("Start ab_server Docker Container Done");

            var attachParam = new ContainerAttachParameters()
            {
                Stream = true,
                Stdout = true,
                Stderr = true,
                Stdin = false
            };
            MultiplexedStream stream = await _dockerClient.Containers.AttachContainerAsync(_dockerContainer, false, attachParam);
            Logger.Info($"Attached ab_server Docker Container Done");

            Task.Run(() => GetContainerLogs(stream));
        }

        private async void View_ServerCloseRequested(object sender, EventArgs e)
        {
            Logger.Info("Close Server Requested");
            await _dockerClient.Containers.StopContainerAsync(_dockerContainer, new ContainerStopParameters());
            Logger.Info("Stop ab_server Docker Container Done");

            _isServerOpen = false;
            _view.ShowServerOpenInfo(_isServerOpen);
        }

        private void View_TagFilePathChanged(object sender, TagFilePathChangedEventArgs e)
        {
            if (_config.TagFilePath != e.TagFilePath)
            {
                Logger.Info($"Tag File Path Changed To {_config.TagFilePath}");
                SaveTagPath(e.TagFilePath);
                LoadTags();
            }
        }

        private void SaveTagPath(string newPath)
        {
            _config.TagFilePath = newPath.Replace("\\", "/");
        }

        private async void LoadTags()
        {
            if (!File.Exists(_config.TagFilePath))
            {
                Logger.Error("TagFile Not Exists");
                return;
            }

            _tags = TagFileManager.LoadFromFile(_config.TagFilePath);
            if (_tags == null || _tags.Count == 0)
            {
                Logger.Error("Load TagFile Failed");
            }
            else
            {
                Logger.Info("Load TagFile Succeed");

                await Task.Run(() => RemoveDockerContainer());

                _view.ShowTags(_tags);
                _view.ShowTagConfirmed();
            }
        }

        private void View_TagChangingStarted(object sender, CellChangedEventArgs e)
        {
            _cellValue = e.Value;
        }

        private void View_TagInvalidInputRequired(object sender, CellChangedEventArgs e)
        {
            _view.RetriveInvalidValue(e.ColumnIndex, e.RowIndex, _cellValue);
        }

        private async void View_ConfirmTagRequested(object sender, ChangedTagsEventArgs e)
        {
            if (_isServerOpen)
            {
                Logger.Warning("Server Already Running");
                return;
            }

            await Task.Run(() => RemoveDockerContainer());

            TagFileManager.SaveToFile(_config.TagFilePath, e.Tags);
            Logger.Info($"Save Tags To Path {_config.TagFilePath} Succeed");

            _view.ShowTagConfirmed();
        }

        private void View_SetTagValueRequested(object sender, SetTagValueEventArgs e)
        {
            if (_isServerOpen)
            {
                TagInfo tagInfo = e.Tag;
                _tagWriter.TagWrite(tagInfo.Type, tagInfo.Name, tagInfo.Value);
            }
            else
            {
                Logger.Error("Write Value To Tag Failed, Server Not Opened");
                _view.RetriveInvalidValue(e.ColumnIndex, e.RowIndex, _cellValue);
            }
        }

        private async void View_ProgramExitRequested(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you shre to Exit Program?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
            {
                try
                {
                    if (_isServerOpen)
                    {
                        Logger.Warning("Server Already Running");
                        await Task.Run(() => KillDockerContainer());
                    }

                    await Task.Run(() => RemoveDockerContainer());

                    Logger.Debug("Program Exited");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private async void RemoveDockerContainer()
        {
            if (!string.IsNullOrEmpty(_dockerContainer))
            {
                await _dockerClient.Containers.RemoveContainerAsync(_dockerContainer, new ContainerRemoveParameters());
                _dockerContainer = string.Empty;
                Logger.Info("Remove Existing Container Done");
            }
        }

        private async void KillDockerContainer()
        {
            if (!string.IsNullOrEmpty(_dockerContainer))
            {
                await _dockerClient.Containers.KillContainerAsync(_dockerContainer, new ContainerKillParameters());
            }
        }

        private async void GetContainerLogs(MultiplexedStream stream)
        {
            var readTask = Task.Run(async () =>
            {
                byte[] buffer = ArrayPool<byte>.Shared.Rent(81920);

                try
                {
                    for (; ; )
                    {
                        MultiplexedStream.ReadResult result = await stream.ReadOutputAsync(buffer, 0, buffer.Length, CancellationToken.None);

                        if (result.EOF)
                        {
                            return;
                        }

                        if (result.Count == 0)
                        {
                            return;
                        }

                        var output = Encoding.UTF8.GetString(buffer);
                        if (!string.IsNullOrEmpty(output))
                        {
                            Logger.Info(output);
                            buffer = Enumerable.Repeat((byte)0, buffer.Length).ToArray();
                        }
                    }
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(buffer);
                }
            });

            await readTask;
        }
    }
}
