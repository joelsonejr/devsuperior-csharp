/* using System;
using System.ComponentModel;

namespace Course {
    class Program {
        static void Main(string[] args) { */
        
        //Ex01
/*         Console.Write("Digite um valor entre 1 e 1000: ");
        int userInput = int.Parse(Console.ReadLine());

        while ( userInput < 1 || userInput > 1000) {
            Console.Write("Valor inválido. Digite um valor entre 1 e 1000: ");
            userInput = int.Parse(Console.ReadLine());
        }

        for (int i = 1; i <= userInput; i++)
        {
            if (i % 2 != 0) 
            {
                Console.WriteLine(i);
            }
        } */

        //Ex02
 /*            Console.Write("Quantos valores inteiros deseja digitar: ");
            int userInput = int.Parse(Console.ReadLine());

            int inInterval = 0;
            int outOfInterval = 0;

            for (int i = 0; i < userInput; i++)
            {   
                Console.Write($"Digite o valor número {i + 1}: ");
                int value = int.Parse(Console.ReadLine());

                if ( value >= 10 && value <= 20)
                {
                    inInterval += 1;
                }
                else 
                {
                    outOfInterval += 1;
                }
            }

            Console.WriteLine($"{inInterval} in");
            Console.WriteLine($"{outOfInterval} out"); */

            //ex03
/*             Console.Write("Digite a quantidade de casos de teste: ");
            double userInput = double.Parse(Console.ReadLine());

            for (int i =0; i < userInput; i++)
            {
                Console.Write($"Digite os três valores do caso de testes número {i + 1}: ");
                string [] testCase = Console.ReadLine().Split(' ');

                double value01, value02,value03;

                value01 = double.Parse(testCase[0]);
                value02 = double.Parse(testCase[1]);
                value03 = double.Parse(testCase[2]);

                double averages = (value01 * 2 + value02 * 3 + value03 * 5 ) / 10;

                Console.WriteLine($"{averages:F1}");

            } */



            //ex04
/*                 Console.Write("Quantas divisões deseja realizar? ");

                int userInput = int.Parse(Console.ReadLine());

                for ( int i = 0; i < userInput; i++)
                {
                    Console.Write("Digite os dois valores, separados por espaço:  ");
                    string [] theDivision = Console.ReadLine().Split(' ');

                    double numerador = double.Parse(theDivision[0]);
                    double denominador = double.Parse(theDivision[1]);

                    if (denominador == 0)
                    {
                        Console.WriteLine("Divisão impossível");
                    } 
                    else{
                        double division = numerador / denominador;
                        Console.WriteLine($"{division}");
                    }
                } */

            //Ex05
/*                     Console.Write("Digite o número cujo fatorial será calculado: ");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 0) {
                    Console.WriteLine(1);
                }
                else
                {
                    int fatorial = userInput * (userInput -1);

                    for (int i = 2; i < userInput; i++)
                    {
                        fatorial = fatorial * (userInput -i);
                    }

                    Console.WriteLine(fatorial);

                } */

            //Ex06
/*              Console.Write("Digite o números cujos divisores serão calculados: ");
                int userInput = int.Parse(Console.ReadLine());

                for (int i = 1; i <= userInput; i++)
                {
                    if (userInput % i == 0)
                    {
                        Console.WriteLine(i);
                    }
                } */

            //Ex07
/*                 Console.Write("Quantas linhas deseja exibir: ");
                int userInput = int.Parse(Console.ReadLine());

                //Minha solução
                for (int i = 1; i <= userInput; i++)
                {   
                    int result = i;
                    Console.Write($"{i} ");
                    int middleMan = i * i ; 
                    Console.Write($"{middleMan} ");
                    middleMan = middleMan * i;
                    Console.Write(middleMan);
                    Console.WriteLine();
                }

                //Solução Proposta
                for (int i = 1; i <= userInput; i++)
                {   
                    int first = i;
                    int second = i * i ; 
                    int third = i * i * i;

                    Console.WriteLine($"{first} {second} {third}");
                } */





/* 
        }

    }
}  */