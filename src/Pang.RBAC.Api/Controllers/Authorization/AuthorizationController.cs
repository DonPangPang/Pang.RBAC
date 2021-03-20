using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pang.RBAC.Api.Authorization;
using Pang.RBAC.Api.Entities;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;

namespace Pang.RBAC.Api.Controllers.Authorization
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class AuthorizationController : ControllerBase
    {
        private TokenParameter _tokenParameter = new TokenParameter();
        private readonly UserRepository _userRepository;
        public AuthorizationController(UserRepository userRepository)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            _tokenParameter = config.GetSection("TokenParameter").Get<TokenParameter>();

            _userRepository = userRepository;
        }

        [HttpPost, Route("requestToken")]
        public IActionResult RequestToken([FromBody] UserDto request)
        {
            // TODO: 对接 Repository
            if (request.Username == null && request.Password == null)
                return BadRequest("Invalid Request");

            

            //生成Token和RefreshToken
            var token = GenUserToken(request.Username, "admin");
            var refreshToken = "123456";

            return Ok(new[] { token, refreshToken });
        }


        //这儿是真正的生成Token代码
        private string GenUserToken(string username, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "3fa85f64-5717-4562-f3fc-2c963f66afa6"),
                new Claim(ClaimTypes.DateOfBirth,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenParameter.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(_tokenParameter.Issuer,
                                                _tokenParameter.Audience,
                                                claims,
                                                expires: DateTime.UtcNow.AddMinutes(_tokenParameter.AccessExpiration),
                                                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }

    }
}