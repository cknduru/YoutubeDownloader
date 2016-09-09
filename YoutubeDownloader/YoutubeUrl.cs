using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    class YoutubeUrl
    {
        public string title { get; set; }
        public string url { get; set; }

        public YoutubeUrl(string urlTitle, string urlAddress)
        {
            title = urlTitle;
            url = urlAddress;
        }
    }
}
