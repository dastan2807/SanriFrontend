using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SanriJP.API.Authentication;
using SanriJP.API.Models;
using SanriJP.API.Service;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace VM.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService employeeService, IMapper mapper) 
            => (_employeeService, _mapper) = (employeeService, mapper);
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _employeeService.GetAllAsync();
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "No Clients!" });
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeService.GetByIdAsync(x => x.Id == id);
            if (result == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "Client doesn't exists!" });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateEmployeeRequest request)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = _mapper.Map<Employee>(request);
                var result = await _employeeService.AddAsync(newEmployee);
                if (result.Item1.Status == ResponseStatus.Error)
                    return BadRequest(result.Item1.Status);
                return Ok(result.Item2);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Employee model)
        {
            var result = await _employeeService.UpdateWithoutNullAsync(model);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);

            var result2 = await _employeeService.GetByIdAsync(x => x.Id == model.Id);
            if (result2 == null)
                return BadRequest(new Response { Status = ResponseStatus.Error, Message = "Client doesn't exists!" });

            return Ok(result2);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteAsync(x => x.Id == id);
            if (result.Status == ResponseStatus.Error)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
