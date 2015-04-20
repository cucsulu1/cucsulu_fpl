using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FPlus;

namespace FPlus
{
    public partial class ucAutoPostFriend : UserControl
    {
        private const string Chars = "abcefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private bool _postfriend;
        private int _countdown;
        private int _postFriendIndex = 0;

        public ucAutoPostFriend()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            this._postfriend = true;
            _postFriendIndex = 0;
            foreach (var faceGroup in App.LstFriends)
            {
                faceGroup.IsRunned = false;
            }
            this.timerstep.Start();
            this.per.Start();
            this._countdown = (int)this.txtTimeDelay.Value;
        }

        private void btnStopPost_Click(object sender, EventArgs e)
        {
            this.per.Stop();
            this.timerstep.Stop();
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            this.timerstep.Interval = ((int)this.txtTimeDelay.Value) * 1000;
        }

        private void per_Tick(object sender, EventArgs e)
        {
            this._countdown--;
            this.lbStatus.Text = @"Còn " + this._countdown.ToString() + @" giây để đăng bạn tiếp theo";
            metroProgressSpinnerOnePost.Value = (int)(_countdown / this.txtTimeDelay.Value * 100);
        }


        private void timerstep_Tick(object sender, EventArgs e)
        {
            if (this._postfriend)
            {
                this.timerstep.Interval = 1000 * ((int)this.txtTimeDelay.Value);
                this._countdown = (int)this.txtTimeDelay.Value;
                progressBarStatus.Value = (int)(_postFriendIndex/App.LstFriends.Count*1000);
                lbTotalProcessed.Text = App.LstFriends.Count(p => p.IsRunned) + @"/" + listBoxFriend.CheckedIndices.Count;
                var urlGroup = "";
                while (!listBoxFriend.CheckedIndices.Contains(_postFriendIndex))
                {
                    _postFriendIndex++;
                    if (_postFriendIndex >= App.LstFriends.Count)
                    {
                        this.per.Stop();
                        this.timerstep.Stop();
                        MessageBox.Show(@"Đăng hoàn tất",@"Thông báo!");
                        return;
                    }
                }
                try
                {
                    string text = this.txtPostLink.Text;
                    int index = text.IndexOf("sid=");
                    text = text.Substring(index + 4);
                    if (text.Contains("&"))
                    {
                        index = text.IndexOf("&");
                        text = text.Substring(0, index);
                    }
                    urlGroup = "https://mbasic.facebook.com/composer/mbasic/?c_src=share&referrer=feed&sid=" + text + "&m=self&target=" + App.LstFriends[_postFriendIndex].Uid;
                    this.wbPostFriend.Navigate(urlGroup);
                }
                catch
                {
                    urlGroup = "https://mbasic.facebook.com/" + App.LstFriends[_postFriendIndex].Uid;
                    this.wbPostFriend.Navigate(urlGroup);
                }
                _postFriendIndex++;
                timerstep.Stop();
                //if (((this.listBoxGroup.SelectedIndex + 1) % 50) == 0)
                //{
                //    this.timerstep.Interval = 0x124f80;
                //    this._countdown = 0x4b0;
                //}
            }
        }
        private void webmain_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (wbPostFriend.Url.Host == "developers.facebook.com")
            {
                wbPostFriend.DocumentText = "";
                this.wbPostFriend.Navigate("https://mbasic.facebook.com/");
            }
        }
        private void webmain_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string documentText = this.wbPostFriend.DocumentText;
            if (this._postfriend && !App.LstFriends[_postFriendIndex].IsRunned)
            {
                HtmlElement element;
                HtmlElementCollection elementsByTagName;
                string text = this.txtPostContent.Text;
                var separator = new string[] { "[r]" };
                string[] strArray2 = text.Split(separator, StringSplitOptions.None);
                string str3 = strArray2.Aggregate("", (current, str4) => current + str4 + this.RandomString(3));
                str3 = str3.Substring(0, str3.Length - 3);
                if (documentText.Contains("/composer/mbasic/"))
                {
                    element = this.wbPostFriend.Document.All["xc_message"];
                    if (element != null)
                    {
                        element.InnerText = str3;
                    }
                    elementsByTagName = this.wbPostFriend.Document.GetElementsByTagName("input");
                    foreach (HtmlElement element2 in elementsByTagName)
                    {
                        if (element2.GetAttribute("name").Equals("file1"))
                        {
                            element2.SetAttribute("value", txtImageFile1.Text);
                        }
                        if (element2.GetAttribute("name").Equals("file2"))
                        {
                            element2.SetAttribute("value", txtImageFile2.Text);
                        }
                        if (element2.GetAttribute("name").Equals("file3"))
                        {
                            element2.SetAttribute("value", txtImageFile3.Text);
                        }
                        if (element2.GetAttribute("name").Equals("photo_upload"))
                        {
                            element2.InvokeMember("Click");
                        }
                    }
                }
                if (documentText.Contains("/a/sharer.php"))
                {
                    element = this.wbPostFriend.Document.All["comment"];
                    if (element != null)
                    {
                        element.InnerText = str3;
                    }
                    elementsByTagName = this.wbPostFriend.Document.GetElementsByTagName("input");
                    foreach (HtmlElement element2 in elementsByTagName)
                    {
                        if (element2.GetAttribute("name").Equals("post"))
                        {
                            element2.InvokeMember("Click");
                        }
                    }
                }
                App.LstFriends[_postFriendIndex].IsRunned = true;
                timerstep.Start();
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
        public void DisplayFriends()
        {
            var i = 1;
            foreach (var item in App.LstFriends)
            {
                this.listBoxFriend.Items.Add(item.Name, true);
                i++;
            }
            this.lbDsBan.Text = @"Danh sách bạn (" + App.LstFriends.Count + @" bạn)";
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

        private void btnChooseImage2_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog
            {
                Filter = @"Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif,*.bmp",
                Multiselect = false
            };
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtImageFile2.Text = op.FileName;
            }
        }

        private void btnChooseImage3_Click(object sender, EventArgs e)
        {
            var op = new OpenFileDialog
            {
                Filter = @"Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif,*.bmp",
                Multiselect = false
            };
            if (op.ShowDialog() == DialogResult.OK)
            {
                txtImageFile3.Text = op.FileName;
            }
        }
    }
}
