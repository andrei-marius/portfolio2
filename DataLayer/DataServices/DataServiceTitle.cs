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

            var titles = db.Titles2
                .Join(
                    db.Rankings,
                    title => title.Id,
                    ranking => ranking.Id,
                    (title, ranking) => new { Title = title, Ranking = ranking }
                )
                .Where(x => x.Title.Type == type)
                .OrderByDescending(x => x.Ranking.AverageRating)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(x => new TitlePosterDto
                {
                    Id = x.Title.Id,
                    Poster = x.Title.Poster,
                    WeightAvgRating = x.Title.WeightAvgRating,
                    Name = x.Title.Name,
                    Type = x.Title.Type,
                })
                .ToList();

            var count = db.Titles2.Count(x => x.Type == type);

            return (titles, count);
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
        public IList<SearchDto> GetSearch2(string searchString )
        {
            var db = new DatabaseContext();
            var titles = db.SearchResults2.FromSql($"select * from NewSearch2({searchString})")
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
                .Join(
                    db.Rankings,
                    title => title.Id,
                    ranking => ranking.Id,
                    (title, ranking) => new { Title = title, Ranking = ranking }
                )
                .OrderByDescending(x => x.Ranking.AverageRating)
                .Skip(page * pageSize)
                .Take(pageSize)
                .Select(x => new TitlePosterDto
                {
                    Id =x.Title.Id,
                    Poster = x.Title.Poster,
                    WeightAvgRating = x.Title.WeightAvgRating,
                    Name = x.Title.Name,
                    Type = x.Title.Type,
                })
                .ToList();

            var totalTitles = db.TitleGenres
                .Where(x => x.Genres == genreName)
                .Count();

            return (titles, totalTitles);
        }



    }
}