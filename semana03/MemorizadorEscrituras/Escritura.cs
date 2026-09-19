using System;
using System.Collections.Generic;
using System.Linq;

namespace MemorizadorEscrituras
{
    public class Escritura
    {
        private Referencia _referencia;
        private List<Palavra> _palavras;

        public Escritura(Referencia referencia, string texto)
        {
            _referencia = referencia;
            _palavras = new List<Palavra>();

            // Divide a string em palavras separadas por espaço
            string[] palavrasMatriz = texto.Split(' ');
            foreach (string p in palavrasMatriz)
            {
                _palavras.Add(new Palavra(p));
            }
        }

        public void EsconderPalavrasAleatorias(int numeroParaEsconder)
        {
            // Seleciona apenas as palavras que ainda não estão escondidas
            List<Palavra> palavrasVisiveis = _palavras.Where(p => !p.EstaEscondida()).ToList();

            if (palavrasVisiveis.Count == 0) return;

            Random random = new Random();
            int escondidasNestaRodada = 0;

            while (escondidasNestaRodada < numeroParaEsconder && palavrasVisiveis.Count > 0)
            {
                int indiceSorteado = random.Next(palavrasVisiveis.Count);
                palavrasVisiveis[indiceSorteado].Esconder();
                
                // Remove da lista local para não sortear a mesma palavra no mesmo ciclo
                palavrasVisiveis.RemoveAt(indiceSorteado);
                escondidasNestaRodada++;
            }
        }

        public string ObterTexto()
        {
            List<string> textosPalavras = new List<string>();
            foreach (Palavra p in _palavras)
            {
                textosPalavras.Add(p.ObterTexto());
            }

            return $"{_referencia.ObterTexto()} - {string.Join(" ", textosPalavras)}";
        }

        public bool EstaCompletamenteEscondida()
        {
            return _palavras.All(p => p.EstaEscondida());
        }
    }
}