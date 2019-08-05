using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tesisCdagAsobiguaApi.Domain.Models;

namespace tesisCdagAsobiguaApi.Domain.Repositories
{
    public interface IShotRepository
    {
        Task<IEnumerable<Shot>> ListAsync();
        Task<IEnumerable<Shot>> FindByTrainerId(long trainerId);
        Task<IEnumerable<Shot>> FindByTrainerUsername(string trainerUsername);
        Task<IEnumerable<Shot>> FindByPlayerId(long playerId);
        Task<IEnumerable<Shot>> FindByPlayerUsernameAsync(string playerUsername);
        Task<IEnumerable<Shot>> Find(long trainerId, long playerId);
        Task<IEnumerable<Shot>> Find(string trainerUsername, string playerUsername);
        Task<Shot> FindById(long id);
        Task AddAsync(Shot shot);
        Task<IEnumerable<Shot>> FindLatestShots(string playerUsername, int count);
    }
}
