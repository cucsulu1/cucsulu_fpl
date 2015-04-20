namespace FPlus
{
    partial class ucAutoPostFriend
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
            this.wbPostFriend = new System.Windows.Forms.WebBrowser();
            this.listBoxFriend = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbTotalProcessed = new System.Windows.Forms.Label();
            this.metroProgressSpinnerOnePost = new MetroFramework.Controls.MetroProgressSpinner();
            this.lbStatus = new System.Windows.Forms.Label();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.btnChooseImage2 = new System.Windows.Forms.Button();
            this.btnChooseImage3 = new System.Windows.Forms.Button();
            this.btnChooseImage1 = new System.Windows.Forms.Button();
            this.txtImageFile2 = new System.Windows.Forms.TextBox();
            this.txtImageFile3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImageFile1 = new System.Windows.Forms.TextBox();
            this.btnStopPost = new MetroFramework.Controls.MetroButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtTimeDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPostContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPostLink = new System.Windows.Forms.TextBox();
            this.lbDsBan = new System.Windows.Forms.Label();
            this.timerstep = new System.Windows.Forms.Timer(this.components);
            this.per = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // wbPostFriend
            // 
            this.wbPostFriend.Location = new System.Drawing.Point(306, 25);
            this.wbPostFriend.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPostFriend.Name = "wbPostFriend";
            this.wbPostFriend.ScriptErrorsSuppressed = true;
            this.wbPostFriend.Size = new System.Drawing.Size(685, 234);
            this.wbPostFriend.TabIndex = 41;
            this.wbPostFriend.Url = new System.Uri("", System.UriKind.Relative);
            this.wbPostFriend.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webmain_DocumentCompleted);
            this.wbPostFriend.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webmain_Navigated);
            // 
            // listBoxFriend
            // 
            this.listBoxFriend.CheckOnClick = true;
            this.listBoxFriend.FormattingEnabled = true;
            this.listBoxFriend.Location = new System.Drawing.Point(9, 28);
            this.listBoxFriend.Name = "listBoxFriend";
            this.listBoxFriend.Size = new System.Drawing.Size(291, 469);
            this.listBoxFriend.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbTotalProcessed);
            this.groupBox1.Controls.Add(this.metroProgressSpinnerOnePost);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Controls.Add(this.progressBarStatus);
            this.groupBox1.Controls.Add(this.btnChooseImage2);
            this.groupBox1.Controls.Add(this.btnChooseImage3);
            this.groupBox1.Controls.Add(this.btnChooseImage1);
            this.groupBox1.Controls.Add(this.txtImageFile2);
            this.groupBox1.Controls.Add(this.txtImageFile3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtImageFile1);
            this.groupBox1.Controls.Add(this.btnStopPost);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtTimeDelay);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPostContent);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPostLink);
            this.groupBox1.Location = new System.Drawing.Point(306, 268);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 229);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tự động đăng bài";
            // 
            // lbTotalProcessed
            // 
            this.lbTotalProcessed.AutoSize = true;
            this.lbTotalProcessed.Location = new System.Drawing.Point(618, 197);
            this.lbTotalProcessed.Name = "lbTotalProcessed";
            this.lbTotalProcessed.Size = new System.Drawing.Size(35, 13);
            this.lbTotalProcessed.TabIndex = 40;
            this.lbTotalProcessed.Text = "label1";
            // 
            // metroProgressSpinnerOnePost
            // 
            this.metroProgressSpinnerOnePost.Location = new System.Drawing.Point(12, 180);
            this.metroProgressSpinnerOnePost.Maximum = 100;
            this.metroProgressSpinnerOnePost.Name = "metroProgressSpinnerOnePost";
            this.metroProgressSpinnerOnePost.Size = new System.Drawing.Size(36, 30);
            this.metroProgressSpinnerOnePost.TabIndex = 39;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(54, 197);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(35, 13);
            this.lbStatus.TabIndex = 38;
            this.lbStatus.Text = "label1";
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(9, 213);
            this.progressBarStatus.Maximum = 1000;
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(644, 10);
            this.progressBarStatus.TabIndex = 37;
            // 
            // btnChooseImage2
            // 
            this.btnChooseImage2.Location = new System.Drawing.Point(592, 48);
            this.btnChooseImage2.Name = "btnChooseImage2";
            this.btnChooseImage2.Size = new System.Drawing.Size(61, 23);
            this.btnChooseImage2.TabIndex = 36;
            this.btnChooseImage2.Text = "Chọn";
            this.btnChooseImage2.UseVisualStyleBackColor = true;
            this.btnChooseImage2.Click += new System.EventHandler(this.btnChooseImage2_Click);
            // 
            // btnChooseImage3
            // 
            this.btnChooseImage3.Location = new System.Drawing.Point(592, 74);
            this.btnChooseImage3.Name = "btnChooseImage3";
            this.btnChooseImage3.Size = new System.Drawing.Size(61, 23);
            this.btnChooseImage3.TabIndex = 35;
            this.btnChooseImage3.Text = "Chọn";
            this.btnChooseImage3.UseVisualStyleBackColor = true;
            this.btnChooseImage3.Click += new System.EventHandler(this.btnChooseImage3_Click);
            // 
            // btnChooseImage1
            // 
            this.btnChooseImage1.Location = new System.Drawing.Point(592, 22);
            this.btnChooseImage1.Name = "btnChooseImage1";
            this.btnChooseImage1.Size = new System.Drawing.Size(61, 23);
            this.btnChooseImage1.TabIndex = 34;
            this.btnChooseImage1.Text = "Chọn";
            this.btnChooseImage1.UseVisualStyleBackColor = true;
            this.btnChooseImage1.Click += new System.EventHandler(this.btnChooseImage1_Click);
            // 
            // txtImageFile2
            // 
            this.txtImageFile2.Location = new System.Drawing.Point(461, 49);
            this.txtImageFile2.Name = "txtImageFile2";
            this.txtImageFile2.ReadOnly = true;
            this.txtImageFile2.Size = new System.Drawing.Size(129, 20);
            this.txtImageFile2.TabIndex = 33;
            // 
            // txtImageFile3
            // 
            this.txtImageFile3.Location = new System.Drawing.Point(461, 75);
            this.txtImageFile3.Name = "txtImageFile3";
            this.txtImageFile3.ReadOnly = true;
            this.txtImageFile3.Size = new System.Drawing.Size(129, 20);
            this.txtImageFile3.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(384, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Link chia sẻ:";
            // 
            // txtImageFile1
            // 
            this.txtImageFile1.Location = new System.Drawing.Point(461, 23);
            this.txtImageFile1.Name = "txtImageFile1";
            this.txtImageFile1.ReadOnly = true;
            this.txtImageFile1.Size = new System.Drawing.Size(129, 20);
            this.txtImageFile1.TabIndex = 29;
            // 
            // btnStopPost
            // 
            this.btnStopPost.Location = new System.Drawing.Point(554, 152);
            this.btnStopPost.Name = "btnStopPost";
            this.btnStopPost.Size = new System.Drawing.Size(99, 43);
            this.btnStopPost.TabIndex = 28;
            this.btnStopPost.Text = "Kết thúc";
            this.btnStopPost.Theme = "Light";
            this.btnStopPost.Click += new System.EventHandler(this.btnStopPost_Click);
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.Color.DarkCyan;
            this.btnStart.Location = new System.Drawing.Point(448, 152);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 43);
            this.btnStart.TabIndex = 22;
            this.btnStart.Text = "Bắt đầu";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtTimeDelay
            // 
            this.txtTimeDelay.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtTimeDelay.Location = new System.Drawing.Point(521, 121);
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
            this.txtTimeDelay.Size = new System.Drawing.Size(132, 20);
            this.txtTimeDelay.TabIndex = 16;
            this.txtTimeDelay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtTimeDelay.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;
            this.label4.Location = new System.Drawing.Point(380, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Thời gian đăng(60> 90 giây)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(9, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Link chia sẻ:";
            // 
            // txtPostContent
            // 
            this.txtPostContent.Location = new System.Drawing.Point(83, 18);
            this.txtPostContent.Multiline = true;
            this.txtPostContent.Name = "txtPostContent";
            this.txtPostContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPostContent.Size = new System.Drawing.Size(291, 123);
            this.txtPostContent.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Nội dung bài:";
            // 
            // txtPostLink
            // 
            this.txtPostLink.Location = new System.Drawing.Point(83, 161);
            this.txtPostLink.Name = "txtPostLink";
            this.txtPostLink.Size = new System.Drawing.Size(291, 20);
            this.txtPostLink.TabIndex = 18;
            // 
            // lbDsBan
            // 
            this.lbDsBan.AutoSize = true;
            this.lbDsBan.ForeColor = System.Drawing.Color.Navy;
            this.lbDsBan.Location = new System.Drawing.Point(6, 12);
            this.lbDsBan.Name = "lbDsBan";
            this.lbDsBan.Size = new System.Drawing.Size(80, 13);
            this.lbDsBan.TabIndex = 43;
            this.lbDsBan.Text = "Danh sách bạn";
            // 
            // timerstep
            // 
            this.timerstep.Interval = 20000;
            this.timerstep.Tick += new System.EventHandler(this.timerstep_Tick);
            // 
            // per
            // 
            this.per.Interval = 1000;
            this.per.Tick += new System.EventHandler(this.per_Tick);
            // 
            // ucAutoPostFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wbPostFriend);
            this.Controls.Add(this.listBoxFriend);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbDsBan);
            this.Name = "ucAutoPostFriend";
            this.Size = new System.Drawing.Size(996, 508);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbPostFriend;
        private System.Windows.Forms.CheckedListBox listBoxFriend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChooseImage2;
        private System.Windows.Forms.Button btnChooseImage3;
        private System.Windows.Forms.Button btnChooseImage1;
        private System.Windows.Forms.TextBox txtImageFile2;
        private System.Windows.Forms.TextBox txtImageFile3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImageFile1;
        private MetroFramework.Controls.MetroButton btnStopPost;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown txtTimeDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPostContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPostLink;
        private System.Windows.Forms.Label lbDsBan;
        private System.Windows.Forms.Timer timerstep;
        private System.Windows.Forms.Timer per;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Label lbStatus;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinnerOnePost;
        private System.Windows.Forms.Label lbTotalProcessed;
    }
}
