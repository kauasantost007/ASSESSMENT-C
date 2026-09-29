using System;
using System.IO;

class Exercício11
{
    static void AdicionarContato()
    {
        Console.WriteLine("\n=== ADICIONAR CONTATO ===");

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(nome) || nome.Contains(","))
        {
            Console.Write("Digite um nome válido, sem vírgulas: ");
            nome = Console.ReadLine();
        }

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(telefone) || telefone.Contains(","))
        {
            Console.Write("Digite um telefone válido, sem vírgulas: ");
            telefone = Console.ReadLine();
        }

        Console.Write("Email: ");
        string email = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(email) || email.Contains(","))
        {
            Console.Write("Digite um email válido, sem vírgulas: ");
            email = Console.ReadLine();
        }

        try
        {
            using (StreamWriter escritor = File.AppendText("contatos.txt"))
            {
                escritor.WriteLine(nome + "," + telefone + "," + email);
            }

            Console.WriteLine("Contato cadastrado com sucesso!");
        }
        catch (IOException)
        {
            Console.WriteLine("Erro ao salvar o contato!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Sem permissão para salvar o contato!");
        }
    }

    static void ListarContatos()
    {
        Console.WriteLine("\n=== CONTATOS CADASTRADOS ===");

        if (!File.Exists("contatos.txt"))
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        try
        {
            bool encontrou = false;

            using (StreamReader leitor = new StreamReader("contatos.txt"))
            {
                string linha;

                while ((linha = leitor.ReadLine()) != null)
                {
                    string[] dados = linha.Split(',');

                    if (dados.Length == 3)
                    {
                        Console.WriteLine("Nome: " + dados[0] +
                            " | Telefone: " + dados[1] +
                            " | Email: " + dados[2]);

                        encontrou = true;
                    }
                    else
                    {
                        Console.WriteLine("Registro inválido encontrado!");
                    }
                }
            }
            if (!encontrou)
            {
                Console.WriteLine("Nenhum contato cadastrado.");
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Erro ao ler o arquivo!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Sem permissão para ler o arquivo!");
        }
    }

    static void Main()
    {
        int opcao = 0;

        while (opcao != 3)
        {
            Console.WriteLine("\n=== GERENCIADOR DE CONTATOS ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Sair");

            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                continue;
            }
            if (opcao == 1)
            {
                AdicionarContato();
            }
            else if (opcao == 2)
            {
                ListarContatos();
            }
            else if (opcao == 3)
            {
                Console.WriteLine("Encerrando programa...");
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }
}