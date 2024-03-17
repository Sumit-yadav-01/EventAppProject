using EventsServices.Models;
using EventsServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventsServices.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    // add contructor and create variable for IUserService and implement the interface
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<Users>> GetUser(string userId)
    {
      var user = await _userService.GetUser(userId);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<bool>> AddUser(Users user)
    {
      var result = await _userService.AddUser(user);
      return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<bool>> UpdateUser(Users user)
    {
      var result = await _userService.UpdateUser(user);
      return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult<bool>> DeleteUser(string userId)
    {
      var result = await _userService.DeleteUser(userId);
      return Ok(result);
    }

  }
}
