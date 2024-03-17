using EventsServices.Models;

namespace EventsServices.Services
{
  public interface IUserService
  {
    //add login() method
    Task<Users> Login(string email, string password);

    // add getUser() method
    Task<Users> GetUser(string userId);

    // add addUser() method
    Task<bool> AddUser(Users user);

    // add updateUser() method
    Task<bool> UpdateUser(Users user);

    // add deleteUser() method
    Task<bool> DeleteUser(string userId);
  }
}
