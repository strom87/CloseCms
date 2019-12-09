using System;
using System.Reflection;
using System.Collections.Generic;

namespace CloseCms.Core.Interfaces
{
    public interface IReflectionService
    {
        List<Type> GetTypesWithSubclassesOf<T>() where T : class;
        IEnumerable<Assembly> LoadAllAssemblies();
    }
}