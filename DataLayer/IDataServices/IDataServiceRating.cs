using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataServices
{
    public interface IDataServiceRating
    {
        List<UserRating>? GetRatings(int userId);
        UserRating? GetRating(string id, int userId);
        UserRating? CreateNewRating(int userId, string id, int rating);
    }
}
