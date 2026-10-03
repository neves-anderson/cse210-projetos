/*
 =============================== RECURSOS ADICIONAIS ==================================
 1. Seleção Única Sem Repetição: As classes AtividadeDeReflexao e AtividadeDeListagem
     mantêm uma fila interna dinâmica para garantir que nenhuma pergunta seja repetido
     antes que todos os itens tenham sido apresentados.
 2. Estatísticas: Há no menu principal uma opção para exibir estatísticas do histórico
    de atividades. Um arquivo chamado 'log_introspecao.txt' registrando o histórico das 
    atividades concluídas.
 ======================================================================================
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace AppIntrospecao
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalSessoesGerais = 0;
            int tempoTotalGeral = 0;

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=================================================");
                Console.WriteLine("         PROGRAMA DE INTROSPECÇÃO E BEM-ESTAR    ");
                Console.WriteLine("=================================================");
                Console.ResetColor();
                Console.WriteLine("Menu de Opções:");
                Console.WriteLine("  1. Iniciar Atividade de Respiração");
                Console.WriteLine("  2. Iniciar Atividade de Reflexão");
                Console.WriteLine("  3. Iniciar Atividade de Listagem");
                Console.WriteLine("  4. Ver Estatísticas do Histórico (Log)");
                Console.WriteLine("  5. Sair");
                Console.Write("\nEscolha uma opção do menu: ");

                string opcao = Console.ReadLine();

                Atividade atividadeAtual = null;

                switch (opcao)
                {
                    case "1":
                        atividadeAtual = new AtividadeDeRespiracao();
                        break;
                    case "2":
                        atividadeAtual = new AtividadeDeReflexao();
                        break;
                    case "3":
                        atividadeAtual = new AtividadeDeListagem();
                        break;
                    case "4":
                        ExibirHistorico();
                        continue;
                    case "5":
                        Console.WriteLine("\nObrigado por dedicar este tempo a si mesmo. Até logo!");
                        return;
                    default:
                        Console.WriteLine("\nOpção inválida! Pressione ENTER para tentar novamente.");
                        Console.ReadLine();
                        continue;
                }

                if (atividadeAtual != null)
                {
                    atividadeAtual.Executar();
                    totalSessoesGerais++;
                    tempoTotalGeral += atividadeAtual.GetDuracao();
                    
                    SalvarLog(atividadeAtual.GetNome(), atividadeAtual.GetDuracao());
                }
            }
        }

        private static void ExibirHistorico()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=== HISTÓRICO DE ATIVIDADES REGISTRADAS ===");
            Console.ResetColor();

            string caminhoArquivo = "log_introspecao.txt";
            if (File.Exists(caminhoArquivo))
            {
                string[] linhas = File.ReadAllLines(caminhoArquivo);
                foreach (string linha in linhas)
                {
                    Console.WriteLine(linha);
                }
            }
            else
            {
                Console.WriteLine("Nenhum registro encontrado ainda.");
            }

            Console.WriteLine("\nPressione ENTER para voltar ao menu.");
            Console.ReadLine();
        }

        private static void SalvarLog(string nomeAtividade, int duracao)
        {
            string caminhoArquivo = "log_introspecao.txt";
            string mensagem = $"[{DateTime.Now:dd/MM/yyyy HH:mm:ss}] Atividade: {nomeAtividade} | Duração: {duracao} segundos";
            try
            {
                File.AppendAllText(caminhoArquivo, mensagem + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar histórico: {ex.Message}");
            }
        }
    }
}