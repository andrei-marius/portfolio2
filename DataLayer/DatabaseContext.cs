using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace WebServer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Title> Titles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder
                .LogTo(Console.Out.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            optionsBuilder.UseNpgsql("host=cit.ruc.dk;db=cit08;uid=cit08;pwd=GGo10g6h7ypY");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Title>().ToTable("title");
            modelBuilder.Entity<Title>().Property(x => x.Id).HasColumnName("title_id");
            modelBuilder.Entity<Title>().Property(x => x.Type).HasColumnName("title_type");
            modelBuilder.Entity<Title>().Property(x => x.PrimaryTitle).HasColumnName("primary_title");
            modelBuilder.Entity<Title>().Property(x => x.StartYear).HasColumnName("start_year");
            modelBuilder.Entity<Title>().Property(x => x.EndYear).HasColumnName("end_year");
            modelBuilder.Entity<Title>().Property(x => x.OmdbTitle).HasColumnName("omdb_title");
            modelBuilder.Entity<Title>().Property(x => x.OmdbYear).HasColumnName("omdb_year");
            modelBuilder.Entity<Title>().Property(x => x.OmdbReleaseDate).HasColumnName("omdb_release_date");
        }
    }
}