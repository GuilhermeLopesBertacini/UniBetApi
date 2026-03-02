using FluentValidation;
using UniBet.Dtos;
using UniBet.Helpers;

namespace UniBet.Validators
{
  public class UserCreateRequestValidator : AbstractValidator<UserCreateRequest>
  {
    public UserCreateRequestValidator()
    {
      RuleFor(x => x.FirstName)
      .NotEmpty().WithMessage("First name is required")
      .MaximumLength(50);

      RuleFor(x => x.LastName)
      .NotEmpty().WithMessage("Last name is required");

      RuleFor(x => x.Email)
      .NotEmpty()
      .EmailAddress().WithMessage("A valid e-mail is required.");

      RuleFor(x => x.Password)
      .NotEmpty()
      .MinimumLength(8)
      .Matches(@"[A-Z]").WithMessage("Password must contain at least one capital letter")
      .Matches(@"[!@#$%&*^]").WithMessage("Password must contain at least one special character");

      RuleFor(x => x.BirthDate)
      .NotEmpty()
      .Must(Helper.BeOver18).WithMessage("User must be at least 18 years old");

      RuleFor(x => x.Cpf)
      .NotEmpty()
      .MinimumLength(11)
      .MaximumLength(14)
      .Must(Helper.BeCpf).WithMessage("A valid CPF is required");
    }
    }

    public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateRequestValidator()
        {
            RuleFor(u => u.FirstName)
            .MaximumLength(50)
            .When(x => x.FirstName != null);

            RuleFor(u => u.Email)
            .EmailAddress().WithMessage("A valid e-mail is required")
            .When(u => u.Email != null);
        }
    }
}