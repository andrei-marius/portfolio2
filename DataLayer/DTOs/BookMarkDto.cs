using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class BookMarkDto
    {
        public int UserId { get; set; }
        public int BookmarkId { get; set; }
        public string? UserNote { get; set; }
    }
}
