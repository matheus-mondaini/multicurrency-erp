using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PedidoInternacional
{
    class Program
    {
        static List<Cliente> clientes = new List<Cliente>();
        static List<Vendedor> vendedores = new List<Vendedor>();
        static void Main(string[] args)
        {
            MenuPrincipal.MostrarOpcoes();
            int opcao;
            do
            {
                opcao = MenuPrincipal.Escolha();
                Console.WriteLine();
                switch (opcao)
                {
                    case 2:
                        {
                            Cliente.Registrar(clientes);
                            break;
                        }
                    case 3:
                        {
                            Vendedor.Registrar(vendedores);
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine("Fechando o programa...");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Opção inválida! Tente novamente. ");
                            break;
                        }
                }
                Console.WriteLine();
            } while (opcao != 8);
        }
        public class MenuPrincipal
        {
            public static void MostrarOpcoes()
            {
                Console.WriteLine("Exporte com nosso Alegre ERP");
                Console.WriteLine("1 - Cadastrar um produto");
                Console.WriteLine("2 - Cadastrar um cliente");
                Console.WriteLine("3 - Cadastrar um vendedor");
                Console.WriteLine("4 - Cadastrar um país");
                Console.WriteLine("5 - Cadastrar uma moeda");
                Console.WriteLine("6 - Alterar a taxa de câmbio de uma moeda");
                Console.WriteLine("7 - Faça uma venda");
                Console.WriteLine("8 - Sair");
            }
            public static int Escolha()
            {
                Console.WriteLine("Escolha uma opção: ");
                int escolha = Convert.ToInt32(Console.ReadLine());
                return escolha;
            }
        }
        public class Produto
        {

        }
        public class Cliente
        {
            public int Codigo { get; set; }
            public string? Nome { get; set; }
            //public Pais Pais { get; set; }
            public static void Registrar(List<Cliente> clientes)
            {
                int codCliente = clientes.Count + 1;
                Console.WriteLine($"Cadastre o Cliente {codCliente}");
                Console.Write("Digite o nome: ");
                string? nomeCliente = Console.ReadLine();
                //Console.WriteLine("Digite o código do país: ");
                //int codPais = Convert.ToInt32(Console.ReadLine());

                Cliente cliente = new Cliente()
                {
                    Codigo = codCliente,
                    Nome = nomeCliente,
                    //Pais = pais
                };
                clientes.Add(cliente);
                Console.WriteLine("Cliente cadastrado com sucesso");
            }

        }
        public class Vendedor : Cliente
        {
            public static void Registrar(List<Vendedor> vendedores)
            {
                int codVendedor = vendedores.Count + 1;
                Console.WriteLine($"Cadastre o Vendedor {codVendedor}");
                Console.Write("Digite o nome: ");
                string? nomeVendedor = Console.ReadLine();

                Vendedor vendedor = new Vendedor()
                {
                    Codigo = codVendedor,
                    Nome = nomeVendedor
                };
                vendedores.Add(vendedor);
                Console.WriteLine("Vendedor cadastrado com sucesso");
            }
        }
        public class Pais
        {

        }
        public class Moeda
        {

        }
        public class Pedido
        {
                
        }
        public class Orcamento
        {
                
        }
    }
}