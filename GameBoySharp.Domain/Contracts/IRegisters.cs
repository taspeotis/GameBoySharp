namespace GameBoySharp.Domain.Contracts
{
    public interface IRegisters
    {
        byte A { get; set; }

        // ReSharper disable once InconsistentNaming
        short AF { get; set; }

        byte B { get; set; }

        // ReSharper disable once InconsistentNaming
        short BC { get; set; }

        byte C { get; set; }

        byte D { get; set; }

        // ReSharper disable once InconsistentNaming
        short DE { get; set; }

        byte E { get; set; }

        byte F { get; set; }

        byte H { get; set; }

        // ReSharper disable once InconsistentNaming
        short HL { get; set; }

        byte L { get; set; }

        // ReSharper disable once InconsistentNaming
        short PC { get; set; }

        // ReSharper disable once InconsistentNaming
        short SP { get; set; }
    }
}