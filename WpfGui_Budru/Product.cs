using System.Collections.Generic;

namespace WpfGui_Budru {
    internal class Product {

        private int productId;
        private string productName;
        private bool available;


        public List<Product> Products { get; set; }

        //Getter und Setter
        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public bool Available { get => available; set => available = value; }
        public string AvailableString { get => available ? "yes" : "no"; set => AvailableString = value; }
    }

       
}