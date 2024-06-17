using System.Globalization;

namespace Course {
    public class ContaBancaria {
        public int Numero {get; private set;}
        public string Titular {get; set;}
        public double Saldo {get; private set;}

    public ContaBancaria( int numero, string titular) {
        Numero = numero;
        Titular = titular;
    }    

    public ContaBancaria(int numero, string titular, double saldo) : this(numero, titular){
        Saldo = saldo;
    }


    override public string ToString() {
        return "Conta"
         + Numero 
         + ", Titular"
         + Titular
         + ", $ "
         + Saldo.ToString("F2", CultureInfo.InvariantCulture);
    }

    
    }
}