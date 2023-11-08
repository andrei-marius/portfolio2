using DataLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataServices
{
    public interface IDataServiceOftenWorkedWith
    {
        IList<OftenWorkedWithDTO> GetOftenWorkedWith(string actorName);
    }
}
