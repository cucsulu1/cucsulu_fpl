using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace AutoClickWebbrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Process CurrentBrower { get; set; }
        WinUtilities win = new WinUtilities();

        private void btnStart_Click(object sender, EventArgs e)
        {
            webBrowser1.Url = new Uri(textBox1.Text); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClickButton("div", "jscontroller", "qG1h8c");
        }
        void ClickButton(string tagName,string attribute, string attName)
        {
            var x = webBrowser1.ProductName;
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName(tagName);
            foreach (HtmlElement element in col)
            {
                if (element.GetAttribute(attribute).Equals(attName))
                {
                    // Invoke the "Click" member of the button
                    element.InvokeMember("click");
                }
            }
        }
        private void btnStartGP_Click(object sender, EventArgs e)
        {
            var x = GetListGroup();
            var y = "";
            foreach (var iem in x)
            {
                y += string.Format("\"{0}\", _\r\n", iem);
            }
            foreach (var item in x)
            {
                WinUtilities.LeftClick(new Point(382, 142));//url
                SendKeys.SendWait(x.FirstOrDefault());
                SendKeys.SendWait("{ENTER}");
                var n = 0;
                while (true)
                {
                    if (WinUtilities.GetPixelColor(51, 115) == ColorTranslator.FromHtml("0xB43525") || n == 20)
                    {
                        n = 0;
                        break;
                    }
                    Thread.Sleep(500);
                    n++;
                }
                WinUtilities.LeftClick(new Point(477, 446));
                while (true)
                {
                    if (WinUtilities.GetPixelColor(635, 452) == ColorTranslator.FromHtml("0x4285F4") || n == 20)
                    {
                        n = 0;
                        break;
                    }
                    Thread.Sleep(500);
                    n++;
                }
                SendKeys.SendWait("http://dichthuatdonga.com/");
                Thread.Sleep(10000);
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{TAB}");
                Thread.Sleep(100);
                SendKeys.SendWait("{DOWN}");
                Thread.Sleep(100);
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(200);
                SendKeys.SendWait("{TAB}");
                while (true)
                {
                    if (WinUtilities.GetPixelColor(524, 580) == ColorTranslator.FromHtml("0x53A93F") || n == 10)
                    {
                        n = 0;
                        break;
                    }
                    Thread.Sleep(500);
                    n++;
                }
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(1000);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            CurrentBrower = Process.Start("firefox.exe", "http:\\www.google.com");
            Thread.Sleep(2000);
            Process[] processesByName = Process.GetProcesses();
            CurrentBrower = processesByName.FirstOrDefault(p => p.ProcessName.Contains("firefox"));
            if (CurrentBrower != null)
            {
                WinUtilities.SetParent(CurrentBrower.MainWindowHandle, pnClient.Handle);
                WinUtilities.MoveWindow(CurrentBrower.MainWindowHandle, 0, 0, pnClient.Width, pnClient.Height, false);
                WinUtilities.WndHandle = CurrentBrower.Handle;
            }
        }


        public List<string> GetListGroup()
        {
            var result = new List<string>();
            if (webBrowserGroup.Document != null)
            {
                HtmlElementCollection col = webBrowserGroup.Document.GetElementsByTagName("a");
                foreach (HtmlElement element in col)
                {
                    var href=element.GetAttribute("href");
                    if (href.Contains("communities") && element.GetAttribute("hc").Contains("off") && !result.Contains(href))
                    {
                        result.Add(href);
                    }
                }
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowserGroup.Url = new Uri("https://plus.google.com/u/0/b/102397380177231200136/communities/113255993038343232025/members");
        }
        SEODBEntities _db=new SEODBEntities();
        private void btnGetPeople_Click(object sender, EventArgs e)
        {
            var str = System.IO.File.ReadAllText("C:/Users/pc/Desktop/tt.htm");
            if (webBrowserGroup.Document != null)
            {
                HtmlElementCollection col = webBrowserGroup.Document.GetElementsByTagName("a");
                var regex = Regex.Matches(str, "oid=\"(\\d*)\"");
                foreach (Match element in regex)
                {
                    var href = element.Groups[1].Value;
                     if (!_db.PlusPeoples.Any(p => p.Name == href))
                     {
                         _db.PlusPeoples.Add(new PlusPeoples() { IsRunAdded = false, Name = href, Url = "https://plus.google.com/"+href,IsFriend = false});
                         _db.SaveChanges();
                     }
                }
            }
        } 
    }
}
