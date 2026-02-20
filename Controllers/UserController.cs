using Microsoft.AspNetCore.Mvc;
using UniBet.Entities;
using UniBet.Interfaces.IServices;

namespace UniBet.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
      this._service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
      List<User> users = this._service.GetUsers();
      return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
      User user = this._service.GetById(id);
      if (user == null)
      {
        return NotFound();
      }
      return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
      User createdUser = this._service.CreateUser(user);
      return CreatedAtAction(nameof(GetById), new { id = createdUser.id }, createdUser);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, User user)
    {
      this._service.UpdateUser(user);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
      this._service.DeleteUser(id);
      return NoContent();
    }
  }
}