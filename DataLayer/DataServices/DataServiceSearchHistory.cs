using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DTOs;
using DataLayer.IDataServices;
using Microsoft.EntityFrameworkCore;
using WebServer;

namespace DataLayer.DataServices
{
    public class DataServiceSearchHistory : IDataServiceSearchHistory
    {
        public IList<SearchHistoryDto> GetSearchHistory(int userId)
        {
            var db = new DatabaseContext();
            var searchHistory = db.SearchHistorys.FromSql($"select * from get_search_history({userId})")
                .Select(x => new SearchHistoryDto
                {
                    SearchQuery = x.SearchQuery,
                    TimeStamp = x.TimeStamp
                });
                   
            return searchHistory.ToList();
        }
    }
}
