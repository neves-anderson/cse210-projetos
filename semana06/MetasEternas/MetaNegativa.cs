using System;

namespace MetasEternas
{
    /// <summary>
    /// Representa um mau hábito a evitar. Quando registrada uma recaída, o jogador perde pontos.
    /// </summary>
    public class MetaNegativa : Meta
    {
        private int _vezesRegistrada;

        public MetaNegativa(string nome, string descricao, int penalidade, int vezesRegistrada = 0)
            : base(nome, descricao, penalidade)
        {
            _vezesRegistrada = vezesRegistrada;
        }

        public override int RegistrarEvento()
        {
            _vezesRegistrada++;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"⚠️ Cuidado! Ceder ao mau hábito '{ObterNome()}' fez você perder {ObterPontos()} pontos.");
            Console.ResetColor();
            return -ObterPontos();
        }

        public override bool EstaConcluida()
        {
            return false;
        }

        public override string ObterDetalhesEmTexto()
        {
            return $"[🚫 Mau Hábito] {ObterNome()} ({ObterDescricao()}) -- Recaídas: {_vezesRegistrada} (-{ObterPontos()} pts/cada)";
        }

        public override string ObterRepresentacaoEmTexto()
        {
            return $"MetaNegativa:{ObterNome()}|{ObterDescricao()}|{ObterPontos()}|{_vezesRegistrada}";
        }
    }
}