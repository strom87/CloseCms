using System;
using System.Collections.Generic;
using System.Text;

namespace CloseCms.Core.Models.Resource
{
    internal class ResourceType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string ClassPath { get; set; }

        public List<ResourceField> Fields { get; set; }
    }
}
