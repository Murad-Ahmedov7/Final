
using System.Text.Json;
using Admins.Models;
using All_Category;
using _Basket;
using Final_Project.Services;
using Users.Services;


namespace Admins.Services
{
    internal class AdminPanel
    {
        public List<Admin> Admins = new List<Admin>();
        Category category = new Category();

        public void AddAdmins(string name, string surname, string login, string password)
        {
            Admin admin = new Admin()
            {
                Name = name,
                Surname = surname,
                Login = login,
                Password = password
            };
            Admins.Add(admin);
        }

        public void AddAdmins2()
        {
            AddAdmins("Murad", "Ahmedov", "21", "sd");
            AddAdmins("Elnur", "Abbasov", "elnur123", "world24");
        }

        public void Login(string log, string log_password)
        {
            AddAdmins2();

            for (int i = 0; i < Admins.Count; i++)
            {
                if (Admins[i].Login == log && Admins[i].Password == log_password)
                {
                    Console.WriteLine("Ugurla giris edildi");
                    Thread.Sleep(2500);
                    return;
                }
                else if (string.IsNullOrWhiteSpace(log))
                {
                    Console.WriteLine("Login bosdu. Yeniden daxil edin: ");
                    Thread.Sleep(2000);
                    LoginPage2();
                    return;
                }
                else if (string.IsNullOrWhiteSpace(log_password))
                {
                    Console.WriteLine("Password bosdu. Yeniden daxil edin: ");
                    Thread.Sleep(2000);
                    LoginPage2();
                    return;
                }
            }
            Console.WriteLine("Giris ugursuz oldu. Yeniden daxil edin:");
            Thread.Sleep(2500);
            LoginPage2();
        }

        public void LoginPage2()
        {
            Console.Clear();

            Console.Write("Login-i daxil edin: ");
            string? log = Console.ReadLine();

            Console.Write("Password-u daxil edin: ");
            string? log_password = Console.ReadLine();

            Login(log!, log_password!);
        }

