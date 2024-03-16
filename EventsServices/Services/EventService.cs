using EventsServices.Models;
using System.Text.Json;

namespace EventsServices.Services
{
  public class EventService : IEventService
  {
    // add constructor and inject Iconfiguration
    private readonly IConfiguration _configuration;
    public EventService(IConfiguration configuration)
    {
      _configuration = configuration;
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
  }
}
