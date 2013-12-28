using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using GameBoySharp.Domain.Contracts;

namespace GameBoySharp.Domain.Providers
{
    [Export(typeof(ISharp))]
    internal sealed class Sharp : ISharp
    {
        private readonly IContiguousMemory _contiguousMemory;
        private readonly IList<IInstruction> _instructions;
        private readonly IRegisters _registers;

        [ImportingConstructor]
        public Sharp(
            IContiguousMemory contiguousMemory,
            [ImportMany] IEnumerable<IInstructions> instructions,
            IRegisters registers)
        {
            _contiguousMemory = contiguousMemory;

            _instructions = instructions
                .SelectMany(i => i.GetInstructions())
                .OrderBy(i => i.OperationCode.Count)
                .ToList();

            _registers = registers;
        }

        public void ExecuteOperation()
        {
            var operationCode = new List<byte>(4);

            foreach (var instruction in _instructions)
            {
                var instructionOperationCode = instruction.OperationCode;

                while (operationCode.Count < instructionOperationCode.Count)
                    operationCode.Add(_contiguousMemory.ReadByte(_registers.PC, (ushort) operationCode.Count));

                if (operationCode.SequenceEqual(instructionOperationCode))
                {
                    _registers.PC =
                        instruction.Execute(_contiguousMemory, _registers)
                        ?? (ushort) (_registers.PC + instruction.OperationCode.Count + instruction.ImmediateSize);

                    return;
                }
            }

            throw new NotImplementedException();
        }
    }
}
