using System;

namespace Exercicio13
{
    public class FilaCircular<T>
    {
        private T[] elementos;
        private int frente;
        private int tras;
        private int capacidade;
        private int tamanho;

        public FilaCircular(int capacidade)
        {
            this.capacidade = capacidade;
            elementos = new T[capacidade];
            frente = 0;
            tras = 0;
            tamanho = 0;
        }

        // Adiciona um item à fila (no final)
        public void Enqueue(T item)
        {
            if (tamanho == capacidade)
            {
                throw new InvalidOperationException("Fila cheia!");
            }

            elementos[tras] = item;
            tras = (tras + 1) % capacidade; // Move o índice 'tras' circularmente
            tamanho++;
        }

        // Remove e retorna o item da frente da fila
        public T Dequeue()
        {
            if (tamanho == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            T item = elementos[frente];
            frente = (frente + 1) % capacidade; // Move o índice 'frente' circularmente
            tamanho--;
            return item;
        }

        // Retorna o item da frente da fila sem removê-lo
        public T Peek()
        {
            if (tamanho == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            return elementos[frente];
        }

        // Retorna a quantidade de itens na fila
        public int Count => tamanho;

        // Verifica se a fila está vazia
        public bool IsEmpty() => tamanho == 0;

        // Verifica se a fila está cheia
        public bool IsFull() => tamanho == capacidade;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Criando uma fila circular com capacidade 5
            FilaCircular<string> fila = new FilaCircular<string>(5);

            // Adicionando itens à fila
            fila.Enqueue("Carro 1");
            fila.Enqueue("Carro 2");
            fila.Enqueue("Carro 3");
            fila.Enqueue("Carro 4");
            fila.Enqueue("Carro 5");

            // Tentando adicionar um item extra (causa exceção, pois a fila está cheia)
            try
            {
                fila.Enqueue("Carro 6");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  // Saída: Fila cheia!
            }

            // Removendo um item da fila
            Console.WriteLine("Removendo item: " + fila.Dequeue());  // Saída: Carro 1

            // Adicionando um novo item (irá ocupar o espaço vazio deixado pelo Carro 1)
            fila.Enqueue("Carro 6");

            // Exibindo o estado da fila
            Console.WriteLine("Estado atual da fila:");
            while (!fila.IsEmpty())
            {
                Console.WriteLine(fila.Dequeue());
            }
        }
    }
}
