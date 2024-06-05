using System;
using System.Globalization;


namespace Course {
    class Program {
        static void Main(string[] args) {

            string maisVelho;

            Pessoa pessoa1, pessoa2;
            pessoa1 = new Pessoa();
            pessoa2 = new Pessoa();

            Console.WriteLine("Dados da primeira pessoa:");
            Console.WriteLine("Nome: ");
            pessoa1.Nome = Console.ReadLine();
            Console.Write("Idade: ");
            pessoa1.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados da segunda pessoa:");
            Console.WriteLine("Nome: ");
            pessoa2.Nome = Console.ReadLine();
            Console.Write("Idade: ");
            pessoa2.Idade = int.Parse(Console.ReadLine());

            if (pessoa1.Idade > pessoa2.Idade)
            {
                maisVelho = pessoa1.Nome;
            }
            else
            {
                maisVelho = pessoa2.Nome;
            }

            Console.WriteLine($"Pessoa mais velha: {maisVelho}");

        }

    }
} 