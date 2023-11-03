using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NpgsqlTypes;
using WebServer.Models;
 

namespace WebServer.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IDataServiceUser _dataService;

        public UsersController(IDataServiceUser dataService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _dataService = dataService;
        }


        [HttpPost]
        public IActionResult CreateUser(User model)
        {
            var user = _dataService.CreateUser(model.UserName, model.Password);
            if (user == null)
            {
                return NotFound();
            }

            return Created($"http://localhost:5001/api/user/{user.UserName}", user);

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
        public IActionResult UserLogin(CreateUserModel ModelUser)
        {
            var rbm = _dataService.Login(ModelUser.UserName, ModelUser.Password);
            if (rbm == null)
            {
                return NotFound();
            }
            return Ok(rbm);
        }


    }
}
