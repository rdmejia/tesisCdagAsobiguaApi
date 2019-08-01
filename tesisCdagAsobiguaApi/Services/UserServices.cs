using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Repositories;
using tesisCdagAsobiguaApi.Domain.Services;
using tesisCdagAsobiguaApi.Domain.Services.Communication;

namespace tesisCdagAsobiguaApi.Services
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserServices(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> FindByIdAsync(long id)
        {
            return await this.userRepository.FindById(id);
        }

        public async Task<User> FindByUsername(string username)
        {
            return await userRepository.FindByUsername(username);
        }

        public async Task<IEnumerable<User>> ListAsync(string userType)
        {
            return await userRepository.ListAsync(userType);
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            return await userRepository.LoginAsync(username, password);
        }

        public async Task<ObjectResponse<User>> SaveAsync(User user)
        {
            try
            {
                await userRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();

                return new ObjectResponse<User>(user);
            }
            catch(Exception ex)
            {
                return new ObjectResponse<User>($"An error ocurred when saving the user: {ex.Message}");
            }
        }
    }
}
