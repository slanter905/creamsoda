using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net;

namespace CreamSoda
{
    class HTTP
    {
        WebClient m_client;

        public HTTP() {
            m_client = new WebClient();
        }

        public bool StartDownload(AsyncCompletedEventHandler dlFinishedCallback,
                                    DownloadProgressChangedEventHandler dlProgressCallback,
                                    string URL,
                                    string SavePath){

            Uri uri;
            try
            {
                uri = new Uri(URL);
            }
            catch (Exception)
            {
                return false;
            }
            m_client.DownloadFileCompleted += dlFinishedCallback;
            m_client.DownloadProgressChanged += dlProgressCallback;

            int chrindex = SavePath.LastIndexOf(@"/");
            if (chrindex == -1) chrindex = SavePath.LastIndexOf(@"\");

            string Path = SavePath.Substring(0, chrindex);
            System.IO.Directory.CreateDirectory(Path);
            
            m_client.DownloadFileAsync(uri,MyToolkit.ValidPath(SavePath));

            return true;
        }

        public void CancelDownload() {
            m_client.CancelAsync();
        }

        public bool Active {
            get { return m_client.IsBusy; }
        }

        public long Length {
            get
            {
                try
                {
                    return Convert.ToInt64(m_client.ResponseHeaders["Content-Length"]);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}
