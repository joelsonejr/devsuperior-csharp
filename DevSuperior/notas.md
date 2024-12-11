# 11. Intefaces 

## Exercício da locadora de carros

### Camada de domínio (Entidades do negócio)

CarRental está associada as classes Vehicle, que trás os dados do carro, e Invoice, que tem os detalhes referentes a nota de pagamento.

- **CarRental**

  - start: Date

  - end: Date

    - **Vehicle**
      - Modelo: String
    - **Invoice**
      - basicPayment: Double
      - tax: Double
      - / totalPayment: Double

    

### Camada de  Serviços

Servicços que realizam as operações, que estão associadas ao negócio.

O serviço de aluguel é responsável pela lógica da nota de pagamento. Porém a lógica do imposto está sendo delegada para um serviço de imposto. Caracterizando uma composição de serviços. 

- **RentalService**
  - pricePerHour: Double
  - pricePerDay: Double
  - processInvoice(carRental: CarRental) : void
  - **BrazilTaxService**
    - tax(amount: Double): Double

### Implementando a solução  - SEM interface

Primeiramente, foram criadas as entidades:

- Vehicle, com a propriedade *Model*.

  ```c#
  namespace Course.Entities
  {
      class Vehicle
      {
          public string Model { get; set; }
          
          public Vehicle(string model)
          {
              Model = model;
          }
      }
  }
  ```

  

- Invoice, com as propriedades *BasicPayment*, *Tax* e a propriedade calculada *TotalPayment* .

  ```C#
  using System.Globalization;
  namespace Course.Entities
  {
      class Invoice
      {
          public double BasicPayment { get; set; }
          public double Tax { get; set; }
          
          public Invoice(double basicPayment, double tax)
          {
              BasicPayment = basicPayment;
              Tax = tax;
          }
  
          public double TotalPayment {
              get { return BasicPayment + Tax; }
          }
          
          public override string ToString()
          {
              return "Basic Payment: "
              + BasicPayment.ToString("F2", CultureInfo.InvariantCulture) 
              + "\nTax: "
              + Tax.ToString("F2", CultureInfo.InvariantCulture)
              + "\nTotal payment: "
              + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
          }
      }
  }
  ```

  

- CarRental, com as propriedades *Start*, *End*, *Vehicle* e *Invoice* . A propriedade invoice não foi incluida no construtor, pois ela receberá seu valor a partir do serviço *RentalService*. 

  ```c#
  namespace Course.Entities
  {
      public class CarRental
      {
  
          public DateTime Start { get; set; }
          public DateTime Finish { get; set; }
          public Vehicle Vehicle { get; set; }
          public Invoice Invoice { get; set; }
  
          public CarRental ( DateTime start, DateTime finish, Vehicle vehicle )
          {
              Start = start;
              Finish = finish;
              Vehicle = vehicle;
          }
  
      }
  }
  ```

  

Depois, foram criados os serviços:

- **BrazilTaxService** : contém a lógica de cálculo de imposto, de acordo com o valor da nota. 

  ```c#
  //BrazilTaxService
  class BrazilTaxService
  {   
      public double Tax(double amount)
      {
          if (amount <= 100)
          {
              return amount * 0.2;
          }
          else
          {
              return amount * 0.15;
          }
  
      }
  }
  ```

  

- **RentalService** : responsável por processar o aluguel, e gerar a nota de pagamento (Invoice). 

  ```c#
  using Course.Entities;
  
  namespace Course.Services
  {
      class RentalService
      {
          public double PricePerHour { get; private set; }
          public double PricePerDay { get; private set; }
       
          public RentalService(double pricePerHour, double pricePerDay)
          {
              PricePerHour = pricePerHour;
              PricePerDay = pricePerDay;
          }
  
          public void ProcessInvoice(CarRental carRental)
          {
             
          }
  
      }
  }
  ```

  

