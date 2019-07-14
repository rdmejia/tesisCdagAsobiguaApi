using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Services.Communication;

namespace tesisCdagAsobiguaApi.Domain.Services
{
    public interface IShotService
    {
        Task<IEnumerable<Shot>> ListAsync();
        Task<IEnumerable<Shot>> FindByTrainerId(long trainerId);
        Task<IEnumerable<Shot>> FindByTrainerUsername(string trainerUsername);
        Task<IEnumerable<Shot>> FindByPlayerId(long playerId);
        Task<IEnumerable<Shot>> FindByPlayerUsernameAsync(string playerUsername);
        Task<IEnumerable<Shot>> Find(long trainerId, long playerId);
        Task<IEnumerable<Shot>> Find(string trainerUsername, string playerUsername);
        Task<Shot> FindByIdAsync(int id);
        Task<ObjectResponse<Shot>> SaveAsync(Shot shot);
    }
}
