using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Repositories;
using tesisCdagAsobiguaApi.Domain.Services;

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

        public Task AddAsync(Shot shot)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<Shot>> FindByPlayerUsername(string playerUsername)
        {
            throw new NotImplementedException();
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
    }
}
