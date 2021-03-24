using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pang.RBAC.Api.Authorization;
using Pang.RBAC.Api.Models;
using Pang.RBAC.Api.Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pang.RBAC.Api.Controllers.Authorization
{
    /// <summary>
    /// 授权接口
    /// </summary>
    [ApiController]
    [Route("[Controller]/[Action]")]
    [EnableCors("Any")]
    public class AuthorizationController : ControllerBase
    {
        private PermissionRequirement _tokenParameter;
        private readonly UserRepository _userRepository;

        public AuthorizationController(UserRepository userRepository)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            _tokenParameter = config.GetSection("TokenParameter").Get<PermissionRequirement>();

            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="request">用户名和密码</param>
        /// <returns>Token</returns>
        [HttpPost]
        public async Task<IActionResult> RequestToken([FromBody] UserDto request)
        {
            if (request.Username == null && request.Password == null)
                return BadRequest("Invalid Request");

            if (!(await _userRepository.UserExistAsync(request.Username)))
            {
                return BadRequest("账号不存在");
            }

            var user = await _userRepository.GetUserByUserNameAsync(request.Username);
            if (user.Password != request.Password)
            {
                return BadRequest("密码错误");
            }

            //生成Token和RefreshToken
            var token = GenUserToken(user.Id, request.Username, "admin");
            var refreshToken = "123456";

            return Ok(new[] { token, refreshToken });
        }

        //生成Token代码
        private string GenUserToken(Guid id, string username, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, id.ToString()),
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