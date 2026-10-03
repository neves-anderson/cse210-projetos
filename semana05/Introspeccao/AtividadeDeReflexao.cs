public class AtividadeDeReflexao : Atividade
    {
        private List<string> _reflexoes;
        private List<string> _perguntas;

        private Queue<string> _reflexoesDisponiveis;
        private Queue<string> _perguntasDisponiveis;

        public AtividadeDeReflexao() : base(
            "Atividade de Reflexão",
            "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida.")
        {
            _reflexoes = new List<string>
            {
                "Pense em uma ocasião em que você defendeu outra pessoa.",
                "Pense em uma ocasião em que você fez algo realmente difícil.",
                "Pense em uma ocasião em que você ajudou alguém necessitado.",
                "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
            };

            _perguntas = new List<string>
            {
                "Por que essa experiência foi significativa para você?",
                "Você já fez algo assim antes?",
                "Como você começou?",
                "Como você se sentiu quando terminou?",
                "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
                "Qual é a sua coisa favorita sobre essa experiência?",
                "O que você pode aprender com essa experiência que se aplica a outras situações?",
                "O que você aprendeu sobre si mesmo por meio dessa experiência?",
                "Como você pode manter essa experiência em mente no futuro?"
            };

            _reflexoesDisponiveis = new Queue<string>();
            _perguntasDisponiveis = new Queue<string>();
        }

        public override void Executar()
        {
            ExibirMensagemInicial();

            string reflexao = ObterReflexaoAleatoriaSemRepetir();
            Console.WriteLine("Considere o seguinte prompt:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"--- {reflexao} ---");
            Console.ResetColor();
            Console.WriteLine("\nQuando você tiver algo em mente, pressione ENTER para continuar.");
            Console.ReadLine();

            Console.WriteLine("Agora, reflita sobre cada uma das seguintes perguntas em relação a essa experiência.");
            Console.Write("Você pode começar em: ");
            ExibirContagemRegressiva(5);
            Console.Clear();

            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(GetDuracao());

            while (DateTime.Now < horaFim)
            {
                string pergunta = ObterPerguntaAleatoriaSemRepetir();
                Console.Write($"\n> {pergunta} ");
                ExibirProgresso(5);
                Console.WriteLine();
            }

            ExibirMensagemFinal();
        }

        private string ObterReflexaoAleatoriaSemRepetir()
        {
            if (_reflexoesDisponiveis.Count == 0)
            {
                List<string> embaralhada = new List<string>(_reflexoes);
                Embaralhar(embaralhada);
                _reflexoesDisponiveis = new Queue<string>(embaralhada);
            }
            return _reflexoesDisponiveis.Dequeue();
        }

        private string ObterPerguntaAleatoriaSemRepetir()
        {
            if (_perguntasDisponiveis.Count == 0)
            {
                List<string> embaralhada = new List<string>(_perguntas);
                Embaralhar(embaralhada);
                _perguntasDisponiveis = new Queue<string>(embaralhada);
            }
            return _perguntasDisponiveis.Dequeue();
        }

        private void Embaralhar(List<string> lista)
        {
            Random rng = new Random();
            int n = lista.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = lista[k];
                lista[k] = lista[n];
                lista[n] = value;
            }
        }
    }