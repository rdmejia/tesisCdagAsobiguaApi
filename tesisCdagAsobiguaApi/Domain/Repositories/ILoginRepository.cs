using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Domain.Repositories
{
    public interface ILoginRepository
    {
        Task<IEnumerable<Login>> ListAsync();
        Task<IEnumerable<Login>> FindByTrainerId(long trainerId);
        Task<IEnumerable<Login>> FindByTrainerUsername(string trainerUsername);
        Task<IEnumerable<Login>> FindByPlayerId(long playerId);
        Task<IEnumerable<Login>> FindByPlayerUsername(string playerUsername);
        Task<IEnumerable<Login>> Find(long trainerId, long playerId);
        Task<IEnumerable<Login>> Find(string trainerUsername, string playerUsername);
        Task AddAsync(Login shot);
    }
}
