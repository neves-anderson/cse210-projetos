using System;

class Program
{
    static void Main(string[] args)
    {
        //Coleta do percentual da nota do usuário
        Console.Write("Qual o percentual da sua nota? ");
        string resposta = Console.ReadLine();
        int percentual = int.Parse(resposta);

        string grade = "";

        if (percentual >= 90)
        {
            grade = "A";
        }
        else if (percentual >= 80)
        {
            grade = "B";
        }
        else if (percentual >= 70)
        {
            grade = "C";
        }
        else if (percentual >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        Console.WriteLine($"Sua nota é: {grade}");
        
        if (percentual >= 70)
        {
            Console.WriteLine("Você está aprovado!");
        }
        else
        {
            Console.WriteLine("Infelizmente, você não está aprovado. Mais sorte na próxima vez!");
        }
    }
}