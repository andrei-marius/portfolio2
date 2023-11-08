using DataLayer.DTOs;
using DataLayer.IDataServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer;

namespace DataLayer.DataServices
{
    public class DataServiceOftenWorkedWith : IDataServiceOftenWorkedWith
    {
        public IList<OftenWorkedWithDTO> GetOftenWorkedWith(string actorName) 
        {
            var db = new DatabaseContext();
            var coActors = db.workedOns.FromSql($"select * from often_worked_with({actorName})")
                .Select(x => new OftenWorkedWithDTO
                {
                    person_id = x.PersonId,
                    fullname = x.FullName,
                    numberOfTitles = x.NumberOfTitles         
                }).ToList();
            return coActors;
        }
    }
}
