namespace GameBoySharp.Domain.Contracts
{
    public interface IWriteableMemory
    {
        void WriteByte(ushort address, byte value, ushort offset = 0);

        // TODO: Extension method for WriteShort

        ushort WriteableFrom { get; }

        ushort WriteableTo { get; }
    }
}