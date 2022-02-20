using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01.Biblioteca
{
    /// <summary>
    /// Base de comandos para manipulação de dados.
    /// </summary>
    public interface IOperacoesBD
    {
        void Inserir() { }
        void Alterar() { }
        void Deletar() { }
        void Pesquisar() { }
    }

    abstract class Cadastros : IOperacoesBD
    {
        protected int Conexao { get; set; }
        public virtual void Inserir() { Console.WriteLine("Cadastros.Inserir() executado."); }
        public virtual void Alterar() { Console.WriteLine("Cadastros.Alterar() executado."); }
        public virtual void Deletar() { Console.WriteLine("Cadastros.Deletar() executado."); }
        public virtual void Pesquisar() { Console.WriteLine("Cadastros.Pesquisar() executado."); }
    }

    sealed class Clientes : Cadastros
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Clientes()
        {
            Nome = "Sicrano";
            Email = null;
            Telefone = null;
            Endereco = null;
        }
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
        public override void Inserir()
        {
            //TODO Sobrecarga Inserir
        }
        public override void Deletar()
        {
            base.Deletar();
        }
    }

    sealed class Pedidos : Cadastros
    {
        string Produto { get; set; }
        public Pedidos()
        {
            Conexao = 0;
            this.Produto = null;
        }
        public Pedidos(int conexao, string produto)
        {
            this.Conexao = conexao;
            this.Produto = produto;
        }
        public override void Inserir()
        {
            //TODO: Sobrecarga
        }
        public override void Deletar()
        {
            base.Deletar();
        }
    }
}
