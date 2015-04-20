namespace FPlus
{
    partial class ucAutoMessage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopPost = new System.Windows.Forms.Button();
            this.lbTotalProcessed = new System.Windows.Forms.Label();
            this.metroProgressSpinnerOnePost = new MetroFramework.Controls.MetroProgressSpinner();
            this.lbStatus = new System.Windows.Forms.Label();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtTimeDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lbDsNhom = new System.Windows.Forms.Label();
            this.timerstep = new System.Windows.Forms.Timer(this.components);
            this.per = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbPostGroup = new System.Windows.Forms.WebBrowser();
            this.txtLimit = new System.Windows.Forms.NumericUpDown();
            this.txtOffset = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.listBoxGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbbGroups = new System.Windows.Forms.ComboBox();
            this.bwSearchMember = new System.ComponentModel.BackgroundWorker();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.txtCountPerSend = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDelay)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountPerSend)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStopPost);
            this.groupBox1.Controls.Add(this.lbTotalProcessed);
            this.groupBox1.Controls.Add(this.metroProgressSpinnerOnePost);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.progressBarStatus);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtTimeDelay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(421, 388);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 111);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tự động tham gia nhóm";
            // 
            // btnStopPost
            // 
            this.btnStopPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(63)))), ((int)(((byte)(58)))));
            this.btnStopPost.FlatAppearance.BorderSize = 0;
            this.btnStopPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopPost.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStopPost.ForeColor = System.Drawing.Color.White;
            this.btnStopPost.Location = new System.Drawing.Point(447, 17);
            this.btnStopPost.Name = "btnStopPost";
            this.btnStopPost.Size = new System.Drawing.Size(100, 43);
            this.btnStopPost.TabIndex = 41;
            this.btnStopPost.Text = "Kết thúc";
            this.btnStopPost.UseVisualStyleBackColor = false;
            this.btnStopPost.Click += new System.EventHandler(this.btnStopPost_Click);
            // 
            // lbTotalProcessed
            // 
            this.lbTotalProcessed.Location = new System.Drawing.Point(446, 70);
            this.lbTotalProcessed.Name = "lbTotalProcessed";
            this.lbTotalProcessed.Size = new System.Drawing.Size(100, 13);
            this.lbTotalProcessed.TabIndex = 40;
            this.lbTotalProcessed.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // metroProgressSpinnerOnePost
            // 
            this.metroProgressSpinnerOnePost.BackColor = System.Drawing.Color.Transparent;
            this.metroProgressSpinnerOnePost.Location = new System.Drawing.Point(16, 65);
            this.metroProgressSpinnerOnePost.Maximum = 100;
            this.metroProgressSpinnerOnePost.Name = "metroProgressSpinnerOnePost";
            this.metroProgressSpinnerOnePost.Size = new System.Drawing.Size(16, 16);
            this.metroProgressSpinnerOnePost.TabIndex = 39;
            this.metroProgressSpinnerOnePost.Visible = false;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(37, 68);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(55, 13);
            this.lbStatus.TabIndex = 38;
            this.lbStatus.Text = "Trạng thái";
            this.lbStatus.Visible = false;
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(13, 86);
            this.progressBarStatus.Maximum = 1000;
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(535, 10);
            this.progressBarStatus.TabIndex = 37;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(342, 17);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 43);
            this.btnStart.TabIndex = 22;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtTimeDelay
            // 
            this.txtTimeDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtTimeDelay.Location = new System.Drawing.Point(245, 28);
            this.txtTimeDelay.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtTimeDelay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTimeDelay.Name = "txtTimeDelay";
            this.txtTimeDelay.Size = new System.Drawing.Size(72, 20);
            this.txtTimeDelay.TabIndex = 16;
            this.txtTimeDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtTimeDelay.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(14, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Thời gian join (nên để thời gian từ 10> 90 giây)";
            // 
            // lbDsNhom
            // 
            this.lbDsNhom.AutoSize = true;
            this.lbDsNhom.ForeColor = System.Drawing.Color.Navy;
            this.lbDsNhom.Location = new System.Drawing.Point(37, 35);
            this.lbDsNhom.Name = "lbDsNhom";
            this.lbDsNhom.Size = new System.Drawing.Size(85, 13);
            this.lbDsNhom.TabIndex = 43;
            this.lbDsNhom.Text = "Kết quả tìm kiếm";
            // 
            // timerstep
            // 
            this.timerstep.Interval = 10000;
            this.timerstep.Tick += new System.EventHandler(this.timerstep_Tick);
            // 
            // per
            // 
            this.per.Interval = 1000;
            this.per.Tick += new System.EventHandler(this.per_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(161, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Bắt đầu từ thứ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCountPerSend);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.wbPostGroup);
            this.groupBox2.Controls.Add(this.txtLimit);
            this.groupBox2.Controls.Add(this.txtOffset);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(421, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 335);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập nội dung bài đăng";
            // 
            // wbPostGroup
            // 
            this.wbPostGroup.Location = new System.Drawing.Point(40, 204);
            this.wbPostGroup.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPostGroup.Name = "wbPostGroup";
            this.wbPostGroup.ScriptErrorsSuppressed = true;
            this.wbPostGroup.Size = new System.Drawing.Size(506, 114);
            this.wbPostGroup.TabIndex = 45;
            this.wbPostGroup.Url = new System.Uri("", System.UriKind.Relative);
            this.wbPostGroup.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbPostGroup_DocumentCompleted);
            // 
            // txtLimit
            // 
            this.txtLimit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtLimit.Location = new System.Drawing.Point(245, 167);
            this.txtLimit.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(139, 20);
            this.txtLimit.TabIndex = 43;
            this.txtLimit.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // txtOffset
            // 
            this.txtOffset.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtOffset.Location = new System.Drawing.Point(245, 117);
            this.txtOffset.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtOffset.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(139, 20);
            this.txtOffset.TabIndex = 44;
            this.txtOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(74, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Tổng số người muốn gửi tin nhắn:";
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Checked = true;
            this.cbSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSelectAll.Location = new System.Drawing.Point(18, 35);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(15, 14);
            this.cbSelectAll.TabIndex = 48;
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // listBoxGroup
            // 
            this.listBoxGroup.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listBoxGroup.CheckBoxes = true;
            this.listBoxGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listBoxGroup.FullRowSelect = true;
            this.listBoxGroup.GridLines = true;
            listViewItem3.StateImageIndex = 0;
            listViewItem4.StateImageIndex = 0;
            this.listBoxGroup.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listBoxGroup.Location = new System.Drawing.Point(12, 51);
            this.listBoxGroup.Name = "listBoxGroup";
            this.listBoxGroup.Size = new System.Drawing.Size(403, 447);
            this.listBoxGroup.TabIndex = 49;
            this.listBoxGroup.UseCompatibleStateImageBehavior = false;
            this.listBoxGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nhóm";
            this.columnHeader1.Width = 299;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Trạng Thái";
            this.columnHeader2.Width = 98;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(239, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 23);
            this.btnSearch.TabIndex = 51;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbbGroups
            // 
            this.cbbGroups.FormattingEnabled = true;
            this.cbbGroups.Location = new System.Drawing.Point(12, 9);
            this.cbbGroups.Name = "cbbGroups";
            this.cbbGroups.Size = new System.Drawing.Size(221, 21);
            this.cbbGroups.TabIndex = 52;
            // 
            // bwSearchMember
            // 
            this.bwSearchMember.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSearchMember_DoWork);
            this.bwSearchMember.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSearchMember_RunWorkerCompleted);
            // 
            // pbLoading
            // 
            this.pbLoading.BackColor = System.Drawing.Color.White;
            this.pbLoading.Image = global::FPlus.Properties.Resources.loading_blue;
            this.pbLoading.Location = new System.Drawing.Point(195, 174);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(48, 48);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 53;
            this.pbLoading.TabStop = false;
            // 
            // txtCountPerSend
            // 
            this.txtCountPerSend.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtCountPerSend.Location = new System.Drawing.Point(245, 81);
            this.txtCountPerSend.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txtCountPerSend.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtCountPerSend.Name = "txtCountPerSend";
            this.txtCountPerSend.Size = new System.Drawing.Size(139, 20);
            this.txtCountPerSend.TabIndex = 47;
            this.txtCountPerSend.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(138, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Số tin nhắn / 1 lần :";
            // 
            // ucAutoMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.cbbGroups);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.listBoxGroup);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbDsNhom);
            this.Controls.Add(this.groupBox2);
            this.Name = "ucAutoMessage";
            this.Size = new System.Drawing.Size(996, 508);
            this.Load += new System.EventHandler(this.ucAutoMessage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDelay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountPerSend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown txtTimeDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbDsNhom;
        private System.Windows.Forms.Timer timerstep;
        private System.Windows.Forms.Timer per;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Label lbStatus;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinnerOnePost;
        private System.Windows.Forms.Label lbTotalProcessed;
        private System.Windows.Forms.Button btnStopPost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.ListView listBoxGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.NumericUpDown txtLimit;
        private System.Windows.Forms.NumericUpDown txtOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser wbPostGroup;
        private System.Windows.Forms.ComboBox cbbGroups;
        private System.ComponentModel.BackgroundWorker bwSearchMember;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.NumericUpDown txtCountPerSend;
        private System.Windows.Forms.Label label3;
    }
}
