namespace AdventOfCode_2022.Day5;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var stacksAndInstructions = InputReader.ReadInputResourceAsStringListIncludedEmptyRows(Inputs.Day5);
        var stacks = Common.ParseStacks(stacksAndInstructions);
        var instructions = Common.ParseInstructions(stacksAndInstructions);

        PerformInstructions(stacks, instructions);

        string topLetters = Common.GetTopLetterOfStacks(stacks);

        return topLetters;
    }

    private static void PerformInstructions(List<Stack<char>> stacks, List<Common.Instruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            for (int i = 0; i < instruction.Count; i++) 
            {
                char letter = stacks[instruction.SourceIndex - 1].Pop();
                stacks[instruction.TargetIndex - 1].Push(letter);
            }
        }
    }
}
