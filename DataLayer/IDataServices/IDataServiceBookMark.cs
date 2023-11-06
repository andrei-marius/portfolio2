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

        BookMarks? AddBookMark(int userId, string titleId, string userNote);

        BookMarks? UpdateBookMark(int userId, int bookmarkId, string userNote);    

        string? RemoveBookMark(int userId, int bookmarkId);

        string? RemoveBookMarks(int userId);
        BookMarks? GetBookMark(int bookmarkId, int userId);
        List<BookMarks>? GetBookMarks(int userId);
    }
}