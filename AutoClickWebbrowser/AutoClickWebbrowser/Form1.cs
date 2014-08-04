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
        private List<string> listFGroups;
        int groupIndex = 0;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //if (chkIsMoblie.Checked)
            //{
            //    textBox1.Text = "https://m.facebook.com/browsegroups/?seemore";
            //}
            //else
            //{
            //    textBox1.Text = "https://m.facebook.com/browsegroups/?seemore";
            //}
            webBrowser1.Url = new Uri(textBox1.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listFGroups = GetListFGroup();
            webBrowser1.DocumentCompleted -= PostFGroup;
            webBrowser1.DocumentCompleted += PostFGroup;
            ProcessPostF();
        }
        void ProcessPostF()
        {
            if (groupIndex < listFGroups.Count)
            {
                webBrowser1.Url = new Uri(listFGroups[groupIndex]);
                groupIndex++;
            }
        }

        private void PostFGroup(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (chkIsMoblie.Checked)
            {
                //m fa
                var element = GetElement("textarea", "name", "message");
                if (element != null)
                {
                    element.InnerHtml = rtbPostFGroupComment.Text;
                    ClickElement("input", "name", "update");
                    return;
                }
                ProcessPostF();
            }
            else
            {
                //fa
                ClickElement("a", "data-endpoint", "/ajax/composerx/attachment/group/post/");
                GetElement("textarea", "name", "xhpc_message_text").InnerHtml = "http://dichthuatdonga.com/";
            }
        }
        void ClickElement(string tagName, string attribute, string attName)
        {
            var x = webBrowser1.ProductName;
            if (webBrowser1.Document != null)
            {
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
        }
        HtmlElement GetElement(string tagName, string attribute, string attName)
        {
            var x = webBrowser1.ProductName;
            if (webBrowser1.Document != null)
            {
                HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName(tagName);
                foreach (HtmlElement element in col)
                {
                    if (element.GetAttribute(attribute).Equals(attName))
                    {
                        return element;
                    }
                }
            }
            return null;
        }
        List<string> GetListFGroup()
        {
            var result = new List<string>();
            if (webBrowser1.Document != null)
            {
                var element = webBrowser1.Document.GetElementsByTagName("ul")[0];
                foreach (HtmlElement item in element.GetElementsByTagName("a"))
                {
                    var href = item.GetAttribute("href");
                    if (href.Contains("groups") && !result.Contains(href))
                    {
                        if (chkIsMoblie.Checked)
                        {
                            result.Add(href); 
                        }
                        else
                        {
                            result.Add(href.Replace("https://m.", "https://www.")); 
                        }
                    }
                }
            }
            return result;
        }
        private void btnStartGP_Click(object sender, EventArgs e)
        {
            var x = new List<string>() { "https://plus.google.com/u/0/113417325382899203255/posts" };
            foreach (var item in x)
            {
                WinUtilities.LeftClick(new Point(165, 146));//url
                SendKeys.SendWait(x.FirstOrDefault());
                SendKeys.SendWait("{ENTER}");
                var n = 0;
                while (true)
                {
                    if (WinUtilities.GetPixelColor(51, 115) == ColorTranslator.FromHtml("0xB43525") || n == 10)
                    {
                        n = 0;
                        MessageBox.Show("Test2");
                        break;
                    }
                    Thread.Sleep(1000);
                    n++;
                }
                SendKeys.SendWait("{DOWN}");
                //SendKeys.SendWait("http://dichthuatdonga.com/");
                //Thread.Sleep(10000);
                //SendKeys.SendWait("{TAB}");
                //SendKeys.SendWait("{TAB}");
                //SendKeys.SendWait("{TAB}");
                //SendKeys.SendWait("{TAB}");
                //SendKeys.SendWait("{TAB}");
                //Thread.Sleep(100);
                SendKeys.SendWait("{DOWN}");
                //Thread.Sleep(100);
                //SendKeys.SendWait("{ENTER}");
                //Thread.Sleep(200);
                //SendKeys.SendWait("{TAB}");
                //while (true)
                //{
                //    if (WinUtilities.GetPixelColor(524, 580) == ColorTranslator.FromHtml("0x53A93F") || n == 10)
                //    {
                //        n = 0;
                //        break;
                //    }
                //    Thread.Sleep(500);
                //    n++;
                //}
                //SendKeys.SendWait("{ENTER}");
                //Thread.Sleep(1000);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //CurrentBrower = Process.Start("firefox.exe", "http:\\www.google.com");
            //Thread.Sleep(5000);
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
                    var href = element.GetAttribute("href");
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*
             <textarea name="xhpc_message_text" title="Write something..." class="uiTextareaAutogrow input autofocus mentionsTextarea textInput DOMControl_placeholder" id="u_0_2a" role="textbox" aria-expanded="false" aria-haspopup="true" aria-owns="typeahead_list_u_0_29" aria-autocomplete="list" aria-label="Write something..." onkeydown='run_with(this, ["legacy:control-textarea"], function() {TextAreaControl.getInstance(this)});' placeholder="Write something..." autocomplete="off">Write something...</textarea>
             */
            ClickElement("a", "data-endpoint", "/ajax/composerx/attachment/group/post/");
            Thread.Sleep(5000);
            var text=GetElement("textarea", "name", "xhpc_message_text");
            var input = GetElement("textarea", "name", "xhpc_message");
            input.InvokeMember("keydown");
            input.SetAttribute("value","http://dichthuatdonga.com/");
            
            //input.InvokeMember("change");
            //<input type="hidden" autocomplete="off" class="mentionsHidden" name="xhpc_message" value="43435435345">
            //var new HtmlElement().InnerHtml=@"<div class='_4_4e'><div class='mvm mhs _9u'><input type='hidden' autocomplete='off' name='aktion' value='post'><input type='hidden' autocomplete='off' name='app_id' value='2309869772'><div id='stage53dc93a38def48275105062' class='UIShareStage clearfix UIShareStage_HasImage'><div class='clearfix UIShareStage_Preview'><div class='UIShareStage_ImageContainer lfloat _ohe'><div class='UIShareStage_Image'><div class='UIShareStage_ThumbPager UIThumbPager' id='c53dc93a38eabf1706340988'><div class='UIThumbPager_Loader' style='display: none;'><img class='img' src='https://fbstatic-a.akamaihd.net/rsrc.php/v2/yb/r/GsNJNwuI-UM.gif' alt='' width='16' height='11'></div><div class='UIThumbPager_Thumbs'><img class='UIThumbPager_Thumb img UIThumbPager_Hidden' src='https://fbexternal-a.akamaihd.net/safe_image.php?d=AQDkc8e63BOjOSxs&amp;w=100&amp;h=100&amp;url=http%3A%2F%2Fdichthuatdonga.com%2Fupload%2Fimages%2Flien-ket-dich-thuat-cong-chung-nhanh-huyndai.jpg&amp;cfs=1&amp;upscale' alt=''><img class='UIThumbPager_Thumb img' src='https://fbexternal-a.akamaihd.net/safe_image.php?d=AQD9WWzTuNkHBYKV&amp;w=100&amp;h=100&amp;url=http%3A%2F%2Fdichthuatdonga.com%2Fupload%2Fimages%2Fschu2.jpg&amp;cfs=1&amp;upscale' alt=''><img class='UIThumbPager_Hidden UIThumbPager_Thumb img' src='https://fbexternal-a.akamaihd.net/safe_image.php?d=AQDLXcnFu1FnU0eh&amp;w=100&amp;h=100&amp;url=http%3A%2F%2Fdichthuatdonga.com%2Fupload%2Fimages%2FLLTP.jpg&amp;cfs=1&amp;upscale' alt=''></div></div></div></div><div class='UIShareStage_ShareContent _42ef'><div class='UIShareStage_Title'><span dir='ltr'><a class='UIShareStage_InlineEdit inline_edit' onclick='new InlineEditor(this, &quot;attachment[params][title]&quot;, $(&quot;stage53dc93a38def48275105062&quot;), null, false, 100); return false;' href='#' role='button'>Dịch Thuật Đông Á - Dịch Thuật Công Chứng Nhanh Rẻ Uy Tín</a></span></div><div class='UIShareStage_Subtitle'>dichthuatdonga.com</div><div class='UIShareStage_Summary'><p class='UIShareStage_BottomMargin'><a class='UIShareStage_InlineEdit inline_edit' onclick='new InlineEditor(this, &quot;attachment[params][summary]&quot;, $(&quot;stage53dc93a38def48275105062&quot;), null, true, 0); return false;' href='#' role='button'>Dịch Thuật Đông Á là công ty Dịch Thuật cung cấp các dịch vụ dịch thuật, công chứng nhanh, lý lịch tư pháp, hợp pháp hóa lãnh sự nhanh rẻ uy tín tại Hà Nội</a></p><div class='UIShareStage_ThumbPagerControl UIThumbPagerControl' id='c53dc93a38ef136071382969'><div class='UIThumbPagerControl_Buttons'><a class='UIThumbPagerControl_Button UIThumbPagerControl_Button_Left'></a><a class='UIThumbPagerControl_Button UIThumbPagerControl_Button_Right'></a></div><div class='UIThumbPagerControl_Text'><span class='UIThumbPagerControl_PageNumber'><span class='UIThumbPagerControl_PageNumber_Current'>2</span> of <span class='UIThumbPagerControl_PageNumber_Total'>3</span></span>Choose a thumbnail</div><div class='uiInputLabel clearfix uiInputLabelLegacy mts'><input class='UIThumbPagerControl_NoPicture uiInputLabelInput uiInputLabelCheckbox' type='checkbox' value='true' name='no_picture' id='u_9l_0'><label for='u_9l_0' class='uiInputLabelLabel'>No thumbnail</label></div></div></div></div></div><input type='hidden' autocomplete='off' id='app_id' name='app_id' value='2309869772'><input type='hidden' name='attachment[params][urlInfo][canonical]' value='http://dichthuatdonga.com/'><input type='hidden' name='attachment[params][urlInfo][final]' value='http://dichthuatdonga.com/'><input type='hidden' name='attachment[params][urlInfo][user]' value='http://dichthuatdonga.com/'><input type='hidden' name='attachment[params][favicon]' value='http://dichthuatdonga.com/Frontend/img/dich-thuat-dong-a-cong-chung-nhanh-favicon.ico'><input type='hidden' name='attachment[params][title]' value='Dịch Thuật Đông Á - Dịch Thuật Công Chứng Nhanh Rẻ Uy Tín'><input type='hidden' name='attachment[params][summary]' value='Dịch Thuật Đông Á là công ty Dịch Thuật cung cấp các dịch vụ dịch thuật, công chứng nhanh, lý lịch tư pháp, hợp pháp hóa lãnh sự nhanh rẻ uy tín tại Hà Nội'><input type='hidden' name='attachment[params][images][0]' value='http://dichthuatdonga.com/upload/images/lien-ket-dich-thuat-cong-chung-nhanh-huyndai.jpg'><input type='hidden' name='attachment[params][medium]' value='106'><input type='hidden' name='attachment[params][url]' value='http://dichthuatdonga.com/'><input type='hidden' name='attachment[type]' value='100'><input type='hidden' name='link_metrics[source]' value='ShareStageExternal'><input type='hidden' name='link_metrics[domain]' value='dichthuatdonga.com'><input type='hidden' name='link_metrics[base_domain]' value='dichthuatdonga.com'><input type='hidden' name='link_metrics[title_len]' value='57'><input type='hidden' name='link_metrics[summary_len]' value='156'><input type='hidden' name='link_metrics[min_dimensions][0]' value='70'><input type='hidden' name='link_metrics[min_dimensions][1]' value='70'><input type='hidden' name='link_metrics[images_with_dimensions]' value='3'><input type='hidden' name='link_metrics[images_pending]' value='0'><input type='hidden' name='link_metrics[images_fetched]' value='0'><input type='hidden' name='link_metrics[image_dimensions][0]' value='1068'><input type='hidden' name='link_metrics[image_dimensions][1]' value='375'><input type='hidden' name='link_metrics[images_selected]' value='3'><input type='hidden' name='link_metrics[images_considered]' value='5'><input type='hidden' name='link_metrics[images_cap]' value='3'><input type='hidden' name='link_metrics[images_type]' value='ranked'><input type='hidden' name='attachment[params][images][0]' value='https://fbexternal-a.akamaihd.net/safe_image.php?d=AQD9WWzTuNkHBYKV&amp;w=100&amp;h=100&amp;url=http%3A%2F%2Fdichthuatdonga.com%2Fupload%2Fimages%2Fschu2.jpg&amp;cfs=1&amp;upscale'><input type='hidden' name='composer_metrics[best_image_w]' value='100'><input type='hidden' name='composer_metrics[best_image_h]' value='100'><input type='hidden' name='composer_metrics[image_selected]' value='1'><input type='hidden' name='composer_metrics[images_provided]' value='3'><input type='hidden' name='composer_metrics[images_loaded]' value='3'><input type='hidden' name='composer_metrics[images_shown]' value='3'><input type='hidden' name='composer_metrics[load_duration]' value='2'><input type='hidden' name='composer_metrics[timed_out]' value='0'><input type='hidden' name='composer_metrics[sort_order]'><input type='hidden' name='composer_metrics[selector_type]' value='UIThumbPager_6'></div><label class='_9s uiCloseButton' for='u_9l_4'><input aria-label='Remove' title='Remove' type='button' id='u_9l_4'></label></div></div>");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentBrower != null) CurrentBrower.Kill();
        }

        private void tmCheckFFIsLoaded_Tick(object sender, EventArgs e)
        {

        }
    }
}
