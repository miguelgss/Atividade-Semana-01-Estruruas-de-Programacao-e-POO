using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivSem01.Biblioteca
{
    /// <summary>
    /// Classe simples para execucao de operacoes
    /// e comparacoes basicas com arrays.
    /// </summary>
    public class Funcoes
    {
        /// <summary>
        /// Permite a entrada de uma matriz dentro da função. Após inserido,
        /// retorna o somatório de todos os elementos.
        /// </summary>
        /// <returns></returns>
        public int SomaMatrizes()
        {
            Console.Clear();
            int x, y;

            Console.WriteLine("SOMA DE MATRIZES: ");
            try
            {
                Console.WriteLine("Insira a quantidade de valores na primeira dimensão da matriz: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Insira a quantidade de valores na segunda dimensão da matriz: ");
                y = int.Parse(Console.ReadLine());
            } catch(Exception e)
            {
                Console.WriteLine("O tipo de dado exigido nao foi passado corretamente...\n" + e.Message );
                return 0;
            }

            int[,] array = new int[x, y];

            for (int Dim2 = 0; Dim2 < y; Dim2++)
            {
                for(int Dim1 = 0; Dim1 < x; Dim1++)
                {
                    Console.Write($"Matriz[{Dim1+1}][{Dim2+1}]: ");
                    try
                    {
                        array[Dim1, Dim2] = int.Parse(Console.ReadLine());
                    } catch (Exception e)
                    {
                        Console.WriteLine("O tipo de dado exigido nao foi passado corretamente...\n" + e.Message);
                        return 0;
                    }
                }
            }
            return SomaMatrizes(array);
        }

        /// <summary>
        /// Retorna o somatório dos elementos do array passado 
        /// como parâmetro.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int SomaMatrizes(int [,] array)
        {
            int soma = 0;
            foreach (var num in array)
            {
                soma += num;
            }
            return soma;
        }

        /// <summary>
        /// Permite a entrada de um vetor dentro da função. Após inserido,
        /// verifica qual dos quatro valores é maior.
        /// </summary>
        /// <returns></returns>
        public int MaiorEntreQuatro()
        {
            Console.Clear();
            int[] array = new int[4];
            Console.WriteLine("QUAIS DOS QUATRO NUMEROS E O MAIOR?: ");
            for (int i = 0; i < 4; i++)
            {
                try
                {
                    Console.WriteLine($"Insira o {i + 1} numero");
                    array[i] = Int32.Parse(Console.ReadLine());
                } catch (Exception e)
                {
                    Console.WriteLine("O tipo de dado exigido nao foi passado corretamente...\n" + e.Message);
                    return 0;
                }
            }
            return MaiorEntreQuatro(array);
        }

        /// <summary>
        /// Retorna o maior número entre os 4 valores passados
        /// como parâmetro.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int MaiorEntreQuatro(int[] array)
        {
            int maior = Int32.MinValue;
            for (int i = 0; i < 4; i++)
            {
                if (array[i] > maior) maior = array[i];
            }
            return maior;
        }
    }
}
