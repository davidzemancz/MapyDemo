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
using System.Runtime.InteropServices;

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
            //tableLayoutPanel1.Controls.Add(chromiumBrowser, 1, 1);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            string testJsDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "mapycz_IEsupport.js");

            StringBuilder htmlBuilder = new StringBuilder();

            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine("<head>");
            htmlBuilder.AppendLine("  <meta http-equiv='X-UA-Compatible' content='IE=11'>");
            htmlBuilder.AppendLine("  <meta charset='utf-8' />");
            htmlBuilder.AppendLine("  <script type='text/javascript' src='https://api.mapy.cz/loader.js'></script>");
            htmlBuilder.AppendLine("  <script type='text/javascript' src='https://api.mapy.cz/virtual-key.js'></script>");
            htmlBuilder.AppendLine("  <link rel='stylesheet' type='text/css' href='https://api.mapy.cz/css/api/v4/smap-jak.css' />");
            htmlBuilder.AppendLine("  <link rel='stylesheet' type='text/css' href='https://api.mapy.cz/css/api/v4/poi.css' />");
            htmlBuilder.AppendLine("  <link rel='stylesheet' type='text/css' href='https://api.mapy.cz/css/api/v4/suggest.css' />");
            htmlBuilder.AppendLine($"  <script type='text/javascript' src='{testJsDir}'></script>");
            htmlBuilder.AppendLine("  <script type='text/javascript' src='https://api.mapy.cz/config.js'></script>");
            htmlBuilder.AppendLine("  <script type='text/javascript' src='https://api.mapy.cz/js/api/v4/poi.js'></script>");
            htmlBuilder.AppendLine("  <script type='text/javascript' src='https://api.mapy.cz/js/api/v4/suggest.js'></script>");
            htmlBuilder.AppendLine("  <script type='text/javascript' src='https://api.mapy.cz/js/lang/cs.js'></script>");
            htmlBuilder.AppendLine("  <script type='text/javascript'>");
            htmlBuilder.AppendLine("    Loader.load(null, {suggest: true, poi: true});");
            htmlBuilder.AppendLine("  </script>");
            htmlBuilder.AppendLine("</head>");
            htmlBuilder.AppendLine("<body>");
            htmlBuilder.AppendLine("  <div id='mapa' style='width:600px;height:300px;'></div>");
            htmlBuilder.AppendLine("  <script>");
            htmlBuilder.AppendLine("    var stred = SMap.Coords.fromWGS84(16.54, 49.02);");
            htmlBuilder.AppendLine("    var mapa = new SMap(document.querySelector('#mapa'), stred, 7);");
            htmlBuilder.AppendLine("    mapa.addDefaultLayer(SMap.DEF_BASE).enable();");
            htmlBuilder.AppendLine("  </script>");
            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");

            string htmlString = htmlBuilder.ToString();


            //webBrowser1.ObjectForScripting = new MyLog();
            webBrowser1.DocumentText = htmlString;
            
            //chromiumBrowser.LoadHtml(htmlString);



        }
    }

    [ComVisible(true)]
    public class MyLog
    {
        public void log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
