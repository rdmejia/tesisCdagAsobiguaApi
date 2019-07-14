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
    public class ShotsController : Controller
    {
        private readonly IShotService shotService;
        private readonly ILoginService loginService;
        private readonly IUserService userService;
        private readonly IMapper mapper;


        public ShotsController(IShotService shotService, ILoginService loginService, IUserService userService, IMapper mapper)
        {
            this.shotService = shotService;
            this.loginService = loginService;
            this.userService = userService;
            this.mapper = mapper;
        }

        // GET v1/values/5
        [HttpGet("trainer/{trainer}/player/{player}")]
        public async Task<IActionResult> GetTrainerPlayerShots(string trainer, string player)
        {
            IEnumerable<Shot> shots = await shotService.Find(trainer, player);

            if(shots == null || shots.Count() <= 0)
            {
                return NotFound(new { message = "No shots were found for the given input", trainer, player });
            }

            var resource = mapper.Map<IEnumerable<Shot>, IEnumerable<ShotResource>>(shots);
            return Ok(resource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShotById(int id)
        {
            var shot = await shotService.FindByIdAsync(id);

            if(shot == null)
            {
                return NotFound(new { mesage = $"Shot with id: {id} was not found" });
            }

            var resource = mapper.Map<Shot, ShotResource>(shot);
            return Ok(resource);
        }

        [HttpGet("player/{username}")]
        public async Task<IActionResult> GetShotsByPlayer(string username)
        {
            var result = await shotService.FindByPlayerUsernameAsync(username);

            if(result == null || result.Count() <= 0)
            {
                return NotFound(new { message = $"Shots were not found for {username}" });
            }

            var resource = mapper.Map<IEnumerable<Shot>, IEnumerable<ShotsByPlayerResource>>(result);

            return Ok(resource);
        }

        // POST v1/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveShotResource resource)
        {
            var trainer = await userService.FindByUsername(resource.Trainer.Username);
            var player = await userService.FindByUsername(resource.Player.Username);

            if(trainer == null || player == null)
            {
                return NotFound(new { message = "Trainer or player not found", trainer, player });
            }

            var shot = mapper.Map<SaveShotResource, Shot>(resource);
            shot.TrainerId = trainer.Id;
            shot.PlayerId = player.Id;
            shot.Player = null;
            shot.Trainer = null;

            var newLogin = new Login { PlayerId = player.Id, TrainerId = trainer.Id, TimeStamp = resource.TimeStamp };
            var saveLoginResult = await loginService.SaveAsync(newLogin);

            if(!saveLoginResult.Success)
            {
                return BadRequest(saveLoginResult);
            }

            var saveShotResult = await shotService.SaveAsync(shot);

            if(!saveShotResult.Success)
            {
                return BadRequest(saveShotResult);
            }

            saveShotResult.value.Player = player;
            saveShotResult.value.Trainer = trainer;

            var shotResource = mapper.Map<Shot, ShotResource>(saveShotResult.value);

            return CreatedAtAction(nameof(GetShotById), new { id = shot.Id }, shotResource);
        }
    }
}
