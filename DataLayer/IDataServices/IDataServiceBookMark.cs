using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataServices
{
    public interface IDataServiceBookMark
    {

        bool AddBookMark(int userId, string titleId, string userNote);

        int GetBookMarkId(int userId, string titleId);

        bool? UpdateBookMark(int userId, int bookmarkId, string userNote);    

        string? RemoveBookMark(int userId, int bookmarkId);

        string? RemoveBookMarks(int userId);
        BookMarks? GetBookMark(int bookmarkId, int userId);
        List<BookMarks>? GetBookMarks(int userId);
    }
}