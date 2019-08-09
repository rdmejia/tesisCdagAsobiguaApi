using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tesisCdagAsobiguaApi.Domain.Models;
using tesisCdagAsobiguaApi.Domain.Services;
using tesisCdagAsobiguaApi.Domain.Services.Communication;
using tesisCdagAsobiguaApi.Resources;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tesisCdagAsobiguaApi.Controllers
{
    [Route("v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string userType)
        {
            var users = await userService.ListAsync(userType);
            var resource = mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);

            return Ok(resource);
        }

        [HttpGet("{username}", Name = "Get")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var user = await userService.FindByUsername(username);

            if(user == null)
            {
                return NotFound(new { message = $"Usuario {username} no encontrado", username });
            }

            var resource = mapper.Map<User, UserResource>(user);
            return Ok(resource);
        }

        // POST v1/values
        [HttpPost]
        [RequireHttps]
        public async Task<IActionResult> PostAsync([FromBody]SaveUserResource resource)
        {
            var userAlreadyExists = (await userService.FindByUsername(resource.Username)) != null;
            User user;
            try
            {
                user = mapper.Map<SaveUserResource, User>(resource);
            }
            catch(AutoMapperMappingException exception)
            {
                return BadRequest(new { message = "La solicitud contiene un error", exception = exception.Message });
            }

            if (userAlreadyExists)
            {
                var userResponse= mapper.Map<User, UserResource>(user);

                return Conflict(
                    new
                    {
                        message = $"El usuario {resource.Username} ya existe",
                        user = userResponse
                    });
            }

            var result = await userService.SaveAsync(user);

            if(!result.Success)
            {
                return BadRequest(result);
            }

            var userResource = mapper.Map<User, UserResource>(result.value);

            return CreatedAtAction(nameof(GetByUsername), new { username = result.value.Username }, userResource);
        }

        [HttpPost("login")]
        [RequireHttps]
        public async Task<IActionResult> LoginAsync([FromBody] UsersLoginResource resource)
        {
            var user = await userService.LoginAsync(resource.Username, resource.Password);

            if(user == null)
            {
                return Unauthorized(new { message = "Usuario o password inválidos" });
            }

            var userResource = mapper.Map<User, UserResource>(user);

            return Ok(userResource);
        }
    }
}
