public abstract class Atividade
    {
        private string _nome;
        private string _descricao;
        private int _duracao;

        public Atividade(string nome, string descricao)
        {
            _nome = nome;
            _descricao = descricao;
            _duracao = 0;
        }

        public string GetNome() => _nome;
        public int GetDuracao() => _duracao;

        public void ExibirMensagemInicial()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"--- Bem-vindo à {GetNome()} ---");
            Console.ResetColor();
            Console.WriteLine($"\n{_descricao}\n");

            Console.Write("Por quantos segundos, em média, você gostaria que esta sessão durasse? ");
            while (!int.TryParse(Console.ReadLine(), out _duracao) || _duracao <= 0)
            {
                Console.Write("Por favor, digite um número inteiro de segundos válido: ");
            }

            Console.Clear();
            Console.WriteLine("Prepare-se para começar...");
            ExibirProgresso(3);
            Console.WriteLine();
        }

        public void ExibirMensagemFinal()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Muito bem!! Você concluiu o exercício com sucesso.");
            Console.ResetColor();
            ExibirProgresso(3);

            Console.WriteLine($"\nVocê completou {_duracao} segundos de {GetNome()}.");
            ExibirProgresso(4);
        }

        public void ExibirProgresso(int segundos)
        {
            List<string> animacaoSpinner = new List<string> { "|", "/", "-", "\\" };
            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = horaInicio.AddSeconds(segundos);

            int i = 0;
            while (DateTime.Now < horaFim)
            {
                string s = animacaoSpinner[i];
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");

                i = (i + 1) % animacaoSpinner.Count;
            }
        }

        public void ExibirContagemRegressiva(int segundos)
        {
            for (int i = segundos; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                
                int tamanhoString = i.ToString().Length;
                Console.Write(new string('\b', tamanhoString) + new string(' ', tamanhoString) + new string('\b', tamanhoString));
            }
        }

        public abstract void Executar();
    }