using CloseCms.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloseCms.Data.Context
{
    public class CloseCmsContext : DbContext
    {
        public DbSet<ResourceEntity> Resources { get; set; }

        public CloseCmsContext(DbContextOptions<CloseCmsContext> options) : base(options) { }
    }
}