- O método responsável por gerar o Invoice, *ProcessInvoice* precisa do valor das taxas, para gerar o mesmo. Logo, será necessário estabelecer uma dependência entre o serviço em questão, e o serviço responsável pelo cálculo das taxas (BrazilTaxService).

  - Para tal será criada uma dependência do RentalService para o BrazilTaxService.

    Dentro da classe (serviço) RentalService, cria-se um atributo privado, o qual receberá uma instância do objeto BrazilTaxService:

    ```c#
    private BrazilTaxService _brazilTaxService = new BrazilTaxService();
    ```

  - Em seguida, é feita a implementação do método *ProcessInvoice* , que possui as regras de negócio necessárias para calcular a o valor total da locação, considerando os impostos, e com essas informações gerar o Invoice.

    ```c#
    public void ProcessInvoice(CarRental carRental)
    {
    	TimeSpan duration = carRenta.Finish.Subtract(carRental.Start);	
        
        double basicPayment = 0.0;
        if (duration.TotalHours <= 12)
        {
            basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
        }
        else
        {
            basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
        }
        
        double tax = _brazilTaxService.Tax(basicPayment);
        
        carRental.Invoice = new Invoice(basicPayment, tax);
    }
    ```

    A estrutura completa do serviço ficou da seguinte forma:

    ```c#
    //Rental Service
    using Course.Entities;
    
    namespace Course.Services
    {
        class RentalService
        {
            public double PricePerHour { get; private set; }
            public double PricePerDay { get; private set; }
         
            private BrazilTaxService _brazilTaxService = new BrazilTaxService(); 
    
            public RentalService(double pricePerHour, double pricePerDay)
            {
                PricePerHour = pricePerHour;
                PricePerDay = pricePerDay;
            }
    
            public void ProcessInvoice(CarRental carRental)
            {
                TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
    
                double basicPayment = 0.0;
    
                if (duration.TotalHours <= 12.0)
                {
                    basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
                }
                else
                {
                    basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
                }
    
                double tax = _brazilTaxService.Tax(basicPayment);
            
                carRental.Invoice = new Invoice(basicPayment, tax);
            }
    
        }
    }
		```
    
		- No programa principal, após serem recebidos todos os dados do usário, e ter sido instanciado um objeto do tipo *carRental*, será instanciado o serviço *RentalService* para que o aluguel possa ser processado.
    
      ```c#
      //Importanto o novo serviço
      using Course.Services;
      
      //(...) corpo do programa, no qual é feita a colheta de dados fornecidos pelo usuário
      
      //Instanciando um novo Aluguel
      CarRental carRental = new CarRental(start, finish, new Vehicle(model));
      
      //Instanciando um novo serviço de aluguel
      RentalService rentalService = new RentalService(hour, day);
      
      //Gerando o objeto Invoice
      rentalService.ProcessInvoice(carRental);
      
      //Por fim, é feita a impressão do Invoice
      Console.WriteLine("INVOICE: ");
      Console.WriteLine(carRental.Invoice);
		  ```
    
		  
		
			### Implementando solução - COM INTERFACE
			
			​	Como foi feita uma dependência direta do serviço de aluguel para o serviço de imposto, eles ficam fortemente acoplados. Ou seja, caso seja necessário trocar o serviço de imposto, também será necessário modificar a implementação do serviço dentro da classe RentalService. 
			
			​	O ideal é que se possa alterar as dependências da classe, sem ter de modificar a classe em sí.
			
			​	Para resolver esse problema, o serviço RentalService passará a ter dependência para uma interface genérica TaxService, que tem uma operação chamada Tax. A interface define o contrato que o serviço de imposto deve cumprir. Nesse caso o contrato estabelece que o serviço de imposto deve implementar uma operação Tax, que recebe uma quantia, e retornando o valor do imposto.
			
			![image-20241104124507544](/home/joe/.var/app/io.typora.Typora/config/Typora/typora-user-images/image-20241104124507544.png)
			
			- Será criado o arquivo de interface *ITaxService* dentro da pasta Services.
			
			  ```c#
			  //ITaxService.cs
			  
			  namespace Course.Services 
			  {
			  	interface ITaxService
			      {
			  		double Tax(double amount);
			      }
			  }
			  ```
			
			- No *RentalService* a dependência pelo serviço *BrazilTaxService* será substituída pela dependência da interface *ITaxService*.
			
			- A instanciação não será mais feita no momento em que se declara a dependência. Ao invés disso, o construtor será modificado, para que receba mais um atributo, que é referente ao serviço de impostos. Isso é chamado de **Inversão de controle, por meio de inversão de dependência.**. A classe RentalService não é mais responsável por instanciar sua própria dependência. 
			
			  ```c#
			  //Rental Service
			  using Course.Entities;
			  
			  namespace Course.Services
			  {
			      class RentalService
			      {
			          public double PricePerHour { get; private set; }
			          public double PricePerDay { get; private set; }
			       
			          private ITaxService _taxService; 
			  
			          public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
			          {
			              PricePerHour = pricePerHour;
			              PricePerDay = pricePerDay;
			              _taxService = taxService;
			          }
			  
			          public void ProcessInvoice(CarRental carRental)
			          { 
			              ...
			          }
			  ```
			
			  - Outro ajuste que precisa ser feito, e corrigir o nome da variável dentro do método ProcessInvoice, alterando de *_brasilTaxService* para *taxService*. 
			
			  ```c#
			  //Rental Service
			  using Course.Entities;
			  
			  namespace Course.Services
			  {
			      class RentalService
			      {
			          public double PricePerHour { get; private set; }
			          public double PricePerDay { get; private set; }
			       
			          private ITaxService _taxService;
			  
			         public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
			          {
			              PricePerHour = pricePerHour;
			              PricePerDay = pricePerDay;
			          }
			  
			          public void ProcessInvoice(CarRental carRental)
			          {
			              TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
			  
			              double basicPayment = 0.0;
			  
			              if (duration.TotalHours <= 12.0)
			              {
			                  basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
			              }
			              else
			              {
			                  basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
			              }
			  
			              double tax = _taxService.Tax(basicPayment);
			          
			              carRental.Invoice = new Invoice(basicPayment, tax);
			          }
			  
			      }
			  }
			  ```
			
			  - Agora, é preciso alterar o *BrazilTaxService*, a fim de informar que ele é um subtipo de *ITaxService*. Essa indicação é feita com o mesmo símbolo utilizado para herança, os dois pontos. 
			  - Como a assinatura do método já está compatível com a assinatura da interface, não foi preciso modificá-la.
			
			  ```c#
			  //BrazilTaxService
			  class BrazilTaxService : ITaxService
			  {   
			      public double Tax(double amount)
			      {
			          if (amount <= 100)
			          {
			              return amount * 0.2;
			          }
			          else
			          {
			              return amount * 0.15;
			          }
			  
			      }
			  }
			  ```
			
			  - No programa principal, faz-se necessário ajustar  a instanciação do *RentalService*. Como seu construtor foi atualizado com um novo objeto do tipo *ItaxService*, o mesmo terá de ser informado na hora de instanciar o *RentalService* .
			
			  ```c#
			  //(...)
			  using Course.Services;
			  
			  //(...) corpo do programa, no qual é feita a colheta de dados fornecidos pelo usuário
			  
			  //Instanciando um novo Aluguel
			  CarRental carRental = new CarRental(start, finish, new Vehicle(model));
			  
			  //Instanciando um novo serviço de aluguel
			  RentalService rentalService = new RentalService(hour, day, new BrazilTaxService);
			  
			  rentalService.ProcessInvoice(carRental);
			  
			  Console.WriteLine("INVOICE: ");
			  Console.WriteLine(carRental.Invoice);
			  ```
			
			  ______________
			  
			  ## Injeção de dependência
			  
			  É quando no momento da instanciação de um objeto é informado qual o outro objeto do qual ele depende.
			  
			  ```c#
			  class Program
			  {
			      static void Main(string[] args)
			      {
			          //(...)
			          RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());
			          //BrazilTaxService é a dependência do objeto rentalService
			      }
			  }
			  ```
			  
			  ```c#
			  class RentalService 
			  {
			      static void Main(string[] args)
			      {
			  		//(...)
			          private ITaxService _taxService; //dependência
			          
			          public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
			          {
			              PricePerHour = pricePerHour;
			              PricePerDay = pricePerDay;
			              _taxService = taxService;
			          }
			      }
			  }
			  ```
			  
			  - Inversão de Controle: a classe não precisa ser responsável de instanciar suas dependências.
			  - Injeção de dependência: uma das formas de realizar inversão de controle, no qual um componente externo instancia a dependência, que é então injetada no pai. Ainjeção de dependência por ser feita por meio de:
			    - Construtor
			    - Objeto de instanciação (builder/ factory)
			    - Container/ framework

