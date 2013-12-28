using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using GameBoySharp.Domain.Contracts;
using GameBoySharp.Domain.Extensions;
using GameBoySharp.Domain.Infrastructure;

namespace GameBoySharp.Domain.Providers
{
    [Export(typeof (IInstructions))]
    internal sealed class LoadUInt16Instructions : IInstructions
    {
        public IEnumerable<IInstruction> GetInstructions()
        {
            yield return new LoadUInt16Instruction(0x01, (r, nn) => r.BC = nn);
            yield return new LoadUInt16Instruction(0x11, (r, nn) => r.DE = nn);
            yield return new LoadUInt16Instruction(0x21, (r, nn) => r.HL = nn);
            yield return new LoadUInt16Instruction(0x31, (r, nn) => r.SP = nn);
        }

        internal class LoadUInt16Instruction : Instruction
        {
            private readonly Action<IRegisters, ushort> _loadAction;

            public LoadUInt16Instruction(byte operationCode, Action<IRegisters, ushort> loadAction)
                : base(12, 2, new[] {operationCode})
            {
                _loadAction = loadAction;
            }

            public override ushort? Execute(IContiguousMemory contiguousMemory, IRegisters registers)
            {
                var immediateValue = contiguousMemory.ReadUInt16(registers.PC, 1);

                _loadAction(registers, immediateValue);

                return null;
            }
        }
    }
}