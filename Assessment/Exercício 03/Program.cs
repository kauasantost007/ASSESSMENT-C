using System;

class Exercício3
{
    static void Main()
    {
        double numero1;
        double numero2;
        int opcao;
        double resultado;

        Console.Write("Digite o primeiro número: ");
        while (!double.TryParse(Console.ReadLine(), out numero1))
        {
            Console.Write("Número inválido! Digite novamente: ");
        }
        Console.Write("Digite o segundo número: ");
        while (!double.TryParse(Console.ReadLine(), out numero2))
        {
            Console.Write("Número inválido! Digite novamente: ");
        }
        Console.WriteLine("\nEscolha uma operação:");
        Console.WriteLine("1 - Soma");
        Console.WriteLine("2 - Subtração");
        Console.WriteLine("3 - Multiplicação");
        Console.WriteLine("4 - Divisão");

        Console.Write("Digite sua opção: ");
        while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 4)
        {
            Console.Write("Opção inválida! Digite novamente: ");
        }
        if (opcao == 1)
        {
            resultado = numero1 + numero2;
            Console.WriteLine("Resultado: " + resultado);
        }
        else if (opcao == 2)
        {
            resultado = numero1 - numero2;
            Console.WriteLine("Resultado: " + resultado);
        }
        else if (opcao == 3)
        {
            resultado = numero1 * numero2;
            Console.WriteLine("Resultado: " + resultado);
        }
        else if (opcao == 4)
        {
            if (numero2 != 0)
            {
                resultado = numero1 / numero2;
                Console.WriteLine("Resultado: " + resultado);
            }
            else
            {
                Console.WriteLine("Erro! Não é possível dividir por zero.");
            }
        }
    }
}