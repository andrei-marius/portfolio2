using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NpgsqlTypes;
using WebServer.Models;

namespace WebServer.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingController : BaseController
    {
        private readonly IDataServiceRating _dataService;

        public RatingController(IDataServiceRating dataService, LinkGenerator linkGenerator)
            : base(linkGenerator)
        {
            _dataService = dataService;
        }

        [HttpGet("{userId}", Name = nameof(GetRatings))]
        public IActionResult GetRatings(int userId)
        {
            var ratings = _dataService.GetRatings(userId);
            if (ratings == null)
            {
                return NotFound();
            }
            return Ok(ratings);
        }

        [HttpGet("{userId}/{titleId}", Name = nameof(GetRating))]
        public IActionResult GetRating(int userId, string titleId)
        {
            var rating = _dataService.GetRating(titleId,userId);
            return Ok(rating);
        }

        [HttpPost]
        public IActionResult GiveRating(UserRating model) 
        {
            var rating = _dataService.CreateNewRating(model.UserId, model.TitleId, model.Rating);
            if (rating == null)
            {
                return NotFound();
            }

            return Created($"http://localhost:5001/api/ratings/{rating.UserId}", rating);
        }

        //TO-DO likely the use of a DTO that takes aspects from user & userRating would be useful here to provide meaningful info to the END USER
            /*
        private RatingModel CreateRatingModel(UserRating rating)
        {
            return new RatingModel
            {
                Url = GetUrl(nameof(GetRating), new { rating.UserId }),
                Rating = rating.Rating,
            };
        }
            */
    }
}
