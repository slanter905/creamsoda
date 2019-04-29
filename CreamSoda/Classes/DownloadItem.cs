using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace CreamSoda
{
    class DownloadItem
    {
        private ArrayList m_urls;
        private string m_filePath;

        public DownloadItem(ArrayList URL, string filePath)
        {
            m_urls = URL;
            m_filePath = MyToolkit.ValidPath(filePath);
        }

        public ArrayList URLs
        {
            get { return m_urls; }
            set { m_urls = URLs; }
        }
        public string FilePath {
            get { return m_filePath; }
            set { m_filePath = MyToolkit.ValidPath(FilePath); }
        }

    }
}
