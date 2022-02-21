using System;
using AtivSem01.Biblioteca;

namespace AtivSem01
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 1;
            string rota = @"C:\Users\Miguel\Desktop\Codigo Fonte\AtivSem01\SolucaoAtivSem01\AtivSem01\Biblioteca\RegistroDados\";

            Clientes clientes = new Clientes();
            Funcoes funcoes = new Funcoes();
            Pedidos pedidos = new Pedidos();

            while (opcao != 0)
            {
                Console.WriteLine
                    (
                    "Selecione uma das opcoes: " +
                    "\n1 - Soma de Matrizes" +
                    "\n2 - Maior entre quatro numeros" +
                    "\n3 - Inserir Cliente" +
                    "\n4 - Alterar Cliente" +
                    "\n5 - Deletar Cliente" +
                    "\n6 - Pesquisar Cliente" +
                    "\n7 - Inserir Pedido" +
                    "\n8 - Alterar Pedido" +
                    "\n9 - Deletar Pedido" +
                    "\n10 - Pesquisar Pedido" +
                    "\n11 - Definir rota de pasta para registrar os dados Cliente/Pedidos" +
                    "\n0 - SAIR" 
                    );
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 0:
                        // Encerra o programa.
                        Console.WriteLine("Encerrando...");
                        break;
                    case 1:
                        Console.WriteLine(funcoes.SomaMatrizes());
                        break;
                    case 2:
                        Console.WriteLine(funcoes.MaiorEntreQuatro());
                        break;
                    case 3:
                        clientes = cadastroCliente();
                        clientes.Inserir(rota);
                        break;
                    case 4:
                        clientes.Alterar();
                        break;
                    case 5:
                        clientes.Deletar();
                        break;
                    case 6:
                        clientes.Pesquisar();
                        break;
                    case 7:
                        pedidos = cadastroPedido();
                        pedidos.Inserir(rota);
                        break;
                    case 8:
                        pedidos.Alterar();
                        break;
                    case 9:
                        pedidos.Deletar();
                        break;
                    case 10:
                        pedidos.Pesquisar();
                        break;
                    case 11:
                        Console.WriteLine("Digite o caminho que deseja salvar os arquivos: ");
                        rota = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Comando nao reconhecido.");
                        break;
                } 
            }
        }

        /// <summary>
        /// Permite o cadastro dos dados do cliente.
        /// </summary>
        /// <returns></returns>
        public static Clientes cadastroCliente()
        {
            Clientes clientes = new Clientes();
            Console.Clear();
            Console.WriteLine("INSERINDO CLIENTE...");
            Console.Write("Nome: ");
            clientes.Nome = Console.ReadLine();
            Console.Write("Email: ");
            clientes.Email = Console.ReadLine();
            Console.Write("Telefone: ");
            clientes.Telefone = Console.ReadLine();
            Console.Write("Endereco: ");
            clientes.Endereco = Console.ReadLine();
            Console.Write("Conexao (ID): ");
            clientes.SetConexao( Int32.Parse(Console.ReadLine()) );
            return clientes;
        }

        /// <summary>
        /// Permite o cadastro dos dados de um pedido.
        /// </summary>
        /// <returns></returns>
        public static Pedidos cadastroPedido()
        {
            Pedidos pedidos = new Pedidos();
            Console.Clear();
            Console.WriteLine("INSERINDO PEDIDO...");
            Console.WriteLine("Produto: ");
            pedidos.Produto = Console.ReadLine();
            Console.WriteLine("Data para entrega: ");
            pedidos.DataEntrega = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Conexao (ID): ");
            pedidos.SetConexao( Int32.Parse(Console.ReadLine()) );

            return pedidos;
        }
    }
}
