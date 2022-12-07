namespace AdventOfCode_2022.Day7;

internal class Puzzle2 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var commandsAndOutputs = InputReader.ReadInputResourceAsStringList(Inputs.Day7);

        var rootDirectory = Common.BuildFileSystem(commandsAndOutputs);
        Common.CalculateDirectorySizes(rootDirectory);

        const int diskSize = 70000000;
        const int requiredSpace = 30000000;

        int freeSpace = diskSize - rootDirectory.Size;
        int additionalRequiredSpace = requiredSpace - freeSpace;

        int bestSize = rootDirectory.Size;
        CalculateClosestRequiredDirectorySize(rootDirectory, additionalRequiredSpace, ref bestSize);

        return bestSize.ToString();
    }

    private static void CalculateClosestRequiredDirectorySize(Common.Directory directory, int idealSize, ref int bestSize)
    {
        // We have to introduce a local variable here because of this error:
        // "Cannot use ref, out, or in parameter 'bestSize' inside an anonymous method, lambda expression, query expression, or local function"
        int bestSize_local = bestSize;

        bestSize = directory.SubDirectories
            .Select(dir => dir.Size)
            .Where(size => idealSize <= size && size < bestSize_local)
            .DefaultIfEmpty(bestSize)
            .Min();

        foreach (var subDirectory in directory.SubDirectories)
        {
            CalculateClosestRequiredDirectorySize(subDirectory, idealSize, ref bestSize);
        }
    }
}
