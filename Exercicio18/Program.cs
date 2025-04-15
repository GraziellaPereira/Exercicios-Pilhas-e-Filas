using System;
using System.Collections.Generic;

namespace Exercicio18
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemplo de expressão pós-fixada
            string expressao = "3 4 + 2 *";

            // Calculando o resultado da expressão pós-fixada
            double resultado = CalcularPosFixada(expressao);

            // Exibindo o resultado
            Console.WriteLine($"Resultado: {resultado}");
        }

        static double CalcularPosFixada(string expressao)
        {
            // Pilha para armazenar os números
            Stack<double> pilha = new Stack<double>();

            // Dividindo a expressão em tokens
            string[] tokens = expressao.Split(' ');

            // Iterando sobre cada token da expressão
            foreach (var token in tokens)
            {
                if (double.TryParse(token, out double numero))
                {
                    // Se for um número, empilhamos
                    pilha.Push(numero);
                }
                else
                {
                    // Se for um operador, desempilhamos dois números e realizamos a operação
                    double operando2 = pilha.Pop();
                    double operando1 = pilha.Pop();

                    switch (token)
                    {
                        case "+":
                            pilha.Push(operando1 + operando2);
                            break;
                        case "-":
                            pilha.Push(operando1 - operando2);
                            break;
                        case "*":
                            pilha.Push(operando1 * operando2);
                            break;
                        case "/":
                            pilha.Push(operando1 / operando2);
                            break;
                        default:
                            throw new InvalidOperationException($"Operador desconhecido: {token}");
                    }
                }
            }

            // O último item na pilha é o resultado da expressão
            return pilha.Pop();
        }
    }
}
