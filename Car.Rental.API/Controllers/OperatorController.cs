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
        public async Task<ActionResult> AddOperator(OperatorModel request)
        {
            var result = await _operatorService.AddOperator(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult> GetClient(int id)
        {
            var result = await _operatorService.GetOperatorById(id);
            return Ok(result.Data);
        }

        [HttpPut]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult> UpdateClient(OperatorModel request)
        {
            var result = await _operatorService.UpdateOperator(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Operator")]
        public async Task<ActionResult> DeleteOperator(int id)
        {
            var result = await _operatorService.DeleteOperator(id);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }
    }
}
