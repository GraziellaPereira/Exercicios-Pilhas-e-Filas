using System;
using System.Collections.Generic;

namespace Exercicio15
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> estacionamento = new Stack<string>(5);

            // Adicionando carros ao estacionamento
            AdicionarCarro(estacionamento, "Carro 1");
            AdicionarCarro(estacionamento, "Carro 2");
            AdicionarCarro(estacionamento, "Carro 3");
            AdicionarCarro(estacionamento, "Carro 4");
            AdicionarCarro(estacionamento, "Carro 5");

            // Tentando adicionar um sexto carro (deve mostrar mensagem de erro)
            AdicionarCarro(estacionamento, "Carro 6");

            // Removendo um carro (o mais recente que entrou no estacionamento)
            Console.WriteLine($"Carro removido: {RemoverCarro(estacionamento)}");

            // Agora vamos remover um carro que está no meio (simulando a remoção de um carro que não está no topo)
            RemoverCarroERecolocar(estacionamento, "Carro 3");

            // Exibindo todos os carros no estacionamento
            Console.WriteLine("\nCarros restantes no estacionamento:");
            ExibirCarros(estacionamento);
        }

        // Método para adicionar um carro ao estacionamento
        static void AdicionarCarro(Stack<string> estacionamento, string carro)
        {
            if (estacionamento.Count >= 5)
            {
                Console.WriteLine("Estacionamento cheio! Não é possível adicionar mais carros.");
            }
            else
            {
                estacionamento.Push(carro);
                Console.WriteLine($"{carro} entrou no estacionamento.");
            }
        }

        // Método para remover o carro mais recente do estacionamento
        static string RemoverCarro(Stack<string> estacionamento)
        {
            if (estacionamento.Count == 0)
            {
                Console.WriteLine("Estacionamento vazio! Não há carros para remover.");
                return null;
            }
            return estacionamento.Pop();
        }

        // Método para remover um carro que não está no topo da pilha (simulando a remoção de um carro no meio)
        static void RemoverCarroERecolocar(Stack<string> estacionamento, string carro)
        {
            Stack<string> temporario = new Stack<string>();

            // Removendo carros até encontrar o carro desejado
            while (estacionamento.Count > 0)
            {
                string carroRemovido = estacionamento.Pop();
                if (carroRemovido == carro)
                {
                    Console.WriteLine($"{carro} removido temporariamente.");
                    break;
                }
                else
                {
                    temporario.Push(carroRemovido); // Colocando os carros removidos em um "estacionamento temporário"
                }
            }

            // Colocando os carros de volta ao estacionamento
            while (temporario.Count > 0)
            {
                estacionamento.Push(temporario.Pop());
            }

            Console.WriteLine($"Todos os carros de volta ao estacionamento após a remoção do {carro}.");
        }

        // Método para exibir todos os carros no estacionamento
        static void ExibirCarros(Stack<string> estacionamento)
        {
            foreach (var carro in estacionamento)
            {
                Console.WriteLine(carro);
            }
        }
    }
}
