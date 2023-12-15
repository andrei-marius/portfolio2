using DataLayer.IDataServices;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonController : BaseController
    {
        private readonly IDataServicePerson _dataService;

        public PersonController(IDataServicePerson dataService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _dataService = dataService;
        }

        [HttpGet("{id}", Name = nameof(GetPerson))]
        public IActionResult GetPerson(string id)
        {
            var person = _dataService.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
