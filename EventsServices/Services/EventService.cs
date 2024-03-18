using EventsServices.Models;
using MongoDB.Driver;
using System.Text.Json;

namespace EventsServices.Services
{
  public class EventService : IEventService
  {
    // add constructor and inject Iconfiguration
    private readonly IConfiguration _configuration;
    private readonly MongoClient _client;
    private readonly IMongoCollection<UserEvents> _userEvents;
    private readonly IMongoCollection<Users> _user;
    public EventService(IConfiguration configuration)
    {
      _configuration = configuration;
      _client = new MongoClient(_configuration.GetConnectionString("DefaultConnection"));
      var mongoDatabase = _client.GetDatabase("EventApp_symd");
      _userEvents = mongoDatabase.GetCollection<UserEvents>("user_events");
      _user = mongoDatabase.GetCollection<Users>("users");
    }

    //Implement IEventService
    public async Task<Events> GetEvents()
    {

      var apiUrl = "https://api.seatgeek.com/2/events?client_id=NDA0MDM5ODR8MTcxMDQ3OTQwMi45NzM3MTkx&client_secret=59c750f975f178764ac1e0bd85872243f245dfbc03cb9ff4db8495a1f137d6ea";

      //make a call to apiUrl and get the response

      HttpClient client = new HttpClient();
      var response = await client.GetAsync(apiUrl);

      if (response.IsSuccessStatusCode)
      {
        var content = await response.Content.ReadAsStringAsync();
        //deserialise content to a list of events
        var events = JsonSerializer.Deserialize<Events>(content);
        return events;
      }
      else
      {
        return null;
      }
    }

    //Implement EventDetails method to get event details
    public async Task<EventDetails> GetEventDetails(string eventId)
    {
      var apiUrl = $"https://api.seatgeek.com/2/events/{eventId}?client_id=NDA0MDM5ODR8MTcxMDQ3OTQwMi45NzM3MTkx&client_secret=59c750f975f178764ac1e0bd85872243f245dfbc03cb9ff4db8495a1f137d6ea";

      //make a call to apiUrl and get the response

      HttpClient client = new HttpClient();
      var response = await client.GetAsync(apiUrl);

      if (response.IsSuccessStatusCode)
      {
        var content = await response.Content.ReadAsStringAsync();
        //deserialise content to a list of events
        var events = JsonSerializer.Deserialize<EventDetails>(content);
        return events;
      }
      else
      {
        return null;
      }
    }

    //Implement AddFavorite method to add event to favorites
    public async Task<bool> AddFavouriteEvent(string eventId, string userId)
    {
      try
      {
        // check if user exists
        var user = await _user.Find(x => x.user_id == userId).FirstOrDefaultAsync();

        if (user == null)
        {
          return false;
        }

        // check if user event already exists exists
        var userEventExists = await _userEvents.Find(x => x.event_id == eventId && x.user_id == userId).FirstOrDefaultAsync();

        if (userEventExists != null)
        {
          return false;
        }

        var userEvent = new UserEvents
        {
          event_id = eventId,
          user_id = userId
        };

        await _userEvents.InsertOneAsync(userEvent);
        return true;

      }
      catch (Exception ex)
      {
        return false;
      }
    }

    //Implement RemoveFavorite method to remove event from favorites
    public async Task<bool> RemoveFavouriteEvent(string eventId, string userId)
    {
      try
      {
        var userEvent = await _userEvents.Find(x => x.event_id == eventId && x.user_id == userId).FirstOrDefaultAsync();

        if (userEvent == null)
        {
          return false;
        }

        await _userEvents.DeleteOneAsync(x => x.event_id == eventId && x.user_id == userId);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    //Implement GetFavouriteEvents method to get user's favorite events
    public async Task<List<UserEvents>> GetFavouriteEvents(string userId)
    {
      var userEvents = await _userEvents.Find(x => x.user_id == userId).ToListAsync();

      return userEvents;
    }
  }
}
