using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ReSTful_letcom_user_management_API.Models
{
    [BsonIgnoreExtraElements]
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;


        [BsonElement("email")]
        public string Email { get; set; } = String.Empty;


        [BsonElement("password")]
        public string Password { get; set; } = String.Empty;


        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("is_suspended")]
        public bool Is_suspended { get; set; }

        [BsonElement("role")]
        public string Role { get; set; } = String.Empty;

    }
}
