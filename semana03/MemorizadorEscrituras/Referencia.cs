namespace MemorizadorEscrituras
{
    public class Referencia
    {
        private string _livro;
        private int _capitulo;
        private int _versiculo;
        private int _ultimoVersiculo;

        // Construtor para versículo único
        public Referencia(string livro, int capitulo, int versiculo)
        {
            _livro = livro;
            _capitulo = capitulo;
            _versiculo = versiculo;
            _ultimoVersiculo = versiculo;
        }

        // Construtor para intervalo de versículos
        public Referencia(string livro, int capitulo, int versiculoInicial, int versiculoFinal)
        {
            _livro = livro;
            _capitulo = capitulo;
            _versiculo = versiculoInicial;
            _ultimoVersiculo = versiculoFinal;
        }

        public string ObterTexto()
        {
            if (_versiculo == _ultimoVersiculo)
            {
                return $"{_livro} {_capitulo}:{_versiculo}";
            }
            return $"{_livro} {_capitulo}:{_versiculo}-{_ultimoVersiculo}";
        }
    }
}