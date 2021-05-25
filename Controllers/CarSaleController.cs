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
    public class CarSaleController : ControllerBase
    {
        private readonly ICarSaleService _carSaleService;
        private readonly IMapper _mapper;

        public CarSaleController(ICarSaleService carSaleService, IMapper mapper) 
            => (_carSaleService, _mapper) = (carSaleService, mapper);

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _carSaleService.GetAllAsync();
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "No CarSales!" });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _carSaleService.GetByIdAsync(x => x.Id == id);
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "CarSale doesn't exists!" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCarSaleRequest request)
        {
            if (ModelState.IsValid)
            {
                var newCarResale = _mapper.Map<CarSale>(request);
                var result = await _carSaleService.AddAsync(newCarResale);
                if (result.Item1.Status == ResponseStatus.Error)
                    return BadRequest(result.Item1.Status);
                return Ok(result.Item2);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarSale model)
        {
            var result = await _carSaleService.UpdateWithoutNullAsync(model);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);

            var result2 = await _carSaleService.GetByIdAsync(x => x.Id == model.Id);
            if (result2 == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "CarSale doesn't exists!" });

            return Ok(result2);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _carSaleService.DeleteAsync(x => x.Id == id);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
