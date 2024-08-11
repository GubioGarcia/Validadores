bool isNumeric(char caracter)
{
    return Char.IsDigit(caracter);
}

bool isValidCpf(string cpf)
{
    if (cpf == null)
        throw new Exception("CPF is required");

    if (cpf.Length != 11)
        throw new Exception("CPF is not valid");

    char[] _cpfDigits = cpf.ToCharArray();

    foreach (char c in _cpfDigits)
    {
        if (!isNumeric(c))
            throw new Exception("CPF is not valid");
    }

    #region Digit Checker 1

    int digitCheckerOne = 0;
    for (int i = 0, f = 10; i < 9; i++, f--)
    {
        digitCheckerOne += (int)char.GetNumericValue(_cpfDigits[i]) * f;
    }
    digitCheckerOne = (digitCheckerOne * 10) % 11;
    if (digitCheckerOne == 10)
        digitCheckerOne = 0;

    #endregion

    #region Digit Checker 2

    int digitCheckerTwo = 0;
    for (int i = 0, f = 11; i < 10; i++, f--)
    {
        digitCheckerTwo += (int)char.GetNumericValue(_cpfDigits[i]) * f;
    }
    digitCheckerTwo = (digitCheckerTwo * 10) % 11;
    if (digitCheckerTwo == 10)
        digitCheckerTwo = 0;

    #endregion

    if (digitCheckerOne != (int)char.GetNumericValue(_cpfDigits[9]) || digitCheckerTwo != (int)char.GetNumericValue(_cpfDigits[10]))
        return false;

    return true;
}

try
{
    Console.WriteLine("Digite o CPF no formato '12345678911':");
    string _cpf = Console.ReadLine();

    if (isValidCpf(_cpf))
        Console.WriteLine("CPF is valid");
    else
        Console.WriteLine("CPF is not valid");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadLine();
}