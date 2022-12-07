using System.Net.Sockets;

namespace AdventOfCode_2022.Day7;

internal class Common
{
    public class Directory
    {
        public string Name = string.Empty;
        public Directory? ParentDirectory;
        public List<Directory> SubDirectories = new();
        public List<File> Files = new();
        public int Size = 0;
    }

    public class File
    {
        public string Name = string.Empty;
        public int Size = 0;
    }

    public static Directory BuildFileSystem(List<string> commandsAndOutputs)
    {
        var rootDirectory = new Directory()
        {
            Name = "/",
            ParentDirectory = null
        };

        var currentDirectory = rootDirectory;

        foreach (string line in commandsAndOutputs)
        {
            // Change directory
            if (line.StartsWith("$ cd"))
            {
                string nextDirectoryName = line.Replace("$ cd ", "");

                currentDirectory = nextDirectoryName switch
                {
                    "/" => rootDirectory,
                    ".." => currentDirectory.ParentDirectory,
                    _ => currentDirectory.SubDirectories.First(dir => dir.Name == nextDirectoryName),
                };
            }

            // List files and subdirectories
            else if (line == "$ ls")
            {
                // The ls command will always be used with the current directory
                // We can skip this safely
            }

            // Shows directory
            else if (line.StartsWith("dir "))
            {
                var subDirectory = new Directory()
                {
                    Name = line.Replace("dir ", ""),
                    ParentDirectory = currentDirectory
                };

                currentDirectory.SubDirectories.Add(subDirectory);
            }

            // Shows file
            else
            {
                // File names don't contain spaces so we can split safely
                var fileData = line.Split();

                var file = new File()
                {
                    Name = fileData[1],
                    Size = int.Parse(fileData[0])
                };

                currentDirectory.Files.Add(file);
            }
        }

        return rootDirectory;
    }

    public static void CalculateDirectorySizes(Directory directory)
    {
        directory.SubDirectories.ForEach(CalculateDirectorySizes);
        directory.Size = directory.SubDirectories.Sum(dir => dir.Size) + directory.Files.Sum(file => file.Size);
    }
}
