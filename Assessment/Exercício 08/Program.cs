using System;

class Funcionario
{
    public string Nome;
    public string Cargo;
    public decimal SalarioBase;
}
class Gerente : Funcionario
{
    public decimal CalcularSalario()
    {
        return SalarioBase + (SalarioBase * 0.20m);
    }
}
class Exercício8
{
    static void Main()
    {
        Funcionario funcionario = new Funcionario();

        funcionario.Nome = "João";
        funcionario.Cargo = "Atendente";
        funcionario.SalarioBase = 3000;

        Gerente gerente = new Gerente();

        gerente.Nome = "Roberto";
        gerente.Cargo = "Gerente";
        gerente.SalarioBase = 5000;

        Console.WriteLine("\nFuncionário:");
        Console.WriteLine("Nome: " + funcionario.Nome);
        Console.WriteLine("Cargo: " + funcionario.Cargo);
        Console.WriteLine("Salário: R$ " + funcionario.SalarioBase.ToString("F2"));
        Console.WriteLine("\nGerente:");
        Console.WriteLine("Nome: " + gerente.Nome);
        Console.WriteLine("Cargo: " + gerente.Cargo);
        Console.WriteLine("Salário com bônus: R$ " + gerente.CalcularSalario().ToString("F2"));
    }
}