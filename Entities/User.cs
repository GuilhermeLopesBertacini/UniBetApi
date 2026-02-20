namespace UniBet.Entities
{
    public class User
  {
      public Guid id { get; private set; }
      public string FirstName { get; private set; } = string.Empty;
      public string LastName { get; private set; } = string.Empty;
      public string Email { get; private set; } = string.Empty;
      public string Password { get; private set; } = string.Empty;
      public DateTime BirthDate { get; private set; }
      public string Cpf { get; private set; } = string.Empty;
      public string Rg { get; private set; } = string.Empty;
      public float Balance { get; private set; }
  public string UpdatePassword(string newPassword)
  {
    this.Password = newPassword;
    return newPassword;
  }
  public void Deposit(float amount)
  {
    if (amount <= 0) throw new ArgumentException("Amount must be positive");
    this.Balance += amount;
  }
  }
}