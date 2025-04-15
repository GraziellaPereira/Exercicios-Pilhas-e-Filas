using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio14
{
    // Classe do item com prioridade
    public class ItemComPrioridade<T>
    {
        public T Valor { get; set; }
        public int Prioridade { get; set; }

        public ItemComPrioridade(T valor, int prioridade)
        {
            Valor = valor;
            Prioridade = prioridade;
        }
    }

    // Criação de uma fila de tipo t que considera prioridade
    public class FilaDePrioridade<T>
    {
        private Queue<ItemComPrioridade<T>> fila;

        public FilaDePrioridade()
        {
            fila = new Queue<ItemComPrioridade<T>>();
        }

        // Método Enqueue
        public void Enqueue(T item, int prioridade)
        {
            var itemComPrioridade = new ItemComPrioridade<T>(item, prioridade);
            // Enfileira de maneira que quanto maior a prioridade, primeiro ele estará na lista
            var listaOrdenada = fila.OrderByDescending(x => x.Prioridade).ToList();
            listaOrdenada.Add(itemComPrioridade); 
            fila = new Queue<ItemComPrioridade<T>>(listaOrdenada); 
        }

        // Método Dequeue
        public T Dequeue()
        {
            if (fila.Count == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            var item = fila.Dequeue(); // Remove o primeiro item que é o de maior prioridade
            return item.Valor;
        }

        // Método Peek
        public T Peek()
        {
            if (fila.Count == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            return fila.Peek().Valor; // Retorna o primeiro item da fila, já tratado
        }

        // Count
        public int Count => fila.Count;

        // Verifica se a fila está vazia
        public bool IsEmpty() => fila.Count == 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Criando a fila de prioridade
            FilaDePrioridade<string> fila = new FilaDePrioridade<string>();

            // Permite que o usuário insira o número de elementos na fila
            Console.Write("Quantos itens você deseja adicionar à fila? ");
            int numeroDeItens = int.Parse(Console.ReadLine());

            // Adicionando itens à fila com prioridade
            for (int i = 0; i < numeroDeItens; i++)
            {
                // Solicitando o valor do item e sua prioridade
                Console.Write($"Digite o item #{i + 1}: ");
                string item = Console.ReadLine();

                Console.Write("Digite a prioridade (número inteiro), quanto maior o número, maior a prioridade: ");
                int prioridade = int.Parse(Console.ReadLine());

                fila.Enqueue(item, prioridade);
            }

            // Mostrando o item de maior prioridade
            Console.WriteLine($"\nO item com maior prioridade é: {fila.Peek()}");

            // Removendo itens da fila, começando pelo de maior prioridade
            Console.WriteLine("\nRemovendo itens da fila (maior prioridade primeiro):");
            while (!fila.IsEmpty())
            {
                Console.WriteLine(fila.Dequeue());
            }

            // Tentando remover de uma fila vazia (causa exceção)
            try
            {
                fila.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Saída: Fila vazia!
            }
            Console.ReadKey();
        }
    }
}