----

# 11.7 - Herdar vs Cumprir contrato

## Revisão de Polimorfismo (capítulo 8.6)

- Recurso que permite que variáveis de  um mesmo tipo, mais genérico, possam apontar para objetos de tipos específicos diferentes, tendo assim comportamentos específicos.

  ```c#
  //Classe Account
  namespace Course
  {
      class Account
      {
          public int AccountNumber { get; set;}
          public string HolderName { get; set; }
          public double Balance { get; private set; }
          
          public Account(int number, string name, double balance)
          {
              AccountNumber = number;
              HolderName = name;
              Balance = balance;
          }
          
          //virtual permite que seja realizado um override nesse método.
          public virtual void Withdraw(double amount)
          {
              Balance -= amount + 5.0;
          }
      }
  }
  ```

  ```c#
  //Classe SavingsAccount
  namespace Course
  {
      class SavingsAccount : Account
      {
          public double Interest { get; set;}
          
          public SavingsAccount(int number, string name, double balance, double interest)
              : base(number, name, balance)
          {
              Interest = interest;
          }
          
  
          public override void Withdraw(double amount)
          {
              base.Withdraw(amout);
              Balance -= 2.0;
          }
      }
  }
  ```

  

  ```c#
  Account acc1 = new Account(1001, "Joe", 500.00);
  Account acc2 = new SavingsAccount(1002, "Anna", 500.0, 0.01);
  
  acc1.Withdraw(10.0);
  acc2.Withdraw(10.0);
  ```

  - Quando for chamado o saque, para acc1 e acc2, os comportamentos serão diferentes. 
  - Vale lembrar que, no Polimorfismo, a associação é feita em tempo de execução.

