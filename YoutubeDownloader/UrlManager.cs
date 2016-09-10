using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    class UrlManager
    {
        List<YoutubeUrl> _urls;

        public UrlManager()
        {
            _urls = new List<YoutubeUrl>();
        }

        public string UrlFromTitle(string title)
        {
            return _urls.First(e => e.title == title).url;
        }
        
        public void AddUrl(YoutubeUrl url)
        {
            _urls.Add(url);
        }

        public bool isValidUrl(string url)
        {
            if (url.Contains("http://www.youtube.com") || url.Contains("https://www.youtube.com"))
            {
                return true;
            }

            return false;
        }
    }
}
