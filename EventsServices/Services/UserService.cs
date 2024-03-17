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
    public async Task<Users> Login(string email, string password)
    {
      var user = await _user.Find(u => u.email == email && u.password == password).FirstOrDefaultAsync();

      return user;
    }

    public async Task<Users> GetUser(string userId)
    {
      var user = await _user.Find(u => u.id == userId).FirstOrDefaultAsync();
      return user;
    }

    public async Task<bool> AddUser(Users user)
    {
      await _user.InsertOneAsync(user);
      return true;
    }

    public async Task<bool> UpdateUser(Users user)
    {
      var updateResult = await _user.ReplaceOneAsync(filter: u => u.id == user.id, replacement: user);
      return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteUser(string userId)
    {
      var deleteResult = await _user.DeleteOneAsync(u => u.id == userId);
      return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

  }
}
