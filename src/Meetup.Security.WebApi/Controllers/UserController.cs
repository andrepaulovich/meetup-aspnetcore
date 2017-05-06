using Meetup.Security.Shared.BusinessObjects;
using Meetup.Security.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Meetup.Security.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserController(IGoalAuthenticationService authenticationService, ILogger<UserController> log)
        {
            AuthenticationService = authenticationService;
            Log = log;
        }

        private IGoalAuthenticationService AuthenticationService { get; set; }

        private ILogger<UserController> Log { get; set; }

        // GET: api/values
        [HttpGet]
        [Authorize(Roles = "SysAdmin")]
        public IEnumerable<UserDto> Get()
        {
            // log test
            Log.LogInformation("I'm alive!");
            Log.LogWarning("Log warning sample.");
            Log.LogError("Log error sample.");

            // Services > Respositores
            return AuthenticationService.GetUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public UserDto Get(long id)
        {
            return AuthenticationService.GetUser(id);
        }
    }
}
