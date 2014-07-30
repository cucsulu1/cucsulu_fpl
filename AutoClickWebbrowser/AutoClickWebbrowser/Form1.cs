using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoClickWebbrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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
    }
}
