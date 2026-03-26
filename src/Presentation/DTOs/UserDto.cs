namespace UniBet.Presentation.DTOs
{
  public sealed record UserResponseDto(
    Guid Id,
    string FullName,
    string Email,
    float Balance
  );

  public sealed record UserCreateRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    DateTime BirthDate,
    string Cpf
  );

  public sealed record ChangeProfileRequest(
    string? FirstName,
    string? LastName,
    string? Email
  );
}
