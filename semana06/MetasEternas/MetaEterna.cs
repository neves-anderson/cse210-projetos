using System;

namespace MetasEternas
{
    /// <summary>
    /// Representa uma meta eterna que nunca é concluída, concedendo pontos a cada repetição.
    /// </summary>
    public class MetaEterna : Meta
    {
        public MetaEterna(string nome, string descricao, int pontos)
            : base(nome, descricao, pontos)
        {
        }

        public override int RegistrarEvento()
        {
            return ObterPontos();
        }

        public override bool EstaConcluida()
        {
            return false;
        }

        public override string ObterRepresentacaoEmTexto()
        {
            return $"MetaEterna:{ObterNome()}|{ObterDescricao()}|{ObterPontos()}";
        }
    }
}