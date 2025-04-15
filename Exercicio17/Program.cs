using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercicio17
{
    // Classe que representa um documento com prioridade
    public class Documento
    {
        public string Nome { get; set; }
        public int Prioridade { get; set; } // Quanto maior o valor, maior a prioridade

        public Documento(string nome, int prioridade)
        {
            Nome = nome;
            Prioridade = prioridade;
        }
    }

    // Fila de prioridade para os documentos
    public class FilaDePrioridade<T>
    {
        private List<Documento> fila;

        public FilaDePrioridade()
        {
            fila = new List<Documento>();
        }

        // Adiciona um documento à fila
        public void Enqueue(Documento documento)
        {
            fila.Add(documento);
            // Ordena os documentos por prioridade (maior prioridade vem primeiro)
            fila = fila.OrderByDescending(d => d.Prioridade).ToList();
        }

        // Remove e retorna o documento de maior prioridade
        public Documento Dequeue()
        {
            if (fila.Count == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            var documento = fila[0]; // O primeiro documento tem a maior prioridade
            fila.RemoveAt(0); // Remove o primeiro documento da lista
            return documento;
        }

        // Retorna o documento de maior prioridade sem removê-lo
        public Documento Peek()
        {
            if (fila.Count == 0)
            {
                throw new InvalidOperationException("Fila vazia!");
            }

            return fila[0]; // Retorna o primeiro documento
        }

        // Retorna a quantidade de documentos na fila
        public int Count => fila.Count;

        // Verifica se a fila está vazia
        public bool IsEmpty() => fila.Count == 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            FilaDePrioridade<Documento> filaDeImpressao = new FilaDePrioridade<Documento>();

            // Adicionando documentos com diferentes prioridades
            filaDeImpressao.Enqueue(new Documento("Documento 1", 1)); // Prioridade 1 (baixa)
            filaDeImpressao.Enqueue(new Documento("Documento 2", 3)); // Prioridade 3 (alta)
            filaDeImpressao.Enqueue(new Documento("Documento 3", 2)); // Prioridade 2 (média)

            // Exibindo o documento de maior prioridade
            Console.WriteLine("Documento de maior prioridade: " + filaDeImpressao.Peek().Nome);

            // Removendo documentos da fila (impressão dos documentos)
            Console.WriteLine("\nImpressão dos documentos:");
            while (!filaDeImpressao.IsEmpty())
            {
                Documento doc = filaDeImpressao.Dequeue();
                Console.WriteLine($"Imprimindo: {doc.Nome} com prioridade {doc.Prioridade}");
            }

            // Tentando imprimir de uma fila vazia (causa exceção)
            try
            {
                filaDeImpressao.Dequeue();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); // Saída: Fila vazia!
            }
        }
    }
}
