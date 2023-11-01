using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class DataTable
    {
        public string Id { get; set; }
        public string? OmdbPoster { get; set; }
        public string? OmdbPlot { get; set; }
    }
}
