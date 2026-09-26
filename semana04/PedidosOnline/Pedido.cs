using System.Collections.Generic;
using System.Text;

namespace SistemaPedidos
{
    public class Pedido
    {
        private List<Produto> _produtos;
        private Cliente _cliente;

        public Pedido(Cliente cliente)
        {
            _cliente = cliente;
            _produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            _produtos.Add(produto);
        }

        public decimal CalcularCustoTotal()
        {
            decimal totalProdutos = 0m;
            foreach (Produto produto in _produtos)
            {
                totalProdutos += produto.CalcularCustoTotal();
            }

            decimal custoEnvio = _cliente.MoraNosEUA() ? 5.00m : 35.00m;
            return totalProdutos + custoEnvio;
        }

        public string ObterEtiquetaEmbalagem()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ETIQUETA DE EMBALAGEM:");
            foreach (Produto produto in _produtos)
            {
                sb.AppendLine($" - Item: {produto.GetNome()} | ID: {produto.GetIdProduto()} | Qtd: {produto.GetQuantidade()}");
            }
            return sb.ToString();
        }

        public string ObterEtiquetaEnvio()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ETIQUETA DE ENVIO:");
            sb.AppendLine($"Cliente: {_cliente.GetNome()}");
            sb.AppendLine(_cliente.GetEndereco().ObterEnderecoFormatado());
            return sb.ToString();
        }
    }
}