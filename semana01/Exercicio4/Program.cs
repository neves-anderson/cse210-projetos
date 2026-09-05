using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();
        
        int numeroUsuario = -1;
        while (numeroUsuario != 0)
        {
            Console.Write("Digite um número (0 para sair): ");
            
            string respostaUsuario = Console.ReadLine();
            if (int.TryParse(respostaUsuario, out numeroUsuario) && numeroUsuario != 0)
            {
                numeros.Add(numeroUsuario);
            }
        }

        // Evita erro caso o usuário saia sem digitar nenhum número válido
        if (numeros.Count == 0)
        {
            Console.WriteLine("Nenhum número foi digitado.");
            return;
        }

        // Calcula a soma
        int soma = 0;
        foreach (int numero in numeros)
        {
            soma += numero;
        }

        Console.WriteLine($"A soma é: {soma}");

        // Calcula a média     
        float media = (float)soma / numeros.Count;
        Console.WriteLine($"A média é: {media}");

        // Encontra o maior e o menor número da lista
        int maior = numeros[0];
        int menor = numeros[0];

        foreach (int numero in numeros)
        {
            if (numero > maior)
            {
                maior = numero;
            }
            if (numero < menor)
            {
                menor = numero;
            }
        }

        Console.WriteLine($"O maior valor é: {maior}");
        Console.WriteLine($"O menor valor é: {menor}");

        // Ordena a lista fora do loop
        numeros.Sort();
        Console.WriteLine("\nNúmeros ordenados:");
        Console.WriteLine(string.Join(" ; ", numeros));
   }
}
