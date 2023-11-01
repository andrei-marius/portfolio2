using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class RegionalInfo
    {
        public string Id { get; set; }
        public string? Region { get; set; }
        public bool Language { get; set; }
        public int? OmdbLanguage { get; set; }
        public string? OmdbCountry { get; set; }
    }

}