## Semelhanças e Diferenças entre Herança e Cumprir contrato

![image-20241108124914695](/home/joe/.var/app/io.typora.Typora/config/Typora/typora-user-images/image-20241108124914695.png)

### Semelhanças

- Relação é um : *Rectangle* é uma *Shape*, assim como *Circle* também é. Analogamente, *BrazilTaxService* e *UsaTaxService* são *TaxService*.
- Generalização/ especialização: *Shape* é um tipo genérico, e *Rectangle* e *Circle* são tipos específicos. Vale a mesma idéia para a Interface e os serviços.
- Polimorfismo: uma variável do tipo *Shape* pode, em tempo de execução, ser associada com um objeto concreto *Rectangle* ou *Circle*. E a operação *Area()* irá se comportar conforme a implementação que foi feita no objeto concreto. A mesma lójgica se aplica para a interface *ITaxService*, os serviços associados, e a operação *Tax* terá um compormento polimórfico, de acordo com qual objeto concreto será feita a associação (*BrazilTaxService*, ou *UsaTaxService*).

### Diferenças:

- Herança implica no reuso de informações e comportamentos. 
  - A classe *Shape* tem o atributo *Color*, que será herdado por *Rectangle* e *Circle*. Ou seja, reaproveitamento do atributo e do seu *get/ set*.
- Interface tem como objetivo a implementação do contrato a ser cumprido. 
  - A interface *ITaxService* tem um contrato definido. Ela indica que a classe concreta que implementar o *TaxService* tem que possuir o método *double Tax( double amount)*.
  - Quando, por exemplo, é feita a classe concreta *BrazilTaxService* , não está sendo feito nenhum reaproveitamento. Apenas a implementação do contrato (método) que é estabelecido pela interface *TaxService*.

- Expandindo o exemplo acima, também é possível implementar uma interface *Shape*, tendo também uma estrutura reutilizável. 

  ![image-20241108130803119](/home/joe/.var/app/io.typora.Typora/config/Typora/typora-user-images/image-20241108130803119.png)

  - Interface *Shape*, que define a operação área, mais uma classe abstrata que define o atributo *Color*. Por a classe ser abstrata, ela não irá implementar a operação área. Em seguida, as classes concretas, que herdam da AbstractShape, é quem serão responsáveis por implementar o método, que foi definido na interface.
  - Uma vantagem dessa abordagem é que pode-se ter classes concretas que não possuem o atributo cor, mas que são figuras. 

---

# 11.8 - Problema do diamante

![image-20241113172226767](/home/joe/.var/app/io.typora.Typora/config/Typora/typora-user-images/image-20241113172226767.png)

Esse problema se refere a uma ambiguidade gerada pela existência do mesmo método em mais de uma superclase. 

Herança múltipla não é permitida. Ex.: ProcessDoc está implementado nas classes Scanner e Printer. De qual dos dois a classe ComboDevice herdará esse método?

