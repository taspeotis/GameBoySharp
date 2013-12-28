namespace GameBoySharp.Domain.Contracts
{
    public interface IReadableMemory
    {
        byte ReadByte(short address);
        
        short ReadableFrom { get; }

        short ReadableTo { get; }
    }
}