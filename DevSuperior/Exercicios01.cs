
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

            int a,b,c,d;
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

            Console.WriteLine($"A diferença é {difference}");


        }
    }
}