using AbPlcEmulator.Models;
using AbPlcEmulator.View;
using CoPick;
using CoPick.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core.Tokens;

namespace AbPlcEmulatorForm
{
    public partial class AbPlcEmulatorForm : Form, IAbPlcEmulatorView
    {
        private static readonly LogHelper Logger = LogHelper.Logger;

        public event EventHandler ServerOpenRequested;
        public event EventHandler ServerCloseRequested;
        public event EventHandler<ChangedTagsEventArgs> ConfirmTagRequested;
        public event EventHandler<TagFilePathChangedEventArgs> TagFilePathChanged;
        public event EventHandler<CellChangedEventArgs> TagChangingStarted;
        public event EventHandler<CellChangedEventArgs> TagInvalidInputRequired;
        public event EventHandler<FormClosingEventArgs> ProgramExitRequested;
        public event EventHandler<SetTagValueEventArgs> SetTagValueRequested;
        public event EventHandler<ChangedTagsEventArgs> ShowValuesRequested;

        bool RetriveValue = false;
        public bool IsServerOpening { get; set; } = false;

        public object ServerInfoGridDataSource
        {
            set
            {
                serverInfoGrid.InvokeIfNeeded(() =>
                {
                    serverInfoGrid.SelectedObject = value;
                });
            }
        }

        public string TagFilePath
        {
            get => tbTagPath.InvokeIfNeeded(() => tbTagPath.Text);
            set => tbTagPath.InvokeIfNeeded(() => tbTagPath.Text = value);
        }

        public AbPlcEmulatorForm()
        {
            InitializeComponent();

            Logger.RtbLog = rtbLog;
            Logger.MaxLine = 1000;

            string newline = Environment.NewLine;
            lblTagTypeInfosLeft.Text = $"SINT   - 1-byte signed integer.{newline}INT    - 2-byte signed integer.{newline}DINT   - 4-byte signed integer.{newline}LINT   - 8-byte signed integer.";
            lblTagTypeInfosRight.Text = $"REAL   - 4-byte floating point number.{newline}LREAL  - 8-byte floating point number.{newline}STRING - 82-byte string.{newline}BOOL   - 1-byte boolean value.";

            cmbTagType.DataSource = Enum.GetValues(typeof(TagTypes));

            dgvTags.RowHeadersVisible = false;
            dgvTags.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTags.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            SetDefaultDgvTag();
            dgvTags.CellBeginEdit += dgvTags_CellBeginEdit;
        }

