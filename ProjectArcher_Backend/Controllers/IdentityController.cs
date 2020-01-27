using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectArcher_Backend.DTOs;
using ProjectArcher_Backend.Services;

namespace ProjectArcher_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet]
        public ActionResult<bool> Login([FromBody] UserDTO user)
        {
            return Ok(_identityService.Login(user.Username, user.PlainTextPassword));
        }

        [HttpGet]
        public ActionResult<bool> Register([FromBody] UserDTO user)
        {
            return Ok(_identityService.Register(user.Username, user.PlainTextPassword));
        }
    }
}