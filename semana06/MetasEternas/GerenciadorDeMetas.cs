using System;
using System.Collections.Generic;
using System.IO;

namespace MetasEternas
{
    public class GerenciadorDeMetas
    {
        private List<Meta> _metas;
        private int _pontos;

        public GerenciadorDeMetas()
        {
            _metas = new List<Meta>();
            _pontos = 0;
        }

        public void Iniciar()
        {
            bool sair = false;
            while (!sair)
            {
                Console.WriteLine();
                ExibirInfoJogador();
                Console.WriteLine("\n=== M E N U   P R I N C I P A L ===");
                Console.WriteLine("1. Criar Nova Meta");
                Console.WriteLine("2. Listar Metas");
                Console.WriteLine("3. Salvar Metas");
                Console.WriteLine("4. Carregar Metas");
                Console.WriteLine("5. Registrar Evento (Meta Cumpri)");
                Console.WriteLine("6. Ver Estatísticas & Conquistas");
                Console.WriteLine("7. Sair");
                Console.Write("Selecione uma opção do menu: ");

                string opcao = Console.ReadLine()?.Trim();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        CriarMeta();
                        break;
                    case "2":
                        ListarDetalhesDasMetas();
                        break;
                    case "3":
                        SalvarMetas();
                        break;
                    case "4":
                        CarregarMetas();
                        break;
                    case "5":
                        RegistrarEvento();
                        break;
                    case "6":
                        ExibirConquistas();
                        break;
                    case "7":
                        sair = true;
                        Console.WriteLine("Obrigado por usar o Programa de Metas Eternas! Continue progredindo na sua missão!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Tente novamente.");
                        break;
                }
            }
        }

        public void ExibirInfoJogador()
        {
            
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Pontuação Atual: {_pontos} pontos");
            
            // Barra de Progresso Visual
            int progresso = Math.Min(100, Math.Max(0, (_pontos % 500) * 100 / 500));
            int barras = progresso / 10;
            string barraVisual = new string('█', barras) + new string('░', 10 - barras);
            Console.WriteLine($"Progresso: {barraVisual} {progresso}% ({_pontos % 500}/500)");
            Console.ResetColor();
        }

        public void ListarNomesDasMetas()
        {
            if (_metas.Count == 0)
            {
                Console.WriteLine("Nenhuma meta cadastrada no momento.");
                return;
            }

            for (int i = 0; i < _metas.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {_metas[i].ObterNome()}");
            }
        }

