using System;

class Aluno
{
    public string nome;
    public string matricula;
    public string curso;
    public double media;

    // Exibe os dados do aluno
    public void ExibirDados()
    {
        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Matrícula: " + matricula);
        Console.WriteLine("Curso: " + curso);
        Console.WriteLine("Média: " + media);
    }
    // Verifica se o aluno foi aprovado
    public string VerificarAprovacao()
    {
        if (media >= 7)
        {
            return "Aprovado";
        }
        else
        {
            return "Reprovado";
        }
    }
}
class Exercício6
{
    static void Main()
    {
        Aluno aluno = new Aluno();

        // Cadastra os dados do aluno
        aluno.nome = "Kauã";
        aluno.matricula = "123456";
        aluno.curso = "Engenharia de Software";
        aluno.media = 8.5;

        // Exibe os dados e a situação do aluno
        aluno.ExibirDados();
        Console.WriteLine("Situação: " + aluno.VerificarAprovacao());
    }
}