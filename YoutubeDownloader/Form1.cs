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

        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // look for ctrl v
            if(e.Control && e.KeyCode == Keys.V)
            {
                // add dictionary to keep track of names and urls
                var url = new YoutubeUrl(Downloader.getWebsiteTitle(Clipboard.GetText()), Clipboard.GetText());
                _urls.Add(url.url);

                listBox1.DataSource = null;
                listBox1.DataSource = _urls;
            }
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            foreach (var url in listBox1.Items)
            {
                //Downloader.Download(url.ToString());
            }

            try
            {
                Downloader.Download(listBox1.Items[0].ToString());

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
