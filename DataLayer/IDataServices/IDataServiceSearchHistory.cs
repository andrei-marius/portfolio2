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
        bool DeleteSearchHistory(int userId);

        bool DeleteSearchHistoryById(int userId,int historyId);
    }
}
