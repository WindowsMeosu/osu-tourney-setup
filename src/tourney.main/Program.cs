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
        // reminder to myself/todo: eventually make sure this is done before opening osu!. I have no fucking idea why that isn't already the case
        string localcat = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"osu!tourney/tournament.cfg");

        Console.WriteLine("create tournament.cfg file? (y/n)");
        string response = Console.ReadLine();

        if (response.ToLower() == "y")
        {
            try
            {
                // checks if tournament.cfg already exists otherwise don't create/overwrite.

                if (!File.Exists(localcat))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(localcat));

                    System.IO.FileStream fs = System.IO.File.Create(localcat);
                    if (File.Exists(localcat))
                    {
                        Console.WriteLine("tournament config file has been created.");
                    }
                }
            }
            catch
            // todo: add exception
            {
                Console.WriteLine("failed to create tournament.cfg.");
            }
        }
        else
        {
            Console.WriteLine("acknowledged, will not create tournament.cfg.");
        }

        Console.ReadLine();
    }
}
// this is going to become disorganized fast