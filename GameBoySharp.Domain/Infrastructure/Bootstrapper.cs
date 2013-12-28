using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;

namespace GameBoySharp.Domain.Infrastructure
{
    public static class Bootstrapper
    {
        private static readonly Assembly[] EmptyAssemblies = { };

        private static readonly ComposablePartCatalog[] DefaultComposablePartCatalogs =
        {
            new DirectoryCatalog(".", "GameBoySharp.*.dll")
        };

        public static CompositionContainer CreateCompositionContainer(params Assembly[] additionalAssemblies)
        {
            var composablePartCatalogs = GetComposablePartsCatalog(additionalAssemblies);
            var aggregateCatalog = new AggregateCatalog(composablePartCatalogs);

            return new CompositionContainer(aggregateCatalog);
        }

        private static IEnumerable<ComposablePartCatalog> GetComposablePartsCatalog(Assembly[] additionalAssemblies)
        {
            var assemblyCatalogs =
                from additionalAssembly in additionalAssemblies ?? EmptyAssemblies
                select new AssemblyCatalog(additionalAssembly);

            return assemblyCatalogs.Union(DefaultComposablePartCatalogs);
        }
    }
}