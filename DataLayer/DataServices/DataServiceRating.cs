using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data.SqlTypes;
using WebServer;

namespace DataLayer.DataServices
{
    public class DataServiceRating : IDataServiceRating
    {
        public List<UserRating> GetRatings(int userId)
        {
            var db = new DatabaseContext();
            return db.UsersRatings.Where(x => x.UserId == userId)
                .Select(rating => new UserRating
                {
                    UserId = rating.UserId,
                    Id = rating.Id

                }).ToList();

        }

        public UserRating? GetRating(string id, int userId )
        {
            var db = new DatabaseContext();
            return db.UsersRatings.FirstOrDefault(x => x.UserId == userId && x.Id == id);
        }
        public UserRating? CreateNewRating(int userId, string id, int rating)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from update_rating({userId}, {id}, {rating} )");
            return GetRating(id, userId);
        }
        //TODO the database does not contain a DeleteRating function as of yet 
    }
}