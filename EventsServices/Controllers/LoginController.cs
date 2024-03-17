using EventsServices.Models;
using EventsServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace EventsServices.Controllers
{
  [Route("api/login")]
  [ApiController]
  public class LoginController : ControllerBase
  {
    //add configuration
    private IConfiguration _config;
    private readonly IUserService _userService;
    public LoginController(IUserService userService, IConfiguration config)
    {
      _userService = userService;
      _config = config;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel user)
    {
      var existingUser = await _userService.AuthenticateUser(user.email, user.password);
      if (existingUser == null)
      {
        return NotFound();
      }

      //return jsonwebtoken if user exists
      var tokenString = GenerateJSONWebToken();
      return Ok(new { token = tokenString });
    }

    //Create a method to GenerateJSONWebToken
    private string GenerateJSONWebToken()
    {
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        _config["Jwt:Issuer"],
        null,
        expires: DateTime.Now.AddMinutes(120),
        signingCredentials: credentials);

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
