using System.ComponentModel.DataAnnotations.Schema;

namespace CloseCms.Data.Entities
{
    [Table("Resource")]
    public class ResourceEntity : BaseEntity
    {
        public string Name { get; set; }
        public string ClassName { get; set; }
        public string ClassPath { get; set; }
    }
}
