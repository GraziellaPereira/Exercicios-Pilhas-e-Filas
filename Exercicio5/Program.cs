using System;
using System.Collections.Generic;

namespace Exercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string palavra;
            Console.WriteLine("Digite uma palarva: ");
            palavra = Console.ReadLine();
            // Cria e inicializa uma nova Stack.
            Stack<char> minhaStack = new Stack<char>();

            // Desmembra a palavra e adiciona na minha stack
            foreach (char letra in palavra)
            {
                minhaStack.Push(letra);
            }

            // Exibe as propriedades e valores da Stack.
            Console.WriteLine("Minha Stack:\n");

            Console.Write("\tValores: ");
            while (minhaStack.Count > 0)
            {
                Console.Write(minhaStack.Pop());
            }

            Console.ReadKey();
        }
    }
}
