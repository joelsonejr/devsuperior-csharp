using System;

namespace Course {
    class Program {
        static void Main(string[] args) {

//01

/*         int numberToCheck;

        Console.WriteLine("Digite um número: ");
        numberToCheck = int.Parse(Console.ReadLine());

        if (numberToCheck == 0) {
            Console.WriteLine("0 não é negativo nem positivo");
        }
        else if (numberToCheck < 0) {
            Console.WriteLine($"O número {numberToCheck} é negativo");
        }
        else {
            Console.WriteLine($"O número {numberToCheck} é positivo");
        } */

//02
/*         int numberToCheck;

        Console.Write("Digite um número: ");
        numberToCheck = int.Parse(Console.ReadLine());
        
        if (numberToCheck % 2 == 0) {
            Console.WriteLine("PAR");
        }
        else {
            Console.WriteLine("ÍMPAR");
        } */

//03 
      /*   int a, b, c;

        Console.Write("Digite dois valores, separados por espaço: ");

        string [] userInput = Console.ReadLine().Split(' ');

        a = int.Parse(userInput[0]);
        b = int.Parse(userInput[1]);

        if (a == 0 || b == 0) {
            Console.WriteLine("0 não é um valor válido");
            return;
        }

        if (a < b) {
            c = b % a;
        }
        else {
            c = a % b;
        }
        
        if (c == 0) {
            Console.WriteLine("São Muliplos");
        }
        else {
            Console.WriteLine("Não são multiplos");
        } */

//04

        int gameStart, gameEnd;
        int gameDuration = 0;
        string [] userInput;

        Console.WriteLine("Digite horas de início e término, separadas por espaço:");
        userInput = Console.ReadLine().Split(' ');

        gameStart = int.Parse(userInput[0]);
        gameEnd = int.Parse(userInput[1]);

        if (gameStart < gameEnd) {
            gameDuration = gameEnd - gameStart;
        } else {
            gameDuration = gameDuration = 24 - gameStart + gameEnd;
        }


        Console.WriteLine($"O jogo durou {gameDuration} hora(s)");






        }
    }
}