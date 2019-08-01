using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync(string userType);
        Task AddAsync(User user);
        Task<User> FindById(long id);
        Task<User> FindByUsername(string username);
        Task<User> LoginAsync(string username, string password);
    }
}
