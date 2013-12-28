using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using GameBoySharp.Domain.Contracts;

namespace GameBoySharp.Domain.Providers
{
    [Export(typeof (IContiguousMemory))]
    internal sealed class ContiguousMemory : IContiguousMemory
    {
        private readonly IList<IReadableMemory> _readableMemories;

        private readonly IList<IWriteableMemory> _writeableMemories;

        [ImportingConstructor]
        public ContiguousMemory(
            [ImportMany] IEnumerable<IReadableMemory> readableMemories,
            [ImportMany] IEnumerable<IWriteableMemory> writeableMemories)
        {
            _readableMemories = readableMemories.ToList();
            _writeableMemories = writeableMemories.ToList();
        }

        public byte ReadByte(ushort address, ushort offset)
        {
            address += offset;

            var readableMemory = _readableMemories.FirstOrDefault(
                rm => address >= rm.ReadableFrom && address < rm.ReadableTo);

            if (readableMemory == null)
                throw new ArgumentOutOfRangeException("address");

            return readableMemory.ReadByte(address);
        }

        public ushort ReadableFrom
        {
            get { return _readableMemories.Min(rm => rm.ReadableFrom); }
        }

        public ushort ReadableTo
        {
            get { return _readableMemories.Max(rm => rm.ReadableTo); }
        }

        public void WriteByte(ushort address, byte value, ushort offset)
        {
            address += offset;

            var writeableMemory = _writeableMemories.FirstOrDefault(
                wm => address >= wm.WriteableFrom && address < wm.WriteableTo);

            if (writeableMemory == null)
                throw new ArgumentOutOfRangeException("address");

            writeableMemory.WriteByte(address, value);
        }

        public ushort WriteableFrom
        {
            get { return _writeableMemories.Min(wm => wm.WriteableFrom); }
        }

        public ushort WriteableTo
        {
            get { return _writeableMemories.Max(wm => wm.WriteableTo); }
        }
    }
}