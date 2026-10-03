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
            Console.Write("\nInspire:");
            ExibirAnimacaoRespiracao(4, inspirar: true);

            if (DateTime.Now >= horaFim) break;

            Console.Write("\nExpire:");
            ExibirAnimacaoRespiracao(6, inspirar: false);
            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }

    private void ExibirAnimacaoRespiracao(int segundos, bool inspirar)
    {
        int passos = segundos * 2;
        int tempoPorPasso = 500;

        for (int i = 0; i < passos; i++)
        {
            // Inspirar: começa cheio (passos - i) e vai reduzindo
            // Expirar: começa vazio (i) e vai aumentando
            int tamanhoBarra = inspirar ? (passos - i) : i;
            string barraVisual = new string('*', tamanhoBarra);

            // Formata a barra dinamicamente com base no total de passos da etapa
            string textoExibido = $" [{barraVisual.PadRight(passos)}] ";

            Console.Write(textoExibido);
            Thread.Sleep(tempoPorPasso);

            // Apaga exatamente a quantidade de caracteres exibidos na tela
            Console.Write(new string('\b', textoExibido.Length));
        }

        // Limpa permanentemente a linha ao finalizar o ciclo da animação
        int larguraTotal = passos + 4;
        Console.Write(new string(' ', larguraTotal));
        Console.Write(new string('\b', larguraTotal));
    }
}