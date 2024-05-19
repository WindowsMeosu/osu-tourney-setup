using System;
using System.IO;
using System.Diagnostics;

namespace debug
{
    class osucopydb
    {
        public static void CopyDir(DirectoryInfo sdir, DirectoryInfo tdir)
        {
            if (sdir.FullName.ToLower() == tdir.FullName.ToLower())
            {
                return;
            }

            foreach (FileInfo finf in sdir.GetFiles())
            {
                try
                {
                    Console.WriteLine(@"Copying mappool directory contents. {0}\{1}", tdir.FullName, finf.Name);
                    finf.CopyTo(Path.Combine(tdir.ToString(), finf.Name), true);
                }
                catch (Exception err)
                {
                    Console.WriteLine("failed: " + err.Message);
                }
            }

            foreach (DirectoryInfo subdir in sdir.GetDirectories())
            {
                DirectoryInfo subtdir = tdir.CreateSubdirectory(subdir.Name);
                CopyDir(subdir, subtdir);
            }
        }

        public static void Main()
        {
            try
            {
                string scat = Environment.ExpandEnvironmentVariables("%localAppData%\\osu!/mappool");
                string tcat = Environment.ExpandEnvironmentVariables("%localAppData%\\osu!tourneydb/Songs");
                DirectoryInfo sourcedir = new DirectoryInfo(scat);
                DirectoryInfo targetdir = new DirectoryInfo(tcat);

                CopyDir(sourcedir, targetdir);

                string localcat = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"osu!tourneydb/tournament.cfg");

                Console.WriteLine("Create tournament.cfg file? (y/n)");
                string response = Console.ReadLine();

                if (response.ToLower() == "y")
                {
                    if (!File.Exists(localcat))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(localcat));

                        using (FileStream fs = File.Create(localcat))
                        {
                            if (File.Exists(localcat))
                            {
                                Console.WriteLine("tournament config file has been created.");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("acknowledged, will not create tournament.cfg.");
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("failed: " + err.Message);
            }

            Console.ReadLine();
        }
    }
}