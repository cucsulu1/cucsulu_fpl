using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Drawing;
using MetroFramework.Forms;

namespace UpdateFPlus
{
    public partial class frmUpdate : MetroForm
    {
        public static string SeverUrl = "http://plus24h.com/";

        public List<string> LstUpdate=new List<string>(); 
        public frmUpdate()
        {
            InitializeComponent();
            
        }

        private void bwUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int index = 0; index < LstUpdate.Count; index++)
            {
                try
                {
                    var filename = Path.GetFileName(LstUpdate[index].Replace("/", "\\"));
                    if (filename!="MetroFramework.dll")
                    {
                        var webClient = new WebClient();
                        webClient.DownloadFile(new Uri(LstUpdate[index]), Path.Combine(Application.StartupPath, filename));
                        bwUpdate.ReportProgress(index);
                    }
                }
                catch { }
            }
        }

        private void bwUpdate_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try { 
            lbStatus.Text = "Đang tải " + Path.GetFileName(LstUpdate[e.ProgressPercentage].Replace("/", "\\"));
            progressBar1.Value = (int) (e.ProgressPercentage + 1)/LstUpdate.Count*100;
            }
            catch { }
        }

        private void bwUpdate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MessageBox.Show("Cập nhật thành công.'","FPlus");
                var startInfo = new ProcessStartInfo("FPlus.exe")
                {
                    UseShellExecute = true,
                    Verb = "runas"
                };
                Process.Start(startInfo);
            }
            catch
            {
                //MessageBox.Show("Cập nhật lỗi. Vui lòng chạy file 'UpdateFPlus.exe' để cập nhật phần mềm.'");
            }
            Application.ExitThread();
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(SeverUrl + "fplus/runupdate");
                request.Method = "GET";
                WebResponse response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string str = reader.ReadToEnd();
                reader.Close();
                response.Close();
                str = Uri.UnescapeDataString(str);
                LstUpdate = str.Split(',').ToList();
                if (!bwUpdate.IsBusy)
                {
                    bwUpdate.RunWorkerAsync();
                }
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server!", "Thông báo");
                //Application.ExitThread();
            }
        }


    }
}
