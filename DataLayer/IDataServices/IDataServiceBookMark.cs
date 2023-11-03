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

        BookMarks? SQLAddBookMark(int userId, string titleId);

        string? SQLRemoveBookMark(int userId, string titleId);

        BookMarks? GetBookMark(string id, int userId);
        List<BookMarks>? GetBookMarks(int userId);
    }
}