namespace AutoClickWebbrowser
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnStartGP = new System.Windows.Forms.Button();
            this.pnClient = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.rtbPostFGroupComment = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkIsMoblie = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGetPeople = new System.Windows.Forms.Button();
            this.webBrowserGroup = new System.Windows.Forms.WebBrowser();
            this.tmCheckFFIsLoaded = new System.Windows.Forms.Timer(this.components);
            this.tmCheckIs = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(6, 32);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(258, 373);
            this.webBrowser1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "https://m.facebook.com/browsegroups/?seemore";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(577, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "GO";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(451, 5);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 3;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(601, 534);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLoad);
            this.tabPage2.Controls.Add(this.btnStartGP);
            this.tabPage2.Controls.Add(this.pnClient);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(593, 508);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "G+";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load FF";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnStartGP
            // 
            this.btnStartGP.Location = new System.Drawing.Point(129, 4);
            this.btnStartGP.Name = "btnStartGP";
            this.btnStartGP.Size = new System.Drawing.Size(75, 23);
            this.btnStartGP.TabIndex = 1;
            this.btnStartGP.Text = "Start +";
            this.btnStartGP.UseVisualStyleBackColor = true;
            this.btnStartGP.Click += new System.EventHandler(this.btnStartGP_Click);
            // 
            // pnClient
            // 
            this.pnClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnClient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnClient.Location = new System.Drawing.Point(3, 30);
            this.pnClient.Name = "pnClient";
            this.pnClient.Size = new System.Drawing.Size(591, 478);
            this.pnClient.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.rtbPostFGroupComment);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.chkIsMoblie);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.btnPost);
            this.tabPage1.Controls.Add(this.webBrowser1);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(593, 508);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Post FGroup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // rtbPostFGroupComment
            // 
            this.rtbPostFGroupComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPostFGroupComment.Location = new System.Drawing.Point(270, 32);
            this.rtbPostFGroupComment.Name = "rtbPostFGroupComment";
            this.rtbPostFGroupComment.Size = new System.Drawing.Size(397, 373);
            this.rtbPostFGroupComment.TabIndex = 6;
            this.rtbPostFGroupComment.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // chkIsMoblie
            // 
            this.chkIsMoblie.AutoSize = true;
            this.chkIsMoblie.Checked = true;
            this.chkIsMoblie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsMoblie.Location = new System.Drawing.Point(365, 9);
            this.chkIsMoblie.Name = "chkIsMoblie";
            this.chkIsMoblie.Size = new System.Drawing.Size(62, 17);
            this.chkIsMoblie.TabIndex = 4;
            this.chkIsMoblie.Text = "Fmobile";
            this.chkIsMoblie.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnGetPeople);
            this.tabPage3.Controls.Add(this.webBrowserGroup);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(593, 508);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "GROUP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnGetPeople
            // 
            this.btnGetPeople.Location = new System.Drawing.Point(3, 18);
            this.btnGetPeople.Name = "btnGetPeople";
            this.btnGetPeople.Size = new System.Drawing.Size(75, 23);
            this.btnGetPeople.TabIndex = 1;
            this.btnGetPeople.Text = "GetPeop";
            this.btnGetPeople.UseVisualStyleBackColor = true;
            this.btnGetPeople.Click += new System.EventHandler(this.btnGetPeople_Click);
            // 
            // webBrowserGroup
            // 
            this.webBrowserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserGroup.Location = new System.Drawing.Point(3, 47);
            this.webBrowserGroup.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserGroup.Name = "webBrowserGroup";
            this.webBrowserGroup.Size = new System.Drawing.Size(294, 361);
            this.webBrowserGroup.TabIndex = 0;
            // 
            // tmCheckFFIsLoaded
            // 
            this.tmCheckFFIsLoaded.Tick += new System.EventHandler(this.tmCheckFFIsLoaded_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 534);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnClient;
        private System.Windows.Forms.Button btnStartGP;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser webBrowserGroup;
        private System.Windows.Forms.CheckBox chkIsMoblie;
        private System.Windows.Forms.Button button1;
                private System.Windows.Forms.Button btnGetPeople;
                private System.Windows.Forms.RichTextBox rtbPostFGroupComment;
                private System.Windows.Forms.Timer tmCheckFFIsLoaded;
                private System.Windows.Forms.Timer tmCheckIs;

    }
}

