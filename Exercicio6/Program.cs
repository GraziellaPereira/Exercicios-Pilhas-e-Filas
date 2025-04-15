using System;
using System.Collections.Generic;

namespace Exercicio6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> historico = new Stack<string>();
            string paginaAtual = "Home";
            int opcao;

            do
            {
                Console.Clear();
                Console.WriteLine($"Página atual: {paginaAtual}");
                Console.WriteLine("Escolha uma opção: ");
                Console.WriteLine("1 - Acessar nova página");
                Console.WriteLine("2 - Voltar à página anterior");
                Console.WriteLine("3 - Sair");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o nome da nova página: ");
                        historico.Push(paginaAtual); 
                        paginaAtual = Console.ReadLine();
                        Console.WriteLine($"Você está na seguinte página: {paginaAtual}");
                        Console.ReadKey();
                        break;

                    case 2:
                        if (historico.Count > 0)
                        {
                            paginaAtual = historico.Pop(); // Volta para a página anterior
                            Console.WriteLine($"Você voltou para a seguinte página: {paginaAtual}");
                        }
                        else
                        {
                            Console.WriteLine("Não há nada no histórico de navegação.");
                            Console.WriteLine($"Você continua na seguinte página: {paginaAtual}");
                            Console.ReadKey();
                        }
                        Console.ReadKey(); 
                        break;

                    case 3:
                        Console.WriteLine("Saindo do navegador...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }

            } while (opcao != 3);
        }
    }
}