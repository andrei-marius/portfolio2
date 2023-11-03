using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IDataServices
{
    public interface IDataServiceUser
    {
        User GetUser(string username);

        User? SQLCreateUser(string username, string password);

        User? SQLUpdateUser(int id, string newUserName, string newPassword);

        User? SQLLogin(string username, string password);

        

        string? SQLDeleteUser(string username);
    }
}
