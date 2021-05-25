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
    public class CarResaleController : ControllerBase
    {
        private readonly ICarResaleService _carResaleService;
        private readonly IMapper _mapper;

        public CarResaleController(ICarResaleService carResaleService, IMapper mapper) 
            => (_carResaleService, _mapper) = (carResaleService, mapper);

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _carResaleService.GetAllAsync();
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "No CarResales!" });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _carResaleService.GetByIdAsync(x => x.Id == id);
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "CarResale doesn't exists!" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCarResaleRequest request)
        {
            if (ModelState.IsValid)
            {
                var newCarResale = _mapper.Map<CarResale>(request);
                var result = await _carResaleService.AddAsync(newCarResale);
                if (result.Item1.Status == ResponseStatus.Error)
                    return BadRequest(result.Item1.Status);
                return Ok(result.Item2);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarResale model)
        {
            var result = await _carResaleService.UpdateWithoutNullAsync(model);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);

            var result2 = await _carResaleService.GetByIdAsync(x => x.Id == model.Id);
            if (result2 == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "CarResale doesn't exists!" });

            return Ok(result2);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _carResaleService.DeleteAsync(x => x.Id == id);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
