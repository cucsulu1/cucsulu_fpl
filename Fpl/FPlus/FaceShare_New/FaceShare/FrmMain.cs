using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Facebook;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using FPlus;
using Microsoft.Win32;

namespace FPlus
{
    public partial class FrmMain : MetroForm
    {
        [DllImport("winmm.dll")]
        private static extern int waveOutGetVolume(IntPtr hwo, out uint dwVolume);
        [DllImport("winmm.dll")]
        private static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        readonly List<Control> _lstTabPages = new List<Control>();
        readonly ucLoginFacebook _ucFaceLogin;
        readonly ucAutoPostGroup _ucAutoPost;
        #region Events
        public FrmMain()
        {
            this.components = null;
            this.InitializeComponent();
            _ucFaceLogin = new ucLoginFacebook();
            _ucAutoPost = new ucAutoPostGroup();
            _lstTabPages.Add(_ucFaceLogin);
            _lstTabPages.Add(_ucAutoPost);
            _lstTabPages.Add(new ucGuide());
            _lstTabPages.Add(new ucBuy());
            _lstTabPages.Add(new ucMoveComputer());
            _lstTabPages.Add(new ucAds());
            _lstTabPages.Add(new ucAutoJoinGroup());
            _lstTabPages.Add(new ucAutoInviGroup());
            _lstTabPages.Add(new ucAutoMessage());
            //var th = new Thread(() =>
            //{
            //    var x = new ucAds();
            //});
            //th.SetApartmentState(ApartmentState.STA);
            //th.Start();
        
            foreach (var item in _lstTabPages)
            {
                pnMain.Controls.Add(item);
                item.Dock = DockStyle.Fill;
                item.BackColor = Color.FromArgb(234, 250, 255);
            }
            _ucFaceLogin.FacebookLoggedIn += new EventHandler(FacebookLoggedin);
            _ucFaceLogin.Show();

            App.Accesstoken = "";
            App.CurrentCpuId = Utilities.GetCpuId();
            // save the current volume
            uint savedVolume;
            waveOutGetVolume(IntPtr.Zero, out savedVolume);
            // mute
            if (savedVolume > 1) waveOutSetVolume(IntPtr.Zero, 1);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CheckUpdate();
            CheckKey();
            this.thongbao.Text = Utilities.GetHtml(App.SeverUrl + "/fplus/notify");
            //ShowFaceLogin();
        }
       
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            App.SaveListGroup();
            Application.ExitThread();
            Application.Exit();
            RegistryKey add = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            add.SetValue("FPlus", "\"" + Application.ExecutablePath.ToString() + "\"");
        }
        #endregion

        #region Method
        private void CheckKey()
        {
            try
            {
                string jsonResult = Utilities.GetHtml(App.SeverUrl + "/fplus/checklic?cpu=" + App.CurrentCpuId + "&id=" + new Random().Next(1, 999999) + "&type=1");
                var jsonUserInfo = JObject.Parse(jsonResult);
                var result = jsonUserInfo.Value<string>("result");
                var remainLic = jsonUserInfo.Value<int>("remain");
                var appId = jsonUserInfo.Value<int>("appid");

                //var name = (string.IsNullOrEmpty(lastName) ? "" : (lastName + " ")) + firstName;
                //var email = jsonUserInfo.Value<JArray>("emails")[0].Value<string>("value");
                //var googleUId = jsonUserInfo.Value<string>("id");
                switch (jsonResult)
                {
                    //success
                    case "0":
                        break;
                    // Hết hạn
                    case "1":
                        break;
                    // Đã đăng kí máy khác
                    case "2":
                        break;
                    // đang chuyển - vui long xac nhan chuyen
                    case "3":
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
                //Application.ExitThread();
            }
        }
        private void CheckUpdate()
        {
            string newVer = Utilities.GetHtml(App.SeverUrl + "/fplus/checkversion");
            if (newVer != App.CurrentVersion)
            {
                try
                {
                    var startInfo = new ProcessStartInfo("UpdateFPlus.exe")
                    {
                        UseShellExecute = true,
                        Verb = "runas"
                    };
                    Process.Start(startInfo);
                    Application.ExitThread();
                }
                catch
                {
                    MessageBox.Show("Cập nhật lỗi. Vui lòng chạy file 'UpdateFPlus.exe' để cập nhật phần mềm.'");
                    //Application.ExitThread();
                }
            }
        }
        #endregion
        private void FacebookLoggedin(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(App.Accesstoken))
            {
                _ucAutoPost.DisplayGroups();
                foreach (Control item in pnTab.Controls)
                {
                    if (item.Tag.ToString() == "ucLoginFacebook")
                    {
                        item.Hide();
                    }
                    else
                    {
                        item.Show();
                        if (item.Tag.ToString() == "ucAutoPostGroup")
                        {
                            item.TabIndex = 1;
                        }
                    }
                }
            }
            else
            {
                foreach (Control item in pnTab.Controls)
                {
                    if (item.Tag.ToString() == "ucLoginFacebook")
                    {
                        item.Show();
                        item.TabIndex = 1;
                    }
                    else
                    {
                        item.Hide();
                    }
                }
                //foreach (var item in _lstTabPages)
                //{
                //    item.Hide();
                //}
                //_ucFaceLogin.Show();
            }
        }

        private void tab_Click(object sender, EventArgs e)
        {
            foreach (Control item in pnTab.Controls)
	        {
                item.TabIndex = 0;
	        }
            ((Control)sender).TabIndex = 1;
            foreach (var item in _lstTabPages)
            {
                item.Hide();
                if(item.Name == ((Button)sender).Tag.ToString())
                item.Show();
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            var btn = (Control)sender;
            if (btn.TabIndex==0)
            {
                btn.ForeColor = Color.FromArgb(0, 108, 197);
            }
            else
            {
                 btn.ForeColor = Color.White; 
            }
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            var btn = (Control)sender;
            btn.ForeColor = Color.White;
        }

        private void button1_TabStopChanged(object sender, EventArgs e)
        {
            
            //_ucAutoPost.Show();
            //_ucAutoPost.Focus();
        }

        private void button1_TabIndexChanged(object sender, EventArgs e)
        {
            var btn = (Control)sender;
            if (btn.TabIndex==0)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = Color.FromArgb(0, 108, 197);
            }
            else
            {
                btn.BackColor = Color.FromArgb(2, 159, 218);
                btn.ForeColor = Color.White;
            }
            foreach (var item in _lstTabPages)
            {
                item.Hide();
                if (item.Name == btn.Tag.ToString())
                {
                    item.Show();
                    item.Focus();
                }
            }
        }
    }
   
}
