using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio14
{
    // Classe que representa um item na fila com um valor e sua prioridade
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

    // Implementação de uma fila de prioridade utilizando Queue<T>
    public class FilaDePrioridade<T>
    {
        private Queue<ItemComPrioridade<T>> fila;

        public FilaDePrioridade()
        {
            fila = new Queue<ItemComPrioridade<T>>();
        }

        // Adiciona um item à fila com a prioridade
        public void Enqueue(T item, int prioridade)
        {
            var itemComPrioridade = new ItemComPrioridade<T>(item, prioridade);
            // Enfileira o item de maneira que o de maior prioridade seja atendido primeiro
            var listaOrdenada = fila.OrderByDescending(x => x.Prioridade).ToList();
            listaOrdenada.Add(itemComPrioridade); // Adiciona o novo item à lista ordenada
            fila = new Queue<ItemComPrioridade<T>>(listaOrdenada); // Atualiza a fila com a nova ordem
        }

        // Remove e retorna o item de maior prioridade da fila
        public T Dequeue()
        {
            if (fila.Count == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            var item = fila.Dequeue(); // O primeiro item é o de maior prioridade
            return item.Valor;
        }

        // Retorna o item de maior prioridade sem removê-lo
        public T Peek()
        {
            if (fila.Count == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            return fila.Peek().Valor; // Retorna o item da frente
        }

        // Retorna a quantidade de itens na fila
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

                Console.Write("Digite a prioridade (número inteiro): ");
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
        }
    }
}
