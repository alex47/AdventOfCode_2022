namespace AdventOfCode_2022.Day10;

internal class Puzzle1 : IPuzzle
{
    public static string PuzzleSolution()
    {
        var instructions = InputReader.ReadInputResourceAsStringList(Inputs.Day10);
        int signalStrengthSum = CalculateSignalStrengthSum(instructions);

        return signalStrengthSum.ToString();
    }

    private static int CalculateSignalStrengthSum(List<string> instructions)
    {
        int signalStrengthSum = 0;

        int registerValue = 1;
        int currentCycle = 0;

        foreach (string instruction in instructions)
        {
            var instructionType = Common.CalculateInstructionType(instruction);
            int instructionCycleCount = Common.CalculateInstructionCycleCount(instructionType);

            for (int i = 0; i < instructionCycleCount; i++)
            {
                currentCycle++;

                if ((currentCycle + 20) % 40 == 0)
                {
                    signalStrengthSum += currentCycle * registerValue;
                }
            }

            if (instructionType == Common.InstructionType.Addx)
            {
                int value = int.Parse(instruction.Split()[1]);
                registerValue += value;
            }
        }

        return signalStrengthSum;
    }
}
