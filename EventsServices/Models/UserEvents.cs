using MongoDB.Bson.Serialization.Attributes;

namespace EventsServices.Models
{
  public class UserEvents
  {
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? id { get; set; }
    public string user_id { get; set; }
    public string event_id { get; set; }
  }
}
