using DataLayer.DTOs;
using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Numerics;
using WebServer;

namespace DataLayer.DataServices
{
    public class DataServiceBookMark : IDataServiceBookMark
    {


        // Due to a change in the structure in the methods in the sqlfunction, addBookmark and GetBookMark no longer contain information that allow for the call of GetBookMark in the AddBookMark
        
        public bool AddBookMark(int userId, string titleId, string userNote)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from add_bookmark({userId}, {titleId}, {userNote})");
            return db.BookMarks.Select(x => x.TitleId == titleId).FirstOrDefault() ? false : true;
        }
        
        
        //public BookMarks? AddBookMark(int userId, string titleId, string userNote)
        //{
        //    var db = new DatabaseContext();
        //    var bm = db.BookMarks.FromSql($"select * from add_bookmark2({userId}, {titleId}, {userNote})");
        //    //var bookmarkId = db.BookMarks.Where(x => x.UserId == userId && x.TitleId == titleId).Select(x => x.BookmarkId);
        //    return GetBookMark(GetBookMarkId(userId,titleId), userId);
        //}
       
        public bool? UpdateBookMark(int userId, int bookmarkId, string userNote)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select update_bookmark({userId}, {bookmarkId}, {userNote})");
            return db.BookMarks.Select(x => x.BookmarkId == bookmarkId).FirstOrDefault() != null;
        }

        // i think the call of remove_bookmark can be done with "exec" or "peform" in the call
        public bool? RemoveBookMark(int userId, int bookmarkId)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from remove_bookmark({userId}, {bookmarkId})");
            return db.BookMarks.Select(x => x.BookmarkId == bookmarkId).FirstOrDefault() ? false : true;
        }

        public bool? RemoveBookMarks(int userId)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from remove_bookmarks({userId})");
            return db.BookMarks.Select(x => x.UserId == userId).FirstOrDefault() ? false : true;
        }
        public BookMarks? GetBookMark(int bookmarkId, int userId)
        {
            var db = new DatabaseContext();
            return db.BookMarks.FirstOrDefault(x => x.BookmarkId == bookmarkId && x.UserId == userId);
        }

        public List<BookMarkPosterDto> GetBookMarks(int userId)

        {
            var db = new DatabaseContext();
            var bookmark = db.BookMarkPosterDtos.FromSql($"select * from bookmark_posters({userId})")
                .Select(x => new BookMarkPosterDto
                {
                    UserId = x.UserId,
                    BookmarkId = x.BookmarkId,
                    TitleId = x.TitleId,
                    UserNote = x.UserNote,
                    OmdbPoster = x.OmdbPoster,
                    PrimaryTitle = x.PrimaryTitle
                })
                .ToList();
            

            return (bookmark);
        }

        public int GetBookMarkId(int userId, string titleId) 
        {
            var db = new DatabaseContext();
            var bookmarkId = db.BookMarks.FirstOrDefault(x => x.UserId == userId && x.TitleId == titleId).BookmarkId;
            return bookmarkId;
        }

    }
}