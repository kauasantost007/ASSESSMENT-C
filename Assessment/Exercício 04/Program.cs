
using System;

class Exercício4
{
    static void Main()
    {
        Console.Write("Digite sua data de nascimento (dd/mm/aaaa): ");
        DateTime nascimento;

        while (!DateTime.TryParse(Console.ReadLine(), out nascimento) || nascimento > DateTime.Today)
        {
            Console.Write("Data inválida! Digite novamente: ");
        }
        DateTime hoje = DateTime.Today;

        DateTime aniversario = nascimento.AddYears(hoje.Year - nascimento.Year);

        if (aniversario < hoje)
        {
            aniversario = nascimento.AddYears(hoje.Year - nascimento.Year + 1);
        }
        int dias = (aniversario - hoje).Days;

        Console.WriteLine("Próximo aniversário: " + aniversario.ToString("dd/MM/yyyy"));
        Console.WriteLine("Faltam " + dias + " dias para seu próximo aniversário!");

        if (dias == 0)
        {
            Console.WriteLine("Parabéns! Hoje é seu aniversário!!!");
        }
        else if (dias < 7)
        {
            Console.WriteLine("Se prepare, falta 1 semana pro seu grande dia!!!");
        }
    }
}