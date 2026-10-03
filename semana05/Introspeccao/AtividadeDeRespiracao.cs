public class AtividadeDeRespiracao : Atividade
    {
        public AtividadeDeRespiracao() : base(
            "Atividade de Respiração",
            "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
        {
        }

        public override void Executar()
        {
            ExibirMensagemInicial();

            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(GetDuracao());

            while (DateTime.Now < horaFim)
            {
                Console.Write("\nInspire...");
                ExibirAnimacaoRespiracao(4, inspirar: true);

                if (DateTime.Now >= horaFim) break;

                Console.Write("\nExpire...");
                ExibirAnimacaoRespiracao(6, inspirar: false);
                Console.WriteLine();
            }

            ExibirMensagemFinal();
        }

        private void ExibirAnimacaoRespiracao(int segundos, bool inspirar)
        {
            int passos = segundos * 2;
            int tempoPorPasso = 500;

            for (int i = 1; i <= passos; i++)
            {
                int tamanhoBarra = inspirar ? i : (passos - i + 1);
                string barraVisual = new string('*', tamanhoBarra);

                Console.Write($" [{barraVisual,-12}] ");
                Thread.Sleep(tempoPorPasso);
                Console.Write(new string('\b', 17));
            }
            Console.Write(new string(' ', 17));
            Console.Write(new string('\b', 17));
        }
    }