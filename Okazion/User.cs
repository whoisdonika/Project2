using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okazion
{
    internal class User
    {
        private string username;
        private string password;
        private int number;
        private double balance;
        private List<Product> products = new List<Product>();
        private List<Product> cart = new List<Product>();
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public User(string username, string password, int number, double balance)
        {
            this.username = username;
            this.password = password;
            this.number = number;
            this.balance = balance;
        }
        public void AddToCart(Product product)
        {
            cart.Add(product);
        }
        public void PrintCart()
        {
            foreach (var item in this.cart)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {item.Name} ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"| {item.Price:f2} лв. |");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        public void RegisterProduct(Product product)
        {
            this.products.Add(product);
        }
        public void PrintProducts()
        {
            foreach (var item in this.products)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {item.Name} ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"| {item.Price:f2} лв. |");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        public void UserPrint()
        {
            foreach (var item in this.products)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($" {this.username} ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"| 0{this.number} |");
                Console.ResetColor();
                Console.Write($"   ---->   ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($" {item.Name.ToUpper()} ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"| {item.Price:f2} лв. |");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($" ID: {item.ID} ");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}
