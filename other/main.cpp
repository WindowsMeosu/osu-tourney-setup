#include <iostream>
#include <filesystem>
#include <fstream>
#include <windows.h>
#include <shlwapi.h>

void CopyFile(const std::string& source, const std::string& target)
{
    std::ifstream src(source, std::ios::binary);
    std::ofstream dst(target, std::ios::binary);
    dst << src.rdbuf();
}

void CopyDir(const std::string& source, const std::string& target)
{
    std::string targetDir = target + "\\" + PathFindFileNameA(source.c_str());
    CreateDirectoryA(targetDir.c_str(), nullptr);

    std::string sourceDir = source + "\\*";
    WIN32_FIND_DATAA findData;
    HANDLE hFind = FindFirstFileA(sourceDir.c_str(), &findData);

    if (hFind != INVALID_HANDLE_VALUE)
    {
        do
        {
            if (findData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
            {
                if (strcmp(findData.cFileName, ".") != 0 && strcmp(findData.cFileName, "..") != 0)
                {
                    std::string subSource = source + "\\" + findData.cFileName;
                    std::string subTarget = targetDir + "\\" + findData.cFileName;
                    CopyDir(subSource, subTarget);
                }
            }
            else
            {
                std::string sourceFile = source + "\\" + findData.cFileName;
                std::string targetFile = targetDir + "\\" + findData.cFileName;
                std::cout << "Copying mappool directory contents. " << targetFile << std::endl;
                CopyFile(sourceFile, targetFile);
            }
        } while (FindNextFileA(hFind, &findData) != 0);

        FindClose(hFind);
    }
}

int main()
{
    std::string sourceDir = std::getenv("localappdata");
    sourceDir += "\\osu!\\mappool";
    std::string targetDir = std::getenv("localappdata");
    targetDir += "\\osu!tourney\\Songs";

    CopyDir(sourceDir, targetDir);

    std::cout << "Launching osu!tourney..." << std::endl;
    std::string osuExePath = std::getenv("localappdata");
    osuExePath += "\\osu!tourney\\osu!.exe";
    ShellExecuteA(NULL, "open", osuExePath.c_str(), NULL, NULL, SW_SHOWNORMAL);

    {
        std::string localcat = std::getenv("localappdata") + std::string("\\osu!tourney\\tournament.cfg");

    std::cout << "create tournament.cfg file? (y/n)" << std::endl;
    std::string response;
    std::cin >> response;

    if (response == "y")
    {
        std::ifstream file(localcat);
        if (!file)
        {
            std::ofstream ofs(localcat);
            if (ofs)
            {
                std::cout << "tournament config file has been created." << std::endl;
            }
            else
            {
                std::cout << "failed to create tournament.cfg." << std::endl;
            }
        }
    }
    else
    {
        std::cout << "acknowledged, will not create tournament.cfg." << std::endl;
    }

    std::cin.ignore();
    std::cin.get();
    return 0;
   }
}