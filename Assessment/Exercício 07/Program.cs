using System;

class ContaBancaria
{
    public string Titular;
    private decimal saldo = 0;

    // Adiciona dinheiro à conta
    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            saldo = saldo + valor;
            Console.WriteLine("Depósito de R$ " + valor.ToString("F2") + " realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
        }
    }
    // Retira dinheiro da conta
    public void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do saque deve ser positivo!");
        }
        else if (valor <= saldo)
        {
            saldo = saldo - valor;
            Console.WriteLine("Saque de R$ " + valor.ToString("F2") + " realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
        }
    }
    // Exibe o saldo sem permitir alterações diretas
    public void ExibirSaldo()
    {
        Console.WriteLine("Saldo atual: R$ " + saldo.ToString("F2"));
    }
}

class Exercício7
{
    static void Main()
    {
        ContaBancaria conta = new ContaBancaria();

        conta.Titular = "Kauã";

        Console.WriteLine("Titular: " + conta.Titular);

        conta.Depositar(500);
        conta.ExibirSaldo();

        Console.WriteLine("Tentativa de saque: R$ 700,00");
        conta.Sacar(700);

        conta.Sacar(200);
        conta.ExibirSaldo();
    }
}