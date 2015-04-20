using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Facebook;

namespace FPlus
{
    public partial class ucLoginFacebook : UserControl
    {
        //https://www.facebook.com/v2.0/dialog/oauth?response_type=token&display=popup&client_id=246307945442076&redirect_uri=https%3A%2F%2Fdevelopers.facebook.com%2Ftools%2Fexplorer%2Fcallback&scope=user_groups
        //https://www.facebook.com/v2.0/dialog/oauth?response_type=token&display=popup&client_id=145634995501895&redirect_uri=https%3A%2F%2Fdevelopers.facebook.com%2Ftools%2Fexplorer%2Fcallback&scope=user_groups
        public event EventHandler FacebookLoggedIn;
        private const string AppId = "1390532984544664";
        private const string ExtendedPermissions = "user_about_me,user_groups,user_status,user_photos,manage_pages,publish_actions,read_insights,read_stream";
        protected readonly FacebookClient _fb;
        public ucLoginFacebook()
        {
            _fb=new FacebookClient();
            InitializeComponent();
           // pictureBox1.Parent = wbLoginFace;
            dynamic parameters = new ExpandoObject();
            parameters.client_id = AppId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";
            parameters.response_type = "token";
            parameters.display = "popup";
            if (!string.IsNullOrWhiteSpace(ExtendedPermissions))
                parameters.scope = ExtendedPermissions;

            wbLoginFace.Navigate(_fb.GetLoginUrl(parameters));
           
        }

        private void wbLoginFace_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            pictureBox1.Hide();
            var documentText = this.wbLoginFace.DocumentText;
            if (App.LstGroups.Count <= 0)
            {
                documentText = documentText.Replace(@"\/", "/").Replace(@"\u0025", "%").Replace("&amp;", "&").Replace("&quot;", "\"");
                MatchCollection matchs = new Regex("/groups/([0-9]{6,30})[^>]+>([^<]+)").Matches(documentText);
                foreach (Match match in matchs)
                {
                    if (App.LstGroups.All(p => p.Uid != match.Groups[1].Value))
                    {
                        var groupName = match.Groups[2].Value;
                        var id = match.Groups[1].Value;
                        App.LstGroups.Add(new FaceGroup()
                        {
                            Uid = id,
                            GroupName = groupName,
                            IsChecked = true
                        });
                    }
                }
                App.SaveListGroup();
            }
        }

        private void wbLoginFace_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if ((App.Accesstoken.Length < 20))
            {
                string fragment = e.Url.Fragment;
                if (fragment.Contains("access_token") && fragment.Contains("#"))
                {
                    string[] strArray = new Regex("#").Replace(fragment, "?", 1).Split(new char[] { '=' });
                    App.Accesstoken = strArray[1].Substring(0, strArray[1].Length - 11);
                    this.GetGroup();
                    if (App.LstGroups.Count <= 0)
                    {
                        App.OpenListGroup();
                    }
                    if (!string.IsNullOrEmpty(App.Accesstoken))
                    {
                        if (FacebookLoggedIn != null)
                        {
                            FacebookLoggedIn(sender, e);
                        }
                    }
                }
            }
        }
        private void GetGroup()
        {
            var client = new FacebookClient(App.Accesstoken);
            //var obj2 = (JsonObject)client.Get("me");
            //this.pictureBox1.Load("https://graph.facebook.com/" + obj2["id"] + "/picture");
            client = new FacebookClient(App.Accesstoken);
            var groups = (JsonObject)client.Get("me/groups?limit=100000");
            foreach (var obj3 in (JsonArray)groups["data"])
            {
                var id = (string)((JsonObject)obj3)["id"];
                var name = (string)((JsonObject)obj3)["name"];
                App.LstGroups.Add(new FaceGroup() { Uid = id, GroupName = name, IsChecked = true });
            }
            var friends = (JsonObject)client.Get("me/friends?limit=100000");
            foreach (var item in (JsonArray)friends["data"])
            {
                var id = (string)((JsonObject)item)["id"];
                var name = (string)((JsonObject)item)["name"];
                App.LstFriends.Add(new FaceFriend(){ Uid = id, Name = name, IsChecked = true });
            }
            App.SaveListGroup();
        }

        private void wbLoginFace_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            pictureBox1.Show();
        }
    }
}
