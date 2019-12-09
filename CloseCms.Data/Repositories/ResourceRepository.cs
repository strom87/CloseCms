using CloseCms.Data.Context;
using CloseCms.Data.Entities;
using CloseCms.Data.Interfaces;

namespace CloseCms.Data.Repositories
{
    public class ResourceRepository : BaseRepository<ResourceEntity>, IResourceRepository
    {
        public ResourceRepository(CloseCmsContext context) : base(context) { }
    }
}
