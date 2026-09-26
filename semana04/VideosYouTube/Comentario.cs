namespace YouTubeMonitoring
{
    public class Comentario
    {
        public string NomeAutor { get; set; }
        public string Texto { get; set; }

        public Comentario(string nomeAutor, string texto)
        {
            NomeAutor = nomeAutor;
            Texto = texto;
        }
    }
}