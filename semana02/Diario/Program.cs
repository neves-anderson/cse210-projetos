/* Acréscimos:
1. O programa valida entradas vazias e opções do menu para evitar exceções de execução.
2. Ao carregar um arquivo, o diário informa a quantidade de registros.*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Diario meuDiario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();

        bool executar = true;

        while (executar)
        {
            Console.WriteLine("\nPor favor, escolha uma das seguintes opções:");
            Console.WriteLine("1. Escrever um novo registro");
            Console.WriteLine("2. Exibir o diário");
            Console.WriteLine("3. Carregar o diário a partir de um arquivo");
            Console.WriteLine("4. Salvar o diário em um arquivo");
            Console.WriteLine("5. Sair");
            Console.Write("O que você gostaria de fazer? ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    string pergunta = gerador.ObterPerguntaAleatoria();
                    Console.WriteLine($"\nPergunta: {pergunta}");
                    Console.Write("> ");
                    string resposta = Console.ReadLine();

                    string dataAtual = DateTime.Now.ToShortDateString();
                    Registro novoRegistro = new Registro(dataAtual, pergunta, resposta);
                    meuDiario.AdicionarRegistro(novoRegistro);
                    
                    Console.WriteLine("Registro adicionado com sucesso!");
                    break;

                case "2":
                    meuDiario.ExibirTodos();
                    break;

                case "3":
                    Console.Write("\nQual é o nome do arquivo? ");
                    string arquivoCarregar = Console.ReadLine();
                    meuDiario.CarregarDoArquivo(arquivoCarregar);
                    break;

                case "4":
                    Console.Write("\nQual é o nome do arquivo? ");
                    string arquivoSalvar = Console.ReadLine();
                    meuDiario.SalvarNoArquivo(arquivoSalvar);
                    break;

                case "5":
                    executar = false;
                    Console.WriteLine("\nObrigado por usar o Programa de Diário. Até logo!");
                    break;

                default:
                    Console.WriteLine("\nOpção inválida. Por favor, tente novamente.");
                    break;
            }
        }
    }
}