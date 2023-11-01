using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string? FullName { get; set; }
        public string? BirthYear { get; set; }
        public string? DeathYear { get; set; }
        public string? Profession { get; set; }
        public string? KnownForTitles { get; set; }
    }
}