        public void AfterLoginPage2()
        {
            Program program1 = new Program();
            UserPanel userPanel = new UserPanel();
            _History.History history = new _History.History();
            Basket1 basket1 = new Basket1();
            int count = 0;

        BackToStart2:
            Console.Clear();
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Produkt Elave et");
            Console.WriteLine("2.Produkt melumatlarin deyismek");
            Console.WriteLine("3.Hesabat");

            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 0)
            {
                program1.AdminChoice();
            }
            else if (choice == 1)
            {

            }
            else if (choice == 2)
            {
            BackToStart4:
                Console.Clear();

                if (count == 0)
                {
                    category.AddProducts2();
                    category.ShowProducts();
                    count++;
                }
                else
                {
                    category.ShowProducts();
                }

                Console.Clear();
              
                int count2 = 0;

                foreach (var categoryss in category.categories)
                {
                    
                    Console.WriteLine($"Category: {categoryss.Category_Name}, Product: {categoryss.Product_Name}, Price: {categoryss.Product_Price}, Count: {categoryss.Product_Count}");
                    count2 += 1;
                    if (count2 == 2)
                    {
                        break;
                    }

                }

                Console.WriteLine();








                Console.WriteLine("0.Exit");
                Console.WriteLine("Deyismek istediyiniz produktu secin:(reqem ile): ");
                int choice1 = Convert.ToInt32(Console.ReadLine());
                if (choice1 == 0)
                {
                    goto BackToStart2;
                }
                var Change_for_Product = category.categories[choice1 - 1];

                Console.WriteLine(Change_for_Product);
                Thread.Sleep(2500);
                Console.Clear();

            BackToStart3:
                Console.WriteLine(Change_for_Product);
                Console.WriteLine("Deyismek istediyiniz parametri secin:(0.Exit/1.Name/2.Price/3.Count)");

                int choice2 = Convert.ToInt32(Console.ReadLine());

                if (choice2 == 0)
                {
                    goto BackToStart2;
                }
                else if (choice2 == 1)
                {
                GoBack5:
                    Console.Clear();
                    Console.WriteLine($"Old Name:{Change_for_Product.Product_Name}");
                    Console.Write($"New Name:");
                    string newName1 = Console.ReadLine();
                    if (Change_for_Product.Product_Name == newName1)
                    {
                        Console.WriteLine("Kohne ad ile eynidi. Yeniden daxil edin: ");
                        Thread.Sleep(2500);
                        goto GoBack5;
                    }
                    Console.Clear();
                    Console.WriteLine($"Old Name:{Change_for_Product.Product_Name}");
                    Console.Write($"New Name");
                    Console.WriteLine($":{newName1}");
                    Change_for_Product.Product_Name = newName1;
                    Console.WriteLine("Ad deyisdirildi");
                    SaveProductToFile();
                    

                    Thread.Sleep(2500);
                    goto BackToStart4;
                }
                else if (choice2 == 2)
                {
                GoBack5:
                    Console.Clear();
                    Console.WriteLine($"Old price:{Change_for_Product.Product_Price}");
                    Console.Write($"New Price:");
                    int newPrice1 = Convert.ToInt32(Console.ReadLine());
                    if (Change_for_Product.Product_Price == newPrice1)
                    {
                        Console.WriteLine("Kohne qiymet ile eynidi. Yeniden daxil edin: ");
                        Thread.Sleep(2500);
                        goto GoBack5;
                    }
                    Console.Clear();
                    Console.WriteLine($"Old Price:{Change_for_Product.Product_Price}");
                    Console.Write($"New Price");
                    Console.WriteLine($":{newPrice1}");
                    Change_for_Product.Product_Price = newPrice1;
                    Console.WriteLine("Qiymet deyisdirildi");
                    SaveProductToFile();

                    Thread.Sleep(2500);
                    goto BackToStart4;
                }
                else if (choice2 == 3)
                {
                    GoBack5:
                    Console.Clear();
                    Console.WriteLine($"Old Count:{Change_for_Product.Product_Count}");
                    Console.Write($"New Count:");
                    int newCount = Convert.ToInt32(Console.ReadLine());
                    if (Change_for_Product.Product_Count == newCount)
                    {
                        Console.WriteLine("Kohne say ile eynidi. Yeniden daxil edin: ");
                        Thread.Sleep(2500);
                        goto GoBack5;
                    }
                    Console.Clear();
                    Console.WriteLine($"Old Count:{Change_for_Product.Product_Count}");
                    Console.Write($"New Count:");
                    Console.WriteLine($":{newCount}");
                    Change_for_Product.Product_Count = newCount;
                    Console.WriteLine("Say deyisdirildi");
                    SaveProductToFile();

                    Thread.Sleep(2500);
                    goto BackToStart4;


                }
                else
                {
                    Console.WriteLine("Seciminiz yanlisdir. Yeniden daxil edin:");
                    Thread.Sleep(2500);
                    goto BackToStart3;
                }
            }
            else if (choice == 3)
            {
                
                Console.Clear();
                
              
                
                
                history.Read_History_From_File();
                history.Add_History(basket1);
                history.Print_History2();

                Thread.Sleep(2400);
                

            }
            else
            {
                Console.WriteLine("Seciminiz yanlisdir. Yeniden daxil edin:");
                Thread.Sleep(2500);
                goto BackToStart2;
            }
        }

        public void SaveProductToFile()
        {
            var json = JsonSerializer.Serialize(category.categories);
            File.WriteAllText("prod.json", json);
        }

        public void LoadProductFromFile()
        {
            if (File.Exists("prod.json"))
            {
                string json = File.ReadAllText("prod.json");
                category.categories = JsonSerializer.Deserialize<List<Category>>(json);
            }
        }
    }
}
