using EventsServices.Models;
using EventsServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsServices.Controllers
{
  [Route("api/event")]
  [ApiController]
  public class EventsController : ControllerBase
  {
    // add contructor
    private readonly IEventService _eventService;
    public EventsController(IEventService eventService)
    {
      _eventService = eventService;
    }

    //add method to get Events
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
      var events = await _eventService.GetEvents();
      return Ok(events);
    }

    //add method to get EventDetails by event id

    [HttpGet("{eventId}")]
    public async Task<ActionResult<EventDetails>> GetEventDetails(string eventId)
    {
      var eventDetails = await _eventService.GetEventDetails(eventId);
      if (eventDetails == null)
      {
        return NotFound();
      }
      return Ok(eventDetails);
    }

    //add method to add favourite event
    [HttpPost("favourite")]
    public async Task<ActionResult<bool>> AddFavouriteEvent(string eventId, string userId)
    {
      var result = await _eventService.AddFavouriteEvent(eventId, userId);
      return Ok(result);
    }

    //create method to remove favourite event
    [HttpDelete]
    public async Task<ActionResult<bool>> RemoveFavouriteEvent(string eventId, string userId)
    {
      var result = await _eventService.RemoveFavouriteEvent(eventId, userId);
      return Ok(result);
    }
  }
}
