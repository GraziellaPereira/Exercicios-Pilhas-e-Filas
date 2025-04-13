using System;
using System.Collections.Generic;

namespace Exercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> minhaFila = new Queue<string>();
            minhaFila.Enqueue("Ana");
            minhaFila.Enqueue("Carlos");
            minhaFila.Enqueue("Beatriz");
            minhaFila.Enqueue("Daniel");
            minhaFila.Dequeue();

            Console.WriteLine("Minha Fila\n");
            Console.Write("\tValores: ");
            foreach (Object obj in minhaFila)
                Console.Write($"\t{obj}");
            Console.ReadKey();
        }
    }
}
