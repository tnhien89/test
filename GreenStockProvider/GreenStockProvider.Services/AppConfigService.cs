using GreenStockProvider.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenStockProvider.Services
{
    public class AppConfigService
    {
        private readonly IMongoCollection<AppConfigModel> _configs;

        public AppConfigService(IConnectionOption settings)
        {
            var client = new MongoClient(settings.DbConnectionString);
            var database = client.GetDatabase(settings.StockMgmtDBName);

            _configs = database.GetCollection<AppConfigModel>(settings.AppConfigCollectionName);
        }

        public List<AppConfigModel> Get()
        {
            return _configs.Find(c => true).ToList();
        }

        public AppConfigModel Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }

            return _configs.Find(c => c.Id == id).FirstOrDefault();
        }

        public AppConfigModel Create(AppConfigModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            _configs.InsertOne(model);
            return model;
        }

        public List<Strategy> GetStrategies(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(id);
            }

            var config = _configs.Find(c => c.Id == id).FirstOrDefault();
            return config.Strategies;
        }

        public int UpdateStrategies(string id, List<Strategy> strategies)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(id);
            }

            var update = Builders<AppConfigModel>.Update
                .Set("strategy_listing", strategies);
            _configs.UpdateOne(c => c.Id == id, update);

            return strategies.Count;
        }

        public AppConfigModel Update(AppConfigModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            if (string.IsNullOrEmpty(model.Id))
            {
                throw new KeyNotFoundException("model.Id");
            }

            var update = Builders<AppConfigModel>.Update
                .Set("app_version", model.AppVersion)
                .Set("last_login_date_in_long", model.LastLoginDateInLong)
                .Set("last_login_date_string", model.LastLoginDateString)
                .Set("strategy_listing", model.Strategies);

            _configs.UpdateOne(c => c.Id == model.Id, update);
            return model;
        }
    }
}
