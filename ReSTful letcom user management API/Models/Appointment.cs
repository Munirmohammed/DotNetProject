using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace REST_letcom_API_V2.Models
{
        [BsonIgnoreExtraElements]
        public class Appointment
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; } = String.Empty;

            [BsonElement("name_of_HI")]
            public string HI_Name { get; set; } = String.Empty;
            [BsonElement("name_of_Assitant")]
            public string  Assitant_Name { get; set; } = String.Empty;

            [BsonElement("completed")]
            public bool IsCompleted { get; set; }

            [BsonElement("appointment_date")]
            public string Appointment_date { get; set; } = String.Empty;
            [BsonElement("appointment_Time")]
            public string Appointment_time { get; set; } = String.Empty;
            [BsonElement("appointment_place")]
            public string Appointment_place { get; set; } = String.Empty;

            [BsonElement("fee")]
            public int Fee { get; set; }
        }
}