        private void SetDefaultDgvTag()
        {
            DataGridViewColumn nameCol = new DataGridViewColumn();
            nameCol.Name = "Name";
            nameCol.ValueType = typeof(string);
            nameCol.CellTemplate = new DataGridViewTextBoxCell();
            dgvTags.Columns.Add(nameCol);

            DataGridViewComboBoxColumn typeCol = new DataGridViewComboBoxColumn();
            typeCol.Name = "Type";
            typeCol.DataSource = Enum.GetValues(typeof(TagTypes));
            typeCol.ValueType = typeof(TagTypes);
            dgvTags.Columns.Add(typeCol);

            DataGridViewColumn sizeCol = new DataGridViewColumn();
            sizeCol.Name = "Size";
            sizeCol.ValueType = typeof(int);
            sizeCol.CellTemplate = new DataGridViewTextBoxCell();
            dgvTags.Columns.Add(sizeCol);

            DataGridViewColumn valueCol = new DataGridViewColumn();
            valueCol.Name = "Value";
            valueCol.ValueType = typeof(string);
            valueCol.CellTemplate = new DataGridViewTextBoxCell();
            dgvTags.Columns.Add(valueCol);
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            if (btnChangeTags.BackColor == Color.Tomato)
            {
                if (DialogResult.Yes == MessageBox.Show("Open Server Not Reflecting Changes?", "Warning", MessageBoxButtons.YesNo))
                {
                    ServerOpenRequested?.Invoke(this, EventArgs.Empty);
                }
            }
            else
            {
                ServerOpenRequested?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnCloseServer_Click(object sender, EventArgs e)
        {
            ServerCloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnChangeTags_Click(object sender, EventArgs e)
        {
            Dictionary<string, TagInfo> tags = GetAllTags();
            ConfirmTagRequested?.Invoke(this, new ChangedTagsEventArgs(tags));
        }

        private void btnBrowseTagPath_Click(object sender, EventArgs e)
        {
            if (!btnOpenServer.Enabled)
            {
                Logger.Warning("Server Already Running");
                return;
            }

            if (openFileDialogTagPath.ShowDialog() == DialogResult.OK)
            {
                tbTagPath.Text = openFileDialogTagPath.FileName;
                TagFilePathChanged?.Invoke(this, new TagFilePathChangedEventArgs(tbTagPath.Text));
            }
        }

        public void ShowTags(Dictionary<string, TagInfo> tags)
        {
            this.InvokeIfNeeded(() =>
            {
                dgvTags.Rows.Clear();
                foreach (TagInfo tag in tags.Values)
                {
                    dgvTags.Rows.Add(tag.Name, tag.Type, tag.Size, tag.Value);
                }
            });
        }

        private void dgvTags_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            TagChangingStarted?.Invoke(this, new CellChangedEventArgs(e.ColumnIndex, e.RowIndex, dgvTags[e.ColumnIndex, e.RowIndex].Value));
        }

        private void dgvTags_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Invalid Value");
            TagInvalidInputRequired?.Invoke(this, new CellChangedEventArgs(e.ColumnIndex, e.RowIndex, dgvTags[e.ColumnIndex, e.RowIndex].Value));
        }

        public void RetriveInvalidValue(int columnIndex, int rowIndex, object value)
        {
            this.InvokeIfNeeded(() =>
            {
                RetriveValue = true;
                dgvTags[columnIndex, rowIndex].Value = value;
            });
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            if ((TagTypes)cmbTagType.SelectedValue == TagTypes.None)
            {
                MessageBox.Show("Please Select TagType");
                return;
            }

            if (string.IsNullOrEmpty(tbTagName.Text))
            {
                MessageBox.Show("Please Enter TagName");
                return;
            }

            int tagSize = 0;
            if (string.IsNullOrEmpty(tbTagSize.Text))
            {
                MessageBox.Show("Please Enter TagSize");
                return;
            }
            else if (!int.TryParse(tbTagSize.Text, out tagSize))
            {
                MessageBox.Show("Please Enter TagSize In Integer Value");
                return;
            }

            TagInfo tag = new TagInfo(tbTagName.Text, (TagTypes)cmbTagType.SelectedValue, tagSize);
            dgvTags.Rows.Add(tag.Name, tag.Type, tag.Size, tag.Value.ToString());
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTags.SelectedRows)
            {
                dgvTags.Rows.Remove(row);
            }
        }

        private bool CheckInvalidValue(TagTypes tagType, string value)
        {
            switch (tagType)
            {
                case TagTypes.Sint:
                    return sbyte.TryParse(value, out sbyte resByte);
                case TagTypes.Int:
                    return short.TryParse(value, out short resShort);
                case TagTypes.Dint:
                    return int.TryParse(value, out int resInt);
                case TagTypes.Lint:
                    return long.TryParse(value, out long resLong);
                case TagTypes.String:
                    return true;
                case TagTypes.Real:
                    return float.TryParse(value, out float resFloat);
                case TagTypes.Lreal:
                    return double.TryParse(value, out double resDouble);
                case TagTypes.Bool:
                    return bool.TryParse(value.ToLower(), out bool resBool);
                default:
                    return false;
            }
        }


