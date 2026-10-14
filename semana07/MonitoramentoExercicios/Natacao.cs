public class Natacao : Atividade
{
    private int _numeroVoltas;

    public Natacao(string data, int duracaoMinutos, int numeroVoltas) : base(data, duracaoMinutos)
    {
        _numeroVoltas = numeroVoltas;
    }

    public override double ObterDistancia()
    {
        return (_numeroVoltas * 50.0) / 1000.0;
    }

    public override double ObterVelocidade()
    {
        return (ObterDistancia() / DuracaoMinutos) * 60;
    }

    public override double ObterRitmo()
    {
        return DuracaoMinutos / ObterDistancia();
    }
}