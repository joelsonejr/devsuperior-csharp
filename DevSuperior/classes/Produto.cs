// using System.Globalization;

// namespace Course 
// {
//     class Produto
//     {
//         private string _nome;
//         public double Preco {get; private set;}  //auto propertie
//         public int Quantidade {get; private set;} //auto propertie

//         //Construtor padrão
//         public Produto()
//         {
            
//         }

//         //Construtor com 3 argumentos
//         public Produto(string nome, double preco, int quantidade)
//         {
//             _nome = nome;
//             Preco = preco;
//             Quantidade = quantidade;
//         }
//         //Construtor com 2 argumentos
//         public Produto(string nome, double preco)
//         {
//             _nome = nome;
//             Preco = preco;
//             Quantidade = 5;
//         }

//         public double ValorTotalEmEstoque()
//         {
//             return Quantidade * Preco;
//         }

//         //Implementação de propertie, definindo as operações de get e set
//         public string Nome {
//             get { return _nome;}
//             set {
//                  if (value != null && value.Length > 1){
//                 _nome = value;
//             }
//             }
//         }




//         public void AdicionarProdutos (int quantity)
//         {
//             Quantidade += quantity;
//         }

//         public void RemoverProdutos(int quantity)
//         {
//             Quantidade -= quantity;
//         }
        
//         public override string ToString()
//         {
//             return _nome 
//                 + ", $" 
//                 + Preco.ToString("F2",CultureInfo.InvariantCulture) 
//                 + ", "
//                 + Quantidade
//                 + " unidades, Total: $ "
//                 + ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
//         }
//     }
// }