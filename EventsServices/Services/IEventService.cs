using EventsServices.Models;

namespace EventsServices.Services
{
  public interface IEventService
  {
    // add getEvents() method
    Task<Events> GetEvents();

    // add getEventDetails() method
    Task<EventDetails> GetEventDetails(string eventId);

    //add AddFavouriteEvent() method
    Task<bool> AddFavouriteEvent(string events, string userId);

    // add remove favourite event method
    Task<bool> RemoveFavouriteEvent(string eventId, string userId);

    // add getFavouriteEvents method
    Task<List<UserEvents>> GetFavouriteEvents(string userId);
  }
}
