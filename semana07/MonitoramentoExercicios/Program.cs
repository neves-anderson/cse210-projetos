using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Atividade> listaAtividades = new List<Atividade>();

        Corrida corrida = new Corrida("03 Nov 2022", 30, 4.8);
        Ciclismo ciclismo = new Ciclismo("04 Nov 2022", 40, 20.0);
        Natacao natacao = new Natacao("05 Nov 2022", 25, 20);

        listaAtividades.Add(corrida);
        listaAtividades.Add(ciclismo);
        listaAtividades.Add(natacao);

        foreach (Atividade atividade in listaAtividades)
        {
            Console.WriteLine(atividade.ObterResumo());
        }
    }
}