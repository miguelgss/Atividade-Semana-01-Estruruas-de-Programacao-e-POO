using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01.Biblioteca
{
    interface IOperacoesBD
    {
        void Inserir() { Console.WriteLine("IOperacoesBD.Inserir() executado."); }
        void Alterar() { Console.WriteLine("IOperacoesBD.Alterar() executado."); }
        void Deletar() { Console.WriteLine("IOperacoesBD.Deletar() executado."); }
        void Pesquisar() { Console.WriteLine("IOperacoesBD.Pesquisar() executado."); }

    }

    /// <summary>
    /// Instancia um cliente, o permitindo fazer pedidos.
    /// </summary>
    abstract class Cadastros : IOperacoesBD
    {
        protected int Conexao { get; set; }
    }

    sealed class Clientes : Cadastros
    {
        string Nome { get; set; }
        string Email { get; set; }
        string Telefone { get; set; }
        string Endereco { get; set; }

        public Clientes(
            int conexao, string nome, 
            string email, string telefone, 
            string endereco
        )
        { 
            this.Conexao = conexao;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Endereco = endereco;
        }

        void Deletar()
        {
            base.Deletar();
        }
    }

    sealed class Pedidos : Cadastros
    {
        string Produto { get; set; }
        public Pedidos(int conexao, string produto)
        {
            this.Conexao = conexao;
            this.Produto = produto;
        }
        void Inserir()
        {

        }
    }
}
