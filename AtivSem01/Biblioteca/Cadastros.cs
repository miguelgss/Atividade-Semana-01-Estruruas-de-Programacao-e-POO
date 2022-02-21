using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Resolvers;

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
        public virtual void Inserir(string rota) 
        { 
            Console.WriteLine("Cadastros.Inserir() executado. Inserindo cliente em " + rota + "..."); 
        }
        public virtual void Alterar(string rota) 
        {
            Console.WriteLine("Cadastros.Alterar() executado. Alterando arquivo em " + rota + "...");
        }
        public virtual void Deletar(string Nome, string rota)
        { 
            Console.WriteLine("Cadastros.Deletar() executado. Deletando " + Nome + " em " + rota );
        }
        public virtual void Pesquisar(string rota) 
        { 
            Console.WriteLine("Cadastros.Pesquisar() executado. Lendo " + rota + "..."); 
        }
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
        public override void Inserir(string rota)
        {
            /*
             * TODO: O serializador não consegue imprimir o valor de Conexao por conta de sua visibilidade.
             * Isso ainda exige correção, seja trocando o modificador de acesso da variável ou por algum outro
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

        public override void Alterar(string rota)
        {
            // TODO: Implementar Clientes.Alterar()
        }

        /// <summary>
        /// Deleta a linha que contenha a string inserida.
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="rota"></param>
        public override void Deletar(string Nome, string rota)
        {
            string rotaAbsoluta = rota + "Clientes" + ".xml";
            base.Deletar(Nome, rotaAbsoluta);

            string tempFile = Path.GetTempFileName(); // Cria um arquivo temporario
            string eraser = null; // Substituirá a linha designada para ser apagada

            /* 
             * TODO: Implementar um método que apague adequadamente todas as informações RELACIONADAS ao Clientes.Nome.
             * 1 - Uma solução possível (mas porca) seria converter a Serialização de dados para um .txt ao invés de um .xml,
             * pois assim cada informação estaria armazenada em apenas uma linha.
             * 2 - Verificar os números de linhas que estão contidos entre um <node> e outro <node> que cobrem cada
             * informação.
            */
            if (File.Exists(rotaAbsoluta))
            {
                string[] readText = File.ReadAllLines(rotaAbsoluta); // Armazena as linhas do arquivo em um vetor String.
                foreach (string item in readText)
                {
                    if (item.Contains(Nome)) // Caso a linha contenha a string inserida como parâmetro, ela será apagada.
                    {
                        using (StreamWriter sw = File.AppendText(tempFile))
                        {
                            sw.WriteLine(eraser);
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(tempFile))
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
            }
            File.Delete(rotaAbsoluta);
            File.Move(tempFile, rotaAbsoluta);
        }

        /// <summary>
        /// Imprime bruscamente os dados do Clientes.xml, linha por linha.
        /// </summary>
        /// <param name="rota"></param>
        public override void Pesquisar(string rota)
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
                    "Mude o path ou crie algum Cliente e tente novamente.");
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
        public override void Inserir(string rota)
        {
            /*
             * TODO: O serializador não consegue imprimir o valor de Conexao por conta de sua visibilidade.
             * Isso ainda exige correção, seja trocando o modificador de acesso da variável ou por algum outro
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

        public override void Alterar(string rota)
        {
            // TODO: Implementar Pedidos.Alterar()
        }

        /// <summary>
        /// Deleta a linha que contenha a string inserida.
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="rota"></param>
        public override void Deletar(string Nome, string rota)
        {
            string rotaAbsoluta = rota + "Pedidos" + ".xml";
            base.Deletar(Nome, rotaAbsoluta);

            string tempFile = Path.GetTempFileName(); // Cria um arquivo temporario
            string eraser = null; // Substituirá a linha designada para ser apagada

            /* 
             * TODO: Implementar um método que apague adequadamente todas as informações RELACIONADAS ao Pedidos.Produto.
             * 1 - Uma solução possível(mas porca) seria converter a Serialização de dados para um .txt ao invés de um.xml,
             * pois assim cada informação estaria armazenada em apenas uma linha.
             * 2 - Verificar os números de linhas que estão contidos entre um<node> e outro<node> que cobrem cada
             * informação.
            */
            if (File.Exists(rotaAbsoluta))
            {
                string[] readText = File.ReadAllLines(rotaAbsoluta); // Armazena as linhas do arquivo em um vetor String.
                foreach (string item in readText) 
                {
                    if (item.Contains(Nome)) // Caso a linha contenha a string inserida como parâmetro, ela será apagada.
                    {
                        using (StreamWriter sw = File.AppendText(tempFile))
                        {
                            sw.WriteLine(eraser);
                        }
                    } else
                    {
                        using (StreamWriter sw = File.AppendText(tempFile))
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
            }
            File.Delete(rotaAbsoluta);
            File.Move(tempFile, rotaAbsoluta);
        }

        /// <summary>
        /// Imprime bruscamente os dados do Pedidos.xml, linha por linha.
        /// </summary>
        /// <param name="rota"></param>
        public override void Pesquisar(string rota)
        {
            Console.Clear();
            string rotaAbsoluta = rota + "Pedidos" + ".xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Pedidos));
            if (File.Exists(rotaAbsoluta))
            {
                string[] readText = File.ReadAllLines(rotaAbsoluta); // Armazena as linhas do arquivo em um vetor String.
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
