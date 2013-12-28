using GameBoySharp.Domain.Contracts;
using GameBoySharp.Domain.Infrastructure;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var compositionContainer = Bootstrapper.CreateCompositionContainer())
            {
                var sharp = compositionContainer.GetExportedValue<ISharp>();

                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
                sharp.ExecuteOperation();
            }
        }
    }
}