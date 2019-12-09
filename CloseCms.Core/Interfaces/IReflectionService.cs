using System;
using System.Reflection;
using System.Collections.Generic;

namespace CloseCms.Core.Interfaces
{
    public interface IReflectionService
    {
        List<Type> GetClassesThatIsSubclassOf<TBaseClass>() where TBaseClass : class;
        IEnumerable<Assembly> LoadAllAssemblies();
    }
}