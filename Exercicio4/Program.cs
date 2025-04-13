using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue minhaFila = new Queue();
            Console.WriteLine("Como a fila está antes de adicionar elementos? ");
            Console.WriteLine(minhaFila.Count == 0 ? "\tA fila está vazia." : "\tA fila contém elementos.");
            minhaFila.Enqueue("Cobra");
            minhaFila.Enqueue("Gato");
            minhaFila.Enqueue("Macaco");

            Console.WriteLine("Como a fila está após adicionar elementos? ");
            Console.WriteLine(minhaFila.Count == 0 ? "\tA fila está vazia." : "\tA fila contém elementos.");

            Console.WriteLine("minhaFila\n");
            Console.WriteLine($"\tQuantidade :\t {minhaFila.Count}");
            Console.Write("\tValores: ");
            foreach (Object obj in minhaFila)
                Console.Write($"\t{obj}");
            Console.ReadKey();
        }
    }
}