        public void ListarDetalhesDasMetas()
        {
            if (_metas.Count == 0)
            {
                Console.WriteLine("Nenhuma meta para exibir.");
                return;
            }

            Console.WriteLine("=== LISTA DE METAS ===");
            for (int i = 0; i < _metas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_metas[i].ObterDetalhesEmTexto()}");
            }
        }

        public void CriarMeta()
        {
            Console.WriteLine("Tipos de Metas:");
            Console.WriteLine("  1. Meta Simples (Realizada 1 vez)");
            Console.WriteLine("  2. Meta Eterna (Repetida continuamente)");
            Console.WriteLine("  3. Meta de Lista de Tarefas (Requer N realizações + Bônus)");
            Console.WriteLine("  4. Meta Negativa (Evitar Mau Hábito - Perde Pontos se falhar)");
            Console.Write("Qual tipo de meta você gostaria de criar? ");

            string tipo = Console.ReadLine()?.Trim();

            Console.Write("Qual é o nome da sua meta? ");
            string nome = Console.ReadLine();

            Console.Write("Qual é uma curta descrição dela? ");
            string descricao = Console.ReadLine();

            int pontos = LerInteiro("Qual é a quantidade de pontos associada a esta meta? ");

            switch (tipo)
            {
                case "1":
                    _metas.Add(new MetaSimples(nome, descricao, pontos));
                    Console.WriteLine("Meta Simples criada com sucesso!");
                    break;

                case "2":
                    _metas.Add(new MetaEterna(nome, descricao, pontos));
                    Console.WriteLine("Meta Eterna criada com sucesso!");
                    break;

                case "3":
                    int total = LerInteiro("Quantas vezes essa meta precisa ser realizada para um bônus? ");
                    int bonus = LerInteiro("Qual é o bônus por realizar esse número de vezes? ");
                    _metas.Add(new MetaDeListaDeTarefas(nome, descricao, pontos, total, bonus));
                    Console.WriteLine("Meta de Lista de Tarefas criada com sucesso!");
                    break;

                case "4":
                    _metas.Add(new MetaNegativa(nome, descricao, pontos));
                    Console.WriteLine("Meta Negativa (Controle de Mau Hábito) criada com sucesso!");
                    break;

                default:
                    Console.WriteLine("Tipo de meta inválido. Operação cancelada.");
                    break;
            }
        }

        public void RegistrarEvento()
        {
            if (_metas.Count == 0)
            {
                Console.WriteLine("Você ainda não criou nenhuma meta.");
                return;
            }

            Console.WriteLine("Qual meta você cumpriu?");
            ListarNomesDasMetas();
            int indice = LerInteiro("Digite o número da meta: ") - 1;

            if (indice >= 0 && indice < _metas.Count)
            {
                Meta metaSelecionada = _metas[indice];
                int pontosGanhos = metaSelecionada.RegistrarEvento();

                if (pontosGanhos != 0)
                {
                    _pontos += pontosGanhos;
                    if (pontosGanhos > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\n🎉 Parabéns! Você ganhou {pontosGanhos} pontos!");
                        Console.WriteLine($"Você agora tem um total de {_pontos} pontos.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"Seu novo total é de {_pontos} pontos.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Número de meta inválido!");
            }
        }

        public void SalvarMetas()
        {
            Console.Write("Qual é o nome do arquivo de texto (ex: metas.txt)? ");
            string nomeArquivo = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(nomeArquivo)) nomeArquivo = "metas.txt";

            try
            {
                using (StreamWriter writer = new StreamWriter(nomeArquivo))
                {
                    writer.WriteLine(_pontos);
                    foreach (Meta meta in _metas)
                    {
                        writer.WriteLine(meta.ObterRepresentacaoEmTexto());
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Metas e pontuação salvas com sucesso em '{nomeArquivo}'!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar arquivo: {ex.Message}");
            }
        }

        public void CarregarMetas()
        {
            Console.Write("Qual é o nome do arquivo a ser carregado (ex: metas.txt)? ");
            string nomeArquivo = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(nomeArquivo)) nomeArquivo = "metas.txt";

            if (!File.Exists(nomeArquivo))
            {
                Console.WriteLine($"Arquivo '{nomeArquivo}' não encontrado!");
                return;
            }

            try
            {
                string[] linhas = File.ReadAllLines(nomeArquivo);
                if (linhas.Length == 0) return;

                _metas.Clear();
                _pontos = int.Parse(linhas[0]);

                for (int i = 1; i < linhas.Length; i++)
                {
                    string linha = linhas[i];
                    if (string.IsNullOrWhiteSpace(linha)) continue;

                    string[] partesTipo = linha.Split(':');
                    if (partesTipo.Length < 2) continue;

                    string tipo = partesTipo[0];
                    string[] dados = partesTipo[1].Split('|');

                    switch (tipo)
                    {
                        case "MetaSimples":
                            _metas.Add(new MetaSimples(dados[0], dados[1], int.Parse(dados[2]), bool.Parse(dados[3])));
                            break;

                        case "MetaEterna":
                            _metas.Add(new MetaEterna(dados[0], dados[1], int.Parse(dados[2])));
                            break;

                        case "MetaDeListaDeTarefas":
                            _metas.Add(new MetaDeListaDeTarefas(dados[0], dados[1], int.Parse(dados[2]), int.Parse(dados[4]), int.Parse(dados[3]), int.Parse(dados[5])));
                            break;

                        case "MetaNegativa":
                            _metas.Add(new MetaNegativa(dados[0], dados[1], int.Parse(dados[2]), int.Parse(dados[3])));
                            break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Metas e pontuação carregadas com sucesso de '{nomeArquivo}'!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar arquivo: {ex.Message}");
            }
        }

        public void ExibirConquistas()
        {
            Console.WriteLine("\n=== ESTATÍSTICAS E CONQUISTAS ===");
            Console.WriteLine($"Total de Metas Ativas: {_metas.Count}");
            Console.WriteLine($"Pontuação Total acumulada: {_pontos} pts");

            Console.WriteLine("\nBadges / Conquistas Desbloqueadas:");
            if (_pontos >= 100) Console.WriteLine("  🏆 [Primeiro Passo] Acumulou 100 pontos.");
            if (_pontos >= 500) Console.WriteLine("  🏆 [Guerreiro das Metas] Alcançou 500 pontos.");
            if (_pontos >= 1000) Console.WriteLine("  🏆 [Mestre Eterno] Ultrapassou 1.000 pontos!");
            if (_metas.Exists(m => m.EstaConcluida())) Console.WriteLine("  🏆 [Missão Cumprida] Concluiu pelo menos uma meta simples ou checklist.");
            if (_pontos < 100 && !_metas.Exists(m => m.EstaConcluida())) Console.WriteLine("  (Continue trabalhando para desbloquear mais conquistas!)");
        }

        private int LerInteiro(string mensagem)
        {
            int valor;
            while (true)
            {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out valor))
                {
                    return valor;
                }
                Console.WriteLine("Por favor, digite um número inteiro válido.");
            }
        }
    }
}