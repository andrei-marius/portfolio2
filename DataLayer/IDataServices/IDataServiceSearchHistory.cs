using DataLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataServices
{
    public interface IDataServiceSearchHistory
    {
        IList<SearchHistoryDto> GetSearchHistory(int userId);
        string DeleteSearchHistory(int userId);

        string DeleteSearchHistoryById(int userId,int historyId);
    }
}
