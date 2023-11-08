using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class WorkedOn
    {
        public string PersonId { get; set; }
        public int NumberOfTitles { get; set; }
        public string? FullName { get; set; }
        public string? TitleId { get; set; }
        public string? PrimaryTitle { get; set;}
    }
}
