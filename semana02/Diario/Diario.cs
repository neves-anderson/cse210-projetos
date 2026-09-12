using System;
using System.Collections.Generic;
using System.IO;

public class Diario
{
    public List<Registro> _registros { get; set; }

    public Diario()
    {
        _registros = new List<Registro>();
    }

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        if (_registros.Count == 0)
        {
            Console.WriteLine("\nO diário está vazio.");
            return;
        }

        Console.WriteLine("\n=== REGISTROS DO DIÁRIO ===");
        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    public void SalvarNoArquivo(string arquivo)
    {
        using (StreamWriter escritor = new StreamWriter(arquivo))
        {
            foreach (Registro registro in _registros)
            {
                // Utilizando '~|~' como separador para evitar conflitos com vírgulas no texto
                escritor.WriteLine($"{registro._data}~|~{registro._textoPergunta}~|~{registro._textoResposta}");
            }
        }
        Console.WriteLine($"Diário salvo com sucesso em '{arquivo}'.");
    }

    public void CarregarDoArquivo(string arquivo)
    {
        if (!File.Exists(arquivo))
        {
            Console.WriteLine($"Erro: O arquivo '{arquivo}' não foi encontrado.");
            return;
        }

        _registros.Clear();
        string[] linhas = File.ReadAllLines(arquivo);

        foreach (string linha in linhas)
        {
            string[] partes = linha.Split(new[] { "~|~" }, StringSplitOptions.None);
            if (partes.Length == 3)
            {
                Registro registro = new Registro(partes[0], partes[1], partes[2]);
                _registros.Add(registro);
            }
        }
        Console.WriteLine($"Diário carregado com sucesso de '{arquivo}'. Total de registros: {_registros.Count}");
    }
}