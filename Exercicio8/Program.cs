using System;
using System.Collections.Generic;

namespace Exercicio8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite a sequência de parênteses: ");
            string parenteses = Console.ReadLine();
            Stack<char> sequenciaParenteses = new Stack<char>();

            foreach (char parentese in parenteses)
            {
                if (parentese == '(')
                {
                    sequenciaParenteses.Push(parentese);
                }
 
                else if (parentese == ')')
                {
                    
                    if (sequenciaParenteses.Count > 0)
                    {
                        sequenciaParenteses.Pop();  
                    }
                    else
                    {
                        
                        Console.WriteLine("Sequência de parênteses desbalanceada.");
                        return;
                    }
                }
            }

            if (sequenciaParenteses.Count == 0)
            {
                Console.WriteLine("Sequência de parênteses balanceada.");
            }
            else
            {
                Console.WriteLine("Sequência de parênteses desbalanceada.");
            }
            Console.ReadKey();
        }
    }
}
