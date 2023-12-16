using DataLayer.IDataServices;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer;

namespace DataLayer.DataServices
{
    public class DataServicePerson : IDataServicePerson
    {
        public Person? GetPerson(string id)
        {
            var db = new DatabaseContext();
            return db.Persons.FirstOrDefault(x => x.Id == id);
        }
    }
}
