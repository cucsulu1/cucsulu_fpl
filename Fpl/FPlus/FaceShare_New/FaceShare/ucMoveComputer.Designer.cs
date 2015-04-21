namespace FPlus
{
    partial class ucMoveComputer
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
            this.btnMoveComputer = new System.Windows.Forms.Button();
            this.wbHelpMoveComputer = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btnMoveComputer
            // 
            this.btnMoveComputer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnMoveComputer.Location = new System.Drawing.Point(868, 0);
            this.btnMoveComputer.Name = "btnMoveComputer";
            this.btnMoveComputer.Size = new System.Drawing.Size(125, 33);
            this.btnMoveComputer.TabIndex = 6;
            this.btnMoveComputer.Text = "Xác nhận chuyển máy";
            this.btnMoveComputer.UseVisualStyleBackColor = true;
            this.btnMoveComputer.Visible = false;
            this.btnMoveComputer.Click += new System.EventHandler(this.btnMoveComputer_Click);
            // 
            // wbHelpMoveComputer
            // 
            this.wbHelpMoveComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHelpMoveComputer.Location = new System.Drawing.Point(0, 0);
            this.wbHelpMoveComputer.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHelpMoveComputer.Name = "wbHelpMoveComputer";
            this.wbHelpMoveComputer.ScriptErrorsSuppressed = true;
            this.wbHelpMoveComputer.Size = new System.Drawing.Size(996, 508);
            this.wbHelpMoveComputer.TabIndex = 5;
            // 
            // ucMoveComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMoveComputer);
            this.Controls.Add(this.wbHelpMoveComputer);
            this.Name = "ucMoveComputer";
            this.Size = new System.Drawing.Size(996, 508);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMoveComputer;
        private System.Windows.Forms.WebBrowser wbHelpMoveComputer;
    }
}
