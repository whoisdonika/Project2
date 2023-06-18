using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Okazion
{
    internal class Program
    {
        static string currentPage = "Register"; // current page user is on
        static void Main(string[] args)
        {
            bool logged = false; // is user logged in
            bool isRunning = true; // is program running
            var random = new Random(); // random generator

            //register
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("            Register ");
            Console.WriteLine(" --------------------------------\n");

            Console.Write("Username: ");
            string regName = Console.ReadLine();
            Console.Write("Password: ");
            string regPassword = Console.ReadLine();
            Console.Write("Phone number: ");
            int regNumber = int.Parse(Console.ReadLine());
            Console.Write("Account balance (лв): ");
            double regBalance = double.Parse(Console.ReadLine());

            Console.Clear();

            //local user
            var local = new User(regName, regPassword, regNumber, regBalance);

            //welcome message
            Console.WriteLine($"Welcome {local.Username} !");
            Thread.Sleep(2000); // 2 sec timer
            Console.Clear();

            //user generator - generates user with random name, number and balance

            var users = new List<User>(); // list of all users
            string[] names = new string[] { "Clement", "Vienna", "Polly", "Jaxtyn", "Naum",
                "Jenny", "Louisa", "Emory", "Davinia", "Giselle", "Ulyssa", "Miley", "Milen",
                "Pippa", "Sharyn", "Dayna", "Sloan", "Doroteya", "Dodie", "Nigella", "Elma",
                "Honour", "Buffy", "Giana", "Stamen", "Ida", "Pip", "Rylan", "Gerrard",
                "Krystine", "Bryan", "Rory", "Doria", "Brianna", "Brannon" }; // random names array
            int usersCount = random.Next(30, 150); // random user count
            for (int i = 0; i < usersCount; i++)
            {
                string userName = names[random.Next(0, names.Length)];
                int userNumber = random.Next(0000000000, 999999999);
                double userBalance = random.NextDouble() * random.Next(0, 10000);

                var user = new User(userName, null, userNumber, userBalance);
                users.Add(user);
            }

            //product generator - generates random product and its price

            var products = new List<Product>(); // list of all products
            string[] productName = new string[] { "вода", "дантела", "чаша", "легло", "отметка",
                "игла", "ваза", "пила за нокти", "гумена лента", "пластмасова вилица", "чекова книжка", "вилица",
                "броколи", "тоалетна", "глинен съд", "камион", "часовник", "прозорец", "гледам", "високоговорители",
                "лепкава бележка", "възглавница", "Портмоне", "нокторезачка", "побелявам", "къща", "панталони", "врата",
                "връзка на обувка", "слушалки", "парфюм", "шал", "клечки за зъби", "подложки за чаши", "очна линия",
                "храна", "светещ стик", "шарпи", "знаме", "одеяло", "моркови", "туистър", "моп", "измиване на лицето",
                "блокче за скици", "бутон", "молив", "гланц за устни", "CD", "термостат", "каска", "обувки", "ръждив пирон",
                "тиксо", "гумено пате", "пиано", "пари", "чорапи", "плоча", "видео игри", "ябълка", "цип", "катарама", "огледало",
                "свещ", "балсам", "купа", "пясъчна хартия", "винт", "книга с глави", "магнит", "цветя", "тебешир", "маса", "корк",
                "изход", "предпазен колан", "фотоалбум", "бюро", "нож", "улични светлини", "обвивка от бонбони", "мечета",
                "модел кола", "банани", "блуза", "ключодържател", "радио", "скоба", "бутилка за вода", "чорапи", "вестник",
                "гъба", "пръстен", "телевизия", "купия за салфетки", "рамка на картина", "поздравителна картичка", "капачка на бутилка",
                "USB устройство", "пакетче соев сос", "мляко", "форма за лед", "карта за игра", "телевизия", "контролер", "дезодорант",
                "хляб", "пръстен на крака", "абажур", "диван", "дрехи", "дистанционно", "гумичка", "буркан за сладки",
                "Подложка за мишка", "лопата", "гривна", "риза", "зарядно устройство", "шоколад", "кредитна карта",
                "четка за рисуване", "дърво", "клавиатура", "кукла", "освежител за въздух", "кърпа за баня", "телефон", "четка за коса",
                "опаковане на фъстъци", "лампа", "шлаков блок", "балон", "очила", "бутилка", "етаж", "котка", "лъжица", "локва",
                "бум кутия", "вагон", "кутия", "пролет", "гума люлка", "чанта", "тротоар", "сандал", "ключове", "платно", "ipod",
                "Председател", "мобилен телефон", "кола", "решетъчна хартия", "сапун", "лосион", "портфейл", "пинсети", "диван",
                "четка за зъби", "хладилник", "домат", "фалшиви цветя", "слънчеви очила", "хартия", "паста за зъби", "химилка",
                "Книга", "камера", "mp3 плейър", "монитор", "чехъл", "чекмедже", "говеждо месо", "бормашина", "лък", "компютър",
                "стъклена чаша", "термометър", "стик за басейн", "шампоан", "ластик за коса", "платноходка", "пералня", "сода може",
                "закачалка", "знак Стоп", "резба", "килим"}; // random product name array
            for (int i = 0; i < productName.Length; i++)
            {
                string name = productName[random.Next(0, productName.Length)];
                double price = random.NextDouble() * random.Next(2, 1000);
                int id = random.Next(1000, 9999);
                var product = new Product(name, price, id);
                products.Add(product);
            }

            //adds product posts to users
            foreach (var user in users)
            {
                for (int i = 1; i < random.Next(1, 6); i++)
                {
                    user.RegisterProduct(products[random.Next(products.Count)]);
                }
            }

            // input commands
            Menu(local);
            currentPage = "Menu";

            while (isRunning)
            {
                Console.Write(" Selection: ");
                int selection = int.Parse(Console.ReadLine());
                if (currentPage == "Menu")
                {
                    switch (selection)
                    {
                        case 1: Logout(); logged = false; break;
                        case 2: SellProduct(local); break;
                        case 3: Okazion(users); break;
                        case 4: MyAccount(local); break;
                        case 5: isRunning = false; Console.Clear(); break;
                        default: Console.WriteLine("Please enter correct number!"); break;
                    }
                }
                else if (currentPage == "Logout")
                {
                    switch (selection)
                    {
                        case 1: UserLogin(regName, regPassword, local, logged); break;
                        case 2: isRunning = false; Console.Clear(); break;
                        default: Console.WriteLine("Please enter correct number!"); break;
                    }
                }
                else if (currentPage == "Products")
                {
                    switch (selection)
                    {
                        case 1: BuyItem(local, products); break;
                        case 2: Menu(local); break;
                        default: Console.WriteLine("Please enter correct number!"); break;
                    }
                }
                else if (currentPage == "MyAccount")
                {
                    switch (selection)
                    {
                        case 1: Menu(local); break;
                        default: Console.WriteLine("Please enter correct number!"); break;
                    }
                }
                //Console.WriteLine(currentPage);
            }

        }

        private static void BuyItem(User local, List<Product> products)
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            if (products.Find(x => x.ID == id).Price < local.Balance)
            {
                Console.Write($"You bought ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(products.Find(x => x.ID == id).Name);
                Console.ResetColor();
                Console.Write(" for ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"{products.Find(x => x.ID == id).Price:f2} лв.");
                Console.ResetColor();
                local.Balance -= products.Find(x => x.ID == id).Price;
                Console.WriteLine();
                local.AddToCart(products.Find(x => x.ID == id));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Not enough money!");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
        private static void Okazion(List<User> users)
        {
            Console.Clear();

            currentPage = "Products";

            Console.WriteLine(" --------------------------------");
            Console.WriteLine("             OKAZION ");
            Console.WriteLine(" --------------------------------\n");
            foreach (var user in users)
            {
                user.UserPrint();
                Thread.Sleep(20);
            }
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("\t1. Buy product by ID \t");
            Console.WriteLine("\t2. Back \t");
            Console.WriteLine(" --------------------------------");
        }
        private static void MyAccount(User local)
        {
            Console.Clear();

            currentPage = "MyAccount";

            Console.WriteLine(" --------------------------------");
            Console.WriteLine("       Registered Products ");
            Console.WriteLine(" --------------------------------\n");
            local.PrintProducts();
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("            My cart ");
            Console.WriteLine(" --------------------------------\n");
            local.PrintCart();
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("\t1. Back \t");
            Console.WriteLine(" --------------------------------");

        }
        private static void SellProduct(User local)
        {
            Console.Clear();

            currentPage = "Sell";

            Console.Write("Product name: ");
            string prodName = Console.ReadLine();
            Console.Write("Product price: ");
            double prodPrice = double.Parse(Console.ReadLine());
            var product = new Product(prodName, prodPrice);
            local.RegisterProduct(product);

            Menu(local);
        }
        private static void Logout()
        {
            Console.Clear();

            currentPage = "Logout";

            Console.WriteLine(" -------------------------\n");
            Console.WriteLine("\t1. Login \t");
            Console.WriteLine("\t2. Exit \t\n");
            Console.WriteLine(" -------------------------");
            //Console.WriteLine(currentPage);
        }
        private static void Menu(User local)
        {
            currentPage = "Menu";

            Console.Clear();
            Console.WriteLine($" Username: {local.Username} | Number: 0{local.Number} | Balance: {local.Balance:f2} лв.");
            Console.WriteLine(" --------------------------------\n");
            Console.WriteLine("\t1. Logout \t");
            Console.WriteLine("\t2. Sell products \t");
            Console.WriteLine("\t3. Buy products \t");
            Console.WriteLine("\t4. My account \t");
            Console.WriteLine("\t5. Exit \t\n");
            Console.WriteLine(" --------------------------------");
        }
        private static void UserLogin(string regName, string regPassword, User local, bool logged)
        {
            while (!logged)
            {
                Console.Write("Username: ");
                regName = Console.ReadLine();
                Console.Write("Password: ");
                regPassword = Console.ReadLine();
                if (regName == local.Username && regPassword == local.Password)
                {
                    logged = true;
                    Menu(local);

                    currentPage = "Menu";
                }
                else
                {
                    logged = false;
                    Console.WriteLine("Wrong username or password!");
                }
            }
        }

    }
    
}
