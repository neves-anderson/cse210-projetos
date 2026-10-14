public abstract class Atividade
{
    private string _data;
    private int _duracaoMinutos;

    public Atividade(string data, int duracaoMinutos)
    {
        _data = data;
        _duracaoMinutos = duracaoMinutos;
    }

    protected string Data => _data;
    protected int DuracaoMinutos => _duracaoMinutos;

    public abstract double ObterDistancia();
    public abstract double ObterVelocidade();
    public abstract double ObterRitmo();

    public virtual string ObterResumo()
    {
        string nomeAtividade = GetType().Name;
        if (nomeAtividade == "Natacao") nomeAtividade = "Natação";

        return $"{_data} {nomeAtividade} ({_duracaoMinutos} min): " +
               $"Distância {ObterDistancia():F1} km, " +
               $"Velocidade: {ObterVelocidade():F1} km/h, " +
               $"Ritmo: {ObterRitmo():F2} min por km";
    }
}