using System;
using AtivSem01.Biblioteca;

namespace AtivSem01
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 1;

            Funcoes funcoes = new Funcoes();
            Clientes clientes = new Clientes();
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
                        clientes.Inserir();
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
                        pedidos.Inserir();
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
                    default:
                        Console.WriteLine("Comando nao reconhecido.");
                        break;
                } 
            }
        }
    }
}
