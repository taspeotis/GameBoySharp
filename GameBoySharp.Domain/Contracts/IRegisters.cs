namespace GameBoySharp.Domain.Contracts
{
    public interface IRegisters
    {
        byte A { get; set; }

        // ReSharper disable once InconsistentNaming
        ushort AF { get; set; }

        byte B { get; set; }

        // ReSharper disable once InconsistentNaming
        ushort BC { get; set; }

        byte C { get; set; }

        byte D { get; set; }

        // ReSharper disable once InconsistentNaming
        ushort DE { get; set; }

        byte E { get; set; }

        byte F { get; set; }

        byte H { get; set; }

        // ReSharper disable once InconsistentNaming
        ushort HL { get; set; }

        byte L { get; set; }

        // ReSharper disable once InconsistentNaming
        ushort PC { get; set; }

        // ReSharper disable once InconsistentNaming
        ushort SP { get; set; }
    }
}