using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode_2022.Day5;

internal class Common
{
    public struct Instruction
    {
        public int Count;
        public int SourceIndex;
        public int TargetIndex;
    }

    public static List<Stack<char>> ParseStacks(List<string> stacksAndInstructions)
    {
        var stacks = new List<Stack<char>>();
        int stackCount = (stacksAndInstructions[0].Length + 1) / 4;

        for (int i = 0; i < stackCount; i++)
        {
            stacks.Add(new Stack<char>());
        }

        int firstEmptyLineIndex = stacksAndInstructions.FindIndex(string.IsNullOrWhiteSpace);
        var stacksDescription = stacksAndInstructions.GetRange(0, firstEmptyLineIndex);

        for (int i = stacksDescription.Count - 2; 0 <= i; i--)
        {
            for (int j = 0; j < stackCount; j++)
            {
                int letterIndex = 1 + j * 4;
                char letter = stacksDescription[i][letterIndex];

                if (letter != ' ')
                {
                    stacks[j].Push(letter);

                }
            }
        }

        return stacks;
    }

    public static List<Instruction> ParseInstructions(List<string> stacksAndInstructions)
    {
        var instructions = new List<Instruction>();

        int firstEmptyLineIndex = stacksAndInstructions.FindIndex(string.IsNullOrWhiteSpace);
        var instructionsDescriptions = stacksAndInstructions.GetRange(firstEmptyLineIndex + 1, stacksAndInstructions.Count - (firstEmptyLineIndex + 1));

        var regex = new Regex(@"\d+");

        foreach (var instructionsDescription in instructionsDescriptions)
        {
            var matches = regex.Matches(instructionsDescription);

            var instruction = new Instruction()
            {
                Count = int.Parse(matches[0].Value),
                SourceIndex = int.Parse(matches[1].Value),
                TargetIndex = int.Parse(matches[2].Value)
            };

            instructions.Add(instruction);
        }

        return instructions;
    }

    public static string GetTopLetterOfStacks(List<Stack<char>> stacks)
    {
        var stringBuilder = new StringBuilder();

        foreach (var stack in stacks)
        {
            stringBuilder.Append(stack.Peek());
        }

        return stringBuilder.ToString();
    }
}
