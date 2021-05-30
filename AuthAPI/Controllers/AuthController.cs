using AuthAPI.Models;
using DataLayer.Models;
using DataLayer.Repositories.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AuthOptions.AuthOptions> _authOptions;

        public AuthController(
            IUserRepository userRepository,
            IOptions<AuthOptions.AuthOptions> authOptions
            )
        {
            _userRepository = userRepository;
            _authOptions = authOptions;
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody] Login request)
        {
            var user = AuthentivateUser(request.UserName, request.Password);
            if (user != null)
            {
                //Create token
                var token = GenerateJWT(user);

                return Ok(new
                {
                    access_token = token
                });
            }
            return Unauthorized();
        }

        private Account AuthentivateUser(string login, string password)
        {
            var passwordHash = GetHash(password);
            var user = _userRepository.GetByLoginPassword(login, passwordHash);
            if (user != null && user.PasswordHash == passwordHash)
            {
                Account account = new Account
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserRole = user.UserRole
                };
                return account;
            }
            return null;
        }

        private string GenerateJWT(Account account)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, account.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, account.Id.ToString()),
            };

            claims.Add(new Claim("role", account.UserRole.Title.ToString()));

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public static string GetHash(string password)
        {
            using (var hash = SHA1.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(password)).Select(x => x.ToString("X2")));
            }
        }

    }
}
