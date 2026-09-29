using System;
using System.IO;

class Exercício9
{
    static void Main()
    {
        string arquivo = "estoque.txt";
        int opcao = 0;
        
        try
        {
            if (!File.Exists(arquivo))
            {
                using (StreamWriter escritor = new StreamWriter(arquivo))
                {
                }
            }
        }
        catch (IOException)
        {
            Console.WriteLine("Erro ao criar o arquivo!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Sem permissão para criar o arquivo!");
        }
        while (opcao != 3)
        {
            Console.WriteLine("\n=== CONTROLE DE ESTOQUE ===");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                continue;
            }

            try
            {
                if (opcao == 1)
                {
                    int total = 0;

                    using (StreamReader leitor = new StreamReader(arquivo))
                    {
                        while (leitor.ReadLine() != null)
                        {
                            total++;
                        }
                    }

                    if (total >= 5)
                    {
                        Console.WriteLine("Limite de produtos atingido!");
                    }
                    else
                    {
                        Console.Write("Nome do produto: ");
                        string nome = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(nome) || nome.Contains(","))
                        {
                            Console.Write("Digite um nome válido, sem vírgulas: ");
                            nome = Console.ReadLine();
                        }
                        int quantidade;
                        Console.Write("Quantidade em estoque: ");

                        while (!int.TryParse(Console.ReadLine(), out quantidade) || quantidade < 0)
                        {
                            Console.Write("Quantidade inválida! Digite novamente: ");
                        }

                        decimal preco;
                        Console.Write("Preço unitário: R$ ");

                        while (!decimal.TryParse(Console.ReadLine(), out preco) || preco < 0)
                        {
                            Console.Write("Preço inválido! Digite novamente: R$ ");
                        }
                        using (StreamWriter escritor = File.AppendText(arquivo))
                        {
                            escritor.WriteLine(nome + "," + quantidade +
                                "," + preco.ToString("F2").Replace(",", "."));
                        }

                        Console.WriteLine("Produto cadastrado com sucesso!");
                    }
                }
                else if (opcao == 2)
                {
                    bool encontrou = false;

                    Console.WriteLine("\n=== PRODUTOS CADASTRADOS ===");

                    using (StreamReader leitor = new StreamReader(arquivo))
                    {
                        string linha;

                        while ((linha = leitor.ReadLine()) != null)
                        {
                            string[] dados = linha.Split(',');

                            int quantidade;
                            decimal preco;

                            if (dados.Length != 3 ||
                                string.IsNullOrWhiteSpace(dados[0]) ||
                                !int.TryParse(dados[1], out quantidade) ||
                                quantidade < 0 ||
                                !decimal.TryParse(dados[2].Replace(".", ","), out preco) ||
                                preco < 0)
                            {
                                Console.WriteLine("Registro inválido!");
                                continue;
                            }
                            Console.WriteLine("Produto: " + dados[0] +
                                " | Quantidade: " + quantidade +
                                " | Preço: R$ " + preco.ToString("F2"));

                            encontrou = true;
                        }
                    }
                    if (!encontrou)
                    {
                        Console.WriteLine("Nenhum produto cadastrado.");
                    }
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("Programa encerrado!");
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