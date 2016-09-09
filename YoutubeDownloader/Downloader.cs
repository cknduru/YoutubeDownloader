using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeExtractor;

namespace YoutubeDownloader
{
    static class Downloader
    {
        public static void Download(string urlRaw)
        {
            // todo: store location somewhere, folder on desktop for now
            string pathString = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), "test");
            System.IO.Directory.CreateDirectory(pathString);

            // get possible formats for download
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(urlRaw);

            // find an mp4 format
            VideoInfo video = videoInfos
            .First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);
            
            // download the video
            var videoDownloader = new VideoDownloader(video, Path.Combine(pathString, video.Title + video.VideoExtension));
            videoDownloader.Execute();

            // convert from mp4 to mp3 and delete original video

            int x = 2;



            //string fileName = urlRaw.Substring(urlRaw.IndexOf("v=") + 2) + ".mp3";
          /*  string url = "http://www.youtubeinmp3.com/fetch/?video=" + urlRaw;
            string fileName = getWebsiteTitle(urlRaw) + ".mp3";

            // download file
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            myHttpWebRequest.MaximumAutomaticRedirections = 10;
            myHttpWebRequest.AllowAutoRedirect = true;
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

            using (var responseStream = myHttpWebResponse.GetResponseStream()) 
            {
                using (var fileStream = new FileStream(pathString + @"\" + fileName, FileMode.Create)) 
                {
                    responseStream.CopyToAsync(fileStream);
                }
            }*/
        }
        
        public static string getWebsiteTitle(string url)
        {
            WebClient x = new WebClient();
            string source = x.DownloadString(url);

            return Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }

    }
}
