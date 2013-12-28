using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameBoySharp.Domain.Contracts;

namespace GameBoySharp.Domain.Infrastructure
{
    public abstract class Instruction : IInstruction
    {
        protected Instruction(byte cycles, byte immediateSize, IList<byte> operationCode)
        {
            Cycles = cycles;
            ImmediateSize = immediateSize;
            OperationCode = new ReadOnlyCollection<byte>(operationCode);
        }

        public byte Cycles { get; private set; }

        public byte ImmediateSize { get; private set; }

        public IReadOnlyCollection<byte> OperationCode { get; private set; }

        public abstract ushort? Execute(IContiguousMemory contiguousMemory, IRegisters registers);
    }
}