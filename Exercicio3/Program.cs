using System;
using System.Collections;

namespace Exercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cria e inicializa uma nova Stack.
            Stack minhaStack = new Stack();
            Console.WriteLine("Como a pilha está antes de adicionar elementos? ");
            Console.WriteLine(minhaStack.Count == 0 ? "\tA pilha está vazia." : "\tA pilha contém elementos.");
            minhaStack.Push("Cachorro");
            minhaStack.Push("Gato");
            minhaStack.Push("Pato");
            Console.WriteLine("Como a pilha está após adicionar elementos? ");
            Console.WriteLine(minhaStack.Count == 0 ? "\tA pilha está vazia." : "\tA pilha contém elementos.");

            // Exibe as propriedades e valores da Stack.
            Console.WriteLine("minhaStack\n");
            Console.WriteLine($"\tQuantidade :\t {minhaStack.Count}");
            Console.Write("\tValores: ");
            foreach (Object obj in minhaStack)
                Console.Write($"\t{obj}");
            Console.ReadKey();
        }
    }
}