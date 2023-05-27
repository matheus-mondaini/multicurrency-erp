using System;
using System.Linq;

namespace PedidoInternacional
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal.MostrarOpcoes();
            while (MenuPrincipal.Escolha()!=8)
            {
                switch(MenuPrincipal.Escolha())
                {
                    case 2:
                        {
                            Cliente.Registrar();
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
            public int codigo { get; set; }
            public string nome { get; set; }
            public Pais pais { get; set; }
            public static void Registrar()
            {

            }

        }
        public class Vendedor
        {

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