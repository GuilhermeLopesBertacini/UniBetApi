using Microsoft.AspNetCore.Mvc;
using UniBet.Presentation.DTOs;
using UniBet.Presentation.Mappers;
using UniBet.Application.Interfaces;
using UniBet.Domain.Entities;

namespace UniBet.Presentation.Controllers
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
    public IActionResult ChangeProfile(Guid id, ChangeProfileRequest request)
    {
      _service.ChangeProfile(id, request);
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
