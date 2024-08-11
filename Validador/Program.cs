bool isNumber(string aux)
{
    char[] _auxDigits = aux.ToCharArray();
    foreach (char item in _auxDigits)
    {
        if (!Char.IsDigit(item))
            return false;
    }

    return true;
}

bool isValidCpf(string cpf)
{
    if (cpf == null)
        throw new Exception("CPF is required");

    if (cpf.Length != 11)
        throw new Exception("CPF is not valid");

    if (!isNumber(cpf))
        throw new Exception("CPF is not valid. Please enter only numeric digits.");

    char[] _cpfDigits = cpf.ToCharArray();

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

bool isValidFone(string fone)
{
    if (fone == null)
        throw new Exception("Fone is required");

    if (fone.Length < 8 || fone.Length > 13)
        throw new Exception("Fone is not valid");

    return isNumber(fone);
}

try
{
    Console.WriteLine("Digite o CPF no formato '12345678911':");
    string _cpf = Console.ReadLine();

    if (isValidCpf(_cpf))
        Console.WriteLine("CPF is valid");
    else
        Console.WriteLine("CPF is not valid");
/*
    Console.WriteLine("Digite o Fone. Informe apenas dígitos númericos:");
    string fone = Console.ReadLine();

    if (isValidFone(fone))
        Console.WriteLine("Fone is valid");
    else
        Console.WriteLine("Fone is not valid");
*/
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadLine();
}