using System;
using tesisCdagAsobiguaApi.Persistence.Contexts;

namespace tesisCdagAsobiguaApi.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext context;

        public BaseRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}
