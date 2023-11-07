using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NpgsqlTypes;
using WebServer.Models;
using WebServer.Services;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace WebServer.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IDataServiceUser _dataService;
        private readonly IConfiguration _configuration;
        private readonly Hashing _hashing;


        public UsersController(
            IDataServiceUser dataService,
            LinkGenerator linkGenerator,
            IConfiguration configuration,
            Hashing hashing
        )
            : base(linkGenerator)
        {
            _dataService = dataService;
            _configuration = configuration;
            _hashing = hashing;
        }


        [HttpPost]
        public IActionResult CreateUser(User model)
        {
            if (_dataService.GetUser(model.UserName) != null)
            {
                return Conflict("already exists");
            }

            (var hashedPwd, var salt) = _hashing.Hash(model.Password);

            var user = _dataService.CreateUser(model.UserName, hashedPwd, salt, model.Role);

            return Created($"http://localhost:5001/api/user/{user.UserName}", new
            {
                user.UserId,
                user.UserName,
                user.Role
        });
        }

        [HttpPut]
        public IActionResult UpdateUser(User model)
        { 
            var user = _dataService.UpdateUser(model.UserId, model.UserName, model.Password);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet("{username}", Name = nameof(GetUser))]
        public IActionResult GetUser(string username)
        {
            var user = _dataService.GetUser(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUser(string username)
        {
            var user = _dataService.DeleteUser(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        [HttpPost("login")]
        public IActionResult UserLogin(CreateUserModel user)
        {
            var rbm = _dataService.Login(user.UserName, user.Password);
            if (rbm == null)
            {
                return NotFound("wrong username");
            }

            if (!_hashing.Verify(user.Password, rbm.Password, rbm.Salt))
            {
                return NotFound("wrong password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, rbm.UserName),
                new Claim(ClaimTypes.Role, rbm.Role)
            };

            var secret = _configuration.GetSection("Auth:Secret").Value;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { user.UserName, token = jwt });
        }
    }
}
