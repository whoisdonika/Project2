using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okazion
{
    internal class Product
    {
        private string name;
        private double price;
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        public Product(string name, double price, int id)
        {
            this.name = name;
            this.price = price;
            this.id = id;
        }
    }
}
