using System;
using System.Collections.Generic;

namespace YouTubeMonitoring
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> listaDeVideos = new List<Video>();

            // --- Vídeo 1 ---
            Video video1 = new Video("Análise Teardown do Novo Smartphone X", "TechReview BR", 645);
            video1.AdicionarComentario(new Comentario("Lucas Silva", "Achei a bateria excelente pela faixa de preço!"));
            video1.AdicionarComentario(new Comentario("Mariana Costa", "A câmera em ambientes escuros deixou a desejar."));
            video1.AdicionarComentario(new Comentario("Carlos Eduardo", "Ótima análise detalhada, parabéns pelo canal!"));
            listaDeVideos.Add(video1);

            // --- Vídeo 2 ---
            Video video2 = new Video("Unboxing e Primeiro Uso do Fone NoiseCancelling 3000", "AudioGurus", 420);
            video2.AdicionarComentario(new Comentario("Aline Souza", "O cancelamento de ruído funciona bem no transporte público?"));
            video2.AdicionarComentario(new Comentario("AudioGurus", "Respondi sua dúvida no topo dos comentários fixa!"));
            video2.AdicionarComentario(new Comentario("Roberto Rocha", "Preço meio salgado, mas o acabamento parece premium."));
            video2.AdicionarComentario(new Comentario("Fernanda Lima", "Comprei semana passada e estou adorando."));
            listaDeVideos.Add(video2);

            // --- Vídeo 3 ---
            Video video3 = new Video("Como Escolher o Notebook Ideal para Trabalho e Estudos", "Guia do Consumidor", 890);
            video3.AdicionarComentario(new Comentario("Gabriel Mendes", "Vídeo muito esclarecedor para quem está em dúvida."));
            video3.AdicionarComentario(new Comentario("Beatriz Ramos", "Poderia fazer um vídeo focado só em modelos até R$ 3.000?"));
            video3.AdicionarComentario(new Comentario("João Pedro", "A dica sobre a quantidade de memória RAM salvou minha compra!"));
            listaDeVideos.Add(video3);

            // --- Exibição dos dados armazenados ---
            Console.WriteLine("==================================================");
            Console.WriteLine("    SISTEMA DE RASTREAMENTO DE VÍDEOS DO YOUTUBE  ");
            Console.WriteLine("==================================================\n");

            foreach (Video video in listaDeVideos)
            {
                Console.WriteLine($"Título: {video.ObterTitulo()}");
                Console.WriteLine($"Autor: {video.ObterAutor()}");
                Console.WriteLine($"Duração: {video.ObterDuracaoEmSegundos()} segundos ({video.ObterDuracaoEmSegundos() / 60}m {video.ObterDuracaoEmSegundos() % 60}s)");
                Console.WriteLine($"Total de Comentários: {video.ObterQuantidadeComentarios()}");
                Console.WriteLine("Comentários:");

                foreach (Comentario comentario in video.ObterComentarios())
                {
                    Console.WriteLine($"  - [{comentario.ObterNomeAutor()}]: \"{comentario.ObterTexto()}\"");
                }

                Console.WriteLine("\n--------------------------------------------------\n");
            }
        }
    }
}