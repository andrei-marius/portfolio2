using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NpgsqlTypes;
using WebServer.Controllers;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/bookmarks")]
    [ApiController]
    public class BookMarksController : BaseController
    {
        private readonly IDataServiceBookMark _dataService;

        public BookMarksController(IDataServiceBookMark dataService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _dataService = dataService;
        }

        [HttpPost]
        public IActionResult AddBookMark([FromBody] BookMarks model)
        {
            var bm = _dataService.AddBookMark(model.UserId, model.Id, model.UserNote);
            if (bm == null)
            {
                return NotFound();
            }

            return Created($"http://localhost:5001/api/bookmarks/{bm.UserId}", bm);
        }

        [HttpPut]
        public IActionResult UpdateBookMark([FromBody] BookMarks model)
        {
            var bm = _dataService.UpdateBookMark(model.UserId, model.BookmarkId, model.UserNote);
            if (bm == null)
            {
                return NotFound();
            }

            return Created($"http://localhost:5001/api/bookmarks/{bm.BookmarkId}", bm);
            
        }

        [HttpDelete("{userId}/{bookmarkId}")]
        public IActionResult RemoveBookMark(int userId, int bookmarkId)
        {
            var rbm = _dataService.RemoveBookMark(userId, bookmarkId);
            if (rbm == null)
            {
                return NotFound();
            }

            return Ok(rbm);
        }

        [HttpGet("{userId}/{bookmarkId}", Name = nameof(GetBookmark))]
        public IActionResult GetBookmark(int userId, int bookmarkId)
        {
            var bm = _dataService.GetBookMark(bookmarkId, userId);
            if (bm == null)
            {
                return NotFound();
            }

            return Ok(bm);
        }

        [HttpGet("{userId}", Name = nameof(GetBookmarks))]
        public IActionResult GetBookmarks(int userId)
        {
            var bm = _dataService.GetBookMarks(userId);
            if (bm == null)
            {
                return NotFound();
            }

            return Ok(bm);
        }

    }
}