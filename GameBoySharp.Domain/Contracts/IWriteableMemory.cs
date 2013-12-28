namespace GameBoySharp.Domain.Contracts
{
    public interface IWriteableMemory
    {
        void WriteByte(short address, byte value);

        // TODO: Extension method for WriteShort

        short WriteableFrom { get; }

        short WriteableTo { get; }
    }
}