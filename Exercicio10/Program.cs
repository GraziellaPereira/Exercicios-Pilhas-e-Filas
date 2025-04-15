using System;

namespace exercicio10
{
    public class MinhaPilha<T>
    {
        private T[] elementos;
        private int topo;
        private int capacidade;

        public MinhaPilha(int tamanho)
        {
            capacidade = tamanho;
            elementos = new T[tamanho];
            topo = -1;
        }

        public void Push(T item)
        {
            if (topo == capacidade - 1)
            {
                throw new InvalidOperationException("Pilha cheia!");
            }

            elementos[++topo] = item;
        }

        public T Pop()
        {
            if (topo == -1)
            {
                throw new InvalidOperationException("Pilha vazia!");
            }

            return elementos[topo--];
        }

        public T Peek()
        {
            if (topo == -1)
            {
                throw new InvalidOperationException("Pilha vazia!");
            }

            return elementos[topo];
        }

        public int Count => topo + 1;

        public bool IsEmpty() => topo == -1;
    }

    class Program
    {
        static void Main(string[] args)
        {

            MinhaPilha<int> pilha = new MinhaPilha<int>(5);
            pilha.Push(10);
            pilha.Push(20);
            Console.WriteLine(pilha.Pop());  // Saída: 20
            Console.WriteLine(pilha.Peek()); // Saída: 10
            Console.WriteLine(pilha.Count);  // Saída: 1
            Console.ReadKey();
        }
    }
}
