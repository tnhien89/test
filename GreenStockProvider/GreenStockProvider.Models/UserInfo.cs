using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenStockProvider.Models
{
    //public class PersonInfo
    //{
    //    [BsonElement("first")]
    //    public string FirstName { get; set; }
    //    [BsonElement("last")]
    //    public string LastName { get; set; }
    //}

    //[BsonIgnoreExtraElements]
    public class UserInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("user_fullname")]
        public string FullName { get; set; }
        [BsonElement("user_type")]
        public int Type { get; set; }
        [BsonElement("user_type_name")]
        public string TypeName { get; set; }
        [BsonElement("user_role")]
        public int Role { get; set; }
        [BsonElement("user_role_name")]
        public string RoleName { get; set; }
        [BsonElement("license_type")]
        public int LicenseType { get; set; }
        [BsonElement("license_type_name")]
        public string LicenseTypeName { get; set; }
        [BsonElement("status")]
        public int Status { get; set; }
        [BsonElement("status_name")]
        public string StatusName { get; set; }
        // insert only
        [BsonElement("created_date_in_long")]
        public long CreatedDateInLong { get; set; }
        [BsonElement("created_date_string")]
        public string CreatedDateString { get; set; }
        // insert and update
        [BsonElement("modified_date_in_long")]
        public long ModifiedDateInLong { get; set; }
        [BsonElement("modified_date_string")]
        public string ModifiedDateString { get; set; }
    }
}
