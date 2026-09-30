namespace YouTubeMonitoring
{
    public class Comentario
    {
        private string _nomeAutor;
        private string _texto;

        public Comentario(string nomeAutor, string texto)
        {
            _nomeAutor = nomeAutor;
            _texto = texto;
        }

        public string ObterNomeAutor()
        {
            return _nomeAutor;
        }

        public string ObterTexto()
        {
            return _texto;
        }
    }
}