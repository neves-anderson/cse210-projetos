public class AtividadeDeListagem : Atividade
    {
        private List<string> _prompts;
        private Queue<string> _promptsDisponiveis;

        public AtividadeDeListagem() : base(
            "Atividade de Listagem",
            "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
        {
            _prompts = new List<string>
            {
                "Quem são as pessoas que você aprecia?",
                "Quais são seus pontos fortes pessoais?",
                "Quem são as pessoas que você ajudou esta semana?",
                "Quando você sentiu paz ou gratidão este mês?",
                "Quem são alguns dos seus heróis pessoais?"
            };

            _promptsDisponiveis = new Queue<string>();
        }

        public override void Executar()
        {
            ExibirMensagemInicial();

            string prompt = ObterPromptAleatorioSemRepetir();
            Console.WriteLine("Liste o máximo de itens possível para o seguinte tema:\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"--- {prompt} ---");
            Console.ResetColor();
            Console.Write("\nVocê pode começar em: ");
            ExibirContagemRegressiva(5);
            Console.WriteLine("\n");

            List<string> itensListados = ObterListaDoUsuario(GetDuracao());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nVocê listou {itensListados.Count} itens!");
            Console.ResetColor();

            ExibirMensagemFinal();
        }

        private List<string> ObterListaDoUsuario(int duracaoSegundos)
        {
            List<string> itens = new List<string>();
            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(duracaoSegundos);

            while (DateTime.Now < horaFim)
            {
                Console.Write("> ");

                // Verifica se há texto sem bloquear indefinidamente quando o tempo expira
                while (!Console.KeyAvailable)
                {
                    if (DateTime.Now >= horaFim)
                    {
                        return itens;
                    }
                    Thread.Sleep(100);
                }

                string entrada = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(entrada))
                {
                    itens.Add(entrada.Trim());
                }
            }

            return itens;
        }

        private string ObterPromptAleatorioSemRepetir()
        {
            if (_promptsDisponiveis.Count == 0)
            {
                List<string> embaralhada = new List<string>(_prompts);
                Random rng = new Random();
                int n = embaralhada.Count;
                while (n > 1)
                {
                    n--;
                    int k = rng.Next(n + 1);
                    string value = embaralhada[k];
                    embaralhada[k] = embaralhada[n];
                    embaralhada[n] = value;
                }
                _promptsDisponiveis = new Queue<string>(embaralhada);
            }
            return _promptsDisponiveis.Dequeue();
        }
    }
