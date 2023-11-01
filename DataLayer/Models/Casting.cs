using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Casting
    {
        public string Id { get; set; }
        public int Ordering { get; set; }
        public string? PersonId { get; set; }
        public string? Category { get; set; }
        public string? Job { get; set; }
        public string? Characters { get; set; }
        public string? Writer { get; set; }
        public string? Actors { get; set; }
        public string? Director { get; set; }
        public string? DirectorId { get; set; }
    }
}
