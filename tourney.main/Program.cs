using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace osu_tourney_setup;

class osucopy
{
    public static void CopyDir(DirectoryInfo sdir, DirectoryInfo tdir)
  {
        if (sdir.FullName.ToLower() == tdir.FullName.ToLower())
        {
            return;
        }

        foreach (FileInfo finf in sdir.GetFiles())
        {    
            Console.WriteLine(@"Copying mappool directory contents. {0}\{1}", tdir.FullName, finf.Name);
            finf.CopyTo(Path.Combine(tdir.ToString(), finf.Name), true);
        
        }

        // Uses recursion for subs.
        foreach (DirectoryInfo subdir in sdir.GetDirectories())
        {
            DirectoryInfo subtdir =
                tdir.CreateSubdirectory(subdir.Name);
            CopyDir(subdir, subtdir);
        }
    }

    public static void Main()
     
    {    
        string scat = Environment.ExpandEnvironmentVariables("%localAppData%\\osu!/mappool");
        string tcat = Environment.ExpandEnvironmentVariables("%localAppData%\\osu!tourney/Songs");
        DirectoryInfo sourcedir = new(scat);
        DirectoryInfo targetdir = new(tcat);

        CopyDir(sourcedir, targetdir);
    {
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\osu!tourney\osu!.exe";
        Process.Start(filePath);
    }
    }
}
