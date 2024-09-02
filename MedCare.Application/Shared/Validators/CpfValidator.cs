﻿namespace MedCare.Application.Shared.Validators;

public class CpfValidator
{
    public static bool ValidateCpf(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int soma, resto;
        string tempCpf, digito;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "").Replace(" ", "");

        if (cpf.Length != 11)
        {
            return false;
        }

        string[] invalidCpfs = new string[]
        {
    "00000000000", "11111111111", "22222222222", "33333333333",
    "44444444444", "55555555555", "66666666666", "77777777777",
    "88888888888", "99999999999"
        };

        if (invalidCpfs.Contains(cpf))
        {
            return false;
        }

        tempCpf = cpf.Substring(0, 9);

        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();
        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();
        return cpf.EndsWith(digito);
    }
}
