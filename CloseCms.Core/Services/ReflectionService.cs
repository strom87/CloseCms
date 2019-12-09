using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using CloseCms.Core.Interfaces;

namespace CloseCms.Core.Services
{
    public class ReflectionService : BaseService, IReflectionService
    {
        public List<Type> GetTypesWithSubclassesOf<T>() where T : class
        {
            var values = new List<Type>();
            foreach (var assembly in LoadAllAssemblies())
            {
                var types = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(T)));
                if (types == null) continue;
                    
                values.AddRange(types);
            }

            return values;
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
