using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Facebook;
using FPlus;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace FPlus
{
    public partial class ucAutoMessage : UserControl
    {
        private bool _joinGroup;
        private int _countdown;
        private int _postGroupIndex = -1;
        private readonly List<FaceUser> _searchResults = new List<FaceUser>();
        public ucAutoMessage()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            this._joinGroup = true;
            _postGroupIndex = (int)txtOffset.Value-1;
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
            lbStatus.Text = "Bắt đầu gửi tin nhắn";
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
                this.lbStatus.Text = @"Còn " + this._countdown.ToString() + @" giây để gửi ";
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
                if (_postGroupIndex >= _searchResults.Count || _searchResults.Count(p => p.IsRunned)>=txtLimit.Value)
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
                lbTotalProcessed.Text = "Đã gửi : "+_searchResults.Count(p => p.IsRunned) + @"/" + listBoxGroup.CheckedIndices.Count;
                this.lbStatus.Text = @"Đang gửi tin nhắn cho : " + (group.Name.Length > 50 ? (group.Name.Substring(0, 50) + "..") : group.Name);
                per.Stop();
                string paramIds = "?";
                for (int i = 0; i < txtCountPerSend.Value; i++)
                {
                    paramIds += string.Format("ids[{0}]={1}&",i, _searchResults[_postGroupIndex].Uid);
                    _postGroupIndex++;
                } _postGroupIndex--;
                paramIds=paramIds.Trim('&');
                var urlGroup = "https://mbasic.facebook.com/messages/compose/" + paramIds;
                this.wbPostGroup.Navigate(urlGroup);
                timerstep.Stop();
            }
        }

        public void DisplayUsers()
        {
            this.listBoxGroup.Items.Clear();
            var i = 1;
            foreach (var item in _searchResults)
            {
                var newItem = new ListViewItem(i + ". " + item.Name) {Checked = true};
                newItem.SubItems.Add("");
                this.listBoxGroup.Items.Add(newItem);
                i++;
            }
            this.lbDsNhom.Text = @"" + _searchResults.Count + @" người)";
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem  item in listBoxGroup.Items)
            {
                item.Checked = cbSelectAll.Checked;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            pbLoading.Visible = true;
            if (!bwSearchMember.IsBusy) bwSearchMember.RunWorkerAsync(cbbGroups.SelectedItem);
        }

        private void wbPostGroup_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string documentText = this.wbPostGroup.DocumentText;
            //is not login
            if (documentText.Contains("mbasic.facebook.com/login.php"))
            {
            }
            if (this._joinGroup && _searchResults.Count > _postGroupIndex && wbPostGroup.Document!=null)
            {
                if (!_searchResults[_postGroupIndex].IsRunned)
                {
                    var strComment = GetPostMessage(txtCountPerSend.Value>1?null:_searchResults[_postGroupIndex]);
                    HtmlElementCollection elementsByTextArea = this.wbPostGroup.Document.GetElementsByTagName("textarea");
                    foreach (HtmlElement element2 in elementsByTextArea)
                    {
                        if (element2.GetAttribute("class").Equals("bt bu bv"))
                        {
                             element2.InnerText = strComment;
                        }
                    }
                    
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
                this.listBoxGroup.Items[_postGroupIndex].SubItems[1].Text = @"Đã gửi tin nhắn";
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

        private string GetPostMessage(FaceUser user)
        {
            var msg = txtPostContent.Text;
            if (user == null)
            {
                msg = Regex.Replace(msg, @"\[u\|", "");
                msg = Regex.Replace(msg, @"\]", "");
            }
            else
            {
                msg = Regex.Replace(msg, @"\[u\|.*?\]", user.Name);
                msg = Regex.Replace(msg, @"\[u\]", user.Name);
            }
            return msg;
        }

        private void ucAutoMessage_Load(object sender, EventArgs e)
        {
            var lst=App.LstGroups.ToList();lst.Insert(0,new FaceGroup(){GroupName = "Tất cả",Uid="0"});
            cbbGroups.DataSource = App.LstGroups;
            cbbGroups.DisplayMember = "GroupName";
            cbbGroups.ValueMember = "Uid";
            if (cbbGroups.Items.Count>1) cbbGroups.SelectedIndex = 1;
        }

        private void bwSearchMember_DoWork(object sender, DoWorkEventArgs e)
        {
            var selectedGroup = e.Argument as FaceGroup;
            var client = new FacebookClient(App.Accesstoken);
            foreach (var group in App.LstGroups.Where(p =>p.Uid == selectedGroup.Uid ||  selectedGroup.Uid=="0"))
            {
                var jsonResult = JObject.Parse(client.Get(string.Format("/{0}/members?limit=1000000&offset=0"), group.Uid).ToString());
                _searchResults.Clear();
                foreach (var item in jsonResult.Value<JArray>("data"))
                {
                    var faceGroup = new FaceUser()
                    {
                        Name = item.Value<string>("name"),
                        Uid = item.Value<string>("id")
                    };
                    _searchResults.Add(faceGroup);
                }
            }
        }

        private void bwSearchMember_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DisplayUsers();
            pbLoading.Visible = false;
        }
    }
}
