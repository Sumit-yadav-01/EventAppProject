using MongoDB.Bson.Serialization.Attributes;

namespace EventsServices.Models
{
  public class Users
  {
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? id { get; set; }
    public string user_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string? token { get; set; }
  }

  public class LoginModel
  {
    public string userId { get; set; }
    public string password { get; set; }
  }

  //create a new class for RegisterModel
  public class RegisterModel
  {
    public string userId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string password { get; set; }
  }
}
