using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MediaTypeTable
    {
        public string Id { get; set; }
        public string? EpisodeId { get; set; }
        public string? SeriesId { get; set; }
        public string? EpisodeNumber { get; set; }
        public string? Episode { get; set; }
        public string? SeasonNumber { get; set; }
        public string? TotalSeasons { get; set; }
    }
}
