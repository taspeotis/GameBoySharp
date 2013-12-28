using System;
using System.Composition;
using GameBoySharp.Domain.Contracts;

namespace GameBoySharp.Domain.Providers
{
    [Export(typeof (IFlagRegister)), Shared]
    internal sealed class FlagRegister : IFlagRegister
    {
        private readonly IRegisters _registers;

        [ImportingConstructor]
        public FlagRegister(IRegisters registers)
        {
            _registers = registers;
        }

        private FlagRegisterFlag FlagRegisterFlags
        {
            get { return (FlagRegisterFlag) _registers.F; }
            set { _registers.F = (byte) value; }
        }

        public bool Carry
        {
            get { return GetFlag(FlagRegisterFlag.Carry); }
            set { SetFlag(FlagRegisterFlag.Carry, value); }
        }

        public bool HalfCarry
        {
            get { return GetFlag(FlagRegisterFlag.HalfCarry); }
            set { SetFlag(FlagRegisterFlag.Carry, value); }
        }

        public bool Subtract
        {
            get { return GetFlag(FlagRegisterFlag.Subtract); }
            set { SetFlag(FlagRegisterFlag.Subtract, value); }
        }

        public bool Zero
        {
            get { return GetFlag(FlagRegisterFlag.Zero); }
            set { SetFlag(FlagRegisterFlag.Zero, value); }
        }

        private bool GetFlag(FlagRegisterFlag flagRegisterFlag)
        {
            return FlagRegisterFlags.HasFlag(flagRegisterFlag);
        }

        private void SetFlag(FlagRegisterFlag flagRegisterFlag, bool value)
        {
            FlagRegisterFlags = value
                ? FlagRegisterFlags | flagRegisterFlag
                : FlagRegisterFlags & ~flagRegisterFlag;
        }

        [Flags]
        private enum FlagRegisterFlag : byte
        {
            Carry = 1 << 4,
            HalfCarry = 1 << 5,
            Subtract = 1 << 6,
            Zero = 1 << 7
        }
    }
}