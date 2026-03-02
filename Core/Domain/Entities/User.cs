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
      FirstName = firstName;
      LastName = lastName;
      Email = email;
      Password = password;
      BirthDate = birthdate;
      Cpf = cpf;
      Balance = 0;
    }

    public void Update(string? firstName, string? lastName, string? email)
    {
      if (firstName is not null) FirstName = firstName;
      if (lastName is not null) LastName = lastName;
      if (email is not null) Email = email;
    }

    public void UpdatePassword(string newPassword) => Password = newPassword;

    public void Deposit(float amount)
    {
      if (amount <= 0) throw new ArgumentException("Amount must be positive");
      Balance += amount;
    }
  }
}
