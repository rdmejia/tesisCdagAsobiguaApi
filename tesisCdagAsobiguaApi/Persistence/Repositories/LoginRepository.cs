using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Repositories;
using tesisCdagAsobiguaApi.Persistence.Contexts;

namespace tesisCdagAsobiguaApi.Persistence.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(AppDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Login>> Find(long trainerId, long playerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Login>> Find(string trainerUsername, string playerUsername)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Login>> FindByPlayerId(long playerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Login>> FindByPlayerUsername(string playerUsername)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Login>> FindByTrainerId(long trainerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Login>> FindByTrainerUsernameAsync(string trainerUsername)
        {
            var logins = context.Logins
                                .Include(p => p.Player)
                                .Include(p => p.Trainer)
                                .AsNoTracking();

            return await logins.Where(login => trainerUsername.Equals(login.Trainer.Username))
                                //.GroupBy(login => login.PlayerId)
                                //.Select(login => login.First())
                                .ToListAsync();
        }

        public Task<IEnumerable<Login>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> ListPlayersForAsync(User user)
        {
            var logins = context.Logins
                                .Include(p => p.Player)
                                .AsNoTracking();

            return await logins.Where(login => login.Trainer.Id == user.Id)
                          .GroupBy(login => login.PlayerId)
                          .Select(login => login.First())
                          .Select(login => login.Player)
                          .ToListAsync();
        }

        public async Task SaveAsync(Login login)
        {
            await context.Logins.AddAsync(login);
        }
    }
}
