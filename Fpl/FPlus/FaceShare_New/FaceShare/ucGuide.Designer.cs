namespace FPlus
{
    partial class ucGuide
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
            this.wbHelpGuide = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbHelpGuide
            // 
            this.wbHelpGuide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHelpGuide.Location = new System.Drawing.Point(0, 0);
            this.wbHelpGuide.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHelpGuide.Name = "wbHelpGuide";
            this.wbHelpGuide.Size = new System.Drawing.Size(996, 508);
            this.wbHelpGuide.TabIndex = 3;
            // 
            // ucGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.wbHelpGuide);
            this.Name = "ucGuide";
            this.Size = new System.Drawing.Size(996, 508);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbHelpGuide;
    }
}
