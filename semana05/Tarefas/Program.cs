using System;

class Program
{
    static void Main(string[] args)
    {
        // Cria um objeto "Tarefa" base
        Tarefa t1 = new Tarefa("Samuel Bennett", "Multiplicação");
        Console.WriteLine(t1.ObterResumo());

        // Agora cria os tarefas das classes derivadas
        TarefaDeMatematica t2 = new TarefaDeMatematica("Roberto Rodriguez", "Frações", "7.3", "8-19");
        Console.WriteLine(t2.ObterResumo());
        Console.WriteLine(t2.ObterListaDeTarefas());

        TarefaDeRedacao t3 = new TarefaDeRedacao("Mary Waters", "História Européia", "As Causas da Segunda Guerra Mundial");
        Console.WriteLine(t3.ObterResumo());
        Console.WriteLine(t3.ObterInformacaoDaRedacao());
    }
}