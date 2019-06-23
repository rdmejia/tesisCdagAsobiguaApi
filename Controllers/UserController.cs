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
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new User[] {
                new User() { id = 1, username = "trainer", name = "trainerName", lastName = "trainserLastname", type = UserType.Trainer, birthDate = DateTime.Now, email ="trainer@mail.com" },
                new User() { id = 2, username = "player2", name = "player2Name", lastName = "player2Lastname", type = UserType.Trainer, birthDate = DateTime.Now, email ="player2@mail.com" },
                new User() { id = 4, username = "player4", name = "player4Name", lastName = "player4Lastname", type = UserType.Trainer, birthDate = DateTime.Now, email ="player4@mail.com" }
            };
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return new User() {
                id = 1,
                name = "Juan",
                lastName = "Pérez",
                email = "juan.perez@mail.com",
                birthDate = new DateTime(1990, 1, 1),
                type = (id % 2 == 0 ? UserType.Player : UserType.Trainer), // For mocking purposes, and even id represents a Player, otherwise it represents a Trainer
                username = "username"
            };
        }

        // POST: api/User
        [HttpPost]
        public User Post(User user)
        {
            user.id = 1;
            return user;
        }

        // PUT: api/User/5
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
