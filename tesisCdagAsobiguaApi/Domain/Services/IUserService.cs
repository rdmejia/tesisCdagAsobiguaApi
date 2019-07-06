using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Services.Communication;

namespace tesisCdagAsobiguaApi.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<ObjectResponse<User>> SaveAsync(User user);
        Task<User> FindByIdAsync(long id);
        Task<User> FindByUsername(string username);
    }
}
