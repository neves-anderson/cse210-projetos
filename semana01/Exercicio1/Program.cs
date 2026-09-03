using System;

class Program
{
    static void Main(string[] args)
    {
        //Coleta do nome do usuário
        Console.Write("Qual é o seu primeiro nome? ");
        string primeiroNome = Console.ReadLine();

        //Coleta do sobrenome do usuário   
        Console.Write("Qual é o seu sobrenome? ");
        string sobrenome = Console.ReadLine();
        
        //Exibe o mensagem com o nome do usuário
        Console.WriteLine($"Seu nome é {sobrenome}, {primeiroNome} {sobrenome}.");
    }
}