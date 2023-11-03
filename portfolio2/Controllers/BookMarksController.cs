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
            var bm = _dataService.SQLAddBookMark(model.UserId, model.Id);
            if (bm == null)
            {
                return NotFound();
            }

            return Created($"http://localhost:5001/api/bookmarks/{bm.UserId}", bm);
        }



        [HttpDelete("{userId}/{titleId}")]
        public IActionResult RemoveBookMark(int userId, string titleId)
        {
            var rbm = _dataService.SQLRemoveBookMark(userId, titleId);
            if (rbm == null)
            {
                return NotFound();
            }

            return Ok(rbm);
        }


       // [HttpGet("{Id}", Name = nameof(GetBookmark))]
        public IActionResult GetBookmark(int userId, string id)
        {
            var bm = _dataService.GetBookMark(id, userId);
            if (bm == null)
            {
                return NotFound();
            }

            return Ok(bm);
        }

        [HttpGet("{UserId}", Name = nameof(GetBookmarks))]
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