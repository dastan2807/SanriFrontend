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
    public class CarOrderController : ControllerBase
    {
        private readonly ICarOrderService _carOrderService;
        private readonly IMapper _mapper;
        public CarOrderController(ICarOrderService carOrderService, IMapper mapper) 
            => (_carOrderService, _mapper) = (carOrderService, mapper);

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _carOrderService.GetAllAsync();
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "No Orders!" });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _carOrderService.GetByIdAsync(x => x.Id == id);
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "Order doesn't exists!" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCarOrderRequest request)
        {
            if (ModelState.IsValid)
            {
                var newCarOrder = _mapper.Map<CarOrder>(request);
                var result = await _carOrderService.AddAsync(newCarOrder);
                if (result.Item1.Status == ResponseStatus.Error)
                    return BadRequest(result.Item1.Status);
                return Ok(result.Item2);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarOrder model)
        {
            var result = await _carOrderService.UpdateWithoutNullAsync(model);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);

            var result2 = await _carOrderService.GetByIdAsync(x => x.Id == model.Id);
            if (result2 == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "Order doesn't exists!" });

            return Ok(result2);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _carOrderService.DeleteAsync(x => x.Id == id);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
