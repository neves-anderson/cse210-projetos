using System;

namespace MetasEternas
{
    /// <summary>
    /// Classe base abstrata para todos os tipos de metas.
    /// Demonstra Abstração e Encapsulamento.
    /// </summary>
    public abstract class Meta
    {
        private string _nome;
        private string _descricao;
        private int _pontos;

        public Meta(string nome, string descricao, int pontos)
        {
            _nome = nome;
            _descricao = descricao;
            _pontos = pontos;
        }

        public string ObterNome() => _nome;
        public string ObterDescricao() => _descricao;
        public int ObterPontos() => _pontos;

        /// <summary>
        /// Registra um evento de cumprimento da meta e retorna os pontos ganhos (ou perdidos).
        /// </summary>
        public abstract int RegistrarEvento();

        /// <summary>
        /// Verifica se a meta foi totalmente concluída.
        /// </summary>
        public abstract bool EstaConcluida();

        /// <summary>
        /// Retorna a string formatada para exibição da meta na lista.
        /// </summary>
        public virtual string ObterDetalhesEmTexto()
        {
            string status = EstaConcluida() ? "[X]" : "[ ]";
            return $"{status} {_nome} ({_descricao})";
        }

        /// <summary>
        /// Retorna a representação em texto para salvamento em arquivo.
        /// </summary>
        public abstract string ObterRepresentacaoEmTexto();
    }
}