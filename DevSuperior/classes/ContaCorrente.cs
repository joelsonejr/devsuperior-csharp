using System.Globalization;

namespace Course{
    public class ContaCorrente {
        public double Saldo {get; private set;}
        public int NumeroDaConta {get; private set;}
        public string NomeTitular {get; set;}  //TODO: Verificar método set

        private double TaxaDeSaque = 5.00; 

        public ContaCorrente() {
        
        }

        public ContaCorrente(int conta, string nome, double depositoInicial) {
            NumeroDaConta = conta;
            NomeTitular = nome;
            Depositar(depositoInicial);
        }

        public ContaCorrente(int conta, string nome) {
            NumeroDaConta = conta;
            NomeTitular = nome;
        }


        public void AlterarTitular(string nome) {
            NomeTitular = nome;
        }

        public void Depositar(double valor) {
            Saldo += valor;
        }

        public void Sacar(double valor) {
            Saldo -= valor + TaxaDeSaque;
        }

        public override string ToString()
        {
            return "Conta: "
            + NumeroDaConta 
            + ", Titular: "
            + NomeTitular
            + ", Saldo: "
            + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}


    // - Atributos privados
    // - Propriedades autoimplementadas
    // - Construtores
    // - Propriedades customizadas
    // - Outros médotos da classe
