using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/wo")]
    [ApiController]
    public class OftenWorkedWithController : BaseController
    {
        private readonly IDataServiceOftenWorkedWith _dataService;

        public OftenWorkedWithController(IDataServiceOftenWorkedWith dataService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _dataService = dataService;
        }
        [HttpGet("{actorName}")]//, Name = nameof(GetOftenWorkedWith)
        public IActionResult GetOftenWorkedWith(string actorName)
        {
            var workedWith = _dataService.GetOftenWorkedWith(actorName);
            if (workedWith == null)
            {
                return NotFound();
            }
            return Ok(workedWith);
        }
        

    }

}
