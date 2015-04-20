namespace FPlus
{
    partial class ucLoginFacebook
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
            this.wbLoginFace = new System.Windows.Forms.WebBrowser();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // wbLoginFace
            // 
            this.wbLoginFace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbLoginFace.IsWebBrowserContextMenuEnabled = false;
            this.wbLoginFace.Location = new System.Drawing.Point(0, 0);
            this.wbLoginFace.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbLoginFace.Name = "wbLoginFace";
            this.wbLoginFace.Size = new System.Drawing.Size(996, 508);
            this.wbLoginFace.TabIndex = 0;
            this.wbLoginFace.Url = new System.Uri("", System.UriKind.Relative);
            this.wbLoginFace.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbLoginFace_DocumentCompleted);
            this.wbLoginFace.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wbLoginFace_Navigated);
            this.wbLoginFace.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wbLoginFace_Navigating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::FPlus.Properties.Resources.loading_blue;
            this.pictureBox1.Location = new System.Drawing.Point(454, 199);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // ucLoginFacebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.wbLoginFace);
            this.Name = "ucLoginFacebook";
            this.Size = new System.Drawing.Size(996, 508);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbLoginFace;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
