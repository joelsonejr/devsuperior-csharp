using System;
using System.Globalization;


namespace Course {
    class Program {
        static void Main(string[] args) {
        
            Console.Write("Quantos números inteiros você vai digitar: ");
            int userInput = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < userInput; i++)
            {   
                Console.Write($"Digite o valor numero {i + 1}: ");
                int typedValue = int.Parse(Console.ReadLine());

                sum += typedValue;
            }

            Console.WriteLine($"Soma = {sum}");
        }

    }
} 