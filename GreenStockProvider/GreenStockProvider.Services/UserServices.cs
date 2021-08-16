using GreenStockProvider.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace GreenStockProvider.Services
{
    public class UserServices
    {
        private readonly IMongoCollection<UserInfo> _users;
        public UserServices(IConnectionOption settings)
        {
            var client = new MongoClient(settings.DbConnectionString);
            var database = client.GetDatabase(settings.StockMgmtDBName);

            _users = database.GetCollection<UserInfo>(settings.UserCollectionName);
        }

        public List<UserInfo> Get() 
        {
            return _users.Find(user => true).ToList();
        }
        
        public UserInfo Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            return _users.Find(u => u.Id == id).FirstOrDefault();
        }

        public UserInfo Create(UserInfo user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var now = DateTime.UtcNow;
            user.CreatedDateInLong = now.Ticks;
            user.CreatedDateString = now.ToString("u");
            user.ModifiedDateInLong = user.CreatedDateInLong;
            user.ModifiedDateString = user.CreatedDateString;

            _users.InsertOne(user);
            return user;
        }

        public UserInfo Update(UserInfo user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            var now = DateTime.UtcNow;
            user.ModifiedDateInLong = now.Ticks;
            user.ModifiedDateString = now.ToString("u");

            var updateDefinition = Builders<UserInfo>.Update
                .Set("user_fullname", user.FullName)
                .Set("user_type", user.Type)
                .Set("user_type_name", user.TypeName)
                .Set("user_role", user.Role)
                .Set("user_role_name", user.RoleName)
                .Set("license_type", user.LicenseType)
                .Set("license_type_name", user.LicenseTypeName)
                .Set("status", user.Status)
                .Set("status_name", user.StatusName)
                .Set("modified_date_in_long", user.ModifiedDateInLong)
                .Set("modified_date_string", user.ModifiedDateString);

            var rs = _users.UpdateOne(u => u.Id == user.Id, updateDefinition);
            return user;
        }
    }
}
