using CloseCms.Core.Models;
using CloseCms.Core.Attributes;

namespace CloseCms.Models.Resources
{
    [Resource(Id = 300, Name = "Product Content", Description = "Product of some sort")]
    public class Product : BaseResource
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
