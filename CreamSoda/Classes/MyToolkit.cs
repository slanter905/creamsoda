using System;
using System.IO;

class MyToolkit
{

    public static string[] args;

    public static string AllArgs() { 
        string strArgs = "";

        foreach (string arg in args) {
            strArgs += arg + " ";
        }

        return strArgs.Trim();
    }

    /// <summary>
    /// Static function to make sure dashes are appropiate for the specific OS. 
    /// Make sure all paths are absolute, windows paths must contain the drive name at the start for this to work.
    /// </summary>
    /// <param name="Path">File path to validate</param>
    /// <returns></returns>
    public static string ValidPath(string Path) {
        if (Path.Contains(":\\"))
        {
            // Make sure the file name has propper direction slashes for Windows
            Path = Path.Replace("/", "\\");
        } else {
            // Make sure the file name has propper direction slashes for OSX
            Path = Path.Replace("\\", "/");
        }

        return Path;
    }

    public static int MinMax(int Val, int Min, int Max) {
        if (Val > Max) return Max;
        else if (Val < Min) return Min;
        else return Val;
    }

    /// <summary>
    /// Determines if the directorty where path will allow us to read and write. 
    /// </summary>
    /// <param name="path">Install directory path</param>
    /// <returns>False if we cant write to the path.</returns>
    public static bool InstallDirSafe(string path) {
        try {
            File.Move(Path.Combine(path, "CreamSoda.exe"), Path.Combine(path, "CreamSoda_rename.exe"));
            if (File.Exists(Path.Combine(path, "CreamSoda_rename.exe")))
            {
                File.Move(Path.Combine(path, "CreamSoda_rename.exe"), Path.Combine(path, "CreamSoda.exe"));
                return true;
            } else {
                return false;
            }
        } catch (Exception)
        {
            return false;
        } 
    }

    public static bool CreateShortcut(string LinkPathName, string TargetPathName)
    {
        return true;
    }

    public static void ErrorReporter(Exception ex, string source) {
        System.Windows.Forms.MessageBox.Show(ex.Message, source);
    }


    public static void ActivityLog(string Line) {
        try
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(CreamSoda.Settings.GamePath, "CreamSodaActivityLog.txt"), true))
            {
                writer.WriteLine("[" + DateTime.Now.ToString() + "]\t" + Line);
            }
        }
        catch (Exception)
        {

        }
    }


}