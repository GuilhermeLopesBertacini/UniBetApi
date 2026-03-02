namespace UniBet.Core.Commands
{
  public sealed record UpdateUserCommand(
    Guid Id,
    string? FirstName,
    string? LastName,
    string? Email
  );
}
