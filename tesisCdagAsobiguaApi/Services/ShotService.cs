using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Repositories;
using tesisCdagAsobiguaApi.Domain.Services;
using tesisCdagAsobiguaApi.Domain.Services.Communication;

namespace tesisCdagAsobiguaApi.Services
{
    public class ShotService : IShotService
    {
        private readonly IShotRepository shotRepository;
        private readonly IUnitOfWork unitOfWork;

        public ShotService(IShotRepository shotRepository, IUnitOfWork unitOfWork)
        {
            this.shotRepository = shotRepository;
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Shot>> Find(long trainerId, long playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shot>> Find(string trainerUsername, string playerUsername)
        {
            return await shotRepository.Find(trainerUsername, playerUsername);
        }

        public Task<IEnumerable<Shot>> FindByPlayerId(long playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Shot>> FindByPlayerUsernameAsync(string playerUsername)
        {
            return await shotRepository.FindByPlayerUsernameAsync(playerUsername);
        }

        public Task<IEnumerable<Shot>> FindByTrainerId(long trainerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shot>> FindByTrainerUsername(string trainerUsername)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Shot>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Shot> FindByIdAsync(long id)
        {
            var result = await shotRepository.FindById(id);
            return result;
        }

        public async Task<ObjectResponse<Shot>> SaveAsync(Shot shot)
        {
            try
            {
                await shotRepository.AddAsync(shot);
                await unitOfWork.CompleteAsync();

                return new ObjectResponse<Shot>(shot);
            }
            catch(Exception ex)
            {
                return new ObjectResponse<Shot>($"Un error ocurrió mientras se intentaba guardar el tiro: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Shot>> FindLatestShots(string playerUsername, int count)
        {
            // count <= 0 -> all shots
            return await shotRepository.FindLatestShots(playerUsername, count);
        }
    }
}
