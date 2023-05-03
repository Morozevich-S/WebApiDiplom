using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using WebApiDiplom.Data;
using WebApiDiplom.Dto;
using WebApiDiplom.Interfaces;
using WebApiDiplom.Models;
using WebApiDiplom.Repository;
using WebApiDiplom.Services;

namespace WebApiDiplom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenservice;
        private readonly IMapper _mapper;

        public AuthController(UserManager<AppUser> userManager, ITokenService tokenservice, IMapper mapper)
        {
            _userManager = userManager;
            _tokenservice = tokenservice;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Phone))
            {
                return BadRequest("Phone is taken");
            }

            var user = _mapper.Map<AppUser>(registerDto);

            user.Phone = registerDto.Phone;
            user.UserName = registerDto.Phone.ToString();

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(user, "Client");

            if (!roleResult.Succeeded) 
            {
                return BadRequest(roleResult.Errors);
            }

            return new UserDto
            {
                Phone = user.Phone,
                Token = await _tokenservice.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Phone == loginDto.Phone);

            if (user == null)
            {
                return Unauthorized("Invalid phone");
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result)
            {
                return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                Phone = user.Phone,
                Token = await _tokenservice.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string phone)
        {
            return await _userManager.Users.AnyAsync(x => x.Phone == phone);
        }
    }
}
