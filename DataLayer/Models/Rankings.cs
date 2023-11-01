using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Rankings
    {
        public string Id { get; set; }
        public decimal AverageRating { get; set; }
        public bool NumVotes { get; set; }
        public int? Ratings { get; set; }
        public string? Metascore { get; set; }
        public bool ImdbRating { get; set; }
        public int Awards { get; set; }
        public string? ImdbVotes { get; set; }
        public string? BoxOffice { get; set; }
    }
}
