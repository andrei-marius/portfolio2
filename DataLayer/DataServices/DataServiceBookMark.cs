using DataLayer.DTOs;
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
       

      // Due to a change in the structure in the methods in the sqlfunction, addBookmark and GetBookMark no longer contain information that allow for the call of GetBookMark in the AddBookMark
        public BookMarks? AddBookMark(int userId, string id, string userNote)
        {
            var db = new DatabaseContext();
            var res = db.BookMarks.FromSql($"select * from add_bookmark({userId}, {id}, {userNote}");
            var bookmarkId = res.Select(x => x.BookmarkId).FirstOrDefault();
            return GetBookMark(bookmarkId,userId);
        }

        public BookMarks? UpdateBookMark(int userId, int bookmarkId, string userNote)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from update_bookmark({userId}, {bookmarkId}, {userNote}");
            return GetBookMark(bookmarkId,userId);
        }

        // i think the call of remove_bookmark can be done with "exec" or "peform" in the call
        public string? RemoveBookMark(int userId, int bookmarkId)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from remove_bookmark({userId}, {bookmarkId})");
            return "your bookmark has been deleted";
        }

        public string? RemoveBookMarks(int userId)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from remove_bookmark({userId})");
            return "your bookmark has been deleted";
        }
        public BookMarks? GetBookMark(int bookmarkId, int userId)
        {
            var db = new DatabaseContext();
            return db.BookMarks.FirstOrDefault(x => x.BookmarkId == bookmarkId && x.UserId == userId);
        }

        public List<BookMarks> GetBookMarks(int userId)

        {
            var db = new DatabaseContext();
            return db.BookMarks.Where(bookmark => bookmark.UserId == userId)
                .Select( bookmark => new BookMarks
                {
                  UserId = bookmark.UserId,
                  BookmarkId = bookmark.BookmarkId,
                  Id = bookmark.Id,
                  UserNote = bookmark.UserNote
                  

                }).ToList();
        }

    }
}