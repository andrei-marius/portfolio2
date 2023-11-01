﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using System.Collections.Generic;

namespace DataLayer.IDataServices
{
    public interface IDataServiceTitle
    {
        (IList<Title> titles, int count) GetTitles(int page, int pageSize);
        Title? GetTitle(string id);
    }
}