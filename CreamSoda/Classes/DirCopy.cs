using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CreamSoda
{
    class DirCopy
    {
        public static bool Kill = false;
        private long m_FileCount = 0;
        private long m_FilesDone = 0;
        private bool m_Active = false;
        private string m_SourceDirName;
        private string m_DestDirName;
        private bool m_copySubDirs = true;

        public bool Active
        {
            get { return m_Active; }
        }
        public int Progress
        {
            get {
                return MyToolkit.MinMax((int)((float)m_FilesDone / (float)m_FileCount * 100f), 0, 100); 
            }
        }

        public DirCopy(string SourceDirName, string DestDirName) {
            m_SourceDirName = SourceDirName;
            m_DestDirName = DestDirName;
        }

        public string sourceDirName {
            get { return m_SourceDirName; }
        }

        public string destDirName {
            get { return m_DestDirName; }
        }

        public bool copySubDirs {
            get { return m_copySubDirs; }
        }

        public void DirectoryCopy()
        {
            m_Active = true;
            m_FileCount = DirectoryCount(sourceDirName);
            DirectoryCopyStep(sourceDirName, destDirName, copySubDirs);
            m_Active = false;
        }

        public void DirectoryCopyNoReplace()
        {
            m_Active = true;
            m_FileCount = DirectoryCount(sourceDirName);
            DirectoryCopyStep(sourceDirName, destDirName, copySubDirs, false);
            m_Active = false;
        }

        private void DirectoryCopyStep(string sourceDirName, string destDirName, bool copySubDirs = true, bool replace = true)
        {
            try{
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }

                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (Kill) return;
                    string temppath = Path.Combine(destDirName, file.Name);

                    if (File.Exists(temppath) && replace) {
                        File.SetAttributes(temppath, File.GetAttributes(temppath) & ~FileAttributes.ReadOnly);
                        File.Delete(temppath);
                    }

                    try { file.CopyTo(temppath, true); }
                    catch (Exception) { }
                
                    m_FilesDone += file.Length;
                }

                if (copySubDirs) {
                    foreach (DirectoryInfo subdir in dirs) {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopyStep(subdir.FullName, temppath, copySubDirs);
                    }
                }
            
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, "DirCopy.DirectoryCopyStep");
            }
        }

        private long DirectoryCount(string sourceDirName)
        {
            long count = 0;
            try {

                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo file in files) {
                    if (Kill) return 0;
                    try { count += file.Length; }
                    catch (Exception) { }
                }

                foreach (DirectoryInfo subdir in dirs) {
                    count += DirectoryCount(subdir.FullName);
                }
            
            } catch (Exception ex) {
                MyToolkit.ErrorReporter(ex, "DirCopy.DirectoryCopyStep");
            }
            return count;
        }

    }
}
