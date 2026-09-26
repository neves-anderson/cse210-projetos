using System.Collections.Generic;

namespace YouTubeMonitoring
{
    public class Video
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int DuracaoEmSegundos { get; set; }

        private List<Comentario> _comentarios;

        public Video(string titulo, string autor, int duracaoEmSegundos)
        {
            Titulo = titulo;
            Autor = autor;
            DuracaoEmSegundos = duracaoEmSegundos;
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
    }
}