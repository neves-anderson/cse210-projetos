using System.Collections.Generic;

namespace YouTubeMonitoring
{
    public class Video
    {
        private string _titulo;
        private string _autor;
        private int _duracaoEmSegundos;
        private List<Comentario> _comentarios;

        public Video(string titulo, string autor, int duracaoEmSegundos)
        {
            _titulo = titulo;
            _autor = autor;
            _duracaoEmSegundos = duracaoEmSegundos;
            _comentarios = new List<Comentario>();
        }

        public void AdicionarComentario(Comentario comentario)
        {
            _comentarios.Add(comentario);
        }

        public int ObterQuantidadeComentarios()
        {
            return _comentarios.Count;
        }

        public List<Comentario> ObterComentarios()
        {
            return _comentarios;
        }

        public string ObterTitulo()
        {
            return _titulo;
        }

        public string ObterAutor()
        {
            return _autor;
        }

        public int ObterDuracaoEmSegundos()
        {
            return _duracaoEmSegundos;
        }
    }
}