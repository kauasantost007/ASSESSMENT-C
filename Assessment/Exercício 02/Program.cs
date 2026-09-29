using System;

class Exercício2
{
    static void Main()
    {
        Console.Write("Digite seu nome completo: ");
        string nome = Console.ReadLine();

        // Transforma o nome em um array de caracteres
        char[] letras = nome.ToCharArray();

        // Percorre cada letra do nome
        for (int i = 0; i < letras.Length; i++)
        {
            // Desloca as letras maiúsculas
            if (letras[i] >= 'A' && letras[i] <= 'Z')
            {
                letras[i] = (char)('A' + (letras[i] - 'A' + 2) % 26);
            }
            // Desloca as letras minúsculas
            else if (letras[i] >= 'a' && letras[i] <= 'z')
            {
                letras[i] = (char)('a' + (letras[i] - 'a' + 2) % 26);
            }
        }
        // Transforma o array em uma string novamente
        string nomeCifrado = new string(letras);

        Console.WriteLine("Nome cifrado: " + nomeCifrado);
    }
}