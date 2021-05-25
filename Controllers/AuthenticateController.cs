using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SanriJP.API.Authentication;
using SanriJP.API.Models;
using SanriJP.API.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SanriJP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public AuthenticateController(
            IConfiguration configuration,
            IClientService clientService,
            IEmployeeService employeeService,
            IMapper mapper)
            => (_configuration, _clientService, _employeeService, _mapper)
            = (configuration, clientService, employeeService, mapper);

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                model.Login = model.Login.ToUpper();

                var client = await _clientService.GetByIdAsync(x => x.Login == model.Login && x.Password == model.Password);
                var employee = new Employee();
                if (client == null) 
                        employee = await _employeeService.GetByIdAsync(x => x.Login == model.Login && x.Password == model.Password);

                if (!(client == null && employee == null))
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Login),
                        new Claim(ClaimTypes.Role, employee.Role),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddDays(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        login = model.Login,
                        role = employee.Role,
                        expiration = token.ValidTo
                    });
                }
                return Unauthorized(model);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] CreateClientRequest request)
        {
            if (ModelState.IsValid)
            {
                request.Login = request.Login.ToUpper();

                var client = await _clientService.GetByIdAsync(x => x.Login == request.Login);
                var employee = await _employeeService.GetByIdAsync(x => x.Login == request.Login);

                if (!(client == null && employee == null))
                    return BadRequest(new Response { Status = ResponseStatus.Error, Message = "User Exists!" });

                var newClient = _mapper.Map<Client>(request);

                var result = await _clientService.AddAsync(newClient);

                if (result.Item1.Status == ResponseStatus.Error)
                    return StatusCode(StatusCodes.Status500InternalServerError, result.Item1.Message);

                return Ok(result.Item2);
            }
            return BadRequest();
        }
    }
}