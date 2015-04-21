using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using mshtml;
using Timer = System.Windows.Forms.Timer;

namespace FPlus
{
    public partial class ucAds : UserControl
    {
        private void RunBrowserThread(IEnumerable<string> adUrls )
        {
            var th = new Thread(() =>
            {
                foreach (var adUrl in adUrls)
                {
                    var br = new WebBrowser();
                    br.Name = "br";
                    br.DocumentCompleted += webAds_DocumentCompleted;
                    br.ScriptErrorsSuppressed = true;
                    HtmlElement head = br.Document.GetElementsByTagName("head")[0];
                    HtmlElement scriptEl = br.Document.CreateElement("script");
                    IHTMLScriptElement element = (IHTMLScriptElement)scriptEl.DomElement;
                    string alertBlocker = @"window.alert = function () { }; window.confirm = function () { return true;}; ";
                    element.text = alertBlocker;
                    head.AppendChild(scriptEl);
                    br.Tag = adUrl;
                    br.Navigate(new Uri(adUrl), null, null,
                    "User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
                }
                Application.Run();
             });
             th.SetApartmentState(ApartmentState.STA);
             th.Start();
        }
        public ucAds()
        {
            IEnumerable<string> adUrls = new List<string>() { "http://adf.ly/1EHDVC" };
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
            if (br.Url.Host != adUri.Host)
            {
                br.Navigate(adUri, null, null,
                    "User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
            }
            else
            {
                //timerAds.Start();
                var htmlDocument = br.Document;
                if (htmlDocument != null)
                {
                    var element = htmlDocument.GetElementById("skip_ad_button");
                    if (element != null)
                    {
                        //Thread.Sleep(10000);
                        //element.InvokeMember("Click");
                        var head = br.Document.GetElementsByTagName("head")[0];
                        var scriptEl = br.Document.CreateElement("script");
                        var scriptElement = (IHTMLScriptElement)scriptEl.DomElement;
                        scriptElement.text = "function clickAds() {setTimeout(function(){if($('#skip_ad_button').is(':hidden')){location.reload();}else{$('#skip_ad_button').click()}},10000)}";
                        head.AppendChild(scriptEl);
                        br.Document.InvokeScript("clickAds");
                    }
                    else
                    {
                        br.Navigate(adUri, null, null,
                            "User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
                    }
                }
                else
                {
                    br.Navigate(adUri, null, null,
                        "User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
                }
            }
        }
        private void timerAds_Tick(object sender, EventArgs e)
        {
            //var htmlDocument = this.webAds.Document;
            //if (htmlDocument != null)
            //{
            //    var element = htmlDocument.GetElementById("skip_ad_button");
            //    if (element != null)
            //    {
            //        element.InvokeMember("Click");
            //    }
            //    else
            //    {
            //        webAds.Navigate(new Uri(App.AdsLink), null, null,
            //            "User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
            //    }
            //}
            //else
            //{
            //    webAds.Navigate(new Uri(App.AdsLink), null, null, "User-Agent: Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2272.118 Safari/537.36");
            //}
        }

        #endregion

        private void ucAds_Load(object sender, EventArgs e)
        {


        }
    }
}
