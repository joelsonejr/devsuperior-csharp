/* using System;

namespace Course {
    class Program {
        static void Main(string[] args) { */

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

/*         int gameStart, gameEnd;
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


        Console.WriteLine($"O jogo durou {gameDuration} hora(s)"); */

//05

/*         string[] userInput;
        int itemCode = 0;
        int itemAmount;
        double itemPrice = 0;
        double totalValue;

        Console.Write("Digite o código do produto (de 1 a 5), e a quantidade, separados por espaço: ");
        userInput = Console.ReadLine().Split(' ');

        itemCode = int.Parse(userInput[0]);
        itemAmount = int.Parse(userInput[1]);

        if (itemCode == 1) 
        {
            itemPrice = 4.00;
        }
        else if (itemCode == 2) 
        {
            itemPrice = 4.50;
        }
        else if(itemCode == 3) 
        {
            itemPrice = 5.00;
        }
        else if(itemCode == 4)
        {
            itemPrice = 2.00;
        }
        else if(itemCode == 5)
        {
            itemPrice = 1.50;
        }
        else 
        {
            Console.WriteLine("Código de produto inválido");
        }

        totalValue = itemPrice * itemAmount; 

        Console.WriteLine($"Total: {totalValue:F2}"); */


//06

/*         double providedValue; 

        Console.Write("Escreva o valor selecionado: ");
        providedValue = double.Parse(Console.ReadLine());

        if (providedValue >= 0 && providedValue <= 25) {
            Console.WriteLine("Intervalo [0, 25]");
        }
        else if (providedValue > 25 && providedValue <= 50)
        {
            Console.WriteLine("Intervalo (25, 50])");
        }
        else if (providedValue > 50 && providedValue <= 75)
        {
            Console.WriteLine("Intervalo (50, 75]");
        }
        else if (providedValue > 75 && providedValue <= 100)
        {
            Console.WriteLine("Intervalo (75, 100])");
        }
        else{
            Console.WriteLine("Fora de intervalo");
            Console.WriteLine($"Provided value: {providedValue}");
        }
 */

 //07
       /*  double x, y;
        string[] userInput;

        Console.Write("Digite os valores de x e y, separados por espaço: ");
        userInput = Console.ReadLine().Split(' ');

        x = double.Parse(userInput[0]);
        y = double.Parse(userInput[1]);

        if (x == y && y == 0)
        {
            Console.WriteLine("Origem");
        }
        else if (x == 0) 
        {
            Console.WriteLine("Eixo X");
        }
        else if (y == 0) 
        {
            Console.WriteLine("Eixo Y");
        }
        else if (x > 0 && y > 0)
        {
            Console.WriteLine("Q1");
        }
        else if (x > 0 && y < 0)
        {
            Console.WriteLine("Q4");
        }
        else if(x < 0 && y > 0 )
        {
            Console.WriteLine("Q2");
        }
        else if( x < 0 && y < 0)
        {
            Console.WriteLine("Q3");
        } */

//08

        /* double salary, salaryForTaxes;
        int taxes;


        Console.Write("Digite o valor do salário mensal: ");
        salary = double.Parse(Console.ReadLine());

        salaryForTaxes = salary - 2000;


        double joe = salaryForTaxes % 1000;

        double kenya = salaryForTaxes - joe;

        Console.WriteLine(joe);
        System.Console.WriteLine(kenya); */


        









/*         }
    }
} */