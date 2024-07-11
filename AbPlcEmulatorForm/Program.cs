using AbPlcEmulator.Models;
using AbPlcEmulator.Presenters;
using CoPick.Logging;
using CoPick.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbPlcEmulatorForm
{
    internal static class Program
    {
        private static readonly LogHelper Logger = LogHelper.Logger;
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.Diagnostics.Process.GetProcessesByName("AbPlcEmulatorForm").Length > 1)
            {
                MessageBox.Show("Program is already running.", "WARNING");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Config config;
            try
            {
                string path = ConfigFileManager.GetConfigFilePath();
                config = ConfigFileManager.LoadFromFile<Config>(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ConfigError {ex}");
                return;
            }
            Logger.Configure("./", LogLevel.Debug, LogLevel.Debug);

            var mainForm = new AbPlcEmulatorForm();
            var mainPresenter = new AbPlcEmulatorPresenter(mainForm, config);

            Application.Run(mainForm);
        }
    }
}
