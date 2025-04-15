using System;

namespace Exercicio16
{
    public class Deque<T>
    {
        private T[] elementos;
        private int frente;
        private int tras;
        private int capacidade;
        private int tamanho;

        public Deque(int capacidade)
        {
            this.capacidade = capacidade;
            elementos = new T[capacidade];
            frente = -1;
            tras = -1;
            tamanho = 0;
        }

        // Inserir na frente
        public void AddFirst(T item)
        {
            if (tamanho == capacidade)
            {
                Console.WriteLine("Deque cheio!");
                return;
            }

            if (frente == 0) // Se frente estiver no início
                frente = capacidade;

            elementos[frente--] = item;
            tamanho++;

            if (tras == -1) // Se ainda não há elementos, setamos o "tras"
                tras = 0;
        }

        // Inserir no final
        public void AddLast(T item)
        {
            if (tamanho == capacidade)
            {
                Console.WriteLine("Deque cheio!");
                return;
            }

            if (tras == capacidade - 1) // Se tras estiver no fim
                tras = -1;

            elementos[++tras] = item;
            tamanho++;

            if (frente == -1) // Se ainda não há elementos, setamos o "frente"
                frente = 0;
        }

        // Remover da frente
        public T RemoveFirst()
        {
            if (tamanho == 0)
            {
                throw new InvalidOperationException("Deque vazio!");
            }

            T item = elementos[frente];
            frente++;

            if (frente == capacidade) frente = 0; // Volta ao início se ultrapassar a capacidade
            tamanho--;
            return item;
        }

        // Remover do final
        public T RemoveLast()
        {
            if (tamanho == 0)
            {
                throw new InvalidOperationException("Deque vazio!");
            }

            T item = elementos[tras];
            tras--;

            if (tras == -1) tras = capacidade - 1; // Volta ao final se ultrapassar o começo
            tamanho--;
            return item;
        }

        // Ver o primeiro item
        public T PeekFirst()
        {
            if (tamanho == 0)
            {
                throw new InvalidOperationException("Deque vazio!");
            }

            return elementos[frente];
        }

        // Ver o último item
        public T PeekLast()
        {
            if (tamanho == 0)
            {
                throw new InvalidOperationException("Deque vazio!");
            }

            return elementos[tras];
        }

        // Retorna o número de elementos no deque
        public int Count => tamanho;

        // Verifica se o deque está vazio
        public bool IsEmpty() => tamanho == 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Criando um deque de inteiros com capacidade 5
            Deque<int> deque = new Deque<int>(5);

            // Inserindo elementos no deque
            deque.AddFirst(10);
            deque.AddFirst(20);
            deque.AddLast(30);
            deque.AddLast(40);

            Console.WriteLine("Deque após inserções:");
            Console.WriteLine($"Primeiro elemento: {deque.PeekFirst()}");
            Console.WriteLine($"Último elemento: {deque.PeekLast()}");

            // Removendo elementos da frente e do final
            Console.WriteLine($"\nRemovendo da frente: {deque.RemoveFirst()}");
            Console.WriteLine($"Removendo do final: {deque.RemoveLast()}");

            // Exibindo o deque após remoções
            Console.WriteLine("\nDeque após remoções:");
            Console.WriteLine($"Primeiro elemento: {deque.PeekFirst()}");
            Console.WriteLine($"Último elemento: {deque.PeekLast()}");

            // Inserindo novamente
            deque.AddFirst(50);
            deque.AddLast(60);

            Console.WriteLine("\nDeque após novas inserções:");
            Console.WriteLine($"Primeiro elemento: {deque.PeekFirst()}");
            Console.WriteLine($"Último elemento: {deque.PeekLast()}");

            // Mostrando a quantidade de elementos no deque
            Console.WriteLine($"\nNúmero de elementos no deque: {deque.Count}");
        }
    }
}
