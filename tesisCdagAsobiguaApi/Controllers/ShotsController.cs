using System;
using System.Collections.Generic;
using System.Globalization;
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

        [HttpGet("trainer/{trainer}/player/{player}")]
        public async Task<IActionResult> GetTrainerPlayerShots(string trainer, string player)
        {
            IEnumerable<Shot> shots = await shotService.Find(trainer, player);

            if(shots == null || !shots.Any())
            {
                return NotFound(new { message = "No se encontraron tiros para los parámetros ingresados", trainer, player });
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
                return NotFound(new { mesage = $"Tiro con id: {id} no encontrado" });
            }

            var resource = mapper.Map<Shot, ShotResource>(shot);
            return Ok(resource);
        }

        [HttpGet("player/{username}")]
        public async Task<IActionResult> GetShotsByPlayer(string username)
        {
            var result = await shotService.FindByPlayerUsernameAsync(username);

            if(result == null || !result.Any())
            {
                return NotFound(new { message = $"Tiros para el usuario {username} no fueron encontrados" });
            }

            var resource = mapper.Map<IEnumerable<Shot>, IEnumerable<ShotsByPlayerResource>>(result);

            return Ok(resource);
        }

        private static DateTime GetDefaultDate(string date, DateTime defaultValue)
        {
            if(date is null)
            {
                return defaultValue;
            }
            return DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
        }

        [HttpGet("player/{username}/history")]
        public async Task<IActionResult> GetLatestShotsByPlayer(string username, [FromQuery] int? count, [FromQuery] string fromDate, [FromQuery] string toDate)
        {
            DateTime _fromDate, _toDate;
            DateTime now = DateTime.Now;
            try
            {
                _fromDate = GetDefaultDate(fromDate, DateTime.MinValue);
                _toDate = GetDefaultDate(toDate, now);
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = $"Formato de fecha inválido", exception = ex.Message });
            }

            if(DateTime.Compare(now, _toDate) != 0)
            {
                _toDate = _toDate.AddHours(23).AddMinutes(59).AddSeconds(59);
            }

            if(DateTime.Compare(_toDate, _fromDate) < 0)
            {
                return BadRequest(new { message = $"Las fecha de inicio es mayor a la fecha de fin" });
            }

            int latest;
            if (count is null)
            {
                latest = 0;
            }
            else
            {
                latest = (int)count;
            }

            var result = await shotService.FindLatestShots(username, latest, _fromDate, _toDate);

            if(result == null || !result.Any())
            {
                return NotFound(new { message = $"Tiros para el usuario {username} no fueron encontrados" });
            }


            var resource = mapper.Map<IEnumerable<Shot>, IEnumerable<SingleShotResource>>(result);

            return Ok(resource);
        }

        // POST v1/shots
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveShotResource resource)
        {
            var trainer = await userService.FindByUsername(resource.Trainer.Username);
            var player = await userService.FindByUsername(resource.Player.Username);

            if(trainer == null || player == null)
            {
                return NotFound(new { message = "Entrenador o jugador no enontrados", trainer, player });
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
