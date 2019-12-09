using System;

namespace CloseCms.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ResourceAttribute : Attribute
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public ResourceAttribute() { }
    }
}
