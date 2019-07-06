using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Domain.Services
{
    public interface IShotService
    {
        Task<IEnumerable<Shot>> ListAsync();
        Task<IEnumerable<Shot>> FindByTrainerId(long trainerId);
        Task<IEnumerable<Shot>> FindByTrainerUsername(string trainerUsername);
        Task<IEnumerable<Shot>> FindByPlayerId(long playerId);
        Task<IEnumerable<Shot>> FindByPlayerUsername(string playerUsername);
        Task<IEnumerable<Shot>> Find(long trainerId, long playerId);
        Task<IEnumerable<Shot>> Find(string trainerUsername, string playerUsername);
        Task AddAsync(Shot shot);
    }
}
