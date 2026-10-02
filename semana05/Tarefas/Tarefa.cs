public class Tarefa
{
    private string _nomeEstudante;
    private string _topico;

    public Tarefa(string nomeEstudante, string topico)
    {
        _nomeEstudante = nomeEstudante;
        _topico = topico;
    }

    // Vamos fornecer Getters para nossas variáveis membro privadas para que possam ser acessadas
    // posteriormente tanto fora da classe quanto em classes derivadas.
    public string ObterNomeEstudante()
    {
        return _nomeEstudante;
    }

    public string ObterTopico()
    {
        return _topico;
    }

    public string ObterResumo()
    {
        return _nomeEstudante + " - " + _topico;
    }
}