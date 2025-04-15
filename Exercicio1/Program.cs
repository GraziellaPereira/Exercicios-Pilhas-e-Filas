using System;
using System.Collections.Generic;

namespace Exercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cria e inicializa uma nova Stack.
            Stack<int> minhaStack = new Stack<int>();
            minhaStack.Push(1);
            minhaStack.Push(2);
            minhaStack.Push(3);
            minhaStack.Push(4);
            minhaStack.Push(5);

            // Exibe as propriedades e valores da Stack.
            Console.WriteLine("Minha Stack:\n");
            Console.Write("\tValores: ");
            foreach (Object obj in minhaStack)
                Console.Write($"\t{obj}");
            Console.ReadKey();
        }
    }
}
