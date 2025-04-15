using System;
using System.Collections.Generic;

namespace Exercicio7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> filaCliente = new Queue<string>();
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao gerenciamento da fila de atendimento! ");
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Adicionar cliente à fila");
                Console.WriteLine("2 - Atender próximo cliente");
                Console.WriteLine("3 - Exibir fila atual");
                Console.WriteLine("4 - Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o nome do cliente que entrará na fila: ");
                        string cliente = Console.ReadLine();
                        filaCliente.Enqueue(cliente);
                        Console.WriteLine($"O(a) cliente {cliente} foi adicionado(a) à fila.");
                        Console.ReadKey();
                        break;

                    case 2:
                        if (filaCliente.Count > 0)
                        {
                            string atendido = filaCliente.Dequeue();
                            Console.WriteLine($"O(a) cliente {atendido} foi atendido(a).");
                        }
                        else
                        {
                            Console.WriteLine("A fila está vazia.");
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        if (filaCliente.Count > 0)
                        {
                            Console.WriteLine("Clientes na fila:");
                            foreach (string nome in filaCliente)
                            {
                                Console.WriteLine($"- {nome}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("A fila está vazia.");
                        }
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }

            } while (opcao != 4);
        }
    }
}
