using System.ComponentModel.Composition;
using GameBoySharp.Domain.Contracts;

namespace GameBoySharp.Domain.Providers
{
    [Export(typeof (IRegisters))]
    internal sealed class Registers : IRegisters
    {
        public byte A { get; set; }
        
        // TODO: Split these
        public ushort AF { get; set; }
        
        public byte B { get; set; }
        
        // TODO: Split these
        public ushort BC { get; set; }
        
        public byte C { get; set; }
        
        public byte D { get; set; }
        
        // TODO: Split these
        public ushort DE { get; set; }
        
        public byte E { get; set; }
        
        public byte F { get; set; }
        
        public byte H { get; set; }
        
        // TODO: Split these
        public ushort HL { get; set; }
        
        public byte L { get; set; }
        
        public ushort PC { get; set; }
        
        public ushort SP { get; set; }
    }
}