Para contornar esse problema, são utilizadas interfaces para Scanner e Printer. Dessa forma ComboDevice herdará de *Device* e implementará os métodos das interfaces *IScanner* e *IPrinter* .

![image-20241113172844026](/home/joe/.var/app/io.typora.Typora/config/Typora/typora-user-images/image-20241113172844026.png)

```c#
//Classe Device

namespace Course.Devices
{
    abstract class Device
    {
        public int SerialNumber { get; set; }
        
        public abstract void ProcessDoc(string document);
    }
}
```

```c#
//Interface IScanner

namespace Course.Devices
{
    interface IScanner
    {
        string Scan();
    }
}

```

```c#
//Interface IPrinter

namespace Course.Devices
{
    interface IPrinter
    {
        void Print(string document);
    }
}
```

```c#
//Class ComboDevice
using System; 

namespace Course.Devices
{
    class ComboDevices : Device, IScan, IPrinter
    {
        public override void ProcessDoc(string document)
        {
            Console.WriteLine("ComboDevice processing: " + document);
        }
        
        public string Scan()
        {
            return "ComboDevice scan result";
        }
        
        public void Print(string document)
        {
            Console.WriteLine("ComboDevice print" + document);
        }
    }
}
```

# 11.9 - Interface IComparable

Esse é o padrão utilizado pela linguagem, para se comparar dois objetos. Caso deseje-se que um objeto de um determinado tipo é comparável com outro, esse tipo terá de implementar a interface IComparable.

```c#
public interface IComparable {
    int CompareTo(object other);
}
```

Ex.: suponha que deseja-se ordenar uma lista, que é composta por objetos funcionários. Cada objeto possui duas propriedades, *Nome* e *Salário* . Para que a lista seja ordenada, é necessário que cada um de seus valores seja comparado entre si. 

```c#
//Programa principal
namespace Course
{
	//(...)
    // Criação da lista
    List<Employee> list = new List<Employee>();
    
    //Adicionando ítens a lista
    list.Add(new Employee("Xena", 5.700));
    //(...)
    
    //Após ter inserido todos os funcionários, ordenando a lista
    list.Sort();
    
    //Caso a interface não tenha sido implementada no objeto, a execução do .Sort() disparará uma excessão.
}

```

Implementando a interface

```c#
//Class Employee

namespace Course.Entities
{
    class Employee : IComparable
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        
        public Employee( string name, double salary)
        {
            Name = name;
            Salaray = salary;
        }
        
        public int CompareTo(objetct obj) {
            
        }
        
        //O retorno do CompareTo, diz se o objeto passado como parâmetro é menor, igual ou maior do que o objeto atual.
        // menor -> retorna um valor menor do que zero
        // igual -> retorna zero
        // maior -> retorna um valor maior do que zero
    }
}
```

Abaixo consta um exemplo de implementação da interface, considerando que a comparação será realizada entre os atributos *Name* de cada objeto.

```c#
public int CompareTo(objetc obj)
{
    //Essa verificação foi utilizada apenas para garantir que os elementos comparados possuem o mesmo tipo, uma vez que obj pode ser de qualquer tipo.
    // O tipo do erro a ser disparado depende da preferência/ bom senso de quem estiver escrevendo o código.
    if(!(obj is Employee)) {
        throw new ArgumentException("Comparing error: argument is not of type Employee");
    }
    
    Employee other = obj as Employee; //Downcasting o obj como o tipo Employee.
    return Name.CompareTo(other.Name); //Comparando o objeto atual com o que foi passado como argumento, e retornando se ele é menor, igual ou maior ao objeto que foi fornecido como parâmetro.
}
```



# 12. Generics, Set, Dictionary

## 12.1 e 12.2- Generics

- Permitem que **classes**, **interfaces** e **métodos** possam ser parametrizados por tipo. Seus benefícios são:
  - Reuso
  - Type safety
  - Performance

Exemplo de Generic

````c#
List<string> list = new List<string>();
List.Add("Victory");
string name = list[0] //Victory
````

- Type safety:  a classe *List* foi parametrizada com o tipo string. Garantindo assim com que todos os seus elementos, e que as operações realizadas neles/ com eles sejam desse tipo. 
- Reuso: a classe *List* , e todos os seus métodos, pode ser reutilizada com valores de outros tipos, sem que sua lógica precise ser reescrita. Basta apenas alterar o seu tipo.
- Performance: Podem ser necessárias conversões de tipo ao longo da execução do programa, caso não seja utilizado um tipo genérico.

