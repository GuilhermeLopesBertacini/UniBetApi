using System.Text.RegularExpressions;

namespace UniBet.Core.Domain.Entities
{
  public class User
  {
    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public DateTime BirthDate { get; private set; }
    public string Cpf { get; private set; } = string.Empty;
    public float Balance { get; private set; }

    // EF Core needs an empty constructor
    private User() { }

    // Main constructor for new Users
    public User(
      string firstName,
      string lastName,
      string email,
      string password,
      DateTime birthdate,
      string cpf
    )
    {
      Id = Guid.NewGuid();
      this.SetFirstName(firstName);
      this.SetLastName(lastName);
      this.SetEmail(email);
      this.Password = password;
      this.BirthDate = birthdate;
      this.Cpf = cpf;
      this.Balance = 10;
    }
    public void ChangeName(string firstName, string lastName)
    {
      this.SetFirstName(firstName);
      this.SetLastName(lastName);
    }

    public void ChangeEmail(string email)
    {
      this.SetEmail(email);
    }

    private void SetFirstName(string firstName)
    {
      if (string.IsNullOrWhiteSpace(firstName)) throw new Exception("First Name can not be empty");
      this.FirstName = firstName;
    }

    private void SetLastName(string lastName)
    {
      if (string.IsNullOrWhiteSpace(lastName)) throw new Exception("Last Name can not be empty");
      this.LastName = lastName;
    }

    private void SetEmail(string email)
    {
      if (string.IsNullOrEmpty(email)) throw new Exception("E-mail can not be empty");
      if (!Validator.EmailRegex.IsMatch(email)) throw new Exception("Email must be valid");
      this.Email = email.Trim().ToLowerInvariant();
    }

  public void IncreaseBalance(float amount)
    {
      if (amount < 0) throw new Exception("Amount must be positve");
      this.Balance = this.Balance + amount;
    }

  public void DecreaseBalance(float amount)
    {
      if (amount < 0) throw new Exception("Amount must be positive");
      float newBalance = this.Balance - amount;
      if (newBalance < 0) throw new Exception("Not enought balance to decrease from");
      this.Balance = newBalance;
    }
  }

  public class Validator
  {
    public static readonly Regex EmailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);
  }
}
