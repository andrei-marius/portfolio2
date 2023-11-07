﻿using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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


        [HttpGet(Name = nameof(GetTitles))]
        [Authorize(Roles = "admin")]
        public IActionResult GetTitles(int page = 0, int pageSize = 10)
        {
            (var titles, var total) = _dataService.GetTitles(page, pageSize);

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

        private TitleModel CreateTitleModel(Title title)
        {
            return new TitleModel
            {
                Url = GetUrl(nameof(GetTitle), new { title.Id }).Replace("%20", ""),
                Name = title.PrimaryTitle,
            };
        }
    }
}
