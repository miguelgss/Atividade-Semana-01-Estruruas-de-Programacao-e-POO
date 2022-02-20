using System;
using AtivSem01.Biblioteca;

namespace AtivSem01
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcoes funcoes = new Funcoes();
            Clientes clientes = new Clientes();
            Pedidos pedidos = new Pedidos();


            Console.WriteLine(Funcoes.SomaMatrizes());
            Console.WriteLine(Funcoes.MaiorEntreQuatro());
        }
    }
}
