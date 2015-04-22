using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Facebook;
using mshtml;
using Newtonsoft.Json.Linq;
using Timer = System.Windows.Forms.Timer;

namespace FPlus
{
    public partial class ucAdsYT : UserControl
    {
        private void RunBrowserThread(Dictionary<string, int> adUrls)
        {
            //var th = new Thread(() =>
            //{
                foreach (var adUrl in adUrls)
                {
                    var br = webAds;//new WebBrowser();
                    br.Name = "br";
                    br.DocumentCompleted += webAds_DocumentCompleted;
                    br.ScriptErrorsSuppressed = true;
                    br.Tag = adUrl.Key;
                    br.TabIndex = adUrl.Value;
                    br.Navigate(new Uri(adUrl.Key), null, null,
                    "User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
                    break;
                }
            //    Application.Run();
            //});
            //th.SetApartmentState(ApartmentState.STA);
            //th.Start();
        }
        public ucAdsYT()
        {
            var adUrls = new Dictionary<string, int>();
            adUrls.Add("https://youtu.be/r4LTPgbd5yU",10000);

            var result = Utilities.GetHtml(App.SeverUrl + "fplus/yads");
            if(!string.IsNullOrEmpty(result)){
                var lstUrls = JObject.Parse(result);
                adUrls.Clear();
                foreach (JObject item in lstUrls.Values<JObject>())
                {
                    adUrls.Add(item.Value<string>("url"), item.Value<int>("time"));
                }
            }
            InitializeComponent();
            RunBrowserThread(adUrls);
            //timerAds.Start(); 
        }
        #region ads
        private void webAds_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br = (WebBrowser)sender;
            Console.WriteLine(br.Name + br.Url);
            var adUri = new Uri(br.Tag.ToString());
            //if (br.Url.Host != "www.youtube.com")
            //{
            //    //br.Navigate(adUri, null, null,"User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
            //}
            //else
            //{
                //timerAds.Start();
                var htmlDocument = br.Document;
                if (htmlDocument != null)
                {
                    var head = br.Document.GetElementsByTagName("head")[0];
                    var scriptEl = br.Document.CreateElement("script");
                    var scriptElement = (IHTMLScriptElement)scriptEl.DomElement;
                    scriptElement.text = "function clickAds() {document.getElementById(\"content\").outerHTML=\"\"; setTimeout(function () { if (document.getElementsByClassName(\"ad-container\")[0].getElementsByTagName('a').length == 0) {alert(document.getElementsByClassName(\"recall-button\")[0]); document.getElementsByClassName(\"recall-button\")[0].click(); } setTimeout(function () { document.getElementsByClassName(\"ad-container\")[0].getElementsByTagName(\"a\")[0].setAttribute(\"target\", \"_self\"); document.getElementsByClassName(\"ad-container\")[0].getElementsByTagName(\"a\")[0].click(); }, 1000) }, " + br.TabIndex + "); window.alert = function () { }; window.confirm = function () { return true; }; }";
                    head.AppendChild(scriptEl);
                    br.Document.InvokeScript("clickAds");
                        timerAds.Stop();
                        timerAds.Interval = br.TabIndex; timerAds.Start();
                }
                else
                {
                    //br.Navigate(adUri, null, null,"User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
                }
            //}
        }
        #endregion

        private void timerAds_Tick(object sender, EventArgs e)
        {
            var br = webAds; 
            var head = br.Document.GetElementsByTagName("body")[0];
            HtmlElement scriptEl = br.Document.CreateElement("button");
            scriptEl.SetAttribute("onclick", "document.getElementsByClassName(\"ad-container\")[0].getElementsByTagName(\"a\")[0].setAttribute(\"target\", \"_self\"); alert(document.getElementsByClassName(\"ad-container\")[0].getElementsByTagName(\"a\")[0]);document.getElementsByClassName(\"ad-container\")[0].getElementsByTagName(\"a\")[0].click();");
            head.AppendChild(scriptEl);
            scriptEl.InvokeMember("click");
        }

    }
}
