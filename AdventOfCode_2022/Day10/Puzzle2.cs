using System.Text;

namespace AdventOfCode_2022.Day10;

internal class Puzzle2 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var instructions = InputReader.ReadInputResourceAsStringList(Inputs.Day10);
        var image = CalculateImage(instructions);

        return image;
    }

    private static string CalculateImage(List<string> instructions)
    {
        int registerValue = 1;
        int currentCycle = 0;
        
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Environment.NewLine);

        foreach (string instruction in instructions)
        {
            var instructionType = Common.CalculateInstructionType(instruction);
            int instructionCycleCount = Common.CalculateInstructionCycleCount(instructionType);

            for (int i = 0; i < instructionCycleCount; i++)
            {
                int currentPixel = currentCycle % 40;
                currentCycle++;

                // The sprite is near the current pixel
                if (registerValue - 1 <= currentPixel && currentPixel <= registerValue + 1)
                {
                    stringBuilder.Append('#');
                }

                // The sprite is somewhere else
                else
                {
                    stringBuilder.Append('.');
                }

                // Reached end of the line
                if (currentCycle % 40 == 0)
                {
                    stringBuilder.Append(Environment.NewLine);
                }
            }

            if (instructionType == Common.InstructionType.Addx)
            {
                int value = int.Parse(instruction.Split()[1]);
                registerValue += value;
            }
        }

        return stringBuilder.ToString();
    }
}
