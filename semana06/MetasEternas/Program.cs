/*

RECURSOS ADICIONAIS IMPLEMENTADOS:

1. Exibição visual de barra de progresso: [████░░░░░░] 40%.

2. Tipo de Meta Adicional - Meta Negativa / Mau Hábito (MetaNegativa):
   - Permite ao usuário registrar hábitos indesejados que deseja abandonar.
   - Subtrai pontos quando registrada uma recaída, estimulando o autocontrole.

3. Tratamento de Erros e Validações de Entrada Avançadas:
   - Prevenção de erros ao carregar arquivos vazios ou entradas numéricas inválidas.

*/

using System;

namespace MetasEternas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();
            gerenciador.Iniciar();
        }
    }
}