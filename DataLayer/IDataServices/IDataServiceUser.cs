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

        User? CreateUser(string username, string password);

        User? UpdateUser(int id, string newUserName, string newPassword);

        User? Login(string username, string password);
        string? DeleteUser(string username);
    }
}
