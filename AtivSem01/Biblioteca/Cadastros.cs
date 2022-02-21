using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace AtivSem01.Biblioteca
{
    /// <summary>
    /// Layout de comandos para manipulação de dados.
    /// </summary>
    public interface IOperacoesBD
    {
        void Inserir() { }
        void Alterar() { }
        void Deletar() { }
        void Pesquisar() { }
    }

    public abstract class Cadastros : IOperacoesBD
    {
        protected int Conexao;
        public virtual void Inserir() { Console.WriteLine("Cadastros.Inserir() executado."); }
        public virtual void Alterar() { Console.WriteLine("Cadastros.Alterar() executado."); }
        public virtual void Deletar() { Console.WriteLine("Cadastros.Deletar() executado."); }
        public virtual void Pesquisar() { Console.WriteLine("Cadastros.Pesquisar() executado."); }
    }

    /// <summary>
    /// Classe para manipulação de dados de clientes.
    /// </summary>
    public sealed class Clientes : Cadastros
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        // Construtores
        public Clientes()
        {
            SetConexao(0);
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

        // Getter e Setter para conexao ser acessível
        public void SetConexao(int conexao)
        {
            this.Conexao = conexao;
        }
        public int GetConexao()
        {
            return this.Conexao;
        }

        // Metodos

        /// <summary>
        /// Serializa um objeto do tipo Clientes em um arquivo XML.
        /// </summary>
        /// <param name="rota"></param>
        public void Inserir(string rota)
        {
            string rotaAbsoluta = rota + "Clientes" + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Clientes));
            try{
                if (File.Exists(rotaAbsoluta))
                {
                    using(StreamWriter sw = File.AppendText(rotaAbsoluta))
                    {
                        serializer.Serialize(sw, this);
                    }
                } else
                {
                    using(StreamWriter sw = new StreamWriter(rotaAbsoluta))
                    {
                        serializer.Serialize(sw, this);
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Algo deu errado. Verifique se os dados inseridos estão corretos.");
                Console.WriteLine(ex.Message);
            }
        }
        public override void Deletar()
        {
            base.Deletar();
            //TODO Sobrecarga Inserir
        }
    }

    /// <summary>
    /// Classe para manipulação de dados de pedidos.
    /// </summary>
    public sealed class Pedidos : Cadastros
    {
        public string Produto { get; set; }
        public DateTime DataEntrega { get; set; }
        bool EntregaFeita { get; set; }

        // Construtores
        public Pedidos()
        {
            SetConexao(0);
            this.Produto = null;
            this.DataEntrega = DateTime.MinValue;
        }
        public Pedidos(int conexao, string produto, DateTime dataEntrega)
        {
            this.Conexao = conexao;
            this.Produto = produto;
            this.DataEntrega = dataEntrega;
        }

        // Getter e Setter para conexao ser acessível
        public void SetConexao(int conexao)
        {
            this.Conexao = conexao;
        }
        public int GetConexao()
        {
            return this.Conexao;
        }

        // Metodos

        /// <summary>
        /// Serializa um objeto do tipo Pedidos em um arquivo XML.
        /// </summary>
        /// <param name="rota"></param>
        public void Inserir(string rota)
        {
            string rotaAbsoluta = rota + "Pedidos" + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Pedidos));
            try
            {
                if (File.Exists(rotaAbsoluta))
                {
                    using (StreamWriter sw = File.AppendText(rotaAbsoluta))
                    {
                        serializer.Serialize(sw, this);
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(rotaAbsoluta))
                    {
                        serializer.Serialize(sw, this);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Algo deu errado. Verifique se os dados inseridos estão corretos.");
                Console.WriteLine(ex.Message);
            }
        }
        public override void Deletar()
        {
            base.Deletar();
            //TODO Sobrecarga Inserir
        }
    }
}
