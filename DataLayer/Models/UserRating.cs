using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserRating
    {
        public int UserId { get; set; }
        public string Id { get; set; }
        public int Rating { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
