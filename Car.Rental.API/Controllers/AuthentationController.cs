using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car.Rental.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Car.Rental.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AuthentationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthentationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
     
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> AdminLogin()
        {            
            return Ok();
        }            
    }
}
