using Microsoft.AspNetCore.Mvc;
using UniBet.Core.Commands;
using UniBet.Dtos;
using UniBet.Entities;
using UniBet.Interfaces.IServices;
using UniBet.Mappers;

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
    public ActionResult<IEnumerable<UserResponseDto>> GetUsers()
    {
      List<User> users = this._service.GetUsers();
      var response = users.Select(u => u.ToResponseDto());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<UserResponseDto> GetUserById(Guid id)
    {
      User user = this._service.GetUserById(id);
      var response = user.ToResponseDto();
      return Ok(response);
    }

    [HttpPost]
    public ActionResult<UserResponseDto> CreateUser(UserCreateRequest request)
    {
      User user = request.ToEntity();
      User createdUser = this._service.CreateUser(user);
      var response = createdUser.ToResponseDto();
      return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, response);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UserUpdateRequest request)
    {
      var command = request.ToCommand(id);
      this._service.UpdateUser(command);
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