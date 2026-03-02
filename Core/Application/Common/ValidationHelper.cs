namespace UniBet.Core.Application.Common
{
  public static class ValidationHelper
  {
    public static bool BeOver18(DateTime birthDate)
    {
      return birthDate <= DateTime.Now.AddYears(-18);
    }

    public static bool BeCpf(string cpf)
    {
      int[] mult1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
      int[] mult2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2];

      cpf = cpf.Trim().Replace(".", "").Replace("-", "");
      if (cpf.Length != 11)
        return false;

      for (int j = 0; j < 10; j++)
        if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
          return false;

      string tempCpf = cpf[..9];
      int total = 0;

      for (int i = 0; i < 9; i++)
        total += int.Parse(tempCpf[i].ToString()) * mult1[i];

      int rest = total % 11;
      rest = rest < 2 ? 0 : 11 - rest;

      string digit = rest.ToString();
      tempCpf += digit;
      total = 0;

      for (int i = 0; i < 10; i++)
        total += int.Parse(tempCpf[i].ToString()) * mult2[i];

      rest = total % 11;
      rest = rest < 2 ? 0 : 11 - rest;

      digit += rest.ToString();

      return cpf.EndsWith(digit);
    }
  }
}
