using System;
using System.Collections.Generic;

namespace Exercicio12
{
    internal class Program
    {
        // Método principal para realizar a aplicação
        static void Main(string[] args)
        {
            int numDec;
            Console.WriteLine("Digite um número decimal para que seja convertido em binário: ");
            numDec = int.Parse(Console.ReadLine());
            // Chama o método para converter p/ binário
            string binario = ConverterParaBinario(numDec);

            Console.WriteLine($"O número binário de {numDec} é: {binario}");
            Console.ReadKey();

        }
        // Método para convertr p/ binário
        static string ConverterParaBinario(int numDec)
        {
            Stack<int> paraBinario = new Stack<int>();
            while (numDec > 0)
            {
                paraBinario.Push(numDec % 2);
                numDec /= 2;
            }

            string binario = "";
            while (paraBinario.Count > 0)
            {
                binario += paraBinario.Pop();
            }
            return binario;

        }

           
    }
}
