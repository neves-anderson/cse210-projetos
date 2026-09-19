// REQUISITOS ADICIONAIS:
// 1. O programa possui uma lista contendo as escrituras e seleciona uma aleatoriamente a cada execução.
// 2. A seleção de palavras a serem escondidas escolhe apenas entre as palavras que ainda estão visíveis.
// 3. Optou-se por esconder apenas as palavras, mantendo pontuações (vírgulas, pontos) visíveis.


using System;
using System.Collections.Generic;

namespace MemorizadorEscrituras
{
    class Program
    {
        static void Main(string[] args)
        {
            // Biblioteca de escrituras para seleção aleatória
            List<Escritura> biblioteca = new List<Escritura>
            {
                new Escritura(
                    new Referencia("Provérbios", 3, 5, 6),
                    "Confia no Senhor de todo o teu coração, e não te estribes no teu próprio entendimento. Reconhece-o em todos os teus caminhos, e ele endireitará as tuas veredas."
                ),
                  new Escritura(
                    new Referencia("Eclesiastes", 3, 1),
                    "Tudo tem o seu tempo determinado, e todo propósito debaixo do céu tem seu tempo."
                ),
                new Escritura(
                    new Referencia("João", 3, 16),
                    "Porque Deus amou o mundo de tal maneira, que deu o seu Filho Unigênito, para que todo aquele que nele crê não pereça, mas tenha a vida eterna."
                ),
                new Escritura(
                    new Referencia("Mateus", 4, 2, 4),
                    "E tendo jejuado quarenta dias e quarenta noites, depois teve fome. E chegando-se a ele o tentador, disse: Se tu és o filho de Deus, manda que estas pedras se façam pães. Ele, porém, respondendo, disse: Está escrito: Nem só de pão viverá o homem, mas de toda a palavra que sai boca de Deus."
                ),
                  new Escritura(
                    new Referencia("1Néfi", 3, 7),
                    "E aconteceu que eu, Néfi, disse a meu pai: Eu irei e cumprirei as ordens do Senhor, porque sei que o Senhor nunca dá ordens aos filhos dos homens sem antes preparar um caminho pelo qual suas ordens possam ser cumpridas."
                ),
                  new Escritura(
                    new Referencia("Éter", 12, 27),
                    "E se os homens vierem a mim, mostrar-lhes-ei sua fraqueza. E dou a fraqueza aos homens a fim de que sejam humildes; e minha graça basta a todos os que se humilham perante mim; porque caso se humilhem perante mim e tenham fé em mim, então farei com que as coisas fracas se tornem fortes para eles."
                ),
                  new Escritura(
                    new Referencia("Doutrina & Convênios", 82, 10),
                    "Eu, o Senhor, estou obrigado quando fazeis o que eu digo, mas quando não fazeis, não tendes promessa alguma."
                ),
                  new Escritura(
                    new Referencia("Doutrina & Convênios", 95, 1),
                    "Em verdade assim diz o Senhor a vós, a quem amo; e a quem amo também castigo, para que seus pecados sejam perdoados, pois com o castigo preparo um meio para livrá-los da tentação em todas as coisas; e eu vos amo."
                )
            };

            // Seleciona uma escritura aleatória
            Random random = new Random();
            Escritura escritura = biblioteca[random.Next(biblioteca.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(escritura.ObterTexto());
                Console.WriteLine();

                if (escritura.EstaCompletamenteEscondida())
                {
                    break;
                }

                Console.Write("Pressione Enter para continuar ou digite 'sair' para encerrar: ");
                string entrada = Console.ReadLine();

                if (entrada.Trim().ToLower() == "sair")
                {
                    break;
                }

                // Oculta 3 palavras por iteração
                escritura.EsconderPalavrasAleatorias(3);
            }
        }
    }
}