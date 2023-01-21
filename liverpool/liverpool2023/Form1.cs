using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace liverpool2023
{
    public partial class Form1 : Form
    {
        int contador = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async Task inizated()
        {
            await webView21.EnsureCoreWebView2Async(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadWeb();
        }

        public async void loadWeb()
        {
            await inizated();
            contador++;
            String url = "https://www.liverpool.com.mx/tienda/page-" + contador + "?s=celular";
            textBox1.Text= url;
            webView21.CoreWebView2.Navigate(url);
        }

        private void webView21_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            String line = e.TryGetWebMessageAsString().ToString();
            richTextBox1.Text= line;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String cadena = ""
            + "var aux = '';"
            + "var line = '{\"x\": [';"
            + "var y = document.getElementsByClassName('m-product__listingPlp')[0].getElementsByClassName('m-product__card');"
            + "for (var i = 0;i < y.length; i++) {"
            + "    var x = document.getElementsByClassName('m-product__listingPlp')[0].getElementsByClassName('m-product__card')[i];"
            + "    var img = x.querySelector('[loading=\"lazy\"]');"
            + "    var title = x.querySelector('[class=\"card-title a-card-description\"]');"
            + "    var precio = x.querySelector('[class=\"a-card-price\"]');"
            + "    var precio2 = x.querySelector('[class=\"a-card-discount\"]');"
            + "    if (i != 0) {"
            + "        aux = ' ,';"
            + "    }"
            + "    try {"
            + "        line += aux + '{\"tile\": \"' + title.textContent + '\",\"img\": \"' + img.src.toString() + '\",\"precio\": \"' + precio.textContent + '\",\"precio2\": \"' + "
            + "        precio2.textContent + '\"}';"
            + "    } catch (error) {"
            + "        line += aux + '{\"tile\": \"' + title.textContent + '\",\"img\": \"' + img.src.toString() + '\",\"precio\": \"' + 0 + '\",\"precio2\": \"' + "
            + "        precio2.textContent + '\"}'; "
            + "    }"
            + "}"
            + "line += ']}';"
            + "window.chrome.webview.postMessage(line);";

            webView21.CoreWebView2.ExecuteScriptAsync(cadena);
        }
    }
}
