namespace UniBet.Core.Application.Commands
{
  public sealed record UpdateUserCommand(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? Email
  );
}
