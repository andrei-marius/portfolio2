using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class MetaDataTable
    {
        public string Id { get; set; }
        public string? OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public int? RuntimeMinutes { get; set; }
        public string? RunTime { get; set; }
        public bool IsOriginalTitle { get; set; }
        public int Ordering { get; set; }
        public string? AkasTypes { get; set; }
        public string? AkasAttributes { get; set; }
        public string? Response { get; set; }
        public string? Production { get; set; }
        public string? Website { get; set; }
        public string? DvdRelease { get; set; }
    }
}
