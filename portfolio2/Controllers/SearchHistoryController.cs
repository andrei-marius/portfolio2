using DataLayer.IDataServices;
using Microsoft.AspNetCore.Mvc;

namespace WebServer.Controllers
{
    [Route("api/search-history")]
    [ApiController]
    public class SearchHistoryController : ControllerBase
    {
        private readonly IDataServiceSearchHistory _dataService;

        public SearchHistoryController(IDataServiceSearchHistory dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetSearchHistory(int userId)
        {
            var searchHistory = _dataService.GetSearchHistory(userId);
            if (searchHistory == null)
            {
                return NotFound();
            }

            return Ok(searchHistory);
        }

        [HttpDelete("delete/{userId}")]
        public IActionResult DeleteSearchHistory(int userId)
        {
            var deleteHistory = _dataService.DeleteSearchHistory(userId);
            if (deleteHistory == null) {
                return NotFound();
            }
            return Ok(deleteHistory);

        }

        [HttpDelete("delete/{userId}/{historyid}")]
        public IActionResult DeleteSearchHistoryById(int userId,int historyid)
        {
            var deleteHistory = _dataService.DeleteSearchHistoryById(userId,historyid);
            if (deleteHistory == null)
            {
                return NotFound();
            }
            return Ok(deleteHistory);

        }

    }
}
