using System.Collections.Generic;

namespace GameBoySharp.Domain.Contracts
{
    public interface IInstruction
    {
        byte Cycles { get; }

        byte ImmediateSize { get; }

        IReadOnlyCollection<byte> OperationCode { get; }

        ushort? Execute(IContiguousMemory contiguousMemory, IRegisters registers);
    }
}