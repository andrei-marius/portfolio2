using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class SearchHistoryDto
    {
        public string SearchQuery { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}