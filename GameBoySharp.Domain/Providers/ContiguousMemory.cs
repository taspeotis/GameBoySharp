using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using GameBoySharp.Domain.Contracts;

namespace GameBoySharp.Domain.Providers
{
    [Export(typeof (IContiguousMemory)), Shared]
    internal sealed class ContiguousMemory : IContiguousMemory
    {
        private readonly IList<IReadableMemory> _readableMemories;

        private readonly IList<IWriteableMemory> _writeableMemories;

        [ImportingConstructor]
        public ContiguousMemory(
            IEnumerable<IReadableMemory> readableMemories,
            IEnumerable<IWriteableMemory> writeableMemories)
        {
            _readableMemories = readableMemories.ToList();
            _writeableMemories = writeableMemories.ToList();
        }

        public byte ReadByte(short address)
        {
            var readableMemory = _readableMemories.FirstOrDefault(
                rm => rm.ReadableFrom >= address && address < rm.ReadableTo);

            if (readableMemory == null)
                throw new ArgumentOutOfRangeException("address");

            return readableMemory.ReadByte(address);
        }

        public short ReadableFrom
        {
            get { return _readableMemories.Min(rm => rm.ReadableFrom); }
        }

        public short ReadableTo
        {
            get { return _readableMemories.Max(rm => rm.ReadableTo); }
        }

        public void WriteByte(short address, byte value)
        {
            var writeableMemory = _writeableMemories.FirstOrDefault(
                wm => wm.WriteableFrom >= address && address < wm.WriteableTo);

            if (writeableMemory == null)
                throw new ArgumentOutOfRangeException("address");

            writeableMemory.WriteByte(address, value);
        }

        public short WriteableFrom
        {
            get { return _writeableMemories.Min(wm => wm.WriteableFrom); }
        }

        public short WriteableTo
        {
            get { return _writeableMemories.Max(wm => wm.WriteableTo); }
        }
    }
}