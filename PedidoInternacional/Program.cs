﻿using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PedidoInternacional
{
    class Program
    {
        static List<Produto> produtos = new List<Produto>();
        static List<Cliente> clientes = new List<Cliente>();
        static List<Vendedor> vendedores = new List<Vendedor>();
        static List<Moeda> moedas = new List<Moeda>();
        static List<Pais> paises = new List<Pais>();
        static List<Pedido> pedidos = new List<Pedido>();
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
                    case 1:
                        {
                            Produto.Registrar(produtos);
                            break;
                        }
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
                    case 4:
                        {
                            Pais.Registrar(paises, moedas);
                            break;
                        }
                    case 5:
                        {
                            Moeda.Registrar(moedas);
                            break;
                        }
                    case 6:
                        {
                            Moeda.AlterarValor(moedas);
                            break;
                        }
                    case 7:
                        {
                            Pedido.CriarPedido(clientes, vendedores, moedas, produtos);
                            break;
                        }
                    case 8:
                        {
                            Console.Write("Fechando o programa...");
                            break;
                        }
                    default:
                        {
                            Console.Write("Opção inválida! Tente novamente. ");
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
                Console.WriteLine("8 - Sair\n");
            }
            public static int Escolha()
            {
                Console.Write("Escolha uma opção: ");
                int escolha = Convert.ToInt32(Console.ReadLine());
                return escolha;
            }
        }
        public class Produto : Vendedor
        {
            public decimal Preco { get; set; }
            public static void Registrar(List<Produto> produtos)
            {
                int codProduto = produtos.Count + 1;
                Console.WriteLine($"Cadastre o Produto {codProduto}");
                Console.Write("Digite o nome: ");
                string? nomeProduto = Console.ReadLine();
                Console.Write($"Digite o preço: ");
                decimal precoProduto = Convert.ToInt32(Console.ReadLine());

                Produto produto = new Produto()
                {
                    Codigo = codProduto,
                    Nome = nomeProduto,
                    Preco = precoProduto
                };
                produtos.Add(produto);
                Console.WriteLine("Produto cadastrado com sucesso");
            }
        }
        public class Cliente : Vendedor
        {
            public Pais? Pais { get; set; }
            public static void Registrar(List<Cliente> clientes)
            {
                int codCliente = clientes.Count + 1;
                Console.WriteLine($"Cadastre o Cliente {codCliente}");
                Console.Write("Digite o nome: ");
                string? nomeCliente = Console.ReadLine();
                Console.Write("Digite o código do país: ");
                int codPais = Convert.ToInt32(Console.ReadLine());

                Pais? pais = paises.Find(p => p.Codigo == codPais);

                if (pais != null)
                {
                    Cliente cliente = new Cliente()
                    {
                        Codigo = codCliente,
                        Nome = nomeCliente,
                        Pais = pais
                    };
                    clientes.Add(cliente);
                    Console.WriteLine("Cliente cadastrado com sucesso");
                }
                else
                {
                    Console.WriteLine("País não encontrado");
                }
            }

        }
        public class Vendedor
        {
            public int Codigo { get; set; }
            public string? Nome { get; set; }
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
        public class Pais : Vendedor
        {
            public Moeda? Moeda { get; set; }
            public static void Registrar(List<Pais> paises, List<Moeda> moedas)
            {
                int codPais = paises.Count + 1;
                Console.WriteLine($"Cadastre o país {codPais}");
                Console.Write("Digite o nome: ");
                string? nomePais = Console.ReadLine();
                Console.Write("Digite o código da moeda do país: ");
                string? moedaPais = Console.ReadLine();

                Moeda? moeda = moedas.Find(m => m.Codigo == moedaPais);

                if (moeda != null)
                {
                    Pais pais = new Pais()
                    {
                        Codigo = codPais,
                        Nome = nomePais,
                        Moeda = moeda
                    };
                    paises.Add(pais);
                    Console.WriteLine("País cadastrado com sucesso");
                }
                else
                {
                    Console.WriteLine("Moeda não encontrada");
                }
            }
        }
        public class Moeda
        {
            public string? Codigo { get; set; }
            public string? Nome { get; set; }
            public decimal Valor { get; set; }
            public static void Registrar(List<Moeda> moedas)
            {
                Console.WriteLine($"Cadastre uma nova moeda");
                Console.Write($"Digite o código ISO 4217 (3 Letras): ");
                string? codMoeda = Console.ReadLine();
                Console.Write("Digite o nome: ");
                string? nomeMoeda = Console.ReadLine();
                Console.Write("Digite o valor: ");
                decimal valorMoeda = Convert.ToDecimal(Console.ReadLine());

                Moeda moeda = new Moeda()
                {
                    Codigo = codMoeda,
                    Nome = nomeMoeda,
                    Valor = valorMoeda
                };
                moedas.Add(moeda);
                Console.WriteLine("Moeda cadastrada com sucesso");
            }
            public static void AlterarValor(List<Moeda> moedas)
            {
                Console.Write("Digite o código: ");
                string? codMoeda = Console.ReadLine();

                Moeda? moeda = moedas.Find(m => m.Codigo == codMoeda);

                if (moeda != null)
                {
                    Console.Write("Digite o valor de câmbio atual: ");
                    decimal novoValor = Convert.ToDecimal(Console.ReadLine());

                    moeda.Valor = novoValor;
                    Console.WriteLine("Valor alterado com sucesso");
                }
                else
                {
                    Console.WriteLine("Moeda não encontrada");
                }
            }
        }
        public class Pedido
        {
            public Cliente? Cliente { get; set; }
            public Vendedor? Vendedor { get; set; }
            public Moeda? Moeda { get; set; }
            public List<Produto>? Produtos { get; set; }
            public decimal PrecoTotal { get; set; }

            public static void CriarPedido (List<Cliente> clientes, List<Vendedor> vendedores, List<Moeda> moedas, List<Produto> produtos)
            {
                Console.WriteLine("Faça um pedido: ");

                Console.Write("Código do vendedor: ");
                int codVendedor = Convert.ToInt32(Console.ReadLine());
                Console.Write("Código do cliente: ");
                int codCliente = Convert.ToInt32(Console.ReadLine());
                Console.Write("Código da moeda: ");
                string? codMoeda = Console.ReadLine();

                Vendedor? vendedor = vendedores.Find(v => v.Codigo.Equals(codVendedor));
                Cliente? cliente = clientes.Find(c => c.Codigo.Equals(codCliente));
                Moeda? moeda = moedas.Find(m => m.Codigo == codMoeda);

                if (vendedor == null)
                    Console.WriteLine("Vendedor não encontrado");

                if (cliente == null)
                    Console.WriteLine("Cliente não encontrado");

                if (moeda == null)
                    Console.WriteLine("Moeda não encontrada");

                else
                {
                    List<Produto> produtosPedido = new List<Produto>();

                    bool desejaAdicionar = true;

                    while (desejaAdicionar)
                    {
                        Console.WriteLine("Adicione um produto");
                        Console.Write("Digite o código: ");
                        int codProduto = Convert.ToInt32(Console.ReadLine());

                        Produto? produto = produtos.Find(p => p.Codigo.Equals(codProduto));

                        if (produto != null)
                        {
                            produtosPedido.Add(produto);
                            Console.WriteLine("Produto adicionado com sucesso");
                            Console.Write("Deseja adicionar mais um produto? (S/N): ");
                            string? sN = Console.ReadLine();
                            if (sN?.ToUpper() == "N")
                                desejaAdicionar = false;
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado.");
                            Console.Write("Deseja tentar redigitar o código? (S/N): ");
                            string? sN = Console.ReadLine();
                            if (sN?.ToUpper() == "N")
                                desejaAdicionar = false;
                        }

                    }
                    if (produtosPedido.Count>0)
                    {
                        Pedido pedido = new Pedido
                        {
                            Cliente = cliente,
                            Vendedor = vendedor,
                            Moeda = moeda,
                            Produtos = produtosPedido
                        };
                        
                        pedidos.Add(pedido);
                        Console.WriteLine("Pedido cadastrado com sucesso");

                        pedido.AtualizarPreco();
                    }
                }
            }
            public void AtualizarPreco()
            {
                decimal precoTotal = 0;
                foreach (Produto produto in produtos)
                {
                    precoTotal += produto.Preco;
                }
                PrecoTotal = precoTotal * Moeda.Valor;

                Console.WriteLine($"Preço total atualizado: {PrecoTotal}");
            }
        }
    }
}