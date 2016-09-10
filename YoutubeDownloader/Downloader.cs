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
        public static void Download(string urlRaw, bool audioOnly)
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
            string videoPath = Path.Combine(pathString, video.Title + video.VideoExtension);
            var videoDownloader = new VideoDownloader(video, videoPath);
            videoDownloader.Execute();

            // if only audio is wanted, convert to mp3 using ffmpeg
            if(audioOnly)
            {
                AudioConverter.toMp3(videoPath);
            }
        }
        
        public static string getWebsiteTitle(string url)
        {
            WebClient x = new WebClient();
            string source = x.DownloadString(url);

            return Regex.Match(source, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
        }
    }
}
