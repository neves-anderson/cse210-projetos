using System;

class Program
{
    static void Main(string[] args)
    {
        //Gera um número aleatório entre 1 e 100 
        Random geradorRandomico = new Random();
        int numeroMagico = geradorRandomico.Next(1, 101);

        int palpite = -1;
        int tentativas = 0;
        string resposta = "s";

        Console.WriteLine("Bem-vindo ao jogo de adivinhação!");

        do
        {        
            do
            {
                Console.Write("Qual o seu palpite? ");
                palpite = int.Parse(Console.ReadLine());
                tentativas++;

                if (numeroMagico > palpite)
                {
                    Console.WriteLine("Maior");
                }
                else if (numeroMagico < palpite)
                {
                    Console.WriteLine("Menor");
                }
                else
                {
                    Console.WriteLine("Você adivinhou!");
                    Console.WriteLine($"O total de tentativas foi: {tentativas}");
                    Console.Write("Deseja jogar? (s/n) ");
                    resposta = Console.ReadLine();
                }
            }  while (palpite != numeroMagico);
        } while (resposta == "s" || resposta == "S");
    }
}