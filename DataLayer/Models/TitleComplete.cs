using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class TitleComplete
    {

        public string? Id { get; set; }
        public string? PrimaryTitle { get; set; }
        public string? Type { get; set; }    
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public string? OmdbReleaseDate { get; set; }
        public string? Awards { get; set; }
        public string? Rated { get; set; }
        public string? Year { get; set; }
        public string? Runtime { get; set; }
        public string? Poster { get; set; }
        public string? Director { get; set; }
        public string? TotalSeasons { get; set; }
        public string? BoxOffice { get; set; }
        public string? Country { get; set; }
        public string? Actors { get; set; }
        public string? Writer { get; set; }
        public double? WeightAvgRating { get; set; }
    }
}