Exemplo 2 : criar um programa que leia um conjunto de N números inteiros (N de 1 a 10), e os imprima na tela. Crie um serviço de impressão para resolver esse problema. 

```
//Modelagem do PrintService

PrintService
+ addValue(value : int): void
+ first(): int
+ print(): void
```



- O problema será resolvido de duas formas: utilizando um vetor, e utilizando um Generic.

````c#
//PrintService.cs
using System;
namespace Course
{
    class PrintService
    {
        private int[] _values = new int[10]; //variável interna
        private int _count = 0; //variável interna
        
        public void AddValue(int value) 
        {
            if (_count ==10)
            {
                throw new InvalidOperationException("PrintService is full"); // verificando se ainda tem expaço no vetor.
            }
            _values[_count] = value;
            _count++;
        }
        
        public int First() 
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("PrintService is empty"); // verificando se o vetor está vazio.
            }
            return _values[0];
        }
        
        //O método print deve retornar os valores do vetor no seguinte formato: [val-01, val-02, val-03, ..., val-n]
        public void Print()
        {
            Console.Write("["]);
            for (int i = 0; i < _count -1; i++ )
            {
                Console.Write(_values[i] + ", ");
            }
            if (_count > 0)
            {
                Console.Write(_values[_count-1]);
            }
            Console.WriteLine("]");
        }
        
        
    }
}

````

```c#
//Programa principal		
using System;
namespace Course
{
    class Program
    {
        public static void Main(string[], args)
        {
            PrintService printService = new PrintService();
            
            Console.Write("How many values");
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                printService.Add(x);
            }
            
            printService.Print();
            Console.WriteLine("First: " + printService.First());
        }
    }
}
```

- O problema dessa abordagem que o *PrinService* não pode ser utilizado para valores que não sejam do tipo *int*. Da forma que a solução foi implementada, seria necessário criar uma outra classe, que trabalhasse com valores do tipo *string* .
- Uma saída seria mudar os tipos dentro do *PrintService*  para *object* . Apesar de o serviço passar a aceitar qualquer tipo, isso trará um problema de *TypeSafety*. Como *object* pode ser qualquer tipo, o compilador não será capaz de identificar, por exemplo, caso valores do tipo *string* sejam atribuidos a variáveis do tipo *int* .

- A fim de contornar esses problemas, utiliza-se o *Generic*. A classe será parametrizada por um tipo genérico, que será especificado no momento da instanciação do objeto. 

  ```c#
  //Correções no PrintService
  using System;
  namespace Course
  {
      class PrintService<T> //Parametrizando a classe com o tipo "T". Pode ser utilizada qualquer outra letra, para designar o tipo genérico.
      {
          private T[] _values = new T[10]; //A variável também receberá o tipo T.
         //...
          
          public void AddValue(T value) 
          {
             //...
          }
          
          public T First() 
          {
              //...
          }
          
          public void Print()
          {
             //...
          }
                  
      }
  }
  ```

- No programa principal, basta especificar o tipo, no momento da instanciação do objeto.

  ```c#
  //Programa principal		
  using System;
  namespace Course
  {
      class Program
      {
          public static void Main(string[], args)
          {
              PrintService<int> printService = new PrintService<int>();
              
              Console.Write("How many values");
              int n = int.Parse(Console.ReadLine());
              
              for (int i = 0; i < n; i++)
              {
                  int x = int.Parse(Console.ReadLine());
                  printService.Add(x);
              }
              
              printService.Print();
              Console.WriteLine("First: " + printService.First());
          }
      }
  }
  ```

- Aplica-se a mesma lógica, caso se deseje trabalhar com strings

  ```c#
  //Programa principal		
  using System;
  namespace Course
  {
      class Program
      {
          public static void Main(string[], args)
          {
              PrintService<string> printService = new PrintService<string>();
              
              Console.Write("How many values");
              int n = int.Parse(Console.ReadLine());
              
              for (int i = 0; i < n; i++)
              {
                  string x = Console.ReadLine();
                  printService.Add(x);
              }
              
              printService.Print();
              Console.WriteLine("First: " + printService.First());
          }
      }
  }
  ```

  

  

  
