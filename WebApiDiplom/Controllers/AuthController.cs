using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebApiDiplom.Data;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;
using WebApiDiplom.Services;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenservice;

        public AuthController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenservice = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ClientDto>> Register(RegisterDto registerDto)
        {
            if (await ClientExists(registerDto.Phone))
            {
                return BadRequest("Phone is taken");
            }
            using var hmac = new HMACSHA512();

            var client = new Client
            {
                Phone = registerDto.Phone,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Passport = registerDto.Passport
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return new ClientDto
            {
                Phone = client.Phone,
                Token = _tokenservice.CreateToken(client)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<ClientDto>> Login(LoginDto loginDto)
        {
            var client = await _context.Clients.SingleOrDefaultAsync(x => x.Phone == loginDto.Phone);

            if (client == null)
            {
                return Unauthorized("Invalid phone");
            }

            using var hmac = new HMACSHA512(client.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != client.PasswordHash[i])
                {
                    return Unauthorized("Invalid password");
                }
            }

            return new ClientDto
            {
                Phone = client.Phone,
                Token = _tokenservice.CreateToken(client)
            };
        }

        private async Task<bool> ClientExists(string phone)
        {
            return await _context.Clients.AnyAsync(x => x.Phone == phone);
        }
    }
}
