using System;
using System.Globalization;

namespace SistemaPedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configura formatação de moeda para dólar ($)
            CultureInfo culture = new CultureInfo("en-US");

            // --- Pedido 1: Cliente nos EUA ---
            Endereco endEUA = new Endereco("123 Main Street", "Seattle", "WA", "USA");
            Cliente clienteEUA = new Cliente("John Doe", endEUA);
            Pedido pedido1 = new Pedido(clienteEUA);

            pedido1.AdicionarProduto(new Produto("Teclado Mecânico RGB", "PROD-101", 75.50m, 1));
            pedido1.AdicionarProduto(new Produto("Mouse Ergonomico", "PROD-202", 25.00m, 2));
            pedido1.AdicionarProduto(new Produto("Mousepad Extra Grande", "PROD-303", 15.00m, 1));

            // --- Pedido 2: Cliente fora dos EUA (Brasil) ---
            Endereco endBrasil = new Endereco("Av. Eduardo Ribeiro, 500", "Manaus", "AM", "Brasil");
            Cliente clienteBrasil = new Cliente("Anderson Neves", endBrasil);
            Pedido pedido2 = new Pedido(clienteBrasil);

            pedido2.AdicionarProduto(new Produto("Monitor Ultrawide 29\"", "PROD-404", 299.99m, 1));
            pedido2.AdicionarProduto(new Produto("Suporte Articulado de Piston", "PROD-505", 45.00m, 1));

            // --- Exibição de Pedido 1 ---
            Console.WriteLine("================ PEDIDO NÚMERO 1 ==================");
            Console.Write(pedido1.ObterEtiquetaEmbalagem());
            Console.WriteLine("--------------------------------------------------");
            Console.Write(pedido1.ObterEtiquetaEnvio());
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"PREÇO TOTAL (Produtos + Frete EUA $5.00): {pedido1.CalcularCustoTotal().ToString("C", culture)}");
            Console.WriteLine("==================================================\n");

            // --- Exibição de Pedido 2 ---
            Console.WriteLine("================ PEDIDO NÚMERO 2 ==================");
            Console.Write(pedido2.ObterEtiquetaEmbalagem());
            Console.WriteLine("--------------------------------------------------");
            Console.Write(pedido2.ObterEtiquetaEnvio());
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"PREÇO TOTAL (Produtos + Frete Internacional $35.00): {pedido2.CalcularCustoTotal().ToString("C", culture)}");
            Console.WriteLine("==================================================");
        }
    }
}