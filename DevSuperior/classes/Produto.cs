using System.Globalization;

namespace Course 
{
    class Produto
    {
        public string Nome;
        public double Preco;
        public int Quantidade;

        //Construtor padrão
        public Produto()
        {
            
        }

        //Construtor com 3 argumentos
        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
        //Construtor com 2 argumentos
        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = 5;
        }

        public double ValorTotalEmEstoque()
        {
            return Quantidade * Preco;
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
            return Nome 
                + ", $" 
                + Preco.ToString("F2",CultureInfo.InvariantCulture) 
                + ", "
                + Quantidade
                + " unidades, Total: $ "
                + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}