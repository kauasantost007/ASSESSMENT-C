using System;
using System.IO;
using System.Collections.Generic;

class Contato
{
    public string Nome, Telefone, Email;
}
class ContatoFormatter
{
    public virtual void ExibirContatos(List<Contato> contatos) { }
}
class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("## Lista de Contatos");

        foreach (Contato c in contatos)
        {
            Console.WriteLine("- **Nome:** " + c.Nome);
            Console.WriteLine("- Telefone: " + c.Telefone);
            Console.WriteLine("- Email: " + c.Email);
        }
    }
}
class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("Nome                 Telefone             Email");
        Console.WriteLine("----------------------------------------------------------------");

        foreach (Contato c in contatos)
        {
            Console.WriteLine(c.Nome.PadRight(21) +
                c.Telefone.PadRight(21) + c.Email);
        }

        Console.WriteLine("----------------------------------------------------------------");
    }
}
class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        foreach (Contato c in contatos)
        {
            Console.WriteLine("Nome: " + c.Nome +
                " | Telefone: " + c.Telefone +
                " | Email: " + c.Email);
        }
    }
}
class Exercício12
{
    static void Main()
    {
        int opcao = 0;

        while (opcao != 3)
        {
            Console.WriteLine("\n=== GERENCIADOR DE CONTATOS ===");
            Console.WriteLine("1 - Adicionar contato");
            Console.WriteLine("2 - Listar contatos");
            Console.WriteLine("3 - Sair");
            Console.Write("Opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                continue;
            }
            try
            {
                if (opcao == 1)
                {
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(nome) ||
                        string.IsNullOrWhiteSpace(telefone) ||
                        string.IsNullOrWhiteSpace(email) ||
                        nome.Contains(",") ||
                        telefone.Contains(",") ||
                        email.Contains(","))
                    {
                        Console.WriteLine("Dados inválidos!");
                        continue;
                    }
                    using (StreamWriter escritor = File.AppendText("contatos.txt"))
                    {
                        escritor.WriteLine(nome + "," + telefone + "," + email);
                    }

                    Console.WriteLine("Contato cadastrado com sucesso!");
                }
                else if (opcao == 2)
                {
                    List<Contato> contatos = new List<Contato>();

                    if (File.Exists("contatos.txt"))
                    {
                        using (StreamReader leitor = new StreamReader("contatos.txt"))
                        {
                            string linha;

                            while ((linha = leitor.ReadLine()) != null)
                            {
                                string[] dados = linha.Split(',');

                                if (dados.Length == 3)
                                {
                                    Contato c = new Contato();
                                    c.Nome = dados[0];
                                    c.Telefone = dados[1];
                                    c.Email = dados[2];

                                    contatos.Add(c);
                                }
                            }
                        }
                    }

                    if (contatos.Count == 0)
                    {
                        Console.WriteLine("Nenhum contato cadastrado.");
                        continue;
                    }
                    Console.WriteLine("\n1 - Markdown");
                    Console.WriteLine("2 - Tabela");
                    Console.WriteLine("3 - Texto Puro");
                    Console.Write("Escolha o formato: ");

                    int formato;
                    if (!int.TryParse(Console.ReadLine(), out formato))
                    {
                        Console.WriteLine("Formato inválido!");
                        continue;
                    }
                    ContatoFormatter formatador;

                    if (formato == 1)
                        formatador = new MarkdownFormatter();
                    else if (formato == 2)
                        formatador = new TabelaFormatter();
                    else if (formato == 3)
                        formatador = new RawTextFormatter();
                    else
                    {
                        Console.WriteLine("Formato inválido!");
                        continue;
                    }
                    formatador.ExibirContatos(contatos);
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
            catch (IOException)
            {
                Console.WriteLine("Erro ao acessar o arquivo!");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Sem permissão para acessar o arquivo!");
            }
        }
    }
}