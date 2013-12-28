using GameBoySharp.Domain.Contracts;

namespace GameBoySharp.Domain.Extensions
{
    public static class ExtensionsIReadableMemory
    {
        public static ushort ReadUInt16(this IReadableMemory readableMemory, ushort address, ushort offset = 0)
        {
            address += offset;

            var firstByte = readableMemory.ReadByte(address);
            var secondByte = readableMemory.ReadByte(address, 1);

            return (ushort) (firstByte | secondByte << 8);
        }
    }
}