namespace GameBoySharp.Domain.Contracts
{
    public interface ISharp
    {
        short StackPointer { get; set; }

        short ProgramCounter { get; set; }
    }
}