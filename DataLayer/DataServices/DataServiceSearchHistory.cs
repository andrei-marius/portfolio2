using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DTOs;
using DataLayer.IDataServices;
using DataLayer.Models;
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
                    Id = x.HistoryId,
                    SearchQuery = x.SearchQuery,
                    TimeStamp = x.TimeStamp
                });

            return searchHistory.ToList();
        }

        public bool DeleteSearchHistory(int userID)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"delete from search_history where user_id = {userID}");
            return db.SearchHistorys.Select(x => x.UserId == userID ).FirstOrDefault() ? false : true;
        }

        public bool DeleteSearchHistoryById(int userId, int historyid) { 
        
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"delete from search_history where user_id = {userId} and historyid = {historyid}");
            return db.SearchHistorys.Select(x => x.HistoryId == historyid).FirstOrDefault() ? false : true;
        }
    }
}
