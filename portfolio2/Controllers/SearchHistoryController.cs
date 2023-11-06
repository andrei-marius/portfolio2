using DataLayer.IDataServices;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/titles")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private readonly IDataServiceSearchHistory _dataService;

        public SearchHistoryController(IDataServiceSearchHistory dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("search-history/{userId}")]
        public IActionResult GetSearchHistory(int userId)
        {
            var searchHistory = _dataService.GetSearchHistory(userId);
            if (searchHistory == null)
            {
                return NotFound();
            }

            return Ok(searchHistory);
        }
    }
}
