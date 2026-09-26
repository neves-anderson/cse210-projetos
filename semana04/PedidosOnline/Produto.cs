namespace SistemaPedidos
{
    public class Produto
    {
        private string _nome;
        private string _idProduto;
        private decimal _precoUnitario;
        private int _quantidade;

        public Produto(string nome, string idProduto, decimal precoUnitario, int quantidade)
        {
            _nome = nome;
            _idProduto = idProduto;
            _precoUnitario = precoUnitario;
            _quantidade = quantidade;
        }

        public string GetNome() => _nome;
        public string GetIdProduto() => _idProduto;
        public decimal GetPrecoUnitario() => _precoUnitario;
        public int GetQuantidade() => _quantidade;

        public decimal CalcularCustoTotal()
        {
            return _precoUnitario * _quantidade;
        }
    }
}