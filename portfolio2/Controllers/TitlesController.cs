using DataLayer.IDataServices;
using DataLayer.Models;
using DataLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/titles")]
    [ApiController]
    public class TitlesController : BaseController
    {
        private readonly IDataServiceTitle _dataService;

        public TitlesController(IDataServiceTitle dataService, LinkGenerator linkGenerator)
            :base(linkGenerator) 
        {
            _dataService = dataService;
        }


        [HttpGet("type/{type}", Name = nameof(GetTitles))]
        //[Authorize(Roles = "admin")]
        public IActionResult GetTitles(string type, int page = 0, int pageSize = 10)
        {
            (var titles, var total) = _dataService.GetTitles(page, pageSize, type);

            var items = titles.Select(CreateTitleModel);

            var result = Paging(items, total, page, pageSize, nameof(GetTitles));

            return Ok(result);
        }

        [HttpGet("{id}", Name = nameof(GetTitle))]
        public IActionResult GetTitle(string id)
        {
            var title = _dataService.GetTitle(id);
            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        [HttpGet("similar/{id}")]
        public IActionResult GetSimilarTitles(string id)
        {
            var title = _dataService.GetSimilarTitles(id);
            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        [HttpGet("search/{userId}/{searchString}")]
        public IActionResult GetSearch(int userId, string searchString )
        {
            var search = _dataService.GetSearch(userId, searchString);
            if (search == null)
            {
                return NotFound();
            }

            return Ok(search);
        }

        private TitleModel CreateTitleModel(TitlePosterDto title)
        {
            return new TitleModel
            {
                Url = GetUrl(nameof(GetTitle), new { title.Id }).Replace("%20", ""),
                PrimaryTitle = title.PrimaryTitle,
                Poster = title.Poster,
                WeightAvgRating = title.WeightAvgRating
            };
        }
    }
}
