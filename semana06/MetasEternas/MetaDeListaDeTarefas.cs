using System;

namespace MetasEternas
{
    /// <summary>
    /// Representa uma meta que requer N realizações para ser concluída,
    /// concedendo um bônus especial de pontos no cumprimento total.
    /// </summary>
    public class MetaDeListaDeTarefas : Meta
    {
        private int _concluidas;
        private int _total;
        private int _bonus;

        public MetaDeListaDeTarefas(string nome, string descricao, int pontos, int total, int bonus, int concluidas = 0)
            : base(nome, descricao, pontos)
        {
            _total = total;
            _bonus = bonus;
            _concluidas = concluidas;
        }

        public override int RegistrarEvento()
        {
            if (_concluidas < _total)
            {
                _concluidas++;
                if (_concluidas == _total)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"★ PARABÉNS! Você atingiu o objetivo final de '{ObterNome()}' e ganhou um BÔNUS de {_bonus} pontos!");
                    Console.ResetColor();
                    return ObterPontos() + _bonus;
                }
                return ObterPontos();
            }
            else
            {
                Console.WriteLine("Esta meta de lista de tarefas já foi totalmente concluída!");
                return 0;
            }
        }

        public override bool EstaConcluida()
        {
            return _concluidas >= _total;
        }

        public override string ObterDetalhesEmTexto()
        {
            string status = EstaConcluida() ? "[X]" : "[ ]";
            return $"{status} {ObterNome()} ({ObterDescricao()}) -- Concluído: {_concluidas}/{_total}";
        }

        public override string ObterRepresentacaoEmTexto()
        {
            return $"MetaDeListaDeTarefas:{ObterNome()}|{ObterDescricao()}|{ObterPontos()}|{_bonus}|{_total}|{_concluidas}";
        }
    }
}