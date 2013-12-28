namespace GameBoySharp.Domain.Contracts
{
    public interface IFlagRegister
    {
        bool Carry { get; set; }

        bool HalfCarry { get; set; }

        bool Subtract { get; set; }

        bool Zero { get; set; }
    }
}