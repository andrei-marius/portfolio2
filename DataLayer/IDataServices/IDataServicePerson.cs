using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataServices
{
    public interface IDataServicePerson
    {
        Person? GetPerson(string id);
    }
}
