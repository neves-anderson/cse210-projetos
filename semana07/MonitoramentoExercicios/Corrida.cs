public class Corrida : Atividade
{
    private double _distanciaKm;

    public Corrida(string data, int duracaoMinutos, double distanciaKm) : base(data, duracaoMinutos)
    {
        _distanciaKm = distanciaKm;
    }

    public override double ObterDistancia()
    {
        return _distanciaKm;
    }

    public override double ObterVelocidade()
    {
        return (_distanciaKm / DuracaoMinutos) * 60;
    }

    public override double ObterRitmo()
    {
        return DuracaoMinutos / _distanciaKm;
    }
}