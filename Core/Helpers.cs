namespace UniBet.Helpers
{
  public static class Helper
  {
    public static bool BeOver18(DateTime birthDate)
    {
      return birthDate <= DateTime.Now.AddYears(18);
    }

    public static bool BeCpf(string Cpf)
    {
      int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
      int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

      string cpf = Cpf.Trim().Replace(".", "").Replace("-", "");
      if (cpf.Length != 11)
        return false;

      for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int total = 0;

            for (int i = 0; i < 9; i++)
                total += int.Parse(tempCpf[i].ToString()) * mult1[i];

            int rest = total % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            string digit = rest.ToString();
            tempCpf = tempCpf + digit;
            total = 0;
            for (int i = 0; i < 10; i++)
                total += int.Parse(tempCpf[i].ToString()) * mult2[i];

            rest = total % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            digit = digit + rest.ToString();

            return cpf.EndsWith(digit);
        }
  }
}