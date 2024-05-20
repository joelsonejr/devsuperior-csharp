 using System;
 using System.Globalization;


namespace Course {
    class Exercicios01 {
        static void Main(string[] args) {
 //01           
/*             int firstValue;
            int secondValue;

            Console.Write("Digite o primeiro valor: ");
            firstValue = int.Parse(Console.ReadLine()!);
            Console.Write("Digite o segundo valor: ");
            secondValue = int.Parse(Console.ReadLine()!);

            int sum = firstValue + secondValue;
            

            Console.WriteLine($"O total da soma é: {sum}."); */

//02
            // double raio;
            // double pi = 3.14159;
            // double area;

            // Console.Write("Digite o valor do raio: ");
            // raio = double.Parse(Console.ReadLine());    

            // area = Math.Pow(raio, 2.0) * pi;

            // Console.WriteLine($"A área da circunferência é {area:F4}");

//03

/*             int a,b,c,d;
            int difference;

            Console.Write("Digite o valor de A: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor de B: ");
            b = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor de C: ");
            c = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor de D: ");
            d = int.Parse(Console.ReadLine());

            difference = a * b - c * d;

            Console.WriteLine($"A diferença é {difference}"); */


//04

/*             int employeeNumber;
            int workedHours;
            double hourRate;
            double salary;

            Console.Write("Digite o número do funcionário: ");
            employeeNumber = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade de horas trabalhadas: ");
            workedHours = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que é pago por hora: ");
            hourRate = double.Parse(Console.ReadLine());

            salary = workedHours * hourRate;

            Console.WriteLine($"O numéro do funcionário é: {employeeNumber}");
            Console.WriteLine($"Seu selário é U$: {salary:F2}"); */


//05
/*             int codePart01, codePart02, amountPart01, amountPart02;
            double pricePart01, pricePart02, order1TotalValue, order2TotalValue, totalAmount;

            string [] order01, order02;

            Console.WriteLine("Digite o código, quantidade e valor unitário da peça 1 (separados por espaço): ");
            order01 = Console.ReadLine().Split(' ');

            Console.WriteLine("Digite o código, quantidade e valor unitário da peça 2 (separados por espaço): ");
            order02 = Console.ReadLine().Split(' ');

            codePart01 = int.Parse(order01[0]);
            amountPart01 = int.Parse(order01[1]);
            pricePart01 = double.Parse(order01[2]);
            order1TotalValue = amountPart01 * pricePart01;


            codePart02 = int.Parse(order02[0]);
            amountPart02 = int.Parse(order02[1]);
            pricePart02 = double.Parse(order02[2]);
            order2TotalValue = amountPart02 * pricePart02;

            totalAmount = order1TotalValue + order2TotalValue;

            System.Console.WriteLine($"Valor a pagar: {totalAmount:F2}"); */

//06

            float pi = 3.14159F;
            float a, b, c;
            float triangleArea, circleArea, trapeziumArea, squareArea, rectangleArea;
            string [] userValues;

            Console.Write("Digite os três valores, separados por espaço: ");
            userValues = Console.ReadLine().Split(' ');

            a = float.Parse(userValues[0]);
            b = float.Parse(userValues[1]);  
            c = float.Parse(userValues[2]);

            // System.Console.WriteLine(Math.Pow(c, 2.0));
            triangleArea =  a * c / 2;
            circleArea = pi * (float)Math.Pow(c, 2.0) ;
            trapeziumArea = ((a + b) * c ) / 2;
            squareArea = (float)Math.Pow(b, 2.0);
            rectangleArea = (a * b); 

            System.Console.WriteLine($"Área do triângulo: {triangleArea:F3}");
            System.Console.WriteLine($"Área do circulo: {circleArea:F3}");
            System.Console.WriteLine($"Área do trapézio: {trapeziumArea:F3}");
            System.Console.WriteLine($"Área do quadrado: {squareArea:F3}");
            System.Console.WriteLine($"Área do retângulo: {rectangleArea:F3}");



            













        }
        
    }
}