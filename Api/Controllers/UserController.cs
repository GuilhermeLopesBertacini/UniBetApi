using Microsoft.AspNetCore.Mvc;
using UniBet.Api.DTOs;
using UniBet.Api.Mappers;
using UniBet.Core.Application.Ports;
using UniBet.Core.Domain.Entities;

namespace UniBet.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    private readonly IUserService _service;

    public UserController(IUserService service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserResponseDto>> GetUsers()
    {
      List<User> users = _service.GetAll();
      var response = users.Select(u => u.ToResponseDto());
      return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult<UserResponseDto> GetUserById(Guid id)
    {
      User user = _service.GetById(id);
      var response = user.ToResponseDto();
      return Ok(response);
    }

    [HttpPost]
    public ActionResult<UserResponseDto> CreateUser(UserCreateRequest request)
    {
      User user = request.ToEntity();
      User createdUser = _service.Create(user);
      var response = createdUser.ToResponseDto();
      return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, response);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, UserUpdateRequest request)
    {
      var command = request.ToCommand(id);
      _service.Update(command);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
      _service.Delete(id);
      return NoContent();
    }
  }
}
