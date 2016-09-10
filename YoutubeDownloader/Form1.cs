using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeDownloader
{
    public partial class Form1 : Form
    {
        List<string> _urls = new List<string>();
        UrlManager _urlManager = new UrlManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string clipboardUrl = Clipboard.GetText();

            // look for ctrl v
            if (e.Control && e.KeyCode == Keys.V)// && _urlManager.isValidUrl(clipboardUrl))
            {
                e.SuppressKeyPress = false;

                // add dictionary to keep track of names and urls
                var url = new YoutubeUrl(Downloader.getWebsiteTitle(Clipboard.GetText()), clipboardUrl);
                _urlManager.AddUrl(url);

                // only add urls not already in the list
                if(!_urls.Contains(clipboardUrl))
                {
                    _urls.Add(url.title);

                    listBox1.DataSource = null;
                    listBox1.DataSource = _urls;
                }
            }
            else
            {
                e.SuppressKeyPress = true;
                //MessageBox.Show(string.Format("Url: {0} not valid", clipboardUrl));
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var title in listBox1.Items)
                {
                    Downloader.Download(_urlManager.UrlFromTitle(title.ToString()), checkBoxAudioOnly.Checked);
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
