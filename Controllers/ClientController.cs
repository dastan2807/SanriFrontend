using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SanriJP.API.Authentication;
using SanriJP.API.Models;
using SanriJP.API.Service;
using System;
using System.Threading.Tasks;

namespace VM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientController(IClientService clientService, IMapper mapper) 
            => (_clientService, _mapper) = (clientService, mapper);

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _clientService.GetAllAsync();
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "No Clients!" });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _clientService.GetByIdAsync(x => x.Id == id);
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "Client doesn't exists!" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateClientRequest request)
        {
            if (ModelState.IsValid)
            {
                var newClient = _mapper.Map<Client>(request);
                var result = await _clientService.AddAsync(newClient);
                if (result.Item1.Status == ResponseStatus.Error)
                    return BadRequest(result.Item1.Status);
                return Ok(result.Item2);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Client model)
        {
            var result = await _clientService.UpdateWithoutNullAsync(model);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);

            var result2 = await _clientService.GetByIdAsync(x => x.Id == model.Id);
            if (result2 == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "Client doesn't exists!" });

            return Ok(result2);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clientService.DeleteAsync(x => x.Id == id);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
