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
        private const string Chars = "abcefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private bool _postgroup;
        private int _countdown;
        private int _postGroupIndex = -1;

        public ucAutoJoinGroup()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPostContent.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung", "Thông báo");
                txtPostContent.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtPostLink.Text) && rdSharePost.Checked)
            {
                MessageBox.Show("Vui lòng nhập link chia sẻ", "Thông báo");
                txtPostLink.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLinkWebsite.Text) && rdShareLinkWebsite.Checked)
            {
                MessageBox.Show("Vui lòng nhập nội dung", "Thông báo");
                txtLinkWebsite.Focus();
                return;
            }
            
            this._postgroup = true;
            _postGroupIndex = -1;
            foreach (var faceGroup in App.LstGroups)
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
            lbTotalProcessed.Text = "Đã đăng : 0/" + listBoxGroup.CheckedIndices.Count;
            metroProgressSpinnerOnePost.Spinning = true;
            metroProgressSpinnerOnePost.Show();
            lbStatus.Show();
            lbStatus.Text = "Bắt đầu đăng";
        }

        private void btnStopPost_Click(object sender, EventArgs e)
        {
            this.per.Stop();
            this.timerstep.Stop();
            _postgroup = false;
            MessageBox.Show(@"Đăng hoàn tất", @"Thông báo!");
            metroProgressSpinnerOnePost.Spinning = false;
            lbStatus.Text = "Đăng hoàn tất";
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
            if (this._postgroup)
            {
                _postGroupIndex++;
                if (_postGroupIndex >= App.LstGroups.Count)
                {
                    btnStopPost_Click(null, null);
                    return;
                }
                while (!listBoxGroup.Items[_postGroupIndex].Checked)
                {
                    _postGroupIndex++;
                    if (_postGroupIndex >= App.LstGroups.Count)
                    {
                        btnStopPost_Click(null, null);
                        return;
                    }
                }
                var group = App.LstGroups[_postGroupIndex];
                this.listBoxGroup.Items[_postGroupIndex].Selected = true;
                this.timerstep.Interval = 1000 * ((int)this.txtTimeDelay.Value);
                this._countdown = (int)this.txtTimeDelay.Value;
                progressBarStatus.Value = (int)(_postGroupIndex / App.LstGroups.Count * 1000);
                lbTotalProcessed.Text = "Đã đăng : "+App.LstGroups.Count(p => p.IsRunned) + @"/" + listBoxGroup.CheckedIndices.Count;
                this.lbStatus.Text = @"Đang đăng nhóm : " + (group.GroupName.Length>50?(group.GroupName.Substring(0,50)+".."): group.GroupName);
                per.Stop();
                if (rdShareImage.Checked)
                {
                    var postInfo = new Dictionary<string, object>();
                    postInfo.Add("message", GetPostMessage());
                    if (File.Exists(txtImageFile1.Text))
                    {
                        var facebookUploader = new FacebookMediaObject
                        {
                            FileName = Path.GetFileName(txtImageFile1.Text),
                            ContentType = "image/jpg"
                        };
                        var bytes = File.ReadAllBytes(txtImageFile1.Text);
                        facebookUploader.SetValue(bytes);
                        postInfo.Add("image", facebookUploader);
                    }
                    var client = new FacebookClient(App.Accesstoken);
                    var fbResult = client.Post("/" + group.Uid + "/photos", postInfo);
                    App.LstGroups[_postGroupIndex].IsRunned = true;
                    this.listBoxGroup.Items[_postGroupIndex].SubItems[1].Text = "Đã đăng";
                    per.Start();
                }
                else if (rdSharePost.Checked)
                {
                    var shareId = Regex.Match(txtPostLink.Text, @"\/posts\/(\d+)\?").Groups[1].Value;
                    var urlGroup = "https://mbasic.facebook.com/composer/mbasic/?c_src=share&referrer=feed&sid=" +
                                   shareId + "&m=self&target=" + group.Uid;
                    this.wbPostGroup.Navigate(urlGroup);
                    timerstep.Stop();
                }
                else if (rdShareLinkWebsite.Checked)
                {
                    dynamic parameters = new ExpandoObject();
                    parameters.message = GetPostMessage();
                    parameters.link = txtLinkWebsite.Text;
                    //parameters.picture = "http://www.example.com/article-thumbnail.jpg";
                    //parameters.name = "Article Title";
                    //parameters.caption = "Caption for the link";
                    //parameters.description = "Longer description of the link";

                    var client = new FacebookClient(App.Accesstoken);
                    var fbResult = client.Post("/" + group.Uid + "/feed", parameters);
                    App.LstGroups[_postGroupIndex].IsRunned = true;
                    this.listBoxGroup.Items[_postGroupIndex].SubItems[1].Text = "Đã đăng";
                    per.Start();
                }
                else {
                    var postInfo = new Dictionary<string, object>();
                    postInfo.Add("message", GetPostMessage());
                    var client = new FacebookClient(App.Accesstoken);
                    var fbResult = client.Post("/" + group.Uid + "/feed", postInfo);
                    App.LstGroups[_postGroupIndex].IsRunned = true;
                    this.listBoxGroup.Items[_postGroupIndex].SubItems[1].Text = "Đã đăng";
                    per.Start();
                }
            }
        }

        string GetPostMessage()
        {
            string text = this.txtPostContent.Text;
            var separator = new string[] { "[r]" };
            string[] strArray2 = text.Split(separator, StringSplitOptions.None);
            string strComment = strArray2.Aggregate("", (current, str4) => current + str4 + this.RandomString(3));
            strComment = strComment.Substring(0, strComment.Length - 3);
            return strComment;
        }
        private void webmain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string documentText = this.wbPostGroup.DocumentText;
            //is not login
            if (documentText.Contains("mbasic.facebook.com/login.php"))
            {
            }
            if (this._postgroup && App.LstGroups.Count > _postGroupIndex&& rdSharePost.Checked)
            {
                if (!App.LstGroups[_postGroupIndex].IsRunned)
                {
                    var strComment = GetPostMessage();
                    HtmlElement element = this.wbPostGroup.Document.All["xc_message"];
                    if (element != null)
                    {
                        element.InnerText = strComment;
                    }
                    HtmlElementCollection elementsByTagName = this.wbPostGroup.Document.GetElementsByTagName("input");
                    //go to post image
                    //if (rdShareImage.Checked)
                    //{
                    //    foreach (HtmlElement element2 in elementsByTagName)
                    //    {
                    //        if (element2.GetAttribute("name").Equals("lgc_view_photo"))
                    //        {
                    //            element2.InvokeMember("Click");
                    //            return;
                    //        }
                    //    }
                    //}
                    foreach (HtmlElement element2 in elementsByTagName)
                    {
                        //if (element2.GetAttribute("name").Equals("file1"))
                        //{
                        //    // element2.SetAttribute("value", txtImageFile1.Text);
                        //    //do other works like successful messages/etc
                        //    //element2.Focus();
                        //    //SendKeys.Send(txtImageFile1.Text + (char)(13));
                        //}
                        //if (element2.GetAttribute("name").Equals("file2"))
                        //{
                        //    element2.SetAttribute("value", txtImageFile2.Text);
                        //}
                        //if (element2.GetAttribute("name").Equals("file3"))
                        //{
                        //    element2.SetAttribute("value", txtImageFile3.Text);
                        //}
                        //if (element2.GetAttribute("name").Equals("photo_upload"))
                        //{
                        //    element2.InvokeMember("Click");
                        //}
                        if (element2.GetAttribute("name").Equals("view_post"))
                        {
                            element2.InvokeMember("Click");
                        }
                    }

                }
                App.LstGroups[_postGroupIndex].IsRunned = true;
                this.listBoxGroup.Items[_postGroupIndex].SubItems[1].Text = "Đã đăng";
                per.Start();
                if (_postGroupIndex >= App.LstGroups.Count)
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

        private string RandomString(int size)
        {
            var chArray = new char[size];
            for (int i = 0; i < size; i++)
            {
                chArray[i] = Chars[new Random().Next(0, Chars.Length - 1)];
            }
            return new string(chArray);
        }
        public void DisplayGroups()
        {
            this.listBoxGroup.Items.Clear();
            var i = 1;
            foreach (var item in App.LstGroups)
            {
                var newItem = new ListViewItem(item.GroupName);
                newItem.Checked = true;
                newItem.SubItems.Add("");
                this.listBoxGroup.Items.Add(newItem);
                i++;
            }
            this.lbDsNhom.Text = @"Danh sách nhóm (" + App.LstGroups.Count + @" nhóm)";
        }

        private void btnChooseImage1_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog
            {
                Filter = @"Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif,*.bmp",
                Multiselect = false
            };
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtImageFile1.Text = op.FileName;
            }
        }

        private void rdShareImage_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdSharePost_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem  item in listBoxGroup.Items)
            {
                item.Checked = cbSelectAll.Checked;
            }
        }

        private void btnOpenPost_Click(object sender, EventArgs e)
        {
            var fr=new frmSelectPost();
            if (fr.ShowDialog()==DialogResult.OK)
            {
                if (fr.SelectedPost!=null)
                {
                    txtPostContent.Text=fr.SelectedPost.PostContent;
                    switch (fr.SelectedPost.TypeId) {
                        case 0: break;
                        case 1: rdShareImage.Checked = true; break;
                        case 2: rdSharePost.Checked = true; break;
                        case 3: rdShareLinkWebsite.Checked = true; break;
                    }
                    txtPostLink.Text=fr.SelectedPost.PostLink;
                    txtLinkWebsite.Text=fr.SelectedPost.WebsiteLink;
                    txtImageFile1.Text = fr.SelectedPost.ImageFile;
                }
            }
        }

        private void btnSavePost_Click(object sender, EventArgs e)
        {
            var client = new FacebookClient(App.Accesstoken);
            var lstActivities = JObject.Parse(client.Get("/search?q=programming&type=group").ToString());
            if (string.IsNullOrEmpty(txtPostContent.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung bài viết","Thông báo");
                return;
            }
            var typeid=rdShareImage.Checked?1:rdSharePost.Checked?2:rdShareLinkWebsite.Checked?3:0;
            var typeName=rdShareImage.Checked?"Đăng ảnh":rdSharePost.Checked?"Chia sẻ bài viết":rdShareLinkWebsite.Checked?"Đăng link website":"";
            int id = App.LstPosts.Count>0?App.LstPosts.Max(p=>p.Id)+1:0;
            App.LstPosts.Add(new FacePost() { Id = id, PostContent = txtPostContent.Text, DateCreated = DateTime.Now, TypeId = typeid, TypeName = typeName,PostLink=txtPostLink.Text,WebsiteLink=txtLinkWebsite.Text,ImageFile=txtImageFile1.Text });
            App.SaveListPost();
            MessageBox.Show("Lưu thành công");
        }

        private void ucAutoJoinGroup_Load(object sender, EventArgs e)
        {
            
        }

        //link share friend https://mbasic.facebook.com/composer/mbasic/?mnt_query&csid=88b41973-2fef-4b4f-b050-45593c85b0ab&av=100000298319059
    }
}
