namespace GameBoySharp.Domain.Contracts
{
    public interface IReadableMemory
    {
        byte ReadByte(ushort address, ushort offset = 0);
        
        ushort ReadableFrom { get; }

        ushort ReadableTo { get; }
    }
}