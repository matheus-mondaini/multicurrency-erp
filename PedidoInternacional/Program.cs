using System;
using System.Linq;
using System.Runtime.CompilerServices;
using static PedidoInternacional.Cliente;

namespace PedidoInternacional
{
    class Program
    {
        public static List<Produto> produtos = new List<Produto>();
        public static List<Cliente> clientes = new List<Cliente>();
        public static List<Vendedor> vendedores = new List<Vendedor>();
        public static List<Moeda> moedas = new List<Moeda>();
        public static List<Pais> paises = new List<Pais>();
        public static List<Pedido> pedidos = new List<Pedido>();

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
                        Produto.Registrar();
                        break;
                    case 2:
                        Cliente.Registrar();
                        break;
                    case 3:
                        Vendedor.Registrar();
                        break;
                    case 4:
                        Pais.Registrar();
                        break;
                    case 5:
                        Moeda.Registrar();
                        break;
                    case 6:
                        Moeda.AlterarValor();
                        break;
                    case 7:
                        Pedido.CriarPedido();
                        break;
                    case 8:
                        Console.Write("Fechando o programa...");
                        break;
                    default:
                        Console.Write("Opção inválida! Tente novamente.");
                        break;
                }
                Console.WriteLine();
            } while (opcao != 8);
        }
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
            Console.Write("Escolha uma opção do menu principal: ");
            int escolha;
            while (!int.TryParse(Console.ReadLine(), out escolha))
            {
                Console.WriteLine("\nOpção inválida! Tente novamente.");
                Console.Write("Escolha uma opção: ");
            }
            return escolha;
        }
    }

    public class Produto : Mae
    {
        public decimal Preco { get; set; }
        public static void Registrar()
        {
            int codProduto = Program.produtos.Count + 1;
            Console.WriteLine($"Cadastre o Produto {codProduto}");
            Console.Write("Digite o nome: ");
            string? nomeProduto = Console.ReadLine();
            Console.Write("Digite o preço: ");
            decimal precoProduto;
            while (!decimal.TryParse(Console.ReadLine(), out precoProduto))
            {
                Console.Write("Digite um preço válido: ");
            }

            Produto produto = new Produto()
            {
                Codigo = codProduto,
                Nome = nomeProduto,
                Preco = precoProduto
            };
            Program.produtos.Add(produto);
            Console.WriteLine("Produto cadastrado com sucesso");
        }
    }

    public class Cliente : Mae
    {
        public Pais? Pais { get; set; }
        public static void Registrar()
        {
            int codCliente = Program.clientes.Count + 1;
            Console.WriteLine($"Cadastre o Cliente {codCliente}");
            Console.Write("Digite o nome: ");
            string? nomeCliente = Console.ReadLine();
            Console.Write("Digite o código do país: ");
            int codPais;
            while (!int.TryParse(Console.ReadLine(), out codPais))
            {
                Console.Write("Digite um código númerico: ");
            }

            Pais? pais = Program.paises.Find(p => p.Codigo == codPais);

            if (pais != null)
            {
                Cliente cliente = new Cliente()
                {
                    Codigo = codCliente,
                    Nome = nomeCliente,
                    Pais = pais
                };
                Program.clientes.Add(cliente);
                Console.WriteLine("Cliente cadastrado com sucesso");
            }
            else
            {
                Console.WriteLine("País não encontrado");
            }
        }
    }

    public class Vendedor : Mae
    {
        public static void Registrar()
        {
            int codVendedor = Program.vendedores.Count + 1;
            Console.WriteLine($"Cadastre o Vendedor {codVendedor}");
            Console.Write("Digite o nome: ");
            string? nomeVendedor = Console.ReadLine();

            Vendedor vendedor = new Vendedor()
            {
                Codigo = codVendedor,
                Nome = nomeVendedor
            };
            Program.vendedores.Add(vendedor);
            Console.WriteLine("Vendedor cadastrado com sucesso");
        }
    }

    public class Pais : Mae
    {
        public Moeda? Moeda { get; set; }
        public static void Registrar()
        {
            int codPais = Program.paises.Count + 1;
            Console.WriteLine($"Cadastre o país {codPais}");
            Console.Write("Digite o nome: ");
            string? nomePais = Console.ReadLine();
            Console.Write("Digite o código da moeda do país: ");
            string? moedaPais = Console.ReadLine();

            Moeda? moeda = Program.moedas.Find(m => m.Codigo == moedaPais);

            if (moeda != null)
            {
                Pais pais = new Pais()
                {
                    Codigo = codPais,
                    Nome = nomePais,
                    Moeda = moeda
                };
                Program.paises.Add(pais);
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
        public static void Registrar()
        {
            Console.WriteLine($"Cadastre uma nova moeda");

            Console.Write($"Digite o código ISO 4217 (3 Letras): ");
            string? codMoeda = Console.ReadLine();

            do
            {
                if (codMoeda?.Length != 3)
                {
                    Console.Write("O código ISO 4217 tem apenas 3 letras.\nTente novamente:");
                    codMoeda = Console.ReadLine();
                }

                Moeda? moedaExiste = Program.moedas.Find(m => m.Codigo == codMoeda);
                while (moedaExiste != null)
                {
                    Console.Write("Moeda com o mesmo código já cadastrada.\nDigite outro código ISO 4217: ");
                    codMoeda = Console.ReadLine();
                    moedaExiste = Program.moedas.Find(m => m.Codigo == codMoeda);
                }
            } while (codMoeda?.Length != 3);

            Console.Write("Digite o nome: ");
            string? nomeMoeda = Console.ReadLine();

            Console.Write("Digite o valor: ");
            decimal valorMoeda;
            while (!Decimal.TryParse(Console.ReadLine(), out valorMoeda))
            {
                Console.Write("Digite um valor decimal: ");
            }

            Moeda moeda = new Moeda()
            {
                Codigo = codMoeda,
                Nome = nomeMoeda,
                Valor = valorMoeda
            };
            Program.moedas.Add(moeda);
            Console.WriteLine("Moeda cadastrada com sucesso");
        }
        public static void AlterarValor()
        {
            if (Program.moedas.Count == 0)
                Console.WriteLine("Não há moedas cadastradas");
            else
            {
                Console.Write("Digite o código: ");
                string? codMoeda = Console.ReadLine();

                Moeda? moeda = Program.moedas.Find(m => m.Codigo == codMoeda);

                if (moeda != null)
                {
                    Console.Write("Digite o valor de câmbio atual: ");
                    decimal novoValor;
                    while (!Decimal.TryParse(Console.ReadLine(), out novoValor))
                    {
                        Console.Write("Digite um valor decimal: ");
                    }

                    moeda.Valor = novoValor;
                    Console.WriteLine("Valor alterado com sucesso");
                }
                else
                {
                    Console.WriteLine("Moeda não encontrada");
                }
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

        public static void CriarPedido()
        {
            Console.WriteLine("Faça um pedido: ");

            Console.Write("Código do vendedor: ");
            int codVendedor;
            while (!int.TryParse(Console.ReadLine(), out codVendedor))
            {
                Console.Write("Digite o código numérico do vendedor: ");
            }

            Vendedor? vendedor = Program.vendedores.Find(v => v.Codigo.Equals(codVendedor));

            if (vendedor == null)
            {
                Console.WriteLine("Vendedor não encontrado");
                return;
            }

            Console.Write("Código do cliente: ");
            int codCliente;
            while (!int.TryParse(Console.ReadLine(), out codCliente))
            {
                Console.Write("Digite o código numérico do cliente: ");
            }

            Cliente? cliente = Program.clientes.Find(c => c.Codigo.Equals(codCliente));

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado");
                return;
            }

            Moeda? moeda;
            Console.Write("Deseja usar a moeda do país do cliente? (S/N): ");
            string? usarMoedaCliente = Console.ReadLine();

            while (usarMoedaCliente != "S" && usarMoedaCliente != "N")
            {
                Console.Write("Escolhan sim ou não (S/N): ");
                usarMoedaCliente = Console.ReadLine();
            }

            if (usarMoedaCliente?.ToUpper() == "S")
            {
                moeda = cliente?.Pais?.Moeda;
                Console.WriteLine($"Será utilizada a moeda {moeda?.Codigo}");
            }
            else
            {
                Console.Write("Código da moeda: ");
                string? codMoeda = Console.ReadLine();

                moeda = Program.moedas.Find(m => m.Codigo == codMoeda);

                if (moeda == null)
                {
                    Console.WriteLine("Moeda não encontrada");
                    return;
                }
            }

            List<Produto> produtosPedido = new List<Produto>();

            bool desejaAdicionar = true;

            while (desejaAdicionar)
            {
                Console.WriteLine("Adicione um produto");
                Console.Write("Digite o código: ");
                int codProduto;
                while (!int.TryParse(Console.ReadLine(), out codProduto))
                {
                    Console.Write("Digite o código numérico do Produto: ");
                }

                Produto? produto = Program.produtos.Find(p => p.Codigo.Equals(codProduto));

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
            if (produtosPedido.Count > 0)
            {
                Pedido pedido = new Pedido
                {
                    Cliente = cliente,
                    Vendedor = vendedor,
                    Moeda = moeda,
                    Produtos = produtosPedido
                };

                Program.pedidos.Add(pedido);
                Console.WriteLine("Pedido cadastrado com sucesso");

                pedido.AtualizarPreco();
            }
        }

        public void AtualizarPreco()
        {
            decimal precoTotal = 0;
            foreach (Produto produto in Program.produtos)
            {
                precoTotal += produto.Preco;
            }
            if (Moeda?.Valor != null)
                PrecoTotal = precoTotal * Moeda.Valor;

            Console.WriteLine($"Preço total atualizado: {PrecoTotal}");
        }
    }

    public class Mae
    {
        public int Codigo { get; set; }
        public string? Nome { get; set; }
    }
}