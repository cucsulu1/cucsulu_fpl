using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FPlus
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label txtBanQuyen;
        private ImageList imageList_icontab;
        private Label label1;
        private Label thongbao;
        private Label toolstatus;
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
            this.imageList_icontab = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.thongbao = new System.Windows.Forms.Label();
            this.txtBanQuyen = new System.Windows.Forms.Label();
            this.toolstatus = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.pnTab = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pnTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList_icontab
            // 
            this.imageList_icontab.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_icontab.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList_icontab.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(921, 594);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Version 2.0";
            // 
            // thongbao
            // 
            this.thongbao.AutoSize = true;
            this.thongbao.ForeColor = System.Drawing.Color.DarkGray;
            this.thongbao.Location = new System.Drawing.Point(612, 17);
            this.thongbao.Name = "thongbao";
            this.thongbao.Size = new System.Drawing.Size(59, 13);
            this.thongbao.TabIndex = 31;
            this.thongbao.Text = "Thông báo";
            // 
            // txtBanQuyen
            // 
            this.txtBanQuyen.AutoSize = true;
            this.txtBanQuyen.BackColor = System.Drawing.Color.Transparent;
            this.txtBanQuyen.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBanQuyen.Location = new System.Drawing.Point(677, 17);
            this.txtBanQuyen.Name = "txtBanQuyen";
            this.txtBanQuyen.Size = new System.Drawing.Size(58, 13);
            this.txtBanQuyen.TabIndex = 32;
            this.txtBanQuyen.Text = "Bản quyền";
            // 
            // toolstatus
            // 
            this.toolstatus.AutoSize = true;
            this.toolstatus.ForeColor = System.Drawing.Color.Red;
            this.toolstatus.Location = new System.Drawing.Point(12, 477);
            this.toolstatus.Name = "toolstatus";
            this.toolstatus.Size = new System.Drawing.Size(0, 13);
            this.toolstatus.TabIndex = 33;
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(159)))), ((int)(((byte)(218)))));
            this.pnMain.Location = new System.Drawing.Point(15, 87);
            this.pnMain.Name = "pnMain";
            this.pnMain.Padding = new System.Windows.Forms.Padding(1);
            this.pnMain.Size = new System.Drawing.Size(977, 501);
            this.pnMain.TabIndex = 34;
            // 
            // pnTab
            // 
            this.pnTab.BackColor = System.Drawing.Color.Transparent;
            this.pnTab.Controls.Add(this.button6);
            this.pnTab.Controls.Add(this.button7);
            this.pnTab.Controls.Add(this.button5);
            this.pnTab.Controls.Add(this.button4);
            this.pnTab.Controls.Add(this.button3);
            this.pnTab.Controls.Add(this.button2);
            this.pnTab.Controls.Add(this.button1);
            this.pnTab.Location = new System.Drawing.Point(15, 53);
            this.pnTab.Name = "pnTab";
            this.pnTab.Size = new System.Drawing.Size(977, 34);
            this.pnTab.TabIndex = 35;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.White;
            this.button6.Dock = System.Windows.Forms.DockStyle.Left;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(197)))));
            this.button6.Location = new System.Drawing.Point(739, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(121, 34);
            this.button6.TabIndex = 2;
            this.button6.TabStop = false;
            this.button6.Tag = "ucAutoJoinGroup";
            this.button6.Text = "Gia nhập nhóm";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.tab_Click);
            this.button6.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Dock = System.Windows.Forms.DockStyle.Left;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(197)))));
            this.button7.Location = new System.Drawing.Point(579, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(160, 34);
            this.button7.TabIndex = 0;
            this.button7.TabStop = false;
            this.button7.Tag = "ucAutoPostFriend";
            this.button7.Text = "Đăng lên tường bạn bè";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Visible = false;
            this.button7.TabIndexChanged += new System.EventHandler(this.button1_TabIndexChanged);
            this.button7.TabStopChanged += new System.EventHandler(this.button1_TabStopChanged);
            this.button7.Click += new System.EventHandler(this.tab_Click);
            this.button7.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(159)))), ((int)(((byte)(218)))));
            this.button5.Dock = System.Windows.Forms.DockStyle.Left;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(435, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(144, 34);
            this.button5.TabIndex = 1;
            this.button5.TabStop = false;
            this.button5.Tag = "ucLoginFacebook";
            this.button5.Text = "Đăng Nhập Facebook";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.TabIndexChanged += new System.EventHandler(this.button1_TabIndexChanged);
            this.button5.TabStopChanged += new System.EventHandler(this.button1_TabStopChanged);
            this.button5.Click += new System.EventHandler(this.tab_Click);
            this.button5.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Dock = System.Windows.Forms.DockStyle.Left;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(197)))));
            this.button3.Location = new System.Drawing.Point(221, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 34);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Tag = "ucMoveComputer";
            this.button3.Text = "Chuyển máy";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.TabIndexChanged += new System.EventHandler(this.button1_TabIndexChanged);
            this.button3.TabStopChanged += new System.EventHandler(this.button1_TabStopChanged);
            this.button3.Click += new System.EventHandler(this.tab_Click);
            this.button3.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.Transparent;
            this.metroLabel1.FontSize = MetroFramework.Drawing.MetroFontSize.Large;
            this.metroLabel1.Location = new System.Drawing.Point(44, 5);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(86, 25);
            this.metroLabel1.TabIndex = 37;
            this.metroLabel1.Text = "FPlus v2.0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::FPlus.Properties.Resources.key_blue;
            this.pictureBox3.Location = new System.Drawing.Point(904, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FPlus.Properties.Resources.GooglePlus;
            this.pictureBox2.Location = new System.Drawing.Point(15, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(22, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            this.pictureBox1.Location = new System.Drawing.Point(-89, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1096, 1);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Dock = System.Windows.Forms.DockStyle.Left;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(197)))));
            this.button4.Image = global::FPlus.Properties.Resources.Generate_keys_icon1;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(328, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 34);
            this.button4.TabIndex = 0;
            this.button4.TabStop = false;
            this.button4.Tag = "ucBuy";
            this.button4.Text = "             Gia hạn";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.TabIndexChanged += new System.EventHandler(this.button1_TabIndexChanged);
            this.button4.TabStopChanged += new System.EventHandler(this.button1_TabStopChanged);
            this.button4.Click += new System.EventHandler(this.tab_Click);
            this.button4.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(197)))));
            this.button2.Image = global::FPlus.Properties.Resources.icon_home;
            this.button2.Location = new System.Drawing.Point(179, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(42, 34);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "ucGuide";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.TabIndexChanged += new System.EventHandler(this.button1_TabIndexChanged);
            this.button2.TabStopChanged += new System.EventHandler(this.button1_TabStopChanged);
            this.button2.Click += new System.EventHandler(this.tab_Click);
            this.button2.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(108)))), ((int)(((byte)(197)))));
            this.button1.Image = global::FPlus.Properties.Resources.house1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 34);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "ucAutoPostGroup";
            this.button1.Text = "Tự động đăng bài";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.TabIndexChanged += new System.EventHandler(this.button1_TabIndexChanged);
            this.button1.TabStopChanged += new System.EventHandler(this.button1_TabStopChanged);
            this.button1.Click += new System.EventHandler(this.tab_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // FrmMain
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 612);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnTab);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.thongbao);
            this.Controls.Add(this.txtBanQuyen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolstatus);
            this.Controls.Add(this.metroLabel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnMain;
        private Panel pnTab;
        private Button button1;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button5;
        private Button button7;
        private PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Button button6;

    }
}

