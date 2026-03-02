namespace UniBet.Entities
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

  // EF core needs an empty constructor  
  private User() { }

  // Main constructor for new Users
  public User(
    string firstName,
    string lastName,
    string email,
    string password,
    DateTime birthdate,
    string Cpf
  )
    {
      this.Id = Guid.NewGuid();
      this.FirstName = firstName;
      this.LastName = lastName;
      this.Email = email;
      this.Password = password;
      this.BirthDate = birthdate;
      this.Cpf = Cpf;
      this.Balance = 0;
    }

  public void UpdateUser(string? firstName, string? lastName, string? email)
    {
      if (firstName is not null) this.FirstName = firstName;
      if (lastName is not null) this.LastName = lastName;
      if (email is not null) this.Email = email;
    }
  public void UpdatePassword(string newPassword) => this.Password = newPassword;
  public void Deposit(float amount)
  {
    if (amount <= 0) throw new ArgumentException("Amount must be positive");
    this.Balance += amount;
  }
  }
}