using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;
using FPlus;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace FPlus
{
    public partial class ucAutoJoinGroup : UserControl
    {
        private bool _joinGroup;
        private int _countdown;
        private int _postGroupIndex = -1;
        private readonly List<FaceGroup> _searchResults=new List<FaceGroup>(); 
        public ucAutoJoinGroup()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            this._joinGroup = true;
            _postGroupIndex = (int)txtOffset.Value - 2;
            foreach (var faceGroup in _searchResults)
            {
                faceGroup.IsRunned = false;
            }
            foreach (ListViewItem item in listBoxGroup.Items)
            {
               item.SubItems[1].Text = "";
            }
            this.timerstep.Start();
            this.per.Start();
            this._countdown = (int)this.txtTimeDelay.Value;
            lbTotalProcessed.Text = "Đã gửi : 0/" + listBoxGroup.CheckedIndices.Count;
            metroProgressSpinnerOnePost.Spinning = true;
            metroProgressSpinnerOnePost.Show();
            lbStatus.Show();
            lbStatus.Text = "Bắt đầu gửi yêu cầu";
        }

        private void btnStopPost_Click(object sender, EventArgs e)
        {
            this.per.Stop();
            this.timerstep.Stop();
            _joinGroup = false;
            MessageBox.Show(@"Tham gia nhóm hoàn tất", @"Thông báo!");
            metroProgressSpinnerOnePost.Spinning = false;
            lbStatus.Text = "Tham gia nhóm hoàn tất";
            //var client = new FacebookClient(App.Accesstoken);
            //var lstActivities = JObject.Parse(client.Get("/me/activities").ToString());
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.timerstep.Interval = ((int)this.txtTimeDelay.Value) * 1000;
        }

        private void per_Tick(object sender, EventArgs e)
        {
            this._countdown--;
            if (_countdown >= 0)
            {
                this.lbStatus.Text = @"Còn " + this._countdown.ToString() + @" giây để đăng nhóm tiếp theo";
                try {
                    metroProgressSpinnerOnePost.Value = 100 - (int)(_countdown / this.txtTimeDelay.Value * 100);
                }
                catch { }
            }
        }


        private void timerstep_Tick(object sender, EventArgs e)
        {
            if (this._joinGroup)
            {
                _postGroupIndex++;
                if (_postGroupIndex >= App.LstGroups.Count || App.LstGroups.Count(p => p.IsRunned) >= txtLimit.Value)
                {
                    btnStopPost_Click(null, null);
                    return;
                }
                while (!listBoxGroup.Items[_postGroupIndex].Checked)
                {
                    _postGroupIndex++;
                    if (_postGroupIndex >= _searchResults.Count)
                    {
                        btnStopPost_Click(null, null);
                        return;
                    }
                }
                var group = _searchResults[_postGroupIndex];
                this.listBoxGroup.Items[_postGroupIndex].Selected = true;
                this.timerstep.Interval = 1000 * ((int)this.txtTimeDelay.Value);
                this._countdown = (int)this.txtTimeDelay.Value;
                progressBarStatus.Value = (int)(_postGroupIndex / _searchResults.Count * 1000);
                lbTotalProcessed.Text = "Đã tham gia : "+_searchResults.Count(p => p.IsRunned) + @"/" + listBoxGroup.CheckedIndices.Count;
                this.lbStatus.Text = @"Đang tham gia nhóm : " + (group.GroupName.Length>50?(group.GroupName.Substring(0,50)+".."): group.GroupName);
                per.Stop();
                
                var urlGroup = "https://mbasic.facebook.com/groups/" + group.Uid;
                this.wbPostGroup.Navigate(urlGroup);
                timerstep.Stop();
            }
        }

        public void DisplayGroups()
        {
            this.listBoxGroup.Items.Clear();
            var i = 1;
            foreach (var item in _searchResults)
            {
                var newItem = new ListViewItem(i+". "+item.GroupName);
                newItem.Checked = true;
                newItem.SubItems.Add("");
                this.listBoxGroup.Items.Add(newItem);
                i++;
            }
            this.lbDsNhom.Text = @"" + _searchResults.Count + @" nhóm)";
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem  item in listBoxGroup.Items)
            {
                item.Checked = cbSelectAll.Checked;
            }
        }


        private void ucAutoJoinGroup_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            var client = new FacebookClient(App.Accesstoken);
            if (string.IsNullOrEmpty(txtSearchGroup.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa","Thông báo");
                return;
            } pbLoading.Visible = true;
            var jsonResult = JObject.Parse(client.Get(string.Format("/search?type=group&q={0}&limit=5000&offset=0", txtSearchGroup.Text)).ToString());
            _searchResults.Clear();
            foreach (var item in jsonResult.Value<JArray>("data"))
            {
                var faceGroup = new FaceGroup()
                {
                    GroupName = item.Value<string>("name"),
                    Uid = item.Value<string>("id")
                };
                _searchResults.Add(faceGroup);
            }
            pbLoading.Visible = false;
            DisplayGroups();
        }

        private void wbPostGroup_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string documentText = this.wbPostGroup.DocumentText;
            //is not login
            if (documentText.Contains("mbasic.facebook.com/login.php"))
            {
            }
            if (this._joinGroup && _searchResults.Count > _postGroupIndex)
            {
                if (!_searchResults[_postGroupIndex].IsRunned)
                {
                    HtmlElementCollection elementsByTagName = this.wbPostGroup.Document.GetElementsByTagName("input");
                    foreach (HtmlElement element2 in elementsByTagName)
                    {
                        if (element2.GetAttribute("class").Equals("bs bt bu"))
                        {
                            element2.InvokeMember("Click");
                        }
                    }

                }
                _searchResults[_postGroupIndex].IsRunned = true;
                this.listBoxGroup.Items[_postGroupIndex].SubItems[1].Text = "Đã gửi yêu cầu";
                per.Start();
                if (_postGroupIndex >= _searchResults.Count)
                {
                    btnStopPost_Click(null, null);
                    return;
                }
                else
                {
                    timerstep.Start();
                }
            }
        }
    }
}
