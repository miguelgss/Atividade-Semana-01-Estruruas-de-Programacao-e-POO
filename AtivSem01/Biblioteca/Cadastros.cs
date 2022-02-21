using System;
using System.IO;
using System.Xml.Serialization;

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
        protected abstract int Conexao { get; set; }
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
        protected override int Conexao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        // Construtores
        public Clientes()
        {
            this.Conexao = 0;
            Nome = null;
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
            /*
             * TODO: O serializador não consegue imprimir o valor de Conexao por conta de sua visibilidade.
             * Isso ainda exige correção, seja trocando o encapsulamento da variável ou por algum outro
             * método que não seja muito elaborado.
             */

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
                Console.WriteLine("Algo deu errado. Verifique se os dados inseridos estão corretos e tente novamente.");
                Console.WriteLine(ex.Message);
            }
        }
        public override void Deletar()
        {
            base.Deletar();
            //TODO Sobrecarga Deletar
        }

        /// <summary>
        /// Imprime bruscamente os dados do Clientes.xml, linha por linha.
        /// </summary>
        /// <param name="rota"></param>
        public void Pesquisar(string rota)
        {
            Console.Clear();
            string rotaAbsoluta = rota + "Clientes" + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Clientes));
            if (File.Exists(rotaAbsoluta))
            {
                string[] readText = File.ReadAllLines(rotaAbsoluta); // Armazena as palavras do arquivo em um vetor String.
                foreach (string item in readText)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhum arquivo. " +
                    "Mude o path ou crie algum Pedido e tente novamente.");
            }
        }
    }

    /// <summary>
    /// Classe para manipulação de dados de pedidos.
    /// </summary>
    public sealed class Pedidos : Cadastros
    {
        protected override int Conexao { get; set; }
        public string Produto { get; set; }
        public DateTime DataEntrega { get; set; }
        // TODO: bool EntregaFeita { get; set; }
        // É interessante para verificar se um pedido foi finalizado ou não.

        // Construtores
        public Pedidos()
        {
            this.Conexao = 0;
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
            /*
             * TODO: O serializador não consegue imprimir o valor de Conexao por conta de sua visibilidade.
             * Isso ainda exige correção, seja trocando o encapsulamento da variável ou por algum outro
             * método que não seja muito elaborado.
             */
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
                Console.WriteLine("Algo deu errado. Verifique se os dados inseridos estão corretos e tente novamente.");
                Console.WriteLine(ex.Message);
            }
        }

        public override void Deletar()
        {
            base.Deletar();
            //TODO Sobrecarga Deletar
        }

        /// <summary>
        /// Imprime bruscamente os dados do Pedidos.xml, linha por linha.
        /// </summary>
        /// <param name="rota"></param>
        public void Pesquisar(string rota)
        {
            Console.Clear();
            string rotaAbsoluta = rota + "Pedidos" + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Pedidos));
            if (File.Exists(rotaAbsoluta))
            {
                string[] readText = File.ReadAllLines(rotaAbsoluta); // Armazena as palavras do arquivo em um vetor String.
                foreach(string item in readText)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhum arquivo. " +
                    "Mude o path ou crie algum Pedido e tente novamente.");
            }
        }
    }
}
