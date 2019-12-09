using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using CloseCms.Core.Interfaces;

namespace CloseCms.Core.Services
{
    public class ReflectionService : BaseService, IReflectionService
    {
        public List<Type> GetClassesThatIsSubclassOf<TBaseClass>() where TBaseClass : class
        {
            var types = new List<Type>();
            foreach (var assembly in LoadAllAssemblies())
            {
                types.AddRange(assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(TBaseClass))));
            }

            return types;
        }

        public IEnumerable<Assembly> LoadAllAssemblies()
        {
            var entry = Assembly.GetEntryAssembly();
            var assemblies = entry.GetReferencedAssemblies().Select(Assembly.Load).ToList();
            assemblies.Add(entry);

            return assemblies;
        }
    }
}
