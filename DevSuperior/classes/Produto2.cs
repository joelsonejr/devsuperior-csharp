using System;

namespace Course {
    class Product {
        public string Nome {get; set;}
        public double Preco {get; set;}

        public Product() {

        }

        public Product(string nome, double preco) {
            Nome = nome;
            Preco = preco;
        }
    }
}