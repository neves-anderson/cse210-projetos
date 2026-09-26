namespace SistemaPedidos
{
    public class Cliente
    {
        private string _nome;
        private Endereco _endereco;

        public Cliente(string nome, Endereco endereco)
        {
            _nome = nome;
            _endereco = endereco;
        }

        public string GetNome() => _nome;
        public Endereco GetEndereco() => _endereco;

        public bool MoraNosEUA()
        {
            return _endereco.EUA();
        }
    }
}