        private void dgvTags_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        { 
            if (RetriveValue)
            {
                RetriveValue = false;
                return;
            }
            if (IsServerOpening)
            {
                return;
            }

            if (e.ColumnIndex == 3)
            {
                TagTypes type = (TagTypes)dgvTags[1, e.RowIndex].Value;
                string value = dgvTags[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (!CheckInvalidValue(type, value))
                {
                    MessageBox.Show("Invalid Value");
                    TagInvalidInputRequired?.Invoke(this, new CellChangedEventArgs(e.ColumnIndex, e.RowIndex, value));
                }
                else
                {
                    TagInfo tag = new TagInfo((string)dgvTags[0, e.RowIndex].Value, type, (int)dgvTags[2, e.RowIndex].Value);
                    tag.SetValue(value);
                    SetTagValueRequested?.Invoke(this, new SetTagValueEventArgs(tag, e.ColumnIndex, e.RowIndex));
                }
            }
            else if (e.ColumnIndex == 1)
            {
                if ((TagTypes)dgvTags[1, e.RowIndex].Value == TagTypes.None)
                {
                    TagInvalidInputRequired?.Invoke(this, new CellChangedEventArgs(e.ColumnIndex, e.RowIndex, dgvTags[e.ColumnIndex, e.RowIndex].Value.ToString()));
                }
                else
                {
                    if (btnOpenServer.Enabled)
                    {
                        btnChangeTags.BackColor = Color.Tomato;

                        TagTypes type = (TagTypes)dgvTags[1, e.RowIndex].Value;
                        TagInfo tag = new TagInfo((string)dgvTags[0, e.RowIndex].Value, type, (int)dgvTags[2, e.RowIndex].Value);
                        dgvTags.Rows.RemoveAt(e.RowIndex);
                        dgvTags.Rows.Insert(e.RowIndex, new object[] { tag.Name, type, tag.Size, tag.Value });
                    }
                    else
                    {
                        MessageBox.Show("Server Already Running");
                        TagInvalidInputRequired?.Invoke(this, new CellChangedEventArgs(e.ColumnIndex, e.RowIndex, dgvTags[e.ColumnIndex, e.RowIndex].Value.ToString()));
                    }
                }
            }
            else
            {
                if (btnOpenServer.Enabled)
                {
                    btnChangeTags.BackColor = Color.Tomato;
                }
                else
                {
                    MessageBox.Show("Server Already Running");
                    TagInvalidInputRequired?.Invoke(this, new CellChangedEventArgs(e.ColumnIndex, e.RowIndex, dgvTags[e.ColumnIndex, e.RowIndex].Value.ToString()));
                }
            }
        }

        private void dgvTags_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            btnChangeTags.BackColor = Color.Tomato;
        }

        private void dgvTags_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            btnChangeTags.BackColor = Color.Tomato;
        }

        public void ShowTagConfirmed()
        {
            this.InvokeIfNeeded(() =>
            {
                btnChangeTags.BackColor = Color.LimeGreen;
            });
        }

        public void ShowServerOpenInfo(bool serverOpened)
        {
            this.InvokeIfNeeded(() =>
            {
                if (serverOpened)
                {
                    btnOpenServer.Enabled = false;
                    btnCloseServer.Enabled = true;
                    panelConnection.BackColor = Color.LimeGreen;
                }
                else
                {
                    btnOpenServer.Enabled = true;
                    btnCloseServer.Enabled = false;
                    panelConnection.BackColor = Color.Tomato;
                }
            });
        }

        private void AbPlcEmulatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProgramExitRequested?.Invoke(this, e);
        }

        private Dictionary<string, TagInfo> GetAllTags()
        {
            Dictionary<string, TagInfo> tags = new Dictionary<string, TagInfo>();
            foreach (DataGridViewRow row in dgvTags.Rows)
            {
                string name = (string)row.Cells[0].Value;
                TagInfo tag = new TagInfo(name, (TagTypes)row.Cells[1].Value, (int)row.Cells[2].Value);
                tags.Add(name, tag);
            }
            return tags;
        }

        private void btnShowValues_Click(object sender, EventArgs e)
        {
            Dictionary<string, TagInfo> tags = GetAllTags();
            ShowValuesRequested?.Invoke(this, new ChangedTagsEventArgs(tags));
        }

        public void ShowValues(Dictionary<string, string> values)
        {
            this.InvokeIfNeeded(() =>
            {
                foreach (DataGridViewRow row in dgvTags.Rows)
                {
                    row.Cells[3].Value = values[row.Cells[0].Value.ToString()];
                }
            });
        }

        public void ShowDefaultValues()
        {
            this.InvokeIfNeeded(() =>
            {
                foreach (DataGridViewRow row in dgvTags.Rows)
                {
                    switch ((TagTypes)row.Cells[1].Value)
                    {
                        case TagTypes.Sint:
                        case TagTypes.Int:
                        case TagTypes.Dint:
                        case TagTypes.Lint:
                        case TagTypes.Real:
                        case TagTypes.Lreal:
                            row.Cells[3].Value = "0";
                            break;
                        case TagTypes.String:
                            row.Cells[3].Value = "";
                            break;
                        case TagTypes.Bool:
                            row.Cells[3].Value = "False";
                            break;
                    }
                }
            });
        }
    }
}
