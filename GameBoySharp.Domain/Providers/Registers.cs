using System.Composition;
using GameBoySharp.Domain.Contracts;

namespace GameBoySharp.Domain.Providers
{
    [Export(typeof (IRegisters)), Shared]
    internal sealed class Registers : IRegisters
    {
        public byte A { get; set; }
        
        public short AF { get; set; }
        
        public byte B { get; set; }
        
        public short BC { get; set; }
        
        public byte C { get; set; }
        
        public byte D { get; set; }
        
        public short DE { get; set; }
        
        public byte E { get; set; }
        
        public byte F { get; set; }
        
        public byte H { get; set; }
        
        public short HL { get; set; }
        
        public byte L { get; set; }
        
        public short PC { get; set; }
        
        public short SP { get; set; }
    }
}