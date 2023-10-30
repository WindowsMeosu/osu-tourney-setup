using System;
using System.IO;

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
        DirectoryInfo sourcedir = new DirectoryInfo(scat);
        DirectoryInfo targetdir = new DirectoryInfo(tcat);

        CopyDir(sourcedir, targetdir);
    }

 }