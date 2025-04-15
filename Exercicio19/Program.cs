using System;
using System.Collections.Generic;

namespace Exercicio19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pilhas para armazenar as ações de desfazer e refazer
            Stack<string> pilhaUndo = new Stack<string>();
            Stack<string> pilhaRedo = new Stack<string>();

            // Simulando algumas ações que o usuário faz
            AdicionarAcao(pilhaUndo, pilhaRedo, "Ação 1");
            AdicionarAcao(pilhaUndo, pilhaRedo, "Ação 2");
            AdicionarAcao(pilhaUndo, pilhaRedo, "Ação 3");

            // Exibindo as pilhas antes das operações de desfazer e refazer
            Console.WriteLine("Pilha de Undo:");
            ExibirPilhas(pilhaUndo, pilhaRedo);

            // Desfazendo uma ação
            Desfazer(pilhaUndo, pilhaRedo);
            Console.WriteLine("\nApós desfazer uma ação:");
            ExibirPilhas(pilhaUndo, pilhaRedo);

            // Refazendo uma ação
            Refazer(pilhaUndo, pilhaRedo);
            Console.WriteLine("\nApós refazer uma ação:");
            ExibirPilhas(pilhaUndo, pilhaRedo);

            // Continuando com mais ações
            AdicionarAcao(pilhaUndo, pilhaRedo, "Ação 4");
            Console.WriteLine("\nApós adicionar mais uma ação:");
            ExibirPilhas(pilhaUndo, pilhaRedo);

            // Tentando desfazer e refazer mais
            Desfazer(pilhaUndo, pilhaRedo);
            Desfazer(pilhaUndo, pilhaRedo);
            Console.WriteLine("\nApós dois desfeitos:");
            ExibirPilhas(pilhaUndo, pilhaRedo);
        }

        // Adiciona uma nova ação à pilha de desfazer e limpa a pilha de refazer
        static void AdicionarAcao(Stack<string> pilhaUndo, Stack<string> pilhaRedo, string acao)
        {
            pilhaUndo.Push(acao);
            pilhaRedo.Clear(); // Limpa a pilha de refazer toda vez que uma nova ação é realizada
            Console.WriteLine($"Ação adicionada: {acao}");
        }

        // Desfaz a última ação, movendo-a para a pilha de refazer
        static void Desfazer(Stack<string> pilhaUndo, Stack<string> pilhaRedo)
        {
            if (pilhaUndo.Count > 0)
            {
                string acao = pilhaUndo.Pop();
                pilhaRedo.Push(acao);
                Console.WriteLine($"Desfeito: {acao}");
            }
            else
            {
                Console.WriteLine("Não há mais ações para desfazer.");
            }
        }

        // Refaz a última ação desfeita, movendo-a de volta para a pilha de desfazer
        static void Refazer(Stack<string> pilhaUndo, Stack<string> pilhaRedo)
        {
            if (pilhaRedo.Count > 0)
            {
                string acao = pilhaRedo.Pop();
                pilhaUndo.Push(acao);
                Console.WriteLine($"Refeito: {acao}");
            }
            else
            {
                Console.WriteLine("Não há ações para refazer.");
            }
        }

        // Exibe o conteúdo das pilhas de desfazer e refazer
        static void ExibirPilhas(Stack<string> pilhaUndo, Stack<string> pilhaRedo)
        {
            Console.WriteLine("Pilha de Undo:");
            foreach (var acao in pilhaUndo)
            {
                Console.WriteLine(acao);
            }

            Console.WriteLine("Pilha de Redo:");
            foreach (var acao in pilhaRedo)
            {
                Console.WriteLine(acao);
            }
        }
    }
}
