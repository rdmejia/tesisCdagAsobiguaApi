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
        private readonly IMapper mapper;

        private readonly IUserService userService;

        public ShotsController(IShotService shotService, IMapper mapper, IUserService userService)
        {
            this.shotService = shotService;
            this.mapper = mapper;
            this.userService = userService;
        }

        // GET v1/values/5
        [HttpGet("trainer/{trainer}/player/{player}")]
        public async Task<IActionResult> Get(string trainer, string player)
        {
            IEnumerable<Shot> shots = await shotService.Find(trainer, player);

            if(shots == null || shots.Count() <= 0)
            {
                return NotFound(new { message = "No shots were found for the given input", trainer, player });
            }

            var resource = mapper.Map<IEnumerable<Shot>, IEnumerable<ShotResource>>(shots);
            return Ok(resource);
        }

        // POST v1/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]SaveShotResource resource)
        {
            await shotService.AddAsync(null);
            return Ok();
        }
    }
}
