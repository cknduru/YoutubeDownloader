using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeDownloader
{
    static class AudioConverter
    {
        public static void toMp3(string videoPath)
        {
            string _out = "";
            Process _process = new Process();

            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.RedirectStandardInput = true;
            _process.StartInfo.RedirectStandardOutput = true;
            _process.StartInfo.RedirectStandardError = true;
            _process.StartInfo.CreateNoWindow = true;
            _process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _process.StartInfo.FileName = "ffmpeg";
            _process.StartInfo.Arguments = string.Format(" -i \"{0}\" -vn -f mp3 -ab 192k \"{1}\"", videoPath, videoPath.Replace(".mp4", ".mp3"));
            System.Windows.Forms.MessageBox.Show(_process.StartInfo.Arguments);
            _process.Start();
            _process.StandardOutput.ReadToEnd();
            _out = _process.StandardError.ReadToEnd();
            _process.WaitForExit();

            if(!_process.HasExited)
            {
                _process.Kill();
            }

            /* use this for error handling at a later time
            return _out;
            */
        }
    }
}
