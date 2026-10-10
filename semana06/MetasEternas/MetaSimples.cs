using System;

namespace MetasEternas
{
    /// <summary>
    /// Representa uma meta simples que é realizada uma única vez.
    /// </summary>
    public class MetaSimples : Meta
    {
        private bool _estaConcluida;

        public MetaSimples(string nome, string descricao, int pontos, bool estaConcluida = false)
            : base(nome, descricao, pontos)
        {
            _estaConcluida = estaConcluida;
        }

        public override int RegistrarEvento()
        {
            if (!_estaConcluida)
            {
                _estaConcluida = true;
                return ObterPontos();
            }
            else
            {
                Console.WriteLine("Esta meta já foi concluída anteriormente!");
                return 0;
            }
        }

        public override bool EstaConcluida()
        {
            return _estaConcluida;
        }

        public override string ObterRepresentacaoEmTexto()
        {
            return $"MetaSimples:{ObterNome()}|{ObterDescricao()}|{ObterPontos()}|{_estaConcluida}";
        }
    }
}