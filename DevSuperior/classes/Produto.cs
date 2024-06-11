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