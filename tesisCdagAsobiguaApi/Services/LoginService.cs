using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Repositories;
using tesisCdagAsobiguaApi.Domain.Services;
using tesisCdagAsobiguaApi.Domain.Services.Communication;

namespace tesisCdagAsobiguaApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        private readonly IUnitOfWork unitOfWork;

        public LoginService(ILoginRepository loginRepository, IUnitOfWork unitOfWork)
        {
            this.loginRepository = loginRepository;
            this.unitOfWork = unitOfWork;
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
            return await loginRepository.FindByTrainerUsernameAsync(trainerUsername);
        }

        public Task<IEnumerable<Login>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> ListPlayersForAsync(User user)
        {
            return await loginRepository.ListPlayersForAsync(user);
        }

        public async Task<ObjectResponse<Login>> SaveAsync(Login login)
        {
            try
            {
                await loginRepository.SaveAsync(login);
                await unitOfWork.CompleteAsync();

                return new ObjectResponse<Login>(login);
            }
            catch(Exception ex)
            {
                return new ObjectResponse<Login>($"Un error ocurrió mientras se intentaba guardar el registro de tiro: {ex.Message}");
            }
        }
    }
}
