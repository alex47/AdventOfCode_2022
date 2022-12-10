namespace AdventOfCode_2022.Day10;

internal class Common
{
    public enum InstructionType
    {
        Noop,
        Addx
    }

    public static InstructionType CalculateInstructionType(string instruction)
    {
        return instruction.StartsWith("noop") ? InstructionType.Noop : InstructionType.Addx;
    }

    public static int CalculateInstructionCycleCount(InstructionType instructionType)
    {
        return instructionType switch
        {
            InstructionType.Noop => 1,
            InstructionType.Addx => 2,
            _ => throw new Exception("This should never happen"),
        };
    }
}
