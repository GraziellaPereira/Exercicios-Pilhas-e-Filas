using System;
using System.Collections.Generic;

namespace Exercicio20
{
    public class LRUCache<T>
    {
        private int capacidade;
        private Queue<T> fila;
        private Dictionary<T, DateTime> cache;

        public LRUCache(int capacidade)
        {
            this.capacidade = capacidade;
            fila = new Queue<T>();
            cache = new Dictionary<T, DateTime>();
        }

        // Acessa um item do cache, movendo-o para o final da fila (mais recentemente acessado)
        public void AccessItem(T item)
        {
            if (cache.ContainsKey(item))
            {
                // Se o item já existe, atualiza o timestamp e move para o final da fila
                cache[item] = DateTime.Now;
                // Atualiza a fila: removendo o item e colocando-o novamente no final
                var itemTemp = fila.ToArray();
                fila.Clear();
                foreach (var i in itemTemp)
                {
                    if (!i.Equals(item))
                        fila.Enqueue(i);
                }
                fila.Enqueue(item);
            }
            else
            {
                // Se o item não existe, adiciona ao cache
                if (cache.Count >= capacidade)
                {
                    // Se o cache está cheio, remove o item mais antigo
                    RemoveOldest();
                }
                fila.Enqueue(item);
                cache[item] = DateTime.Now;
            }
        }

        // Remove o item mais antigo (primeiro na fila)
        private void RemoveOldest()
        {
            if (fila.Count == 0)
                return;

            var itemAntigo = fila.Dequeue();
            cache.Remove(itemAntigo);
        }

        // Retorna o conteúdo do cache
        public void ShowCache()
        {
            Console.WriteLine("Cache atual:");
            foreach (var item in fila)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Criando um cache LRU com capacidade 3
            LRUCache<string> cache = new LRUCache<string>(3);

            // Acessando itens no cache
            cache.AccessItem("A"); // Acessa "A"
            cache.AccessItem("B"); // Acessa "B"
            cache.AccessItem("C"); // Acessa "C"
            cache.ShowCache(); // Exibe cache: A, B, C

            // Acessando "A" novamente
            cache.AccessItem("A"); // Acessa "A" novamente, movendo-o para o final
            cache.ShowCache(); // Exibe cache: B, C, A

            // Adicionando um novo item, que vai remover o item mais antigo ("B")
            cache.AccessItem("D");
            cache.ShowCache(); // Exibe cache: C, A, D

            // Adicionando um novo item, que vai remover o item mais antigo ("C")
            cache.AccessItem("E");
            cache.ShowCache(); // Exibe cache: A, D, E
        }
    }
}
