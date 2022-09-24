using Car.Rental.Services.Abstract;
using Car.Rental.Services.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car.Rental.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly IOperatorService _operatorService;
        public OperatorController(IOperatorService operatorService)
        {
            _operatorService = operatorService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AddClient(OperatorModel request)
        {
            var result = await _operatorService.AddOperator(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
    }
}
