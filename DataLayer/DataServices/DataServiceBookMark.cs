using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data.SqlTypes;
using WebServer;

namespace DataLayer.DataServices
{
    public class DataServiceBookMark : IDataServiceBookMark
    {
       

      
        public BookMarks? SQLAddBookMark(int userId, string titleId)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from add_bookmark({userId}, {titleId})");
            return GetBookMark(titleId, userId);
        }

        public string? SQLRemoveBookMark(int userId, string titleId)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from remove_bookmark({userId}, {titleId})");
            return $"The user: {userId}, your bookmark {titleId} has been deleted";
        }

        public BookMarks? GetBookMark(string id, int userId)
        {
            var db = new DatabaseContext();
            return db.BookMarks.FirstOrDefault(x => x.Id == id && x.UserId == userId);
        }

        public List<BookMarks> GetBookMarks(int userId)

        {
            var db = new DatabaseContext();
            return db.BookMarks.Where(bookmark => bookmark.UserId == userId)
                .Select( bookmark => new BookMarks
                {
                  UserId = bookmark.UserId,
                  Id = bookmark.Id

                }).ToList();
        }

    }
}