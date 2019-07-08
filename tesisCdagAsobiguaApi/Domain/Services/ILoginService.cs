using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Services.Communication;

namespace tesisCdagAsobiguaApi.Domain.Services
{
    public interface ILoginService
    {
        Task<IEnumerable<Login>> ListAsync();
        Task<IEnumerable<Login>> FindByTrainerId(long trainerId);
        Task<IEnumerable<Login>> FindByTrainerUsernameAsync(string trainerUsername);
        Task<IEnumerable<Login>> FindByPlayerId(long playerId);
        Task<IEnumerable<Login>> FindByPlayerUsername(string playerUsername);
        Task<IEnumerable<Login>> Find(long trainerId, long playerId);
        Task<IEnumerable<Login>> Find(string trainerUsername, string playerUsername);
        Task<ObjectResponse<Login>> SaveAsync(Login shot);
    }
}
