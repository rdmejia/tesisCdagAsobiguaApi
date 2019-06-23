using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tesisCdagAsobiguaApi.API.Domain.Models;

namespace tesisCdagAsobiguaApi.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class ShotController : ControllerBase
    {
        // GET: api/Shot
        [HttpGet]
        public IEnumerable<Shot> Get()
        {
            User trainer = new User() { id = 1, username = "trainer" };
            User player = new User() { id = 1, username = "player2" };

            var numbers = Enumerable.Range(0, 5);

            Random random = new Random();

            List<ShotXYZ> shotXYZs = (from x in numbers
                                      from y in numbers
                                      from z in numbers
                                      select new ShotXYZ() { timeStamp = DateTime.Now.AddMinutes(1), x = random.NextDouble() * x, y = random.NextDouble() * y, z = random.NextDouble() * z }).ToList();

            Shot[] shots = (from value in Enumerable.Range(0, 25)
                            select new Shot()
                            {
                                id = value,
                                timeStamp = DateTime.Now.AddMinutes(-value),
                                trainer = trainer,
                                player = player,
                                backstokePause = random.Next(0, 10),
                                shotInterval = random.Next(0, 10),
                                jab = random.Next(0, 10),
                                followThrough = random.Next(0, 10),
                                ShotXYZ = shotXYZs
                            }).ToArray();

            return shots;
        }

        // GET: api/Shot/5
        [HttpGet("{id}", Name = "GetShot")]
        public Shot Get(int id)
        {
            User trainer = new User() { id = 1, username = "trainer" };
            User player = new User() { id = 1, username = "player2" };

            var numbers = Enumerable.Range(0, 5);

            Random random = new Random();

            List<ShotXYZ> shotXYZs = (from x in numbers
                                      from y in numbers
                                      from z in numbers
                                      select new ShotXYZ() {timeStamp = DateTime.Now.AddMinutes(1), x = random.NextDouble() * x, y = random.NextDouble() * y, z = random.NextDouble() * z }).ToList();

            return new Shot()
            {
                id = id,
                timeStamp = DateTime.Now,
                trainer = trainer,
                player = player,
                backstokePause = random.Next(0, 10),
                shotInterval = random.Next(0, 10),
                jab = random.Next(0, 10),
                followThrough = random.Next(0, 10),
                ShotXYZ = shotXYZs
            };
        }

        // POST: api/Shot
        [HttpPost]
        public Shot Post([FromBody] Shot value)
        {
            return value;
        }

        // PUT: api/Shot/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
