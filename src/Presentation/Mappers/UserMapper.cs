using UniBet.Presentation.DTOs;
using UniBet.Domain.Entities;

namespace UniBet.Presentation.Mappers
{
  public static class UserMapper
  {
    public static User ToEntity(this UserCreateRequest request)
    {
      return new User(
        request.FirstName,
        request.LastName,
        request.Email,
        request.Password,
        request.BirthDate,
        request.Cpf
      );
    }

    public static UserResponseDto ToResponseDto(this User entity)
    {
      return new UserResponseDto(
        entity.Id,
        $"{entity.FirstName} {entity.LastName}",
        entity.Email,
        entity.Balance
      );
    }
  }
}
