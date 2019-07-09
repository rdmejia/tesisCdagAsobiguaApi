using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Services;
using tesisCdagAsobiguaApi.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tesisCdagAsobiguaApi.Controllers
{
    [Route("v1/[controller]")]
    public class LoginsController : Controller
    {
        private readonly ILoginService loginService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public LoginsController(ILoginService loginService, IUserService userService, IMapper mapper)
        {
            this.loginService = loginService;
            this.userService = userService;
            this.mapper = mapper;
        }

        // GET v1/values/5
        [HttpGet("{trainerUsername}")]
        public async Task<IActionResult> GetLoginsByTrainerAsync(string trainerUsername)
        {
            var trainer = userService.FindByUsername(trainerUsername);

            if(trainer == null)
            {
                return NotFound(new { message = "Trainer was not found", trainerUsername });
            }

            var loginsByTrainer = await loginService.FindByTrainerUsernameAsync(trainerUsername);

            if(loginsByTrainer == null || loginsByTrainer.Count() <= 0)
            {
                return NotFound(new { message = "No entries were found for the given input", trainerUsername });
            }

            var resource = mapper.Map<IEnumerable<Login>, IEnumerable<LoginResource>>(loginsByTrainer);

            return Ok(resource);
        }

        [HttpGet("players/{username}")]
        public async Task<IActionResult> GetPlayersAsync(string username)
        {
            var user = await userService.FindByUsername(username);

            if(user == null)
            {
                return NotFound(new { message = $"Username {username} was not found" });
            }

            if (EUserType.Player.Equals(user.UserType))
            {
                List<User> users = new List<User> { user };

                return Ok(mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users));
            }

            var players = await loginService.ListPlayersForAsync(user);
            var resource = mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(players);
            
            return Ok(resource);
        }
    }
}
