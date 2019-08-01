using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Repositories;
using tesisCdagAsobiguaApi.Extensions;
using tesisCdagAsobiguaApi.Persistence.Contexts;

namespace tesisCdagAsobiguaApi.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task<User> FindById(long id)
        {
            var users = context.Users.AsNoTracking();

            return await users.Where(user => user.Id == id).FirstAsync();
        }

        public async Task<User> FindByUsername(string username)
        {
            var users = context.Users.AsNoTracking();

            return await users.Where(user => username.Equals(user.Username)).DefaultIfEmpty(null).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> ListAsync(string userType)
        {
            var users = context.Users.AsNoTracking();

            if(string.IsNullOrWhiteSpace(userType))
            {
                return await users.ToListAsync();
            }

            return await users.Where(user => userType.Equals(user.UserType.ToString(), StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var users = context.Users.AsNoTracking();

            var encryptedPassword = password.EncryptString().ToByteArrayString();

            return await users.Where(user => username.Equals(user.Username, StringComparison.OrdinalIgnoreCase)
                                            && password.Equals(user.Password))
                            .DefaultIfEmpty(null)
                            .SingleOrDefaultAsync();
        }
    }
}
