
using System;
using System.Globalization;

class Exercício5
{
    static void Main()
    {
        DateTime dataFormatura = new DateTime(2026, 12, 15);
        DateTime dataAtual;

        Console.WriteLine("=== TEMPO ATÉ A FORMATURA ===");

        Console.Write("Digite a data atual (dd/MM/yyyy): ");
        string entrada = Console.ReadLine();

        if (!DateTime.TryParseExact(entrada, "dd/MM/yyyy",
            CultureInfo.InvariantCulture, DateTimeStyles.None,
            out dataAtual))
        {
            Console.WriteLine("Erro: Data inválida!");
            return;
        }
        if (dataAtual > DateTime.Today)
        {
            Console.WriteLine("Erro: A data informada não pode ser no futuro!");
            return;
        }
        if (dataAtual >= dataFormatura)
        {
            Console.WriteLine("Parabéns! Você já deveria estar formado!");
            return;
        }
        int anos = 0;

        while (dataAtual.AddYears(anos + 1) <= dataFormatura)
        {
            anos++;
        }
        DateTime data = dataAtual.AddYears(anos);
        
        int meses = 0;

        while (data.AddMonths(meses + 1) <= dataFormatura)
        {
            meses++;
        }
        data = data.AddMonths(meses);

        int dias = (dataFormatura - data).Days;

        if (anos > 0)
        {
            Console.WriteLine("Faltam " + anos + " anos, " +
                meses + " meses e " + dias + " dias para sua formatura!");
        }
        else
        {
            Console.WriteLine("Faltam " + meses + " meses e " +
                dias + " dias para sua formatura!");
        }
        if (dataAtual.AddMonths(6) > dataFormatura)
        {
            Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
        }
    }
}