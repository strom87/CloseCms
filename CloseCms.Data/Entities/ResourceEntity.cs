using System.ComponentModel.DataAnnotations.Schema;

namespace CloseCms.Data.Entities
{
    [Table("Resource")]
    public class ResourceEntity : BaseEntity
    {
        public string Name { get; set; }
        public string AssemblyPath { get; set; }
    }
}
