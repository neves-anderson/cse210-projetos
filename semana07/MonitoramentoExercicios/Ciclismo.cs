public class Ciclismo : Atividade
{
    private double _velocidadeKmH;

    public Ciclismo(string data, int duracaoMinutos, double velocidadeKmH) : base(data, duracaoMinutos)
    {
        _velocidadeKmH = velocidadeKmH;
    }

    public override double ObterDistancia()
    {
        return (_velocidadeKmH * DuracaoMinutos) / 60;
    }

    public override double ObterVelocidade()
    {
        return _velocidadeKmH;
    }

    public override double ObterRitmo()
    {
        return 60 / _velocidadeKmH;
    }
}