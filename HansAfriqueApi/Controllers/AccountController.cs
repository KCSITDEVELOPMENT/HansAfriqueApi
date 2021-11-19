using HansAfriqueApi.Data;
using HansAfriqueApi.Dto;
using HansAfriqueApi.Entities;
using HansAfriqueApi.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static HansAfriqueApi.Controllers.BaseController;

namespace HansAfriqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
            private readonly ITokenService _tokenservice;
            private readonly DataContext _context;
            private readonly IAuthRepository _repo;
            private readonly IConfiguration _config;

            public AccountController(DataContext context, IAuthRepository repo, IConfiguration config, ITokenService tokenservice)
            {
                _tokenservice = tokenservice;
                _context = context;
                _repo = repo;
                _config = config;
            }


        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserRegisterDto userRegisterDto)
        {
            //Validate request
            userRegisterDto.Username = userRegisterDto.Username.ToLower();

            if (await _repo.UserExist(userRegisterDto.Email))
                return BadRequest("User Already Exist");

            using var hmac = new HMACSHA512();

            var userToCreate = new Person
            {
                Username = userRegisterDto.Username.ToLower(),
                Lastname = userRegisterDto.Lastname,
                CellNumber = userRegisterDto.Mobilenumber,
                Email = userRegisterDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.People.Add(userToCreate);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = userToCreate.Username,
                Token = _tokenservice.CreateToken(userToCreate)
            };
        }

        [HttpPost("login")]
            public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
            {
             
             var user = await _context.People.SingleOrDefaultAsync(x => x.Username == userLoginDto.UsernameLog);

            if (user == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.PasswordLog));

              for (int i = 0; i < computeHash.Length; ++i) 
               {
                if (computeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
               }

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenservice.CreateToken(user)
            };
        }
        
    }
}
