﻿using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;
using System.Collections.Generic;
using DataLayer.DTOs;

namespace DataLayer.IDataServices
{
    public interface IDataServiceTitle
    {
        (IList<TitlePosterDto> titles, int count) GetTitles(int page, int pageSize, string type);
        TitleComplete? GetTitle(string id);
        IList<SimilarTitleDto> GetSimilarTitles(string id);
        IList<SearchDto2> GetSearch(int userId, string searchString);
        IList<SearchDto> GetSearch2(string searchString);
        (IList<TitlePosterDto> titles, int total) GetTitlesByGenre(int page, int pageSize, string genreName);
        IList<Genre> GetGenres();
    }
}
