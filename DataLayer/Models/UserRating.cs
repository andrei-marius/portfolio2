﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class UserRating
    {
        public int UserId { get; set; }
        public string TitleId { get; set; }
        public int Rating { get; set; }
        public DateTime TimeStamp { get; set; }
        public string? OmdbPoster { get; set;}
        public string? PrimaryTitle { get;set;}
    }
}
