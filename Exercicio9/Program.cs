using System;
using System.Collections.Generic;

namespace Exercicio9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> minhaFila = new Queue<int>();
            minhaFila.Enqueue(1);
            minhaFila.Enqueue(2);
            minhaFila.Enqueue(3);
            minhaFila.Enqueue(4);
            minhaFila.Enqueue(5);

            Stack<int> minhaStack = new Stack<int>();
            // Remove da fila e adiciona na stack
            while (minhaFila.Count > 0)
            {
                minhaStack.Push(minhaFila.Dequeue());
            }

            // Volta para a fila, dessa vez na ordem invertida
            while (minhaStack.Count > 0)
            {
                minhaFila.Enqueue(minhaStack.Pop());
            }

            Console.WriteLine("Valores da fila invertidos: ");
            foreach (Object obj in minhaFila)
                Console.Write($"\t{obj}");
            Console.ReadKey();
        }
    }
}
