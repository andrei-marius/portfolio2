﻿using DataLayer.IDataServices;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data.SqlTypes;
using WebServer;

namespace DataLayer.DataServices
{
    public class DataServiceUser : IDataServiceUser
    {

        public User? GetUser(string username)
        {
            var db = new DatabaseContext();
            return db.Users.FirstOrDefault(x => x.UserName == username);
            //return db.Categories.Find(categoryId);
        }
      
        public User SQLCreateUser(string username, string password)
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from create_user({username}, {password})");
            return GetUser(username);
        } 
        //TO-DO Split this into two functions in the database
        public User SQLUpdateUser(int id, string newUserName, string newPassword) 
        {
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from update_user({id}, {newUserName}, {newPassword})");
            return GetUser(newUserName);
        }

        public string SQLDeleteUser(string username) 
        { 
            var db = new DatabaseContext();
            var res = db.Database.ExecuteSqlInterpolated($"select * from delete_user({username})");
            return $"The user: {username} has been deleted";
        }
    }
}