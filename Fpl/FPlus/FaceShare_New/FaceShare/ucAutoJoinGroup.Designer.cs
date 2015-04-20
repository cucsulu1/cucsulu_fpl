namespace FPlus
{
    partial class ucAutoJoinGroup
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            this.wbPostGroup = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStopPost = new System.Windows.Forms.Button();
            this.lbTotalProcessed = new System.Windows.Forms.Label();
            this.metroProgressSpinnerOnePost = new MetroFramework.Controls.MetroProgressSpinner();
            this.lbStatus = new System.Windows.Forms.Label();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtTimeDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnChooseImage1 = new System.Windows.Forms.Button();
            this.txtImageFile1 = new System.Windows.Forms.TextBox();
            this.lbDsNhom = new System.Windows.Forms.Label();
            this.timerstep = new System.Windows.Forms.Timer(this.components);
            this.per = new System.Windows.Forms.Timer(this.components);
            this.txtPostContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPostLink = new System.Windows.Forms.TextBox();
            this.rdShareImage = new System.Windows.Forms.RadioButton();
            this.rdSharePost = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenPost = new System.Windows.Forms.Button();
            this.btnSavePost = new System.Windows.Forms.Button();
            this.rdShareLinkWebsite = new System.Windows.Forms.RadioButton();
            this.txtLinkWebsite = new System.Windows.Forms.TextBox();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.listBoxGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDelay)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbPostGroup
            // 
            this.wbPostGroup.Location = new System.Drawing.Point(19, 39);
            this.wbPostGroup.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPostGroup.Name = "wbPostGroup";
            this.wbPostGroup.ScriptErrorsSuppressed = true;
            this.wbPostGroup.Size = new System.Drawing.Size(631, 114);
            this.wbPostGroup.TabIndex = 41;
            this.wbPostGroup.Url = new System.Uri("", System.UriKind.Relative);
            this.wbPostGroup.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webmain_DocumentCompleted);
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
            this.groupBox1.Location = new System.Drawing.Point(319, 387);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 111);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tự động đăng bài";
            // 
            // btnStopPost
            // 
            this.btnStopPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(63)))), ((int)(((byte)(58)))));
            this.btnStopPost.FlatAppearance.BorderSize = 0;
            this.btnStopPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopPost.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStopPost.ForeColor = System.Drawing.Color.White;
            this.btnStopPost.Location = new System.Drawing.Point(551, 17);
            this.btnStopPost.Name = "btnStopPost";
            this.btnStopPost.Size = new System.Drawing.Size(100, 43);
            this.btnStopPost.TabIndex = 41;
            this.btnStopPost.Text = "Kết thúc";
            this.btnStopPost.UseVisualStyleBackColor = false;
            this.btnStopPost.Click += new System.EventHandler(this.btnStopPost_Click);
            // 
            // lbTotalProcessed
            // 
            this.lbTotalProcessed.Location = new System.Drawing.Point(470, 70);
            this.lbTotalProcessed.Name = "lbTotalProcessed";
            this.lbTotalProcessed.Size = new System.Drawing.Size(179, 13);
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
            this.progressBarStatus.Size = new System.Drawing.Size(638, 10);
            this.progressBarStatus.TabIndex = 37;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(446, 17);
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
            this.txtTimeDelay.Location = new System.Drawing.Point(255, 28);
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
            this.label4.Size = new System.Drawing.Size(235, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Thời gian đăng (nên để thời gian từ 10> 90 giây)";
            // 
            // btnChooseImage1
            // 
            this.btnChooseImage1.Location = new System.Drawing.Point(575, 180);
            this.btnChooseImage1.Name = "btnChooseImage1";
            this.btnChooseImage1.Size = new System.Drawing.Size(73, 23);
            this.btnChooseImage1.TabIndex = 34;
            this.btnChooseImage1.Text = "Chọn ảnh";
            this.btnChooseImage1.UseVisualStyleBackColor = true;
            this.btnChooseImage1.Click += new System.EventHandler(this.btnChooseImage1_Click);
            // 
            // txtImageFile1
            // 
            this.txtImageFile1.Location = new System.Drawing.Point(18, 182);
            this.txtImageFile1.Name = "txtImageFile1";
            this.txtImageFile1.Size = new System.Drawing.Size(551, 20);
            this.txtImageFile1.TabIndex = 29;
            // 
            // lbDsNhom
            // 
            this.lbDsNhom.AutoSize = true;
            this.lbDsNhom.ForeColor = System.Drawing.Color.Navy;
            this.lbDsNhom.Location = new System.Drawing.Point(37, 12);
            this.lbDsNhom.Name = "lbDsNhom";
            this.lbDsNhom.Size = new System.Drawing.Size(88, 13);
            this.lbDsNhom.TabIndex = 43;
            this.lbDsNhom.Text = "Danh sách nhóm";
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
            // txtPostContent
            // 
            this.txtPostContent.Location = new System.Drawing.Point(19, 39);
            this.txtPostContent.Multiline = true;
            this.txtPostContent.Name = "txtPostContent";
            this.txtPostContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPostContent.Size = new System.Drawing.Size(633, 114);
            this.txtPostContent.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Nội dung bài viết:";
            // 
            // txtPostLink
            // 
            this.txtPostLink.Location = new System.Drawing.Point(18, 239);
            this.txtPostLink.Name = "txtPostLink";
            this.txtPostLink.Size = new System.Drawing.Size(632, 20);
            this.txtPostLink.TabIndex = 42;
            // 
            // rdShareImage
            // 
            this.rdShareImage.AutoSize = true;
            this.rdShareImage.Checked = true;
            this.rdShareImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdShareImage.Location = new System.Drawing.Point(19, 160);
            this.rdShareImage.Name = "rdShareImage";
            this.rdShareImage.Size = new System.Drawing.Size(154, 17);
            this.rdShareImage.TabIndex = 45;
            this.rdShareImage.TabStop = true;
            this.rdShareImage.Text = "Đăng ảnh (có thể để trống)";
            this.rdShareImage.UseVisualStyleBackColor = true;
            this.rdShareImage.CheckedChanged += new System.EventHandler(this.rdShareImage_CheckedChanged);
            // 
            // rdSharePost
            // 
            this.rdSharePost.AutoSize = true;
            this.rdSharePost.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdSharePost.Location = new System.Drawing.Point(19, 216);
            this.rdSharePost.Name = "rdSharePost";
            this.rdSharePost.Size = new System.Drawing.Size(178, 17);
            this.rdSharePost.TabIndex = 46;
            this.rdSharePost.Text = "Link bài viết (chia sẻ bài đã viết)";
            this.rdSharePost.UseVisualStyleBackColor = true;
            this.rdSharePost.CheckedChanged += new System.EventHandler(this.rdSharePost_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenPost);
            this.groupBox2.Controls.Add(this.btnSavePost);
            this.groupBox2.Controls.Add(this.rdShareLinkWebsite);
            this.groupBox2.Controls.Add(this.txtLinkWebsite);
            this.groupBox2.Controls.Add(this.rdSharePost);
            this.groupBox2.Controls.Add(this.rdShareImage);
            this.groupBox2.Controls.Add(this.txtImageFile1);
            this.groupBox2.Controls.Add(this.txtPostLink);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnChooseImage1);
            this.groupBox2.Controls.Add(this.txtPostContent);
            this.groupBox2.Controls.Add(this.wbPostGroup);
            this.groupBox2.Location = new System.Drawing.Point(318, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 332);
            this.groupBox2.TabIndex = 47;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhập nội dung bài đăng";
            // 
            // btnOpenPost
            // 
            this.btnOpenPost.Location = new System.Drawing.Point(577, 11);
            this.btnOpenPost.Name = "btnOpenPost";
            this.btnOpenPost.Size = new System.Drawing.Size(75, 23);
            this.btnOpenPost.TabIndex = 52;
            this.btnOpenPost.Text = "Mở bài viết";
            this.btnOpenPost.UseVisualStyleBackColor = true;
            this.btnOpenPost.Click += new System.EventHandler(this.btnOpenPost_Click);
            // 
            // btnSavePost
            // 
            this.btnSavePost.Location = new System.Drawing.Point(494, 11);
            this.btnSavePost.Name = "btnSavePost";
            this.btnSavePost.Size = new System.Drawing.Size(75, 23);
            this.btnSavePost.TabIndex = 51;
            this.btnSavePost.Text = "Lưu bài viết";
            this.btnSavePost.UseVisualStyleBackColor = true;
            this.btnSavePost.Click += new System.EventHandler(this.btnSavePost_Click);
            // 
            // rdShareLinkWebsite
            // 
            this.rdShareLinkWebsite.AutoSize = true;
            this.rdShareLinkWebsite.ForeColor = System.Drawing.Color.DarkBlue;
            this.rdShareLinkWebsite.Location = new System.Drawing.Point(20, 273);
            this.rdShareLinkWebsite.Name = "rdShareLinkWebsite";
            this.rdShareLinkWebsite.Size = new System.Drawing.Size(118, 17);
            this.rdShareLinkWebsite.TabIndex = 48;
            this.rdShareLinkWebsite.Text = "Chia sẻ link website";
            this.rdShareLinkWebsite.UseVisualStyleBackColor = true;
            // 
            // txtLinkWebsite
            // 
            this.txtLinkWebsite.Location = new System.Drawing.Point(19, 296);
            this.txtLinkWebsite.Name = "txtLinkWebsite";
            this.txtLinkWebsite.Size = new System.Drawing.Size(632, 20);
            this.txtLinkWebsite.TabIndex = 47;
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Checked = true;
            this.cbSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSelectAll.Location = new System.Drawing.Point(18, 12);
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
            listViewItem1.StateImageIndex = 0;
            listViewItem2.StateImageIndex = 0;
            this.listBoxGroup.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.listBoxGroup.Location = new System.Drawing.Point(12, 32);
            this.listBoxGroup.Name = "listBoxGroup";
            this.listBoxGroup.Size = new System.Drawing.Size(288, 466);
            this.listBoxGroup.TabIndex = 49;
            this.listBoxGroup.UseCompatibleStateImageBehavior = false;
            this.listBoxGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nhóm";
            this.columnHeader1.Width = 214;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Trạng Thái";
            this.columnHeader2.Width = 70;
            // 
            // ucAutoJoinGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.listBoxGroup);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbDsNhom);
            this.Controls.Add(this.groupBox2);
            this.Name = "ucAutoJoinGroup";
            this.Size = new System.Drawing.Size(996, 508);
            this.Load += new System.EventHandler(this.ucAutoJoinGroup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDelay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbPostGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChooseImage1;
        private System.Windows.Forms.TextBox txtImageFile1;
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
        private System.Windows.Forms.TextBox txtPostContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPostLink;
        private System.Windows.Forms.RadioButton rdShareImage;
        private System.Windows.Forms.RadioButton rdSharePost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdShareLinkWebsite;
        private System.Windows.Forms.TextBox txtLinkWebsite;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.ListView listBoxGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnOpenPost;
        private System.Windows.Forms.Button btnSavePost;
    }
}
