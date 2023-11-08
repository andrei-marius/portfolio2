using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class BookMarks
    {
        public int UserId { get; set; }
        public int BookmarkId { get; set; }
        public string TitleId { get; set; }
        public string? UserNote { get; set; }
    }
}
