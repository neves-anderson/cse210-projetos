using System;

public class Registro
{
    public string _data { get; set; }
    public string _textoPergunta { get; set; }
    public string _textoResposta { get; set; }

    public Registro(string data, string textoPergunta, string textoResposta)
    {
        _data = data;
        _textoPergunta = textoPergunta;
        _textoResposta = textoResposta;
    }

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data} - Pergunta: {_textoPergunta}");
        Console.WriteLine($"Resposta: {_textoResposta}");
        Console.WriteLine(new string('-', 50));
    }
}