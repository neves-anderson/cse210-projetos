public class TarefaDeMatematica : Tarefa
{
    private string _capitulo;
    private string _problemas;

    // Observe a sintaxe aqui: o construtor de TarefaDeMatematica tem 4 parâmetros e, em seguida,
    // passa 2 deles diretamente para o construtor "base", que é o construtor da classe "Tarefa".
    public TarefaDeMatematica(string nomeEstudante, string topico, string capitulo, string problemas)
        : base(nomeEstudante, topico)
    {
        // Aqui definimos as variáveis específicas de TarefaDeMatematica
        _capitulo = capitulo;
        _problemas = problemas;
    }

    public string ObterListaDeTarefas()
    {
        return $"Capítulo {_capitulo} Problemas {_problemas}";
    }
}