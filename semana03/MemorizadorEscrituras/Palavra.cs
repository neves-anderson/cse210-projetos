namespace MemorizadorEscrituras
{
    public class Palavra
    {
        private string _texto;
        private bool _estaEscondida;

        public Palavra(string texto)
        {
            _texto = texto;
            _estaEscondida = false;
        }

        public void Esconder()
        {
            _estaEscondida = true;
        }

        public void Exibir()
        {
            _estaEscondida = false;
        }

        public bool EstaEscondida()
        {
            return _estaEscondida;
        }

        public string ObterTexto()
        {
            if (!_estaEscondida)
            {
                return _texto;
            }

            // Oculta apenas letras e números, mantendo pontuações intactas
            char[] caracteres = _texto.ToCharArray();
            for (int i = 0; i < caracteres.Length; i++)
            {
                if (char.IsLetterOrDigit(caracteres[i]))
                {
                    caracteres[i] = '_';
                }
            }
            return new string(caracteres);
        }
    }
}