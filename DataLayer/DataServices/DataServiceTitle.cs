using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data.SqlTypes;
using WebServer;
using DataLayer.DTOs;

namespace DataLayer.DataServices
{
    public class DataServiceTitle : IDataServiceTitle
    {
        public (IList<TitlePosterDto> titles, int count) GetTitles(int page, int pageSize, string type)
        {
            var db = new DatabaseContext();
            var titles =
                db.Titles2
                    .Where(x => x.Type == type)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            return (titles, db.Titles.Count());
        }

        public TitleComplete? GetTitle(string id)
        {
            var db = new DatabaseContext();
            return db.Titles3.FirstOrDefault(x => x.Id == id);
            //return db.Categories.Find(categoryId);
        }

        public IList<SimilarTitleDto> GetSimilarTitles(string id)
        {
            var db = new DatabaseContext();
            var titles = db.TitleGenres.FromSql($"select * from similar_movies({id})")
                .Select(x => new SimilarTitleDto
                {
                    Id = x.Id
                });
            return titles.ToList();
        }

        public IList<SearchDto> GetSearch(int userId, string searchString )
        {
            var db = new DatabaseContext();
            var titles = db.SearchResults.FromSql($"select * from NewSearch({userId}, {searchString})")
                .Select(x => new SearchDto
                 {
                     SearchString = x.SearchString
                 });
            return titles.ToList();
        }

        public (IList<TitlePosterDto> titles, int total) GetTitlesByGenre(int page, int pageSize, string genreName)
        {
            var db = new DatabaseContext();

            var titles = db.Titles2
                .FromSql($"select * from get_titles_by_genre2({genreName})")
                .Select(x => new TitlePosterDto
                {
                    Id =x.Id,
                    Poster = x.Poster,
                    WeightAvgRating = x.WeightAvgRating,
                    Name = x.Name,
                    Type = x.Type,
                })
                .ToList();

            var totalTitles = db.TitleGenres
                .Where(x => x.Genres == genreName)
                .Count();

            return (titles, totalTitles);
        }



    }
}