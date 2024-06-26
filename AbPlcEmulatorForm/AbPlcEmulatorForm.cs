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
            valueCol.CellTemplate = new DataGridViewTextBoxCell();
            dgvTags.Columns.Add(valueCol);
        }

        private void btnOpenServer_Click(object sender, EventArgs e)
        {
            ServerOpenRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnCloseServer_Click(object sender, EventArgs e)
        {
            ServerCloseRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnChangeTags_Click(object sender, EventArgs e)
        {
            Dictionary<string, TagInfo> tags = new Dictionary<string, TagInfo>();
            foreach (DataGridViewRow row in dgvTags.Rows)
            {
                string name = (string)row.Cells[0].Value;
                TagInfo tag = new TagInfo(name, (TagTypes)row.Cells[1].Value, (int)row.Cells[2].Value);
                tags.Add(name, tag);
            }
            ConfirmTagRequested?.Invoke(this, new ChangedTagsEventArgs(tags));
        }

        private void btnBrowseTagPath_Click(object sender, EventArgs e)
        {
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
            dgvTags.Rows.Add(tag.Name, tag.Type, tag.Size, tag.Value);
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTags.SelectedRows)
            {
                dgvTags.Rows.Remove(row);
            }
        }

        private bool CheckInvalidValue(TagTypes tagType, object value)
        {
            switch (tagType)
            {
                case TagTypes.Sint:
                    return value is byte;
                case TagTypes.Int:
                    return value is short;
                case TagTypes.Dint:
                    return value is int;
                case TagTypes.Lint:
                    return value is long;
                case TagTypes.String:
                    return value is string;
                case TagTypes.Real:
                    return value is float;
                case TagTypes.Lreal:
                    return value is double;
                case TagTypes.Bool:
                    return value is bool;
                default:
                    return false;
            }
        }

        private void dgvTags_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                TagTypes type = (TagTypes)dgvTags[1, e.RowIndex].Value;
                object value = dgvTags[e.ColumnIndex, e.RowIndex].Value;
                if (!CheckInvalidValue(type, value))
                {
                    MessageBox.Show("Invalid Value");
                    TagInvalidInputRequired?.Invoke(this, new CellChangedEventArgs(e.ColumnIndex, e.RowIndex, value));
                    btnChangeTags.BackColor = Color.LimeGreen;
                }
                else
                {
                    btnChangeTags.BackColor = Color.Tomato;
                }
            }
            else
            {
                btnChangeTags.BackColor = Color.Tomato;
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
    }
}
