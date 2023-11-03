using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Title
    {
        public string? Id { get; set; }
        public string? Type { get; set; }
        public string? PrimaryTitle { get; set; }
        public string? StartYear { get; set; }
        public string? EndYear { get; set; }
        public string? OmdbTitle { get; set; }
        public string? OmdbYear { get; set; }
        public string? OmdbReleaseDate { get; set; }
    }
}
