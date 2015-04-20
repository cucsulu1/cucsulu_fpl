using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FPlus
{
    public partial class frmSelectPost : MetroFramework.Forms.MetroForm
    {
        public frmSelectPost()
        {
            InitializeComponent();
            dgvPost.AutoGenerateColumns = false;
        }
        public FacePost SelectedPost {
            get { 
                if (dgvPost.SelectedRows.Count==0)
	            {
		            return null;
	            }
                return dgvPost.SelectedRows[0].DataBoundItem as FacePost;
            }
        }
        private void frmSelectPost_Load(object sender, EventArgs e)
        {
            App.OpenListPost();
            dgvPost.DataSource = App.LstPosts;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvPost.SelectedRows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else {
                MessageBox.Show("Vui lòng chọn bài viết");
            }
        }

        private void dgvPost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPost.SelectedRows.Count > 0 && e.RowIndex>=0 && e.ColumnIndex>=0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4 && e.RowIndex>=0)
            {
                if (MessageBox.Show("Vui lòng chọn bài viết","Thông báo",MessageBoxButtons.OKCancel)==DialogResult.OK)
                {
                    if (SelectedPost!=null)
                    {
                        App.LstPosts.RemoveAll(p => p.Id == SelectedPost.Id);
                        dgvPost.DataSource = null;
                        dgvPost.DataSource = App.LstPosts;
                        App.SaveListPost();
                    }
                }
            }
        }
    }
}
