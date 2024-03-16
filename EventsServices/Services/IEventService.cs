using EventsServices.Models;

namespace EventsServices.Services
{
  public interface IEventService
  {
    // add getEvents() method
    Task<Events> GetEvents();

    // add getEventDetails() method
    Task<EventDetails> GetEventDetails(string eventId);


    //// add addEvent() method
    //Task<Event> AddEvent(Event @event);
    //// add updateEvent() method
    //Task<Event> UpdateEvent(Event @event);
    //// add eventExists() method
    //bool EventExists(int id);
    //Task DeleteEvent(int id);
    //Task<bool> DeleteEventDetails(
    //  int id);
  }
}
