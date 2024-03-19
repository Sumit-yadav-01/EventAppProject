using EventsServices.Models;
using MongoDB.Driver;

namespace EventsServices.Services
{
  public class UserService : IUserService
  {
    // add contructor with MongoClient and IConfiguration
    private readonly IConfiguration _configuration;
    private readonly MongoClient _client;
    private readonly IMongoCollection<Users> _user;
    private readonly IMongoCollection<UserEvents> _userEvents;
    public UserService(IConfiguration configuration)
    {
      _configuration = configuration;
      _client = new MongoClient(_configuration.GetConnectionString("DefaultConnection"));
      var mongoDatabase = _client.GetDatabase("EventApp_symd");
      _user = mongoDatabase.GetCollection<Users>("users");
      _userEvents = mongoDatabase.GetCollection<UserEvents>("user_events");
    }

    //Implement IUserService
    public async Task<Users> AuthenticateUser(string userId, string password)
    {
      var user = await _user.Find(u => u.user_id == userId && u.password == password).FirstOrDefaultAsync();

      return user;
    }

    public async Task<Users> GetUser(string userId)
    {
      var user = await _user.Find(u => u.user_id == userId).FirstOrDefaultAsync();
      return user;
    }

    public async Task<bool> AddUser(RegisterModel user)
    {
      //check if user already exists
      var existingUser = await _user.Find(u => u.user_id == user.userId || u.email == user.email).FirstOrDefaultAsync();
      if (existingUser != null)
      {
        return false;
      }

      //create new user object and assign values
      var newUser = new Users
      {
        user_id = user.userId,
        first_name = user.firstName,
        last_name = user.lastName,
        email = user.email,
        password = user.password
      };

      //add user to the database 
      await _user.InsertOneAsync(newUser);
      return true;
    }

    public async Task<bool> UpdateUser(Users user)
    {
      var updateResult = await _user.ReplaceOneAsync(filter: u => u.user_id == user.user_id, replacement: user);
      return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteUser(string userId)
    {
      var deleteResult = await _user.DeleteOneAsync(u => u.user_id == userId);
      return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

  }
}
