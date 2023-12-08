using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class TitlePosterDto
    {
        public string? Id { get; set; }
        public string? Poster { get; set; }
        public string? Name { get; set; }
        public double WeightAvgRating { get; set; }
        public string Type { get; set; }
    }
}
