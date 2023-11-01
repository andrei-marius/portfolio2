using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data.SqlTypes;
using WebServer;

namespace DataLayer.DataServices
{
    public class DataServiceTitle : IDataServiceTitle
    {
        public (IList<Title> titles, int count) GetTitles(int page, int pageSize)
        {
            var db = new DatabaseContext();
            var titles =
                db.Titles
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();
            return (titles, db.Titles.Count());
        }

        public Title? GetTitle(string id)
        {
            var db = new DatabaseContext();
            return db.Titles.FirstOrDefault(x => x.Id == id);
            //return db.Categories.Find(categoryId);
        }
    }
}