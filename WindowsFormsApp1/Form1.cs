using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using CefSharp.WinForms;
using CefSharp;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly ChromiumWebBrowser chromiumBrowser;

        public Form1()
        {
            InitializeComponent();

            chromiumBrowser = new ChromiumWebBrowser();
            chromiumBrowser.Dock = DockStyle.Fill;
            tableLayoutPanel1.Controls.Add(chromiumBrowser, 1, 1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<!doctype html>");
            stringBuilder.AppendLine("<html>");
            stringBuilder.AppendLine("<head>");
            stringBuilder.AppendLine("<script src='https://api.mapy.cz/loader.js'></script>");
            stringBuilder.AppendLine("<script>Loader.load(null, {suggest:true, poi:true, mode: 'multi'})</script>");
            stringBuilder.AppendLine("</head>");
            stringBuilder.AppendLine("<body>");
            stringBuilder.AppendLine("<div id='mapa' style='width:600px; height:400px;'></div>");
            stringBuilder.AppendLine("<script type='text/javascript'>");
            stringBuilder.AppendLine("alert([1,2].includes(1));");
            stringBuilder.AppendLine("var stred = SMap.Coords.fromWGS84(14.41, 50.08);");
            stringBuilder.AppendLine("var mapa = new SMap(document.querySelector('#mapa'), stred, 10);");
            stringBuilder.AppendLine("mapa.addDefaultLayer(SMap.DEF_BASE).enable();");
            stringBuilder.AppendLine("</script>");
            stringBuilder.AppendLine("</body>");
            stringBuilder.AppendLine("</html>");

            string htmlString = stringBuilder.ToString();

            webBrowser1.DocumentText = htmlString;
            //chromiumBrowser.LoadHtml(htmlString);



        }
    }
}
