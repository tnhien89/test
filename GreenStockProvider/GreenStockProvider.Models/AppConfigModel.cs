using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenStockProvider.Models
{
    [BsonIgnoreExtraElements]
    public class AppConfigModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("appVersion")]
        public string AppVersion { get; set; }
        [BsonElement("lastLoginDateInLong")]
        public long LastLoginDateInLong { get; set; }
        [BsonElement("lastLoginDateString")]
        public string LastLoginDateString { get; set; }
        [BsonElement("userId")]
        public string UserId { get; set; }
        [BsonElement("tdameritraCacheId")]
        public string TdameritraCacheId { get; set; }
        [BsonElement("strategy_listing")]
        public List<Strategy> Strategies { get; set; }

        public AppConfigModel()
        {
            var now = DateTime.UtcNow;
            AppVersion = "1.0.0";
            LastLoginDateInLong = now.Ticks;
            LastLoginDateString = now.ToString("u");
            Strategies = new List<Strategy>();
        }
    }
}
