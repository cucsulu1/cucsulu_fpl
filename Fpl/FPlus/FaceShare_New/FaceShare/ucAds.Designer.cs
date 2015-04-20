namespace FPlus
{
    partial class ucAds
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
            this.timerAds = new System.Windows.Forms.Timer(this.components);
            this.webAds = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // timerAds
            // 
            this.timerAds.Interval = 10000;
            this.timerAds.Tick += new System.EventHandler(this.timerAds_Tick);
            // 
            // webAds
            // 
            this.webAds.Location = new System.Drawing.Point(0, 0);
            this.webAds.MinimumSize = new System.Drawing.Size(20, 20);
            this.webAds.Name = "webAds";
            this.webAds.ScriptErrorsSuppressed = true;
            this.webAds.Size = new System.Drawing.Size(150, 150);
            this.webAds.TabIndex = 0;
            this.webAds.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webAds_DocumentCompleted);
            // 
            // ucAds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webAds);
            this.Name = "ucAds";
            this.Load += new System.EventHandler(this.ucAds_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerAds;
        private System.Windows.Forms.WebBrowser webAds;
    }
}
