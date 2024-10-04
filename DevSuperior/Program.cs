using System;
using System.IO;
using Course.Entities;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Acho o arquivo
            //Leio o conteúdo do arquivo
            //Crio um obj Products para cada linha do arquivo
            //Guardo esse objeto em uma lista
            //Criar pasta de saída
            //Passo o conteúdo dessa lista para um arquivo. 
            //Salvar o arquivo na pasta de saída.

        }

        public string GetFileLocation(string path)
        {   
            string location = Path.GetFullPath(path);
            return location;
        }

        public double CalculateProductPrice(int quantity, double value)
        {
            return quantity * value;
        }

        public void CreateFolder(string path)
        {
            Directory.CreateDirectory($"{path}/out");
        }

        public string CreateFileEntry(string name, double totalValue)
        {
            return "";
        }
    }
}

/*
=========================================================
================= AULAS PASSADAS ========================
=========================================================



/////////////////////////////////////////////////////
//010.6 - Path
using System;
using System.IO;

namespace Course
{
    class Program
    {
        public static void Main(string[] args) 
        {
            string path = @"./ioFiles/file1.txt";

            Console.WriteLine("Directory separator: " + Path.DirectorySeparatorChar);
            Console.WriteLine("Path separator: " + Path.PathSeparator);
            Console.WriteLine("Directory name: " + Path.GetDirectoryName(path));
            Console.WriteLine("File name: " + Path.GetFileName(path));
            Console.WriteLine("File name without extension: " + Path.GetFileNameWithoutExtension(path));
            Console.WriteLine("File extension:  " + Path.GetExtension(path));
            Console.WriteLine("Full path: " + Path.GetFullPath(path));
            Console.WriteLine("Path to tempo folder:  " + Path.GetTempPath());
        }
    }
}

/////////////////////////////////////////////////////
//010.5 - Directory, DirectoryInfo
using System;
using System.Collections.Generic;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path =@"./";

            try
            {
                IEnumerable<string> folder = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS: ");
                foreach (string item in folder)
                {
                    Console.WriteLine(item);
                }

                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("files: ");
                foreach (string item in files)
                {
                    Console.WriteLine(item);
                }

                Directory.CreateDirectory(path + "/pasta-do-curso");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

/////////////////////////////////////////////////////
//010.4 - StringWriter
using System.IO;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            string sourcePath = @"./ioFiles/file1.txt";
            string targetPath = @"./ioFiles/file5.txt";

            try {
                string[] lines = File.ReadAllLines(sourcePath);

                using(StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

/////////////////////////////////////////////////////
//010.3 - Bloco Using
//Garante que os objetos IDisposable ( que não são gerenciados pelo CLR), sejam
// fechados.

using System;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string path = @"./ioFiles/file1.txt";

                using (FileStream fs = new FileStream(path, FileMode.Open)) 
                { 
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Erro {e.Message}");
            }

            //No caso de uma instanciação resumida do StreamReader, seria feito:
            //1. Remover a linha contendo o FileStream
            //2. Inicializar o StreamReader da forma a seguir:
            // using (StreamReader sr = new File.OpenText(path)) 
        }
    }
}

/////////////////////////////////////////////////////
//010.2 - FileStream  e Streamreader
using System.IO;

namespace Course
{
    class Program 
    {
        public static void Main(string[] args) 
        {
            string path = @"./ioFiles/file1.txt";

            FileStream fs = null;
            StreamReader sr = null;

            // Uma forma resumida de realizar a criação dessas instâncias, é 
            // 1. omitindo o FileStream de todo o código.
            // 2. declarar, dentro do bloco try o StreamReader da forma:
            //      sr = File.OpenText(path);
            // O OpenText cria uma FileStream, "por debaixo dos panos".

            try
            {
                fs = new FileStream(path,FileMode.Open);
                sr = new StreamReader(fs);
                while (!sr.EndOfStream) 
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);                    
                }
            }
            catch (IOException  e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            //Fechando as streams, após o uso. 
            finally
            {
                if(fs != null) fs.Close();
                if(sr != null) sr.Close();                
            }
        }
    }

}


/////////////////////////////////////////////////////
//010.1 - File, Fileinfo Ioexception
using System;
using System.IO;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            string sourcePath = @"./ioFiles/file1.txt";
            string targetPath = @"./ioFiles/file4.txt";

            try  
            {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);

                string[] lines = File.ReadAllLines(sourcePath);

                foreach(string line in lines)
                {
                    Console.WriteLine(line);
                }

            }
            catch(IOException e)
            {
                Console.WriteLine("An error occurered!");
                Console.WriteLine(e.Message);              
            }

        }
    }
}

/////////////////////////////////////////////////////
//09.8 - Exercício Proposto

using System.Globalization;
using Course.Entities;
using Course.Entities.Exceptions;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            try 
            {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine());
                Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine());

                Account account = new Account(number, holder, balance, withdrawLimit);

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine());

                account.Withdraw(amount);
                Console.WriteLine($"New balance: {account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            catch (ChallengeException e)
            {
                Console.WriteLine($"Withdraw error: {e.Message}");
            }

            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
        }
    }
}

/////////////////////////////////////////////////////

//09.7 - Criando Excessões Personalizadas - pt 3
//Utilizando tratamento de excessões

using System.ComponentModel;
using Course.Entities;
using Course.Entities.Exceptions;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            try 
            {
                Console.Write("Room number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                
                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine($"Reservation: {reservation}");

                Console.WriteLine();
                Console.WriteLine("Enter data to update reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                reservation.UpdateDates(checkIn, checkOut);

                Console.WriteLine($"Reservation: {reservation}");
            }
            catch (DomainException e)
            {
                Console.WriteLine($"Error in reservation: {e.Message}");
            }

            //Outro exemplo de tratamento de excessão.
            catch (FormatException e)
            {
            Console.WriteLine($"Format error: {e.Message}");
            }

            //Capturando excessões que não foram previstas
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected erro: {e.Message}");
            }

        }
    }
}

/////////////////////////////////////////////////////
//09.6 - Criando Excessões Personalizadas - pt 2
//Passando as validações para a classe Reservation, mas sem utilizar excessões.

using System.ComponentModel;
using Course.Entities;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Room number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            if (checkOut <= checkIn)
            {
                Console.WriteLine("Error in reservation: check-out date must be after check in date ");
            }

            else 
            {
                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine($"Reservation: {reservation}");

                Console.WriteLine();
                Console.WriteLine("Enter data to update reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                string error = reservation.UpdateDates(checkIn, checkOut);

                if (error != null) 
                {   
                    Console.WriteLine($"Error in reservation: {error}");
                }
                else
                {
                    Console.WriteLine($"Reservation: {reservation}");
                }
            }
        }
    }
}

/////////////////////////////////////////////////////
//09.5 - Criando Excessões Personalizadas - pt 1
//Sem utilizar excessões
using System.ComponentModel;
using Course.Entities;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Room number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            if (checkOut <= checkIn)
            {
                Console.WriteLine("Error in reservation: check-out date must be after check in date ");
            }

            else 
            {
                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine($"Reservation: {reservation}");

                Console.WriteLine();
                Console.WriteLine("Enter data to update reservation:");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());

                DateTime now = DateTime.Now;

                if (checkIn < now || checkOut < now)
                {
                    Console.WriteLine("Error in reservation: Reservation dates for update must be future dates");
                }
                else if (checkOut <= checkIn)
                {
                    Console.WriteLine("Error in reservation: check-out date must be after check in date ");
                }
                else 
                {
                    reservation.UpdateDates(checkIn, checkOut);
                    Console.WriteLine($"Reservation: {reservation}");
                }
            }
        }
    }
}


/////////////////////////////////////////////////////
//09.4 - Bloco Finally
using System;
using System.IO;

namespace Course 
{
    class Program
    {
        public static void Main(string[] args)
        {
            FileStream fs = null;

            try 
            {
                fs = new FileStream(@"C:\temp\data.txt", FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }
    }
}


/////////////////////////////////////////////////////
//09.3 - Try-Catch

using System;
using System.Linq.Expressions;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
           try 
           {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            int result = n1 / n2;

            Console.WriteLine(result);
           }
            // catch (Exception e )
            // {
            //     Console.WriteLine("Error: " + e.Message);
            // }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Divison by zero not allowed.");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
        }

    }
}

/////////////////////////////////////////////////////
//9.02 Discussão Inicial Sobre Excessões
Teórica

/////////////////////////////////////////////////////
/////////////////////////////////////////////////////

//8.12 Desafio Plataforma de ensino
using Course.Entities;
using System.Collections.Generic;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Lesson> lessonList = new List<Lesson>();

            Console.Write("Quantas aulas tem o curso? ");
            int numberOfClasses = int.Parse(Console.ReadLine());

            CreateLesson(numberOfClasses, lessonList);       
            
            PrintTotalDuration(lessonList);
            
        }

        public static void CreateLesson(int numClasses, List<Lesson> lessons)
        {
            for(int i = 0; i < numClasses; i++)
            {    
                Console.WriteLine();
                Console.WriteLine($"Dados da {i+1}ª aula:");
                Console.Write("Conteúdo da tarefa (c/t)? ");
                char lessonType = char.Parse(Console.ReadLine().ToLower());
                Console.Write("Título: ");
                string lessonTitle = Console.ReadLine();

                if(lessonType == 'c')
                {
                    CreateVideoClass(lessonTitle, lessons);
                }

                if(lessonType == 't')
                {
                    CreateTaskClass(lessonTitle, lessons);
                }
            }
        }

        public static void CreateVideoClass(string title, List<Lesson> list) {
            Console.Write("URL do vídeo: ");
            string lessonUrl = Console.ReadLine();
            Console.Write("Duração em segundos: ");
            int lessonDuration = int.Parse(Console.ReadLine());

            Video video = new Video(lessonUrl, lessonDuration, title);
            list.Add(video);
        }

        public static void CreateTaskClass(string title, List<Lesson> list)
        {
            Console.Write("Descrição: ");
            string lessonDescription = Console.ReadLine();
            Console.Write("Quantidade de questões: ");
            int lessonQuestions = int.Parse(Console.ReadLine());

            Entities.Task task = new Entities.Task(lessonDescription, lessonQuestions, title);

            list.Add(task);                   
    }

        public static void PrintTotalDuration(List<Lesson> list)
        {   
            int totalDuration = 0;

            foreach(Lesson lesson in list)
            {
                totalDuration += lesson.Duration();
            }

            Console.WriteLine();
            Console.WriteLine($"Duração total do curso = {totalDuration} segundos");
      
        }
    }
}

/////////////////////////////////////////////////////
//8.11 Exercício propost

using System.Globalization;
using Course.Entities;

namespace Course 
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<TaxPayers> payersList = new List<TaxPayers>();

            Console.Write("Enter the number of tax payers: ");
            int numTaxPayers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numTaxPayers; i++)
            {
                Console.WriteLine($"Tax Payer #{i+1} data:");
                Console.Write("Individual or Company (i/c)? ");
                char payerType = char.Parse(Console.ReadLine().ToLower());
                Console.Write("Name: ");
                string payerName = Console.ReadLine();
                Console.Write("Annual income: ");
                double payerIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(payerType == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double payerHealthExp = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    IndividualTaxPayer payer = new IndividualTaxPayer(payerHealthExp, payerName, payerIncome);

                    payersList.Add(payer);
                }

                if(payerType == 'c')
                {
                    Console.Write("Number of employees: ");
                    int employNumber = int.Parse(Console.ReadLine());

                    CompanyTaxPayer company = new CompanyTaxPayer(employNumber, payerName, payerIncome);

                    payersList.Add(company);
                }
            }

            PrintTaxInformation(payersList);

        }

        public static void PrintTaxInformation(List<TaxPayers> payers)
        {
                        Console.WriteLine("");
            Console.WriteLine("TAXES PAID: ");
            double totalTaxes = 0;
            foreach(TaxPayers taxPayer in payers)
            {
                Console.Write($"{taxPayer.Name}: ");
                Console.WriteLine($"$ {taxPayer.CalculateTax().ToString("F2", CultureInfo.InvariantCulture)}");

                totalTaxes += taxPayer.CalculateTax();
            }
            Console.WriteLine();
            Console.Write("TOTAL TAXES: $ ");
            Console.WriteLine(totalTaxes.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}

/////////////////////////////////////////////////////
//8.10 Métodos Abstratos
using System;
using Course.Entities.Enums;
using Course.Entities;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace Course 
{
    class Program 
    {
        public static void Main(string[] args)
        {   
            List<Shape> shapes = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int numShapes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numShapes; i++)
            {
                Console.WriteLine($"Shapen # { i + 1} data: ");
                Console.Write("Rectangle or Circle (r / c): ");
                char shapeType = char.Parse(Console.ReadLine().ToLower());
                Console.Write("Color (Black, Blue, Red): ");
                Colors shapeColor = Enum.Parse<Colors>(Console.ReadLine());

                if(shapeType == 'r')
                {
                    Console.Write("Width: ");
                    double rectWidth = double.Parse(Console.ReadLine());
                    Console.Write("Height: ");
                    double rectHeight = double.Parse(Console.ReadLine());

                    Rectangles rect = new Rectangles(rectWidth, rectHeight, shapeColor);

                    shapes.Add(rect);
                }

                if(shapeType == 'c')
                {
                    Console.Write("Radius: ");
                    double circRadius = double.Parse(Console.ReadLine());

                    Circle circle = new Circle(circRadius, shapeColor);

                    shapes.Add(circle);
                }
            }

            Console.WriteLine();
            Console.WriteLine("SHAPE AREAS: ");
            
            foreach(Shape shape in shapes)
            {
                Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}

/////////////////////////////////////////////////////


//8.9 Classes Abstratas
using System; 
using Course.Entities;
using System.Collections.Generic;
using System.Globalization;

namespace Course 
{
    class Program
    {
        public static void Main(string[] args) 
        {   
            List<Account> list = new List<Account>();

            list.Add(new SavingsAccount(1001, "Joe", 500.0, 0.01));
            list.Add(new BusinessAccount(1001, "Maria", 500.0, 400.0));
            list.Add(new SavingsAccount(1003, "Bob", 500.0, 0.01));
            list.Add(new BusinessAccount(1004, "Ana", 500.0, 500.0));

            double sum = 0;

            foreach (Account acc in list)
            {
                sum += acc.Balance;
            }

            Console.WriteLine($"Total balance: {sum.ToString("F2", CultureInfo.InvariantCulture)}");

            foreach (Account acc in list)
            {
                acc.Withdraw(10.0);
            }

            foreach (Account acc in list)
            {
                Console.WriteLine($"Uptaded balance for account {acc.Number}: {acc.Balance.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            // Account acc = new Account(1001, "Joe", 0.0); //Dá erro, porque agora a classe Account é abstrata.
            // BusinessAccount bacc = new(1002, "Rosa", 0.0, 500.00);


            // Account acc1 = bacc; 
            // Account acc2 = new BusinessAccount(1003, "Ana", 0.0, 200.0);
            // Account acc3 = new SavingsAccount(1004, "Rosana", 0.0, 0.01);


            // BusinessAccount acc4 = (BusinessAccount)acc2; 

            //  acc4.Loan(100.0); 

            // if (acc3 is BusinessAccount)
            // {
            //     BusinessAccount acc5 = (BusinessAccount)acc3;
            //     acc5.Loan(200.0);
            //     Console.WriteLine("Loan!");
            // }

            // if (acc3 is SavingsAccount)
            // {
    
            //     SavingsAccount acc5 = acc3 as SavingsAccount; 
            //     acc5.UpdateBalance();
            //     Console.WriteLine("Update");
            // }
        }
    }
}

/////////////////////////////////////////////////////

//8.8 Exercício Proposto
using System;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Product> productList = new List<Product>();

            Console.Write("Enter the number of products: ");
            int productNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < productNum; i++) 
            {
                 Console.WriteLine($"Product # {i + 1} data:");
                 Console.Write("Common, used or imported (c/u/i)? ");
                 char productOrigin = char.Parse(Console.ReadLine().ToLower());
                 Console.Write("Name: ");
                 string productName = Console.ReadLine();
                 Console.Write("Price: ");
                 double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                 if (productOrigin == 'c')
                 {
                    Product prod = new Product(productName, productPrice);
                    productList.Add(prod);
                 }
                 
                if (productOrigin == 'i')
                {
                    Console.Write("Customs fee: ");
                    double productFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Product importedProd = new ImportedProduct(productName, productPrice, productFee);
                    productList.Add(importedProd);
                }

                if (productOrigin == 'u') {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());

                    Product usedProd = new UsedProducts(productName, productPrice, manufactureDate);
                    productList.Add(usedProd);
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");

            foreach( Product product in productList)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}


/////////////////////////////////////////////////////

//8.7 Exercício Resolvido PT 01
using System.Collections.Generic;
using Course.Entities;
using System.Globalization;

namespace Course 
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the number of employees: ");
            int numEmployees = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for ( int i = 0; i < numEmployees; i ++)
            {
                Console.WriteLine($"Employee # {i + 1} data:");
                Console.Write("Outsourced (y/n)? ");
                char outsourced = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string empName = Console.ReadLine();
                Console.Write("Hours: ");
                int empHours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double empHourValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                double addCharge = 0;

                if ( Char.ToLower(outsourced) == 'y')
                {
                    Console.Write("Additional charge: ");
                    addCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Employee employee = new OutsourcedEmployee(empName, empHours, empHourValue, addCharge);
                    employees.Add(employee);

                }
                else
                {
                    Employee employee = new Employee(empName, empHours, empHourValue);                   
                    employees.Add(employee);
                } 

            }

            Console.WriteLine();
            Console.WriteLine("PAYMENTS: ");
            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.Name} - ${employee.Payment().ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
    }
}

/////////////////////////////////////////////////////

//8.6 Introdução ao Polimorfismo
//Variáveis de um mesmo tipo (mais genérico) ligadas a tipos específicos
//distintos, e possuindo comportamentos referentes a esses tipos. 
//Exemplo: acc1 e acc2 da aula 8.4

/////////////////////////////////////////////////////

//8.5 Classes e Métodos Selados
//Classe: evita que a classe seja herdada.
//Método: evita que um método sobreposto seja sobreposto novamente.
using System;


/////////////////////////////////////////////////////

//8.4 - Sobreposição, palavras virtual, override e base.
using System;
using Course.Entities;

namespace Course 
{
    class Program
    {
        public static void Main(string[] args) 
        {
            Account acc1 = new Account(1001, "Joe", 500.0);
            Account acc2 = new SavingsAccount(1002, "Rosa", 500.0, 0.01);

            acc1.Withdraw(10.0);
            acc2.Withdraw(10.0);

            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);
        }
    }
}

/////////////////////////////////////////////////////

//8.3 - Upcasting e Downcasting
//Upcasting - casting (conversão)  da subclasse para a superclasse
using System;
using System.Data;
using Course.Entities;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            Account acc = new Account(1001, "Joe", 0.0);
            BusinessAccount bacc = new(1002, "Rosa", 0.0, 500.00);

            //Upcasting
            //Superclasse recebendo objeto da subclasse
            Account acc1 = bacc; 
            //Objeto BusinessAccount dentro de uma variável do tipo Account
            Account acc2 = new BusinessAccount(1003, "Ana", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Rosana", 0.0, 0.01);

            //Downcasting

            // BusinessAccount acc4 = acc2; //Para o compilador o que vale é o tipo da variável. Por isso dá erro. 
            BusinessAccount acc4 = (BusinessAccount)acc2; //Fazendo o casting de forma explícita

             acc4.Loan(100.0); //Variável do tipo BusinessAccount, que possui o método Loan. 
            //  acc2.Loan(100.0); //Tipo Account não possui essa operação. Mesmo o conteúdo da variável sendo do tipo BusinessAccount. 

            // BusinessAccount acc5 = (BusinessAccount)acc3; //BusinessAccount não é compatível com SavingsAccount. Apesar 
            // casting não indicar erro, ocorrerá erro de compilção.

            //Deve-se testar primeiro o tipo da variável, antes de realizar o Downcasting
            if (acc3 is BusinessAccount)
            {
                BusinessAccount acc5 = (BusinessAccount)acc3;
                acc5.Loan(200.0);
                Console.WriteLine("Loan!");
            }

            if (acc3 is SavingsAccount)
            {
                // SavingsAccount acc5 = (SavingsAccount)acc3;
                SavingsAccount acc5 = acc3 as SavingsAccount; //Outra forma de realizar o casting
                acc5.UpdateBalance();
                Console.WriteLine("Update");
            }
        }

    }      
}

/////////////////////////////////////////////////////

//8.2 Herança
using System;
using Course.Entities;

namespace Course
{
    class Program
    {
        public static void Main(string[] args) 
        {
            BusinessAccount account = new BusinessAccount(8010, "Joe", 100.0, 500.0);

            Console.WriteLine(account.Balance);

            // account.Balance = 100; Dá erro, por ser protected (só pode ser acessado pela própria classe, ou subclasses)

            account.Loan(500);
        }
    }
}

/////////////////////////////////////////////////////
/////////////////////////////////////////////////////
// DESAFIO do módulo 07
using System;
using Course.Entities;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            Department department = CreateDepartment();

            Console.Write("Quantos funcionários tem o departamento: ");
            int employeeNumber = int.Parse(Console.ReadLine());

            CreateEmployee(employeeNumber, department);

            ShowReport(department);
        }

        public static Address CreateAddress(string email, string phone)
        {   
            Address add = new Address(email, phone);

            return add;
        }

        public static Department CreateDepartment()
            {
                Console.Write("Nome do departamento: ");
                string deptName = Console.ReadLine();
                Console.Write("Dia do pagamento: ");
                int deptPayDay = int.Parse(Console.ReadLine());
                Console.Write("Email: ");
                string deptEmail = Console.ReadLine();
                Console.Write("Telefone: ");
                string deptPhone = Console.ReadLine();

                Address deptAddress = CreateAddress(deptEmail, deptPhone);
                Department dept = new Department(deptName, deptPayDay, deptAddress);

                return dept;
            }

        public static void CreateEmployee(int amount, Department dept)
        {
            for (int i = 0; i < amount; i++)
            {
                Console.WriteLine($"Dados do funcionário {i+1}: ");
                Console.Write("Nome: ");
                string empName = Console.ReadLine();
                Console.Write("Salário: ");
                double empSalary = double.Parse(Console.ReadLine());

                Employee emp = new Employee(empName, empSalary);

                dept.AddEmployee(emp);
                
            }
        }

        public static void ShowReport(Department dept) 
        {
            Console.WriteLine(dept);
        }
    }
}

/////////////////////////////////////////////////////

//7.7 Exercício Proposto

using System;
using System.ComponentModel;
using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Couse {
    class Program
    {
        public static void Main(string[] args)
        {


                Client client = GenerateClient();
  
                Order order = GenerateOrder(client);

                Console.Write("How many items to this order? ");
                int itemAmount = int.Parse(Console.ReadLine());

                GenerateOrderItem(order, itemAmount);

                Console.WriteLine(order);


        }

        public static Client GenerateClient() 
        {
                Console.WriteLine("Enter client data: ");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Birth date (DD/MM/YYYY): ");
                DateTime birthDate = DateTime.Parse(Console.ReadLine());

                Client client = new Client(name, email, birthDate);

                return client;
        }

        public static Order GenerateOrder(Client client)
        {
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            DateTime orderMoment = DateTime.Now;


            Order order = new Order(orderMoment,status, client);

            return order;
        }

        public static void GenerateOrderItem(Order order, int itemAmount)
        {
            for (int i = 0; i < itemAmount; i++)
                {
                    Console.WriteLine($"Enter #{i+1} item data: ");
                    Console.Write("Product name: ");
                    string prodName = Console.ReadLine();
                    Console.Write("Product price: ");
                    double prodPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Quantity: ");
                    int prodQuantity = int.Parse(Console.ReadLine());

                    Product product = new Product(prodName, prodPrice);

                    OrderItem orderItem = new OrderItem(prodQuantity,prodPrice, product);

                    order.AddItem(orderItem);
                }
        }

    }
}

/////////////////////////////////////////////////////

//7.6 - Exercício Resolvido 2 (Stringbuilder)

using System;
using Course.Entities;

namespace Course
{
    class Program 
    {
        public static void Main(string[] args) 
        {
            Comment C1 = new Comment("Have a nive trip");
            Comment C2 = new Comment("Wow that's awesome!");
            Post p1 = new Post(
                DateTime.Parse("2024-07-31 09:48:32" ),
                "Traveling to New Zealand",
                "I'm going to visit this wonderful contry!",
                12
            );
            p1.AddComment(C1);
            p1.AddComment(C2);

            Comment c3 = new Comment("Good Night");
            Comment c4 = new Comment("May the force be with you");
            Post p2 = new Post(
                DateTime.Parse("2018-08-28 23:14:19"),
                "Good night guys",
                "See you tomorrow",
                5
            );
            p2.AddComment(c3);
            p2.AddComment(c4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }
    }
}

////////////////////////////////////////////////////////

//7.5 - Composição de Objetos - exercício resolvido

using System.Globalization;
using Course.Entities;
using Course.Entities.Enums;

namespace Course
{
    class Program
    {
        public static void Main(string[] args) {

 
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());  
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);
                    
            Console.Write("How many contracts to this worker? ");
            int numberOfContracts = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfContracts; i++) 
            {
                Console.WriteLine($"Enter #{i +1} contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);

            }
            
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3)); //Recortará da posição 3 até o final.

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");



        }
    }
}

//////////////////////////////////////////////////////////

//7.3 - Categorias de Classes

using System.Runtime.Serialization;

//Views: telas do sistema
//Controllers: intermediario entre a tela e o sistema 
//Entities: entidades de negócio (produtos, clientes, etc)
//Services:
//Repositories: responsável por acessar os dados de um repositório qualquer

///////////////////////////////////////////////////////////

//7.2 - Enumerações

using System;
using System.Globalization;
using System.Collections.Generic;
using Course.Entities;
using Course.Entities.Enums;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            Order order = new Order {
                Id = 1080,
                Moment = DateTime.Now,
                Status = Entities.Enums.OrderStatus.PendingPayment,
            };

            Console.WriteLine(order);
            
            string txt = order.Status.ToString();

            Console.WriteLine($"From enum to string: {txt}");

            OrderStatus os = Enum.Parse<OrderStatus>(txt);
            Console.WriteLine($"From string to Enum: {os}");
        }
    }
}

//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

//6.10 - DateTimeKind e padrão ISO 8601
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Progam {
        public static void Main(string[] args) {

            //DateTimeKind
            DateTime d1 = new DateTime(2024, 7, 17, 11, 40, 26);
            DateTime d2 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Utc);
            DateTime d3 = new DateTime(2000, 8, 15, 13, 5, 58, DateTimeKind.Local);

            Console.WriteLine(d1);
            Console.WriteLine(d2);
            Console.WriteLine(d3);

            Console.WriteLine($"d1: {d1}");
            Console.WriteLine($"d1 do Local: {d1.ToLocalTime()}");
            Console.WriteLine($"d1 to UTC {d1.ToUniversalTime()}");

            //Padrão ISO
            DateTime d4 = DateTime.Parse("2000-08-15 13:05:58");
            DateTime d5= DateTime.Parse("2000-08-15T13:05:58Z");

            Console.WriteLine($"d4: {d4}");
            Console.WriteLine($"d5: {d5}");
            Console.WriteLine(d5.ToString("yyyy-MM-ddTHH:mm:ssZ")); //Atenção!!! A conversão não ocorre de forma correta.
            Console.WriteLine(d5.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")); 
        }
    }
}

////////////////////////////////////////////////////////

//6.9 - Propriedades de Operações com Timespan
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program { 
        public static void Main(string[] args) {

            TimeSpan t1 = TimeSpan.MaxValue;
            TimeSpan t2 = TimeSpan.MinValue;
            TimeSpan t3 = TimeSpan.Zero;

            Console.WriteLine(t1);
            Console.WriteLine(t2);
            Console.WriteLine(t3);

            //Propriedades
            TimeSpan t = new TimeSpan( 2, 3, 5, 7, 11);
            Console.WriteLine();
            Console.WriteLine($"Timespan: {t}");
            Console.WriteLine($"Days: {t.Days}");
            Console.WriteLine($"Hours: {t.Hours}");
            Console.WriteLine($"Milliseconds: {t.Milliseconds}");
            Console.WriteLine($"Minutes: {t.Minutes}");
            Console.WriteLine($"Seconds: {t.Seconds}");
            Console.WriteLine($"Ticks: {t.Ticks}");
            Console.WriteLine($"TotalDays: {t.TotalDays}");
            Console.WriteLine($"TotalHours: {t.TotalHours}");
            Console.WriteLine($"TotalMinutes: {t.TotalMinutes}");
            Console.WriteLine($"TotalSeconds: {t.TotalSeconds}");
            Console.WriteLine($"TotalMilliseconds: {t.TotalMilliseconds}");

            //Operações
            TimeSpan t4 = new TimeSpan(1, 30, 10);
            TimeSpan t5 = new TimeSpan(0, 10, 5);
            Console.WriteLine();
            Console.WriteLine($"Soma: {t4.Add(t5)}");
            Console.WriteLine($"Subtração: {t4.Subtract(t5)}");
            Console.WriteLine($"Multiplicação: {t5.Multiply(2.0)}");
            Console.WriteLine($"Divisão: {t5.Divide(2.0)}");


        }
    }
}

/////////////////////////////////////////////////////////////////////////////

//6.8 - Propriedades e Operações com DateTime
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            DateTime d = new DateTime(2001, 8, 15, 13, 45, 58, 275);
            DateTime d2 = new DateTime(2011, 10, 31, 9, 18, 29, 80);
            Console.WriteLine(d);
            Console.WriteLine();

            //Propriedades
            Console.WriteLine($"Date: {d.Date}");
            Console.WriteLine($"Day: {d.Day}");
            Console.WriteLine($"DayOfWeek: {d.DayOfWeek}");
            Console.WriteLine($"DayOfYear: {d.DayOfYear}");
            Console.WriteLine($"Hour: {d.Hour}");
            Console.WriteLine($"Kind: {d.Kind}");
            Console.WriteLine($"Milliseconds: {d.Millisecond}");
            Console.WriteLine($"Minute: {d.Minute}");
            Console.WriteLine($"Month: {d.Month}");
            Console.WriteLine($"Second: {d.Second}");
            Console.WriteLine($"Ticks: {d.Ticks}");
            Console.WriteLine($"TimeOfDay: {d.TimeOfDay}");
            Console.WriteLine($"Year: {d.Year}");

            //Formatação
            Console.WriteLine(d.ToLongDateString());
            Console.WriteLine(d.ToLongTimeString());
            Console.WriteLine(d.ToShortDateString());
            Console.WriteLine(d.ToShortTimeString());
            Console.WriteLine(d.ToString());
            Console.WriteLine(d.ToString("dd-MM-yyyy HH:mm:ss"));
            Console.WriteLine(d.ToString("dd-MM-yyyy HH:mm:ss.fff"));

            //Operações com DateTime
            Console.WriteLine(d.AddHours(2));
            Console.WriteLine(d.AddMinutes(3));
            Console.WriteLine(d.AddDays(7));
            TimeSpan t = d2.Subtract(d);
            Console.WriteLine(t);
            Console.WriteLine(d.AddTicks(t.Ticks));

        }
    }
}

/////////////////////////////////////////////////////////////////////////////

//6.7 - TimeSpan
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            TimeSpan t1 = new TimeSpan(0, 1, 30);
            Console.WriteLine(t1);
            Console.WriteLine(t1.Ticks);

            TimeSpan t2 = new TimeSpan();
            Console.WriteLine(t2);

            TimeSpan t3 = new TimeSpan(900000000L);
            Console.WriteLine(t3);

            TimeSpan t4 = new TimeSpan(1, 2, 11, 21);
            Console.WriteLine(t4);

            TimeSpan t5 = new TimeSpan(1, 2, 11, 21, 321);
            Console.WriteLine(t5);

            TimeSpan t6 = TimeSpan.FromDays(1.5);
            Console.WriteLine(t6);

            TimeSpan t7 = TimeSpan.FromHours(1.5);
            Console.WriteLine(t7);

            TimeSpan t8 = TimeSpan.FromMinutes(1.5);
            Console.WriteLine(t8);

            TimeSpan t9 = TimeSpan.FromSeconds(1.5);
            Console.WriteLine(t9);

            TimeSpan t10 = TimeSpan.FromMilliseconds(1.5);
            Console.WriteLine(t10);

            TimeSpan t11 = TimeSpan.FromTicks(900000000);
            Console.WriteLine(t11);
        }
    }
}

/////////////////////////////////////////////////////////////////////////////

//6.6 - Datetime
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            DateTime d1 = DateTime.Now;
            Console.WriteLine(d1);
            Console.WriteLine(d1.Ticks);

            DateTime d2 = new DateTime(2024, 10, 31);
            Console.WriteLine(d2);

            DateTime d3 = new DateTime(2024, 10, 31, 10, 05, 18);
            Console.WriteLine(d3);

            DateTime d4 = DateTime.Today;
            Console.WriteLine(d4);
            
            DateTime d5 = DateTime.UtcNow;
            Console.WriteLine(d5);

            DateTime d6 = DateTime.Parse("2000-08-15");
            Console.WriteLine(d6);

            DateTime d7 = DateTime.Parse("2000-07-17 13:04:55");
            Console.WriteLine(d7);

            DateTime d8 = DateTime.Parse("2024/07/16");
            Console.WriteLine(d8);

            //Para quando se quer determinar o formato da data
            DateTime d9 = DateTime.ParseExact("2000-08-15", "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Console.WriteLine(d9);

            DateTime d10 = DateTime.ParseExact("16/07/2024 12:26:30", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine(d10);

        }
    }
}

/////////////////////////////////////////////////////////////////////////////

//6.5 - Funções interessantes para string
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {
            
            string original = "  abcde FGHIJ ABC abc DEFG      ";

            Console.WriteLine($"Original: ->{original}<-");
            Console.WriteLine($"Maíuscula: ->{original.ToUpper()}<-");
            Console.WriteLine($"Minúscula: ->{original.ToLower()}<-");
            Console.WriteLine($"Trim: ->{original.Trim()}<-");
            Console.WriteLine($"IndexOf: ->{original.IndexOf("bc")}<-");
            Console.WriteLine($"LastIndexOf: ->{original.LastIndexOf("bc")}<-");
            Console.WriteLine($"SubString (aonde começa): ->{original.Substring(3)}<-");
            Console.WriteLine($"SubString (aonde começa e qtd de caracteres): ->{original.Substring(3, 5)}<-");
            Console.WriteLine($"Replace (caracter): ->{original.Replace('a', 'x')}<-");
            Console.WriteLine($"Replace (string): ->{original.Replace("abc", "xy")}<-");
            Console.WriteLine($"Null or Empty: ->{String.IsNullOrEmpty(original)}<-");
            Console.WriteLine($"Null or WhiteSpace: ->{String.IsNullOrWhiteSpace(original)}<-");



        }
    }
}

/////////////////////////////////////////////////////////////////////////////

//6.4 - Expressão condicional ternária

using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Progra {
        public static void Main(string[] args) {

            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double desconto = (preco < 20.0) ? preco * 0.1 : preco * 0.05;

            Console.WriteLine($"Desconto {desconto}");
        }
    }
}

/////////////////////////////////////////////////////////////////////////////

//6.3 - Sintaxe alternativa Switch-Case

using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program{
        public static void Main(string[] args) {
            Console.Write("Digite o número do dia da semana: ");
            int x = int.Parse(Console.ReadLine());

            string day;

            switch (x) {
                case 1: 
                    day = "Sunday";
                    break;
                case 2:
                    day = "Monday";
                    break;
                case 3:
                    day = "Tuesday";
                    break;
                case 4: 
                    day = "Wednesday";
                    break;
                case 5:
                    day = "Thursday";
                    break;
                case 6:
                    day = "Fryday";
                    break;
                case 7:
                    day = "Saturday";
                    break;
                default:
                    day = "Invalid value";
                    break;
            }

            Console.WriteLine ($"Day: {day}");
        }
    }
}

/////////////////////////////////////////////////////////////////////////////

//6.2 - Inferência de Tipos
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            var x = 10; //A palavra var indica que o tipo será inferido quando
                // a variável for inicializada.
            
            var y = 20.0;
            var z = "Maria";
        }
    }
}

/////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////

//5.18 - Exercício de fixação: Matrizes
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            int [,] mat = BuildMatrix();
            Position p = new Position();

            ShowOptionMenu(mat, p);

        }

        public static int[,] BuildMatrix() {

            string[] userInput;

            Console.Write("Digite a quantidade de linhas e colunas da matriz, separados por espaço: ");
            userInput = Console.ReadLine().Split(' ');

            int lin = int.Parse(userInput[0]);
            int col = int.Parse(userInput[1]);

            int[,] matrix = new int[lin,col];

            for (int i = 0; i < lin; i++) {
                Console.Write($"Digite os elementos da linha {i}, separados por espaço: ");
                userInput = Console.ReadLine().Split(' ');

                for( int j = 0; j < col; j++) {
                    matrix[i,j] = int.Parse(userInput[j]);
                }
            }

            return matrix;
        }

        public static void ShowOptionMenu(int[,] matrix, Position p) {
              int? answer = null;

            while (answer != 0 ) {
                Console.WriteLine();
                Console.WriteLine("Digite o número da opção desejada: ");
                Console.WriteLine("Sair (0)");
                Console.WriteLine("Procurar um número (1)");
                Console.WriteLine("Imprimir a matriz (2)");
                Console.WriteLine("Imprimir um elemendo da matriz (3)");
                Console.Write("Opção selecionada: ");
                answer = int.Parse(Console.ReadLine());

                switch (answer) {
                    case 1:
                        FindNumberInfo(matrix, p);
                        answer = 1;
                        break;
                    case 2:
                        PrintMatrix(matrix);
                        answer = 2;
                        break;
                    case 3:
                        PrintMatrixElement(matrix);
                        answer = 3;
                        break;
                    case 0:
                        Console.WriteLine("Encerrando o programa...");
                        answer = 0;
                        break;
                    default: 
                        break;
                }
            }
        }

        public static void FindNumberInfo(int[,] matrix, Position p) {
         
            Console.WriteLine();
            Console.Write("Qual número você gostaria de procurar? ");
            int number = int.Parse(Console.ReadLine());

            Boolean found = false;

            for (int i = 0; i < matrix.GetLength(0); i++ ) {

                for (int j = 0; j < matrix.GetLength(1); j++) {
                

                    if ( number == matrix[i,j]) {
                        p.XPos = i;
                        p.YPos = j;
                        p.Value = matrix[i, j];

                        found = true; 

                        IdentifyNeighbours(p, matrix, i, j );

                        PrintNumberInfo(p);

                    }
                }
            }

            if (!found) {
                Console.WriteLine("Número não encontrado");
            }

        }
            public static void PrintNumberInfo(Position p) {

                Console.WriteLine();

                Console.WriteLine($"Esses são os dados do número {p.Value}: ");

                Console.WriteLine($"Position: {p.XPos}, {p.YPos}");

                if (p.LeftNeighbour != null ) {
                    Console.WriteLine($"Left: {p.LeftNeighbour}");
                }
                if (p.RightNeighbour != null ) {
                    Console.WriteLine($"Right: {p.RightNeighbour}");
                }
                if (p.UpNeighbour != null ) {
                    Console.WriteLine($"Up: {p.UpNeighbour}");
                }
                if (p.DownNeighbour != null ) {
                    Console.WriteLine($"Down: {p.DownNeighbour}");
                }

            }

            public static void PrintMatrix (int[,] matrix) {

                Console.WriteLine();

                for (int i = 0; i < matrix.GetLength(0); i++){
                    for (int j = 0; j < matrix.GetLength(1); j++) {
                        Console.Write($"{matrix[i,j]} ");
                    }
                    Console.WriteLine();
                }
            }

            public static void PrintMatrixElement(int [,] matrix) {
                Console.Write("Digite as coordenadas do número desejado: ");
                string[] userInput = Console.ReadLine().Split(',');

                int coorX = int.Parse(userInput[0]);
                int coorY = int.Parse(userInput[1]);

                Console.WriteLine($"Número selecionado para impressão: {matrix[coorX, coorY]}");

            }   

            public static void IdentifyNeighbours(Position p, int [,] matrix, int xPos, int yPos) {
                if (!(yPos - 1 < 0)) {
                    p.LeftNeighbour = matrix[xPos, yPos - 1];
                } 
                else {
                    p.LeftNeighbour = null;
                }
                
                if (!(yPos + 1 > matrix.GetLength(1) - 1)) {
                    p.RightNeighbour = matrix[xPos, yPos + 1];
                }
                else {
                    p.RightNeighbour=null;
                }

                if (!(xPos - 1 < 0)){
                p.UpNeighbour = matrix[xPos - 1, yPos];
                }
                else {
                    p.UpNeighbour=null;
                }

                if (!(xPos + 1 > matrix.GetLength(0) - 1)){
                p.DownNeighbour = matrix[xPos + 1, yPos];
                }
                else {
                    p.DownNeighbour=null;
                }
            }
    }
}

//////////////////////////////////////////////////////////////

//5.17 - Exercício resolvido - Matrizes

using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            Console.Write("Digite a ordem da Matriz: ");
            int order = int.Parse(Console.ReadLine());

            int [,] mat = new int [order, order];

            for (int i = 0; i < order; i++) {
                Console.Write($"Informe os elementos da linha {i} da matriz: ");
                string[] userInput = Console.ReadLine().Split(' ');

                for(int j = 0; j < order; j++) {
                    mat[i,j] = int.Parse(userInput[j]);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Main diagonal: ");

            for (int i = 0; i < order; i++){
                Console.Write($"{mat[i,i]} ");
            }

            int negativeNumbers = 0;

            for (int i = 0; i < order; i++) {
                for (int j = 0; j < order; j++) {
                    if (mat[i,j] < 0) {
                        negativeNumbers++;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Negative numbers = {negativeNumbers}");
        }
    }
}

////////////////////////////////////////////////////////////////////////

//5.16 - Matrizes

using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            double [,] mat = new double[2, 3];

            //Quantos elementos a matrix tem no total
            Console.WriteLine(mat.Length);  

            //Quanto é a primeira dimensao da matrix (quantidade de linhas)
            Console.WriteLine(mat.Rank);

            //Tamanho da primeira dimensão da matrix (quantidade de linhas)
            Console.WriteLine(mat.GetLength(0));

            //Tamanho da segunda dimensão da matrix (quantidade de colunas)
            Console.WriteLine(mat.GetLength(1));
        }
    }
}

//////////////////////////////////////////////////////////

//5.15 - Exercício de fixação - Listas

using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course{
    class Program {
        public static void Main(string[] args) {

            Console.Write("How many employees will be registered? ");
            int numberOfEmployees = int.Parse(Console.ReadLine());

            List<Employee> allEmployees = new List<Employee>();

            for (int i = 0; i < numberOfEmployees; i++) {

                Employee emp = new Employee();

                Console.WriteLine();
                Console.WriteLine($"Employee { i + 1}");
                Console.Write("Id: ");
                emp.Id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                emp.Name = Console.ReadLine();
                Console.Write("Salary: ");
                emp.Salary = double.Parse(Console.ReadLine());

                allEmployees.Add(emp);

            }
            Console.WriteLine();
            Console.Write("Enter the employee id that will have salary increase (separeted by space): ");
            string[] userInput = Console.ReadLine().Split(' ');

            List<int> ids = new List<int>();

            foreach (string input in userInput) {

                ids.Add(int.Parse(input));
            }

            Console.Write("Enter the percentage: ");
            double percentage = double.Parse(Console.ReadLine());

            foreach(int id in ids) {
                Employee? employeeToUpdate = allEmployees.Find( e => e.Id == id);

                if (employeeToUpdate != null) {
                    employeeToUpdate.SalaryIncrease(percentage);
                }
                else {
                    Console.WriteLine("No employee to update");
                }
            }


            Console.WriteLine();
            Console.WriteLine("Updated list of employees: ");
            foreach (Employee employee in allEmployees) {
                Console.WriteLine(employee);

            }

        }
    }
}

////////////////////////////////////////////////////////

//5.13 - Listas - Parte 2
using System;
using System.Globalization;
using System.Collections.Generic;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            List<string> list = new List<string>();

            //Adicionando itens é no final da lista.
            list.Add("Sabrina");
            list.Add("Kênia");
            list.Add("Ana Beatriz");
            list.Add("Viviane");
            list.Add("Amanda");

            foreach (string obj in list) {
                Console.WriteLine(obj);
            }

            //Inserindo ítens em uma determinada posição da lista
            list.Insert(2, "Cassia");
            
            Console.WriteLine();
            foreach (string obj in list) {
             Console.WriteLine(obj);
            }

            Console.WriteLine();
            //Contanto quantidade de ítens da lista
            Console.WriteLine(list.Count());

            Console.WriteLine();
            //Encontrar na lista a primeirta ocorrência de um elemento que
            //satisfaça um predicado. No exemplo abaixo, será a 
            //primeira ocorrência de um nome começando pela letra A.
            string s1 = list.Find(x => x[0] == 'A');
            Console.WriteLine($"Primeiro nome iniciado pela letra A: {s1}");

            //Encontrar na lista a última ocorrência de um elemento que
            //satisfaça um predicado.
            string s2 = list.FindLast(x => x[0] == 'A');
            Console.WriteLine($"Primeiro nome terminado pela letra A: {s2}");

            //Encontrar a primeira posição de um elemento que satisfaça um 
            //predicado.
            int pos1 = list.FindIndex(x => x[0] == 'K');
            Console.WriteLine(pos1);

            //Encontrar a primeira posição de um elemento que satisfaça um 
            //predicado.
            int pos2 = list.FindLastIndex(x => x[0] == 'A');
            Console.WriteLine(pos2);

            //Filtrar a lista com base em um predicado
            List<string> list2 = list.FindAll(x => x.Length >= 6 );
            foreach (string name in list2) {
                Console.WriteLine(name);
            }

            //Remover elementos da lista
            Console.WriteLine();
            list.Remove("Viviane");
            foreach (string name in list) {
            Console.WriteLine(name);
            }

            //Remover todas as ocorrências com base em um predicado
            list.RemoveAll(x => x[0] == 'A');
            Console.WriteLine();
            foreach (string name in list) {
            Console.WriteLine(name);
            }
            //Caso o método não encontre o objeto informado, ele simplesmente
            //ignora.

            //Remover um elemento de acordo com a posição dele.
            list.RemoveAt(2);
            Console.WriteLine();
            foreach (string name in list) {
            Console.WriteLine(name);
            }

            //Removendo os elementos de uma faixa
            //(n, nn) posição inicial, quantos elementos serão removidos a partir
            //dali.
            list.RemoveRange(0, 2);
            Console.WriteLine();
            Console.WriteLine("Removendo");
            foreach (string name in list) {
            Console.WriteLine(name);
            }
        }
    }
}

/////////////////////////////////////////////////////////

//5.12 Listas - Parte 1

using System;
using System.Globalization;
using System.Collections.Generic; // necessário para acessar a classe lista.

namespace Course {
    class Program {
        public static void Main(string[] args) {

            List<string> list = new List<string>(); //instaciando uma lista vazia.

            List<string> list2 = new List<string> {"Márcis", "Joana"};
        }
    }
}

///////////////////////////////////////////////////////////

//5.11 - Laço Foreach
using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            string[] vect = new string[] { "Ana", "Barbara", "Silvia"};

            foreach (string s in vect) {
                Console.WriteLine(s);
            }

        }
    }
}

//////////////////////////////////////////////////////////////

//5.10 - Boxing e Unboxing

//////////////////////////////////////////////////////////

//5.09 Modificadores de parâmetros Out e Ref
using System;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            int a = 10;
            Calculator.Triple(ref a); //ref faz com que o parametro da função possa
            //alterar o valor (seja referência) da variável original. 

            Console.WriteLine(a);

            int triple;
            Calculator.Triple2(a, out triple);
            // Funcionamento similar ao ref, mas não exige que a variável de saída
            // tenha sido inicializada.
            Console.WriteLine(triple);
        }
    }
}

/////////////////////////////////////////////////////////

//5.08 - Modificador de parâmetros Params

using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main (string[] args) {
            //O Params do método Sum garante que a quantidade de parâmetros 
            // seja variável.
            int s1 = Calculator.Sum(2, 3, 4);
            int s2 = Calculator.Sum(2, 3, 4, 5, 6, 7);

            Console.WriteLine(s1);
            Console.WriteLine(s2);
        }
    }
}

////////////////////////////////////////////////////

//5.06 - Vetores, parte 2

using System;
using System.Globalization;
using System.Reflection.Metadata;

namespace Course {
    class Program {
        public static void Main (string[] args){
            Console.Write("Digite a quantidade de produtos: ");
            int quantidadeProdutos = int.Parse(Console.ReadLine());

            Product[] listaProdutos = new Product[quantidadeProdutos];

            // Versão 01 do Loop
            // for (int i = 0; i < quantidadeProdutos; i++) {
            //     Product p = new Product();

            //     Console.Write($"Digite o nome produto {i + 1}: ");
            //     p.Nome = Console.ReadLine();
            //     Console.Write($"Digite o preço do produto {i + 1}: ");
            //     p.Preco = double.Parse(Console.ReadLine());

            //     listaProdutos[i] = p;
            // }

            // Versão 02 do Loop
            for (int i = 0; i < quantidadeProdutos; i++) {
                Console.WriteLine();
                Console.WriteLine($"Digite os dados do produto {i + 1}");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Preço: ");
                double preco = double.Parse(Console.ReadLine());
            

                Product p = new Product(nome, preco);

                listaProdutos[i] = p;
            }

            double somaPrecos = 0;

            for (int i = 0; i < listaProdutos.Length; i ++){
                somaPrecos += listaProdutos[i].Preco;
            }

            double media = somaPrecos / listaProdutos.Length;
            
            Console.WriteLine($"Average Price = {media:F2}");


        }
    }
}

////////////////////////////////////////////////////////

//5.05 - Vetores, parte 1
using System;
using System.Globalization;

namespace Course {
    class Program {

        public static void Main(string[] args) {

            Console.Write("Digite o valor de N: ");
            int n = int.Parse(Console.ReadLine());

            double[] alturas = new double[n];

            for (int i = 0; i < n; i++) {
                Console.Write($"Digite a altura da pessoa {i}: ");
                alturas[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            double alturaMedia = 0;

            for (int i = 0; i < alturas.Length; i++) {
                alturaMedia += alturas[i];
            }

            double media = alturaMedia / alturas.Length;
            Console.WriteLine($"Altura média igual = {media:F2}");

            
        }
    }
}

///////////////////////////////////////////////////////

// 5.04 - Nullable
using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main(string[] args) {

            // double x = null;  - Dá erro
            // Nullable<double> x = null; 
            double? x = null;

            double? y = 10.0;

            Console.WriteLine(x.GetValueOrDefault()); // Pega o valor da variável, ou o valor padrão do Tipo da variável.
            Console.WriteLine(y.GetValueOrDefault());

            Console.WriteLine(x.HasValue); // Informa se dentro da varíavel existe/ não existe um valor. 
            Console.WriteLine(y.HasValue);

            // Console.WriteLine(x.Value); // Pega o valor diretamente de "dentro do x". Caso seja feito em cima de um objeto que está valendo nulo, dispara uma excessão. 
            // Console.WriteLine(y.Value);

            if (x.HasValue) { Console.WriteLine(x.Value);}
             else Console.WriteLine("x é nulo");

            //Nullish coalescing operator
            double z = x ?? 5;
            double a = y ?? 5;

            Console.WriteLine(a);
            Console.WriteLine(z);


        }
    }
}

///////////////////////////////////////////////////////////

// 5.03 - Desalocação de Memória - Garbage Collector e Escopo Local.

// 5.02 - Tipos Referência vs Tipos valor

using System;
using System.Globalization;

namespace Course {
    class Program {
        public static void Main (string[] args) {

            Point p;

            p.X = 10;
            p.Y = 20;

            Console.WriteLine(p);

            p = new Point();
            Console.WriteLine(p); 

        }
    }
}

/////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////

//4.08 - Modificadores de Acesso

assembly == projeto.
subclasse é um conceito de herança.
* Dentro de uma solução, podem haver vários projetos.

Própria classe
    public
    protected internal
    internal
    protected
    private protected
    private
Subclasse no Assembly
    public
    protected internal
    internal
    protected
    private protected
Classes do Assembly
    public
    protected internal
    internal
Subclasses fora do Assembly
    public
    protected internal
    protected
Classes fora do Assembly
    public
    private


//4.07 - Ordem sugerida para implementação de membros de Classe
    - Atributos privados
    - Propriedades autoimplementadas
    - Construtores
    - Propriedades customizadas
    - Outros médotos da classe

//4.06 - Auto Properties

    using System.Globalization;

    namespace Course 
    {
        class Produto
        {
            private string _nome;
            public double Preco {get; private set;}  //auto propertie
            public int Quantidade {get; private set;} //auto propertie

            //Construtor padrão
            public Produto()
            {
                
            }

            //Construtor com 3 argumentos
            public Produto(string nome, double preco, int quantidade)
            {
                _nome = nome;
                Preco = preco;
                Quantidade = quantidade;
            }
            //Construtor com 2 argumentos
            public Produto(string nome, double preco)
            {
                _nome = nome;
                Preco = preco;
                Quantidade = 5;
            }

            public double ValorTotalEmEstoque()
            {
                return Quantidade * Preco;
            }

            //Implementação de propertie, definindo as operações de get e set
            public string Nome {
                get { return _nome;}
                set {
                    if (value != null && value.Length > 1){
                    _nome = value;
                }
                }
            }




            public void AdicionarProdutos (int quantity)
            {
                Quantidade += quantity;
            }

            public void RemoverProdutos(int quantity)
            {
                Quantidade -= quantity;
            }
            
            public override string ToString()
            {
                return _nome 
                    + ", $" 
                    + Preco.ToString("F2",CultureInfo.InvariantCulture) 
                    + ", "
                    + Quantidade
                    + " unidades, Total: $ "
                    + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
            }
        }
    }

    using System;
    using System.Globalization;

    namespace Course{
        class Program {
            public static void Main(string[] args){
                Produto p = new Produto("TV", 500.00, 10);

                p.Nome = "TV 4k";

                Console.WriteLine(p.Nome);
                Console.WriteLine(p.Preco.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }

///////////////////////////////////////////////////////////////

//4.05 - Properties
    using System.Globalization;

    namespace Course 
    {
        class Produto
        {
            private string _nome;
            private double _preco;
            private int _quantidade;

            //Construtor padrão
            public Produto()
            {
                
            }

            //Construtor com 3 argumentos
            public Produto(string nome, double preco, int quantidade)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = quantidade;
            }
            //Construtor com 2 argumentos
            public Produto(string nome, double preco)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = 5;
            }

            public double ValorTotalEmEstoque()
            {
                return _quantidade * _preco;
            }

            //Implementação de propertie, definindo as operações de get e set
            public string Nome {
                get { return _nome;}
                set {
                    if (value != null && value.Length > 1){
                    _nome = value;
                }
                }
            }

            public double Preco {
                get { return _preco;}
            }

            public int Quantidade {
                get { return _quantidade;}
            }

            public void AdicionarProdutos (int quantity)
                                    {
                _quantidade += quantity;
            }

            public void RemoverProdutos(int quantity)
            {
                _quantidade -= quantity;
            }
            
            public override string ToString()
            {
                return _nome 
                    + ", $" 
                    + _preco.ToString("F2",CultureInfo.InvariantCulture) 
                    + ", "
                    + _quantidade
                    + " unidades, Total: $ "
                    + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
            }
        }
    }   

    using System;
    using System.Globalization;

    namespace Course {
        class Program {
            public static void Main (string[] args) {

                Produto p = new Produto("TV", 500.00, 10);

                p.Nome = "T";

                Console.WriteLine(p.Nome);
                Console.WriteLine(p.Preco);

            }
        }
    }

**************************************************************************



//4.04 - Encapsulamento
    using System;
    using System.Globalization;

    namespace Course {
        class Program {
            static void Main (string[] args) {
                Produto p = new Produto("TV", 500.00, 10);

                p.SetNome("T");

                Console.WriteLine(p.GetNome());
            }
        }
    }

    using System.Globalization;

    namespace Course 
    {
        class Produto
        {
            private string _nome;
            private double _preco;
            private int _quantidade;

            //Construtor padrão
            public Produto()
            {
                
            }

            //Construtor com 3 argumentos
            public Produto(string nome, double preco, int quantidade)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = quantidade;
            }
            //Construtor com 2 argumentos
            public Produto(string nome, double preco)
            {
                _nome = nome;
                _preco = preco;
                _quantidade = 5;
            }

            public double ValorTotalEmEstoque()
            {
                return _quantidade * _preco;
            }

            public string GetNome() {
                return _nome;
            }

            public void SetNome(string nome) {
                if (nome != null && nome.Length > 1){
                    _nome = nome;
                }
            }

            public double GetPreco() {
                return _preco;  
            }

            public int GetQuantidade() {
                return _quantidade;
            }
            
            public void AdicionarProdutos (int quantity)
            {
                _quantidade += quantity;
            }

            public void RemoverProdutos(int quantity)
            {
                _quantidade -= quantity;
            }
            
            public override string ToString()
            {
                return _nome 
                    + ", $" 
                    + _preco.ToString("F2",CultureInfo.InvariantCulture) 
                    + ", "
                    + _quantidade
                    + " unidades, Total: $ "
                    + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
            }
        }
    }

**************************************************************************

//4.03 - Sobrecarga
using System;
using System.Globalization;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto01 = new Produto(nome, preco, quantidade);

            Produto p3 = new Produto {
                Nome = "TV", 
                Preco = 500.00, 
                Quantidade = 20
            };

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");
        }
    }
}

*******************************************************

//4.01 - Construtores
using System;
using System.Globalization;

namespace Course
{
    class Program
    {
        public static void Main (string[] args)
        {

            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Produto produto01 = new Produto(nome, preco, quantidade);

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");
        }
    }
}

-******************************************************************************

//3.10 Membros estáticos - PT 02
    using System;
using System.Globalization;

namespace Course
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.Write("Entre o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double circ = Calculadora.Circunferencia(raio);

            Console.WriteLine($"Circunferencia {circ:F2}");
            double volume = Calculadora.Volume(raio);
            Console.WriteLine($"Volume {volume:F2}");
            Console.WriteLine($"Pi: {Calculadora.Pi}");


        }
    }
}


//3.09 Membros estáticos - PT 01
    using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Course
{
    class Program
    {

        static double Pi = 3.14;
        static void Main (string[] args)
        {
            Console.Write("Entre o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double circ = Circunferencia(raio);

            Console.WriteLine($"Circunferencia {circ:F2}");
            double volume = Volume(raio);
            Console.WriteLine($"Volume {volume:F2}");
            Console.WriteLine($"Pi: {Pi}");


        }

        static double Circunferencia (double r)
        {
            return 2 * Pi * r;
        }

        static double Volume (double r)
        {
            return 4.0 / 3.0 * Pi * Math.Pow(r , 3);
        }
    }
}

-------------------------------------------------

//3.08
    namespace Course {

using System;
using System.Globalization;

    class Program {
        static void Main(string[] args) {

            Produto produto01 = new Produto();;

            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            produto01.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto01.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            produto01.Quantidade = int.Parse(Console.ReadLine());

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");



        }

    }
}  

---------------------------------------------------------

//3.07
    namespace Course {
    class Program {
        static void Main(string[] args) {

            Produto produto01 = new Produto();;

            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            produto01.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto01.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            produto01.Quantidade = int.Parse(Console.ReadLine());

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");



        }

    }
} 

----------------------------------------------------------

//3.06 Segundo Problema Exemplo
    using System;
using System.Globalization;


namespace Course {
    class Program {
        static void Main(string[] args) {

            Produto produto01 = new Produto();;

            Console.WriteLine("Entre od dados do produto:");
            Console.Write("Nome: ");
            produto01.Nome = Console.ReadLine();
            Console.Write("Preço: ");
            produto01.Preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Quantidade no estoque: ");
            produto01.Quantidade = int.Parse(Console.ReadLine());

            double valorTotal = produto01.ValorTotalEmEstoque();

            Console.WriteLine();
            Console.WriteLine($"Dados do produto: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser adicionado ao estoque: ");
            int modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.AdicionarProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

            Console.WriteLine();
            Console.Write("Digite o número de produtos a ser removido do estoque: ");
            modificadorDeEstoque = int.Parse(Console.ReadLine());
            produto01.RemoverProdutos(modificadorDeEstoque);

            Console.WriteLine();
            Console.WriteLine($"Dados atualizados: {produto01}");

        }

    }
} 

==========================================================================

// 3.05 - Criando um método para obter Reaproveitamento e Delegação.
 
using System;
using System.Globalization;


namespace Course {
    class Program {
        static void Main(string[] args) {

            Triangulo x, y;

            x = new Triangulo();
            y = new Triangulo();

            Console.WriteLine("Entre com as medidas do triângulo X:");
            x.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            x.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Entre com as medidas do triângulo Y:");
            y.A = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.B = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            y.C = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double areaX = x.Area();

            double areaY = y.Area();

            Console.WriteLine($"Área de X = {areaX.ToString("F4", CultureInfo.InvariantCulture)})");
            Console.WriteLine($"Área de Y = {areaY.ToString("F4", CultureInfo.InvariantCulture)}");


        }

    }
}  
*/