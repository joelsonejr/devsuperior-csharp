using System.Globalization;

namespace Course{
    public class ContaCorrente {
        private double _saldo; //TODO: verificar atributo
        public int NumeroDaConta {get;}
        public string NomeTitular {get; private set;}  //TODO: Verificar método set

        private double TaxaDeSaque = 5.00; 

        public ContaCorrente() {
        
        }

        public ContaCorrente(int conta, string nome, double saldo) {
            NumeroDaConta = conta;
            NomeTitular = nome;
            _saldo = saldo;
        }

        public ContaCorrente(int conta, string nome) {
            NumeroDaConta = conta;
            NomeTitular = nome;
        }


        public void AlterarTitular(string nome) {
            NomeTitular = nome;
        }

        public void Depositar(double valor) {
            _saldo += valor;
        }

        public void Sacar(double valor) {
            _saldo -= valor + TaxaDeSaque;
        }

        public override string ToString()
        {
            return "Conta: "
            + NumeroDaConta 
            + ", Titular: "
            + NomeTitular
            + ", Saldo: "
            + _saldo.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}


    // - Atributos privados
    // - Propriedades autoimplementadas
    // - Construtores
    // - Propriedades customizadas
    // - Outros médotos da classe
