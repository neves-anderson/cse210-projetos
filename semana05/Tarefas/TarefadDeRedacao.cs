public class TarefaDeRedacao : Tarefa
{
    private string _titulo;

    // Observe a sintaxe aqui: o construtor de TarefaDeRedacao tem 3 parâmetros e, em seguida,
    // passa 2 deles diretamente para o construtor "base", que é o construtor da classe "Tarefa".
    public TarefaDeRedacao(string nomeEstudante, string topico, string titulo)
        : base(nomeEstudante, topico)
    {
        // Aqui definimos quaisquer variáveis específicas da classe TarefaDeRedacao
        _titulo = titulo;
    }

    public string ObterInformacaoDaRedacao()
    {
        // Observe que estamos chamando o getter aqui porque _nomeestudante é privado na classe base
        string nomeEstudante = ObterNomeEstudante();

        return $"{_titulo} por {nomeEstudante}";
    }
}