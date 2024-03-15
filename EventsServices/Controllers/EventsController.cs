using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsServices.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EventsController : ControllerBase
  {
    // add contructor
    private readonly IEventService _eventService;
    public EventsController(IEventService eventService)
    {
      _eventService = eventService;
    }

    // add method
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
    {
      var events = await _eventService.GetEvents();
      return Ok(events);
    }

    // add method
    [HttpGet("{id}")]
    public async Task<ActionResult<Event>> GetEventDetails(int eventId)
    {
      var @event = await _eventService.GetEventDetails(eventId);
      if (@event == null)
      {
        return NotFound();
      }
      return Ok(@event);
    }

    // add method
    [HttpPost]
    public async Task<ActionResult<Event>> PostEvent(Event @event)
    {
      await _eventService.AddEvent(@event);
      return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
    }

    // add method
    [HttpPut("{id}")]

    public async Task<IActionResult> PutEvent(int id, Event @event)
    {
      if (id != @event.Id)
      {
        return BadRequest();
      }
      try
      {
        await _eventService.UpdateEvent(@event);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!_eventService.EventExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }

    // add method
    [HttpDelete("{id}")]
    public async Task<IActionResult> removeFavourites(string userId,string eventId)
    {
      var @event = await _eventService.removeFavourites(userId,eventId);
      if (@event == null)
      {
        return NotFound();
      }
      await _eventService.DeleteEvent(@event);
      return NoContent();
    }
  }
}
