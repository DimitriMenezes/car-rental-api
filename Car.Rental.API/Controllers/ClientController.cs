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
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AddClient(ClientModel request)
        {
            var result = await _clientService.AddClient(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        [Authorize(Roles ="Client")]
        public async Task<ActionResult> GetClient(int id)
        {
            var result = await _clientService.GetClientById(id);           
            return Ok(result.Data);
        }

        [HttpPut]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> UpdateClient(ClientModel request)
        {
            var result = await _clientService.UpdateClient(request);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Client")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var result = await _clientService.DeleteClient(id);
            if (result.Errors != null)
                return BadRequest(result.Errors);

            return Ok(result.Data);
        }

    }
}
