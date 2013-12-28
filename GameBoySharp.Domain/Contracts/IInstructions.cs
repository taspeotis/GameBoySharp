using System.Collections.Generic;

namespace GameBoySharp.Domain.Contracts
{
    interface IInstructions
    {
        IEnumerable<IInstruction> GetInstructions();
    }
}
