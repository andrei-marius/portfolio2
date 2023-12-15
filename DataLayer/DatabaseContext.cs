using DataLayer.DTOs;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection.Emit;

namespace WebServer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Title> Titles { get; set; }
        public DbSet<TitlePosterDto> Titles2 { get; set; }
        public DbSet<TitleComplete> Titles3 { get; set; }
        public DbSet<MediaTypeTable> MediaTypes { get; set; }
        public DbSet<MediaTable> MediaTables { get; set; }
        public DbSet<DataLayer.Models.DataTable> DataTables { get; set; }
        public DbSet<MetaDataTable> MetaDataTables { get; set; }
        public DbSet<Rankings> Rankings { get; set; }
        public DbSet<RegionalInfo> RegionalInfos { get; set; }
        public DbSet<TitleGenre> TitleGenres { get; set; }
        public DbSet<Crew> Crews { get; set; } 
        public DbSet<Casting> Castings { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonRatings> PersonRatings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRating> UsersRatings { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<BookMarks> BookMarks { get; set; }
        public DbSet<SearchHistory> SearchHistorys { get; set; }
        public DbSet<WorkedOn> workedOns { get; set; }
        public DbSet<SearchDto> SearchResults { get; set; }
        public DbSet<SearchDto2> SearchResults2 { get; set; }
        public DbSet<BookMarkPosterDto> BookMarkPosterDtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder
                .LogTo(Console.Out.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseNpgsql("host=cit.ruc.dk;db=cit08;uid=cit08;pwd=GGo10g6h7ypY");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchDto2>().ToFunction("newsearch3");
            modelBuilder.Entity<SearchDto2>().HasNoKey();
            modelBuilder.Entity<SearchDto2>().Property(x => x.Id).HasColumnName("result_id");
            modelBuilder.Entity<SearchDto2>().Property(x => x.SearchString).HasColumnName("result_title");

            modelBuilder.Entity<SearchDto2>().ToFunction("newsearch4");
            modelBuilder.Entity<SearchDto2>().HasNoKey();
            modelBuilder.Entity<SearchDto2>().Property(x => x.Id).HasColumnName("result_id");
            modelBuilder.Entity<SearchDto2>().Property(x => x.SearchString).HasColumnName("result_title");

            modelBuilder.Entity<TitlePosterDto>().ToView("posterview1");
            modelBuilder.Entity<TitlePosterDto>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<TitlePosterDto>().Property(x => x.Poster).HasColumnName("omdb_poster");
            modelBuilder.Entity<TitlePosterDto>().Property(x => x.Name).HasColumnName("primary_title");
            modelBuilder.Entity<TitlePosterDto>().Property(x => x.WeightAvgRating).HasColumnName("average_rating");
            modelBuilder.Entity<TitlePosterDto>().Property(x => x.Type).HasColumnName("title_type");

            modelBuilder.Entity<BookMarkPosterDto>().ToFunction("bookmarks_poster");
            modelBuilder.Entity<BookMarkPosterDto>().HasKey(x => new { x.UserId });
            modelBuilder.Entity<BookMarkPosterDto>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<BookMarkPosterDto>().Property(x => x.BookmarkId).HasColumnName("bookmark_id");
            modelBuilder.Entity<BookMarkPosterDto>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<BookMarkPosterDto>().Property(x => x.UserNote).HasColumnName("user_note");
            modelBuilder.Entity<BookMarkPosterDto>().Property(x => x.OmdbPoster).HasColumnName("omdb_poster");
            modelBuilder.Entity<BookMarkPosterDto>().Property(x => x.PrimaryTitle).HasColumnName("primary_title");

            modelBuilder.Entity<TitleComplete>().ToTable("displaytable");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<TitleComplete>().Property(x => x.PrimaryTitle).HasColumnName("primary_title");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Type).HasColumnName("title_type");
            modelBuilder.Entity<TitleComplete>().Property(x => x.StartYear).HasColumnName("start_year");
            modelBuilder.Entity<TitleComplete>().Property(x => x.EndYear).HasColumnName("end_year");
            modelBuilder.Entity<TitleComplete>().Property(x => x.OmdbReleaseDate).HasColumnName("omdb_release_date");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Rated).HasColumnName("rated");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Year).HasColumnName("year");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Runtime).HasColumnName("runtime");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Poster).HasColumnName("poster");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Director).HasColumnName("director");
            modelBuilder.Entity<TitleComplete>().Property(x => x.TotalSeasons).HasColumnName("totalseasons");
            modelBuilder.Entity<TitleComplete>().Property(x => x.BoxOffice).HasColumnName("box_office");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Country).HasColumnName("country");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Actors).HasColumnName("actors");
            modelBuilder.Entity<TitleComplete>().Property(x => x.Writer).HasColumnName("writer");
            modelBuilder.Entity<TitleComplete>().Property(x => x.WeightAvgRating).HasColumnName("average_weighted_rating");


            modelBuilder.Entity<Title>().ToTable("title");
            modelBuilder.Entity<Title>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<Title>().Property(x => x.Type).HasColumnName("title_type");
            modelBuilder.Entity<Title>().Property(x => x.PrimaryTitle).HasColumnName("primary_title");
            modelBuilder.Entity<Title>().Property(x => x.StartYear).HasColumnName("start_year");
            modelBuilder.Entity<Title>().Property(x => x.EndYear).HasColumnName("end_year");
            modelBuilder.Entity<Title>().Property(x => x.OmdbTitle).HasColumnName("omdb_title");
            modelBuilder.Entity<Title>().Property(x => x.OmdbYear).HasColumnName("omdb_year");
            modelBuilder.Entity<Title>().Property(x => x.OmdbReleaseDate).HasColumnName("omdb_release_date");


            modelBuilder.Entity<MediaTypeTable>().ToTable("media_type");
            modelBuilder.Entity<MediaTypeTable>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<MediaTypeTable>().Property(x => x.EpisodeId).HasColumnName("episodeid");
            modelBuilder.Entity<MediaTypeTable>().Property(x => x.SeriesId).HasColumnName("series_id");
            modelBuilder.Entity<MediaTypeTable>().Property(x => x.EpisodeNumber).HasColumnName("episodenumber");
            modelBuilder.Entity<MediaTypeTable>().Property(x => x.Episode).HasColumnName("episode");
            modelBuilder.Entity<MediaTypeTable>().Property(x => x.SeasonNumber).HasColumnName("seasonnumber");
            modelBuilder.Entity<MediaTypeTable>().Property(x => x.TotalSeasons).HasColumnName("total_seasons");


            modelBuilder.Entity<MediaTable>().ToTable("media");
            modelBuilder.Entity<MediaTable>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<MediaTable>().Property(x => x.Type).HasColumnName("type");
            modelBuilder.Entity<MediaTable>().Property(x => x.ParentalGuidance).HasColumnName("parental_guidance");


            modelBuilder.Entity<DataLayer.Models.DataTable>().ToTable("data");
            modelBuilder.Entity<DataLayer.Models.DataTable>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<DataLayer.Models.DataTable>().Property(x => x.OmdbPoster).HasColumnName("omdb_poster");
            modelBuilder.Entity<DataLayer.Models.DataTable>().Property(x => x.OmdbPlot).HasColumnName("omdb_plot");


            modelBuilder.Entity<MetaDataTable>().ToTable("metadata");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.OriginalTitle).HasColumnName("original_title");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.IsAdult).HasColumnName("is_adult");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.RuntimeMinutes).HasColumnName("runtime_minutes");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.RunTime).HasColumnName("runtime");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.IsOriginalTitle).HasColumnName("is_original_title");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.AkasTypes).HasColumnName("akas_types");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.AkasAttributes).HasColumnName("akas_attributes");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.Response).HasColumnName("response");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.Production).HasColumnName("production");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.Website).HasColumnName("website");
            modelBuilder.Entity<MetaDataTable>().Property(x => x.DvdRelease).HasColumnName("dvd_release");


            modelBuilder.Entity<Rankings>().ToTable("rankings");
            modelBuilder.Entity<Rankings>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<Rankings>().Property(x => x.AverageRating).HasColumnName("average_rating");
            modelBuilder.Entity<Rankings>().Property(x => x.NumVotes).HasColumnName("num_votes");
            modelBuilder.Entity<Rankings>().Property(x => x.Ratings).HasColumnName("ratings");
            modelBuilder.Entity<Rankings>().Property(x => x.Metascore).HasColumnName("metascore");
            modelBuilder.Entity<Rankings>().Property(x => x.ImdbRating).HasColumnName("imdb_rating");
            modelBuilder.Entity<Rankings>().Property(x => x.Awards).HasColumnName("awards");
            modelBuilder.Entity<Rankings>().Property(x => x.ImdbVotes).HasColumnName("imdb_votes");
            modelBuilder.Entity<Rankings>().Property(x => x.BoxOffice).HasColumnName("box_office");


            modelBuilder.Entity<RegionalInfo>().ToTable("regional_info");
            modelBuilder.Entity<RegionalInfo>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<RegionalInfo>().Property(x => x.Region).HasColumnName("region");
            modelBuilder.Entity<RegionalInfo>().Property(x => x.Language).HasColumnName("language");
            modelBuilder.Entity<RegionalInfo>().Property(x => x.OmdbLanguage).HasColumnName("omdb_language");
            modelBuilder.Entity<RegionalInfo>().Property(x => x.OmdbCountry).HasColumnName("omdb_country");


            modelBuilder.Entity<TitleGenre>().ToTable("title_genre");
            modelBuilder.Entity<TitleGenre>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<TitleGenre>().Property(x => x.Genres).HasColumnName("genres");


            modelBuilder.Entity<Crew>().ToTable("crew");
            modelBuilder.Entity<Crew>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<Crew>().Property(x => x.Directors).HasColumnName("directors");
            modelBuilder.Entity<Crew>().Property(x => x.Writers).HasColumnName("writers");


            modelBuilder.Entity<Casting>().ToTable("casting");
            modelBuilder.Entity<Casting>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<Casting>().Property(x => x.Ordering).HasColumnName("ordering");
            modelBuilder.Entity<Casting>().Property(x => x.PersonId).HasColumnName("person_id");
            modelBuilder.Entity<Casting>().Property(x => x.Category).HasColumnName("category");
            modelBuilder.Entity<Casting>().Property(x => x.Job).HasColumnName("job");
            modelBuilder.Entity<Casting>().Property(x => x.Characters).HasColumnName("characters");
            modelBuilder.Entity<Casting>().Property(x => x.Writer).HasColumnName("writer");
            modelBuilder.Entity<Casting>().Property(x => x.Actors).HasColumnName("actors");
            modelBuilder.Entity<Casting>().Property(x => x.Director).HasColumnName("director");
            modelBuilder.Entity<Casting>().Property(x => x.DirectorId).HasColumnName("directorid");


            modelBuilder.Entity<Person>().ToTable("person");
            modelBuilder.Entity<Person>().Property(x => x.Id).HasColumnName("person_id");
            modelBuilder.Entity<Person>().Property(x => x.FullName).HasColumnName("fullname");
            modelBuilder.Entity<Person>().Property(x => x.BirthYear).HasColumnName("birth_year");
            modelBuilder.Entity<Person>().Property(x => x.DeathYear).HasColumnName("death_year");
            modelBuilder.Entity<Person>().Property(x => x.Profession).HasColumnName("profession");
            modelBuilder.Entity<Person>().Property(x => x.KnownForTitles).HasColumnName("known_for_titles");


            modelBuilder.Entity<PersonRatings>().ToTable("person_ratings");
            modelBuilder.Entity<PersonRatings>().Property(x => x.Id).HasColumnName("person_id");
            modelBuilder.Entity<PersonRatings>().Property(x => x.WeightedAverage).HasColumnName("weighted_average");


            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasKey(x => new { x.UserId });
            modelBuilder.Entity<User>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<User>().Property(x => x.UserName).HasColumnName("username");
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("password");
            modelBuilder.Entity<User>().Property(x => x.Salt).HasColumnName("salt");
            modelBuilder.Entity<User>().Property(x => x.Role).HasColumnName("role");


            modelBuilder.Entity<UserRating>().ToTable("user_rating");
            modelBuilder.Entity<UserRating>().HasKey(x => new { x.UserId, x.TitleId });
            modelBuilder.Entity<UserRating>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<UserRating>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<UserRating>().Property(x => x.Rating).HasColumnName("rating");
            modelBuilder.Entity<UserRating>().Property(x => x.TimeStamp).HasColumnName("timestamp");


            modelBuilder.Entity<Notes>().ToTable("notes");
            modelBuilder.Entity<Notes>().HasKey(x => new { x.UserId, x.Id });
            modelBuilder.Entity<Notes>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<Notes>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<Notes>().Property(x => x.UserNote).HasColumnName("user_note");

            // either change the update function to require the titleID of the movie, or change the composite key declaration
            modelBuilder.Entity<BookMarks>().ToTable("bookmarks");
            modelBuilder.Entity<BookMarks>().HasKey(x => new { x.UserId,x.BookmarkId, x.TitleId });
            modelBuilder.Entity<BookMarks>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<BookMarks>().Property(x => x.BookmarkId).HasColumnName("bookmark_id");
            modelBuilder.Entity<BookMarks>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<BookMarks>().Property(x => x.UserNote).HasColumnName("user_note");



            modelBuilder.Entity<SearchHistory>().ToTable("search_history");
            modelBuilder.Entity<SearchHistory>().HasNoKey();
            modelBuilder.Entity<SearchHistory>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder.Entity<SearchHistory>().Property(x => x.SearchQuery).HasColumnName("search_query");
            modelBuilder.Entity<SearchHistory>().Property(x => x.TimeStamp).HasColumnName("timestamp");
            modelBuilder.Entity<SearchHistory>().Property(x => x.HistoryId).HasColumnName("historyid");

            modelBuilder.Entity<WorkedOn>().ToView("workedon");
            modelBuilder.Entity<WorkedOn>().HasKey(x => x.PersonId);
            modelBuilder.Entity<WorkedOn>().Property(x => x.PersonId).HasColumnName("person_id");
            modelBuilder.Entity<WorkedOn>().Property(x => x.NumberOfTitles).HasColumnName("numof_titles");
            modelBuilder.Entity<WorkedOn>().Property(x => x.FullName).HasColumnName("fullname");
            modelBuilder.Entity<WorkedOn>().Property(x => x.TitleId).HasColumnName("title_id");
            modelBuilder.Entity<WorkedOn>().Property(x => x.PrimaryTitle).HasColumnName("primary_title");
            
        }
    }
}