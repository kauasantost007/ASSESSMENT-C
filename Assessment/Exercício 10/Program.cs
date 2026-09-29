using System;

class Exercício10
{
    static void Main()
    {
        Random random = new Random();
        int numeroSecreto = random.Next(1, 51);
        int tentativas = 0;

        Console.WriteLine("=== JOGO DE ADIVINHAÇÃO ===");
        Console.WriteLine("Adivinhe um número de 1 a 50!");
        Console.WriteLine("Você tem 5 tentativas.");

        while (tentativas < 5)
        {
            int numero;

            Console.Write("\nDigite seu número: ");

            try
            {
                numero = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Erro! Digite apenas números!");
                continue;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Erro! Número muito grande!");
                continue;
            }
            if (numero < 1 || numero > 50)
            {
                Console.WriteLine("Erro! Digite um número entre 1 e 50!");
                continue;
            }

            tentativas++;

            if (numero == numeroSecreto)
            {
                Console.WriteLine("Parabéns! Você acertou!");
                break;
            }
            else if (numero < numeroSecreto)
            {
                Console.WriteLine("O número secreto é maior!");
            }
            else
            {
                Console.WriteLine("O número secreto é menor!");
            }

            Console.WriteLine("Tentativas restantes: " + (5 - tentativas));
        }

        if (tentativas == 5)
        {
            Console.WriteLine("\nFim de jogo!");
            Console.WriteLine("O número secreto era: " + numeroSecreto);
        }
    }
}