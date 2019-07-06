using System;
using System.Threading.Tasks;

namespace tesisCdagAsobiguaApi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
