using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FPlus
{
    public partial class ucMoveComputer : UserControl
    {
        public ucMoveComputer()
        {
            InitializeComponent();
            wbHelpMoveComputer.Navigate(App.SeverUrl + "fplus/movecomputer?cpu=" + App.CurrentCpuId);
        }
        private void MoveComputer()
        {
            string result = Utilities.GetHtml(App.SeverUrl + "fplus/movecomputerrequest?cpu=" + App.CurrentCpuId + "&appid=" + App.AppId);
            if (result == "1")
            {
                MessageBox.Show("Yêu cầu chuyển máy thành công! Vui lòng nhập mã phần mềm :" + App.AppId + " trên máy mới.");
            }
        }
        private void btnMoveComputer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn chuyển?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MoveComputer();
            }
        }
    }
}
