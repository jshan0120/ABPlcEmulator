namespace AbPlcEmulatorForm
{
    partial class AbPlcEmulatorForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.serverInfoGrid = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelConnection = new System.Windows.Forms.Panel();
            this.btnChangeTags = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.btnCloseServer = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.btnBrowseTagPath = new System.Windows.Forms.Button();
            this.tbTagPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.dgvTags = new System.Windows.Forms.DataGridView();
            this.btnDeleteTag = new System.Windows.Forms.Button();
            this.btnAddTag = new System.Windows.Forms.Button();
            this.tbTagSize = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTagType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTagName = new System.Windows.Forms.TextBox();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTagTypeInfosRight = new System.Windows.Forms.Label();
            this.lblTagTypeInfosLeft = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.openFileDialogTagPath = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer7);
            this.splitContainer1.Size = new System.Drawing.Size(1484, 761);
            this.splitContainer1.SplitterDistance = 939;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Size = new System.Drawing.Size(939, 761);
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel2);
            this.splitContainer3.Size = new System.Drawing.Size(939, 166);
            this.splitContainer3.SplitterDistance = 768;
            this.splitContainer3.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.serverInfoGrid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 160);
            this.panel1.TabIndex = 0;
            // 
            // serverInfoGrid
            // 
            this.serverInfoGrid.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.serverInfoGrid.LineColor = System.Drawing.Color.Gray;
            this.serverInfoGrid.Location = new System.Drawing.Point(-1, 36);
            this.serverInfoGrid.Name = "serverInfoGrid";
            this.serverInfoGrid.PropertySort = System.Windows.Forms.PropertySort.NoSort;
            this.serverInfoGrid.Size = new System.Drawing.Size(760, 123);
            this.serverInfoGrid.TabIndex = 0;
            this.serverInfoGrid.ToolbarVisible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "AB PLC Emulator Properties";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panelConnection);
            this.panel2.Controls.Add(this.btnChangeTags);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnOpenServer);
            this.panel2.Controls.Add(this.btnCloseServer);
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 160);
            this.panel2.TabIndex = 0;
            // 
            // panelConnection
            // 
            this.panelConnection.BackColor = System.Drawing.Color.Tomato;
            this.panelConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelConnection.Location = new System.Drawing.Point(81, 10);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(63, 16);
            this.panelConnection.TabIndex = 1;
            // 
            // btnChangeTags
            // 
            this.btnChangeTags.Location = new System.Drawing.Point(12, 117);
            this.btnChangeTags.Name = "btnChangeTags";
            this.btnChangeTags.Size = new System.Drawing.Size(137, 35);
            this.btnChangeTags.TabIndex = 0;
            this.btnChangeTags.Text = "Confirm Tags";
            this.btnChangeTags.UseVisualStyleBackColor = true;
            this.btnChangeTags.Click += new System.EventHandler(this.btnChangeTags_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Connection";
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.Location = new System.Drawing.Point(12, 35);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(137, 35);
            this.btnOpenServer.TabIndex = 0;
            this.btnOpenServer.Text = "Open Server";
            this.btnOpenServer.UseVisualStyleBackColor = true;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // btnCloseServer
            // 
            this.btnCloseServer.Location = new System.Drawing.Point(12, 76);
            this.btnCloseServer.Name = "btnCloseServer";
            this.btnCloseServer.Size = new System.Drawing.Size(137, 35);
            this.btnCloseServer.TabIndex = 0;
            this.btnCloseServer.Text = "Close Server";
            this.btnCloseServer.UseVisualStyleBackColor = true;
            this.btnCloseServer.Click += new System.EventHandler(this.btnCloseServer_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.splitContainer4);
            this.panel3.Location = new System.Drawing.Point(2, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(934, 585);
            this.panel3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Size = new System.Drawing.Size(932, 583);
            this.splitContainer4.SplitterDistance = 32;
            this.splitContainer4.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tags";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btnBrowseTagPath);
            this.splitContainer5.Panel1.Controls.Add(this.tbTagPath);
            this.splitContainer5.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(932, 547);
            this.splitContainer5.SplitterDistance = 47;
            this.splitContainer5.TabIndex = 0;
            // 
            // btnBrowseTagPath
            // 
            this.btnBrowseTagPath.Location = new System.Drawing.Point(744, 14);
            this.btnBrowseTagPath.Name = "btnBrowseTagPath";
            this.btnBrowseTagPath.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseTagPath.TabIndex = 2;
            this.btnBrowseTagPath.Text = "...";
            this.btnBrowseTagPath.UseVisualStyleBackColor = true;
            this.btnBrowseTagPath.Click += new System.EventHandler(this.btnBrowseTagPath_Click);
            // 
            // tbTagPath
            // 
            this.tbTagPath.Location = new System.Drawing.Point(117, 14);
            this.tbTagPath.Name = "tbTagPath";
            this.tbTagPath.ReadOnly = true;
            this.tbTagPath.Size = new System.Drawing.Size(621, 21);
            this.tbTagPath.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tag FilePath";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.dgvTags);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.btnDeleteTag);
            this.splitContainer6.Panel2.Controls.Add(this.btnAddTag);
            this.splitContainer6.Panel2.Controls.Add(this.tbTagSize);
            this.splitContainer6.Panel2.Controls.Add(this.label8);
            this.splitContainer6.Panel2.Controls.Add(this.label7);
            this.splitContainer6.Panel2.Controls.Add(this.label6);
            this.splitContainer6.Panel2.Controls.Add(this.cmbTagType);
            this.splitContainer6.Panel2.Controls.Add(this.label5);
            this.splitContainer6.Panel2.Controls.Add(this.tbTagName);
            this.splitContainer6.Size = new System.Drawing.Size(932, 496);
            this.splitContainer6.SplitterDistance = 433;
            this.splitContainer6.TabIndex = 0;
            // 
            // dgvTags
            // 
            this.dgvTags.AllowUserToAddRows = false;
            this.dgvTags.AllowUserToDeleteRows = false;
            this.dgvTags.AllowUserToResizeRows = false;
            this.dgvTags.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTags.Location = new System.Drawing.Point(0, 0);
            this.dgvTags.Name = "dgvTags";
            this.dgvTags.RowTemplate.Height = 23;
            this.dgvTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTags.Size = new System.Drawing.Size(932, 433);
            this.dgvTags.TabIndex = 0;
            this.dgvTags.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTags_CellValueChanged);
            this.dgvTags.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvTags_DataError);
            this.dgvTags.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvTags_RowsAdded);
            this.dgvTags.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTags_RowsRemoved);
            // 
            // btnDeleteTag
            // 
            this.btnDeleteTag.Location = new System.Drawing.Point(830, 23);
            this.btnDeleteTag.Name = "btnDeleteTag";
            this.btnDeleteTag.Size = new System.Drawing.Size(78, 23);
            this.btnDeleteTag.TabIndex = 5;
            this.btnDeleteTag.Text = "Delete";
            this.btnDeleteTag.UseVisualStyleBackColor = true;
            this.btnDeleteTag.Click += new System.EventHandler(this.btnDeleteTag_Click);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Location = new System.Drawing.Point(736, 22);
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Size = new System.Drawing.Size(78, 23);
            this.btnAddTag.TabIndex = 5;
            this.btnAddTag.Text = "Add";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // tbTagSize
            // 
            this.tbTagSize.Location = new System.Drawing.Point(612, 22);
            this.tbTagSize.Name = "tbTagSize";
            this.tbTagSize.Size = new System.Drawing.Size(100, 21);
            this.tbTagSize.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(576, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "Size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(273, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(97, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "Type";
            // 
            // cmbTagType
            // 
            this.cmbTagType.FormattingEnabled = true;
            this.cmbTagType.Location = new System.Drawing.Point(137, 23);
            this.cmbTagType.Name = "cmbTagType";
            this.cmbTagType.Size = new System.Drawing.Size(121, 20);
            this.cmbTagType.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "New Tag |";
            // 
            // tbTagName
            // 
            this.tbTagName.Location = new System.Drawing.Point(318, 22);
            this.tbTagName.Name = "tbTagName";
            this.tbTagName.Size = new System.Drawing.Size(241, 21);
            this.tbTagName.TabIndex = 0;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.rtbLog);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.panel4);
            this.splitContainer7.Size = new System.Drawing.Size(541, 761);
            this.splitContainer7.SplitterDistance = 644;
            this.splitContainer7.TabIndex = 1;
            // 
            // rtbLog
            // 
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Location = new System.Drawing.Point(0, 0);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(541, 644);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblTagTypeInfosRight);
            this.panel4.Controls.Add(this.lblTagTypeInfosLeft);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(540, 110);
            this.panel4.TabIndex = 0;
            // 
            // lblTagTypeInfosRight
            // 
            this.lblTagTypeInfosRight.AutoSize = true;
            this.lblTagTypeInfosRight.Location = new System.Drawing.Point(268, 41);
            this.lblTagTypeInfosRight.Name = "lblTagTypeInfosRight";
            this.lblTagTypeInfosRight.Size = new System.Drawing.Size(0, 12);
            this.lblTagTypeInfosRight.TabIndex = 1;
            // 
            // lblTagTypeInfosLeft
            // 
            this.lblTagTypeInfosLeft.AutoSize = true;
            this.lblTagTypeInfosLeft.Location = new System.Drawing.Point(42, 41);
            this.lblTagTypeInfosLeft.Name = "lblTagTypeInfosLeft";
            this.lblTagTypeInfosLeft.Size = new System.Drawing.Size(0, 12);
            this.lblTagTypeInfosLeft.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tag Types";
            // 
            // AbPlcEmulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1484, 761);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AbPlcEmulatorForm";
            this.Text = "AbPlcEmulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AbPlcEmulatorForm_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTags)).EndInit();
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.Button btnCloseServer;
        private System.Windows.Forms.Button btnChangeTags;
        private System.Windows.Forms.PropertyGrid serverInfoGrid;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button btnBrowseTagPath;
        private System.Windows.Forms.TextBox tbTagPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialogTagPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvTags;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Button btnDeleteTag;
        private System.Windows.Forms.Button btnAddTag;
        private System.Windows.Forms.TextBox tbTagSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTagType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbTagName;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTagTypeInfosLeft;
        private System.Windows.Forms.Label lblTagTypeInfosRight;
        private System.Windows.Forms.Panel panelConnection;
    }
}

