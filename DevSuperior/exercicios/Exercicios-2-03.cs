/* using System;
using System.Globalization;

namespace Course {
    class Program {
        static void Main(string[] args) {
 */
            //Ex.01

/*             int password = 2002;
            int userInput;

            Console.Write("Digite a senha de 4 números: ");
            userInput = int.Parse(Console.ReadLine());

            while (userInput != password)
            {
                Console.WriteLine("Senha Inválida");

                 Console.Write("Digite a senha de 4 números: ");
                userInput = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Acesso Permitido");
             */
            

            //Ex.02

/*             string [] userInput;
            int x, y;

            Console.Write("Escreva as coordenadas, separadas por espaço: ");
            userInput = Console.ReadLine().Split(' ');

            x = int.Parse(userInput[0]);
            y = int.Parse(userInput[1]);


            while (x != 0 && y != 0)
            {   
                string quadrant = quadrantLocator(x, y);
                Console.WriteLine(quadrant);

                Console.Write("Escreva as coordenadas, separadas por espaço: ");
                userInput = Console.ReadLine().Split(' ');

                x = int.Parse(userInput[0]);
                y = int.Parse(userInput[1]);
            }


        }

        static string quadrantLocator(int coordX, int coordY) 
        {   
            string position = "";

            if (coordX > 0 && coordY > 0) 
            {
                position = "primeiro";
            }
            else if (coordX > 0 && coordY <0)
            {
                position = "quarto";
            }
            else if (coordX < 0 && coordY < 0)
            { 
                position = "terceiro";
            }
            else if (coordX < 0 && coordY > 0 )
            {
                position = "segundo";
            }

            return position;
        } */

        //Ex. 03
/* 
        int alcool = 0;
        int gasolina = 0;
        int diesel = 0;
        int userSelection = 0; 

        printOptionMenu();

        userSelection = int.Parse(Console.ReadLine());

        while (userSelection != 4) 
        {
            if (userSelection < 1 || userSelection > 4)
            {
                Console.WriteLine("Código inválido");

                printOptionMenu();
                userSelection = int.Parse(Console.ReadLine());

            }
            else 
            {
                if (userSelection == 1) 
                {
                    alcool ++;
                }
                else if (userSelection == 2)
                {
                    gasolina ++;
                }
                else if (userSelection == 3)
                {
                    diesel ++;
                }

                printOptionMenu();
                userSelection = int.Parse(Console.ReadLine());

            }
        }

        Console.WriteLine("MUITO OBRIGADO");
        Console.WriteLine($"Alcool: {alcool}");
        Console.WriteLine($"Gasolina: {gasolina}");
        Console.WriteLine($"Diesel: {diesel}");

        }

        static void printOptionMenu() 
        {
            Console.WriteLine("Digite o número da opção desejada: ");
            Console.WriteLine("1 - Alcool");
            Console.WriteLine("2 - Gasolina");
            Console.WriteLine("3 - Diesel");
            Console.WriteLine("4 - Fim");
        }
    }
}   */