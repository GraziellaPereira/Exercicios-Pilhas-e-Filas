using System;

namespace Exercicio11
{
    public class MinhaFila<T>
    {
        private T[] elementos;
        private int frente;
        private int tras;
        private int capacidade;
        private int tamanho;

        public MinhaFila(int tamanho)
        {
            capacidade = tamanho;
            elementos = new T[tamanho];
            frente = 0;
            tras = 0;
            tamanho = 0;
        }

        public void Enqueue(T item)
        {
            if (tamanho == capacidade)
            {
                throw new InvalidOperationException("Fila cheia!");
            }

            elementos[tras] = item;
            tras = (tras + 1) % capacidade; 
            tamanho++;
        }

        public T Dequeue()
        {
            if (tamanho == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            T item = elementos[frente];
            frente = (frente + 1) % capacidade; 
            tamanho--;
            return item;
        }

        public T Peek()
        {
            if (tamanho == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            return elementos[frente];
        }


        public int Count => tamanho;


        public bool IsEmpty() => tamanho == 0;
    }

    class Program
    {
        static void Main(string[] args)
        {

            MinhaFila<int> fila = new MinhaFila<int>(5);

            fila.Enqueue(10);
            fila.Enqueue(20);
            fila.Enqueue(30);

            Console.WriteLine(fila.Dequeue());  // Saída: 10
            Console.WriteLine(fila.Peek());     // Saída: 20
            Console.WriteLine(fila.Count);      // Saída: 2
            Console.ReadKey();
        }
    }
}
