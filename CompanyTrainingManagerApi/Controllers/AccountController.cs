using CompanyTrainingManagerApi.Interfaces;
using CompanyTrainingManagerApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyTrainingManagerApi.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] RegisterAccountDto dto)
        {
            _service.RegisterUser(dto);

            return Ok();
        }
    }
}
