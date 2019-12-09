using CloseCms.Core.Attributes;
using CloseCms.Core.Interfaces;
using CloseCms.Core.Models;
using CloseCms.Core.Models.Resource;
using CloseCms.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloseCms.Core.Services
{
    public class ResourceService : BaseService, IResourceService
    {
        private readonly IReflectionService _reflectionService;
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IReflectionService reflectionService, IResourceRepository resourceRepository)
        {
            _reflectionService = reflectionService;
            _resourceRepository = resourceRepository;
        }

        public void GenerateResources()
        {
            var resourceTypes = _reflectionService.GetClassesThatIsSubclassOf<BaseResource>();
            foreach (var type in resourceTypes)
            {
                var resource = new ResourceType
                {
                    ClassName = type.Name,
                    ClassPath = type.FullName
                };

                MapCustomAttributes(resource, type);
                MapProperties(type);
            }
        }

        private void MapProperties(Type type)
        {
            foreach (var property in type.GetProperties())
            {
                var p = property;
            }
        }

        private void MapCustomAttributes(ResourceType resource, Type type)
        {
            var resourceAttribute = (ResourceAttribute)Attribute.GetCustomAttribute(type, typeof(ResourceAttribute));
            if (resourceAttribute != null)
            {
                resource.Id = resourceAttribute.Id;
                resource.Name = resourceAttribute.Name;
            }
        }
    }
}
