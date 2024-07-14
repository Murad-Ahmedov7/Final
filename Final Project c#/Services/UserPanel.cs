


using System.Text.Json;
using Users.Models;
using Admins.Services;
using Final_Project.Services;
using All_Category;
using _Basket;
using _History;


namespace Users.Services
{
    internal class UserPanel
    {

        public List<User> Users { get; set; } = new List<User>();


        public void Register(string name, string surname, string email, string password, string date)
        {
            try
            {

                LoadUsersFromFile();


                var user = Users.FirstOrDefault(e => e.Email.Trim().ToLower() == email);


                if (user is null)
                {
                    user = new User()
                    {
                        Email = email!,
                        Name = name!,
                        Surname = surname!,
                        Password = password!,
                        DateOfBirth = DateOnly.ParseExact(date!, "dd.MM.yyyy")
                    };
                    Users.Add(user);

                    var json = JsonSerializer.Serialize(Users);
                    File.WriteAllText("user.json", json);

                    //foreach (var adam in Users)
                    //{
                    //    Console.WriteLine(adam);
                    //}
                    //Thread.Sleep(4000);

                    return;
                }

                else
                {
                    throw new Exception();
                }
            }

            catch
            {
                Console.WriteLine();
                Console.WriteLine("User is Already Exist");
                Thread.Sleep(3000);
            }







        }


        public void RegisterPage()
        {

            Console.WriteLine("Adinizi daxil edin: ");
            string? name = Console.ReadLine();

            Console.WriteLine("Soyadini daxil edin: ");
            string? surname = Console.ReadLine();

            Console.WriteLine("Email-i daxil edin: ");
            string? email = Console.ReadLine();

            Console.WriteLine("Password-u daxil edin: ");
            string? password = Console.ReadLine();

            Console.WriteLine("DateOfBirth (dd.MM.yyyy)");
            string? date = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Ad bosdu");
            }

            else if (string.IsNullOrWhiteSpace(surname))
            {
                throw new Exception("Soyad bosdu");
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email bosdu");
            }

            else if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password bosdu");
            }

            else if (string.IsNullOrWhiteSpace(date))
            {
                throw new Exception("Ad gunu bosdu");
            }

            Register(name!, surname!, email!.ToLower().Trim(), password!, date!);









        }
        public void SaveUsersToFile()
        {
            var json = JsonSerializer.Serialize(Users);
            File.WriteAllText("user.json", json);
        }
        public void LoadUsersFromFile()
        {
            if (File.Exists("user.json"))
            {
                string json = File.ReadAllText("user.json");
                Users = JsonSerializer.Deserialize<List<User>>(json);
            }
        }

        public void Login(string log_email, string log_password)
        {
            LoadUsersFromFile();

            for (int i = 0; i < Users.Count; i++)
            {

                if (Users[i].Email == log_email && Users[i].Password == log_password)
                {
                    Console.WriteLine("Ugurla giris edildi");
                    Thread.Sleep(2500);
                    return;
                }

                if (string.IsNullOrWhiteSpace(log_email))
                {
                    Console.WriteLine("Email bosdu.Yeniden daxil edin: ");
                    Thread.Sleep(2000);
                    LoginPage();
                    return;


                }

                if (string.IsNullOrWhiteSpace(log_password))
                {
                    Console.WriteLine("Password bosdu.Yeniden daxil edin: ");
                    Thread.Sleep(2000);
                    LoginPage();
                    return;


                }

            }
            Console.WriteLine("Giris ugursuz oldu.Yeniden daxil edin:");
            Thread.Sleep(2500);
            LoginPage();





        }

        public void AfterLoginPage()
        {
            Category category3 = new Category();
            Basket1 basket = new Basket1();
            History history = new History();

            AdminPanel admins = new AdminPanel();

            
            int count = 0;
        Login2:
            Console.Clear();
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Kategoriyalar");
            Console.WriteLine("2.Sebete bax");
            Console.WriteLine("3.Profil");

            int choice = Convert.ToInt32(Console.ReadLine());

            Program program1 = new Program();




            switch (choice)
            {
                case 0:
                    program1.UserChoice();
                    break;
                case 1:
                    Console.Clear();
            
                    if (count >= 1)
                    {

                        category3.ShowProducts();

                    }
                    else
                    {
                        category3.AddProducts2();
                     
                        category3.ShowProducts();
                        count += 1;

                    }



                    Console.WriteLine("0.Exit");
                    Console.WriteLine("1.Add Sebet");

                    int choice2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Seciminizi edin: ");






                    if (choice2 == 0)
                    {
                        goto Login2;
                    }

                    else if (choice2 == 1)


                    {
                    Choice3:
                        Console.Clear();
                        foreach (var categoryss in category3.categories)
                        {
                            Console.WriteLine($"Category: {categoryss.Category_Name}, Product: {categoryss.Product_Name}, Price: {categoryss.Product_Price}, Count: {categoryss.Product_Count}");
                        }


                        Console.WriteLine();

                        Console.WriteLine("Elave etmek istediyiniz produkdu secin(reqem ile):");
                        int choice3 = Convert.ToInt32(Console.ReadLine());





                        var GeneralCategory = category3.categories[choice3 - 1];

                        if (GeneralCategory.Product_Count <= 0)
                        {
                            Console.WriteLine($"{GeneralCategory.Product_Name} adli produkt qalmadi.Yeniden secim edin: ");
                            Thread.Sleep(2000);

                            goto Choice3;
                        }


                        GeneralCategory.Product_Count -= 1;

                        var Temp = GeneralCategory.Product_Count;

                        GeneralCategory.Product_Count = 1;

                        basket.Add_prod_basket(GeneralCategory);




                        Console.WriteLine(GeneralCategory.ToString());



                        GeneralCategory.Product_Count = Temp;








                        Thread.Sleep(2000);
                        goto Login2;




                    }


                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("0.Exit");
                    Console.WriteLine("1.Sebeti tesdiqle");
                    Console.WriteLine("Sebetin daxilinde olan elemenler :");
                    basket.Print2();
                    Console.Write("Produklarin umumi qiymeti: ");
                    Console.WriteLine(basket.PrintTotalPrice());



                    int choice4 = Convert.ToInt32(Console.ReadLine());

                    if (choice4 == 0)
                    {
                        goto Login2;
                    }

                    else if (choice4 == 1)
                    {
                    Pay:
                        Console.Clear();
                        Console.Write("Produklarin umumi qiymeti: ");
                        Console.WriteLine(basket.PrintTotalPrice());
                        Console.WriteLine("Odenisi daxil edin: ");
                        int Pay = Convert.ToInt32(Console.ReadLine());


                        if (Pay > basket.PrintTotalPrice())
                        {
                            int qaliq = Pay - basket.PrintTotalPrice();
                            Console.WriteLine($"Musteriye {qaliq}$ pul qaytarildi");
                            history.Add_History(basket);
                            history.Write_History_To_File();
                            history.Read_History_From_File();
                            basket.Products_In_Basket.Clear();

                            Thread.Sleep(2500);
                            goto Login2;
                        }
                        else if (Pay < basket.PrintTotalPrice())
                        {
                            Console.WriteLine("Odenis yeterli qeder deyil. yeniden daxil edin: ");
                            Thread.Sleep(2500);
                            goto Pay;
                        }
                        else if (Pay == basket.PrintTotalPrice())
                        {
                            Console.WriteLine("Odenis tam olaraq odenildi.Musteriye qaliq pul qaytarilmadi");
                            history.Add_History(basket);
                            history.Write_History_To_File();
                            basket.Products_In_Basket.Clear();
                            Thread.Sleep(2500);

                            goto Login2;
                        }
                    }
                    break;









            }

   
        case3:
        GoBack:
            Console.Clear();
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.History");
            Console.WriteLine("2.Melumatlari deyis");
            Console.WriteLine("3.Parolu deyis");
            int choice6 = Convert.ToInt32(Console.ReadLine());

            if (choice6 == 0)
            {
                goto Login2;
            }
            else if (choice6 == 1)
            {
                history.Read_History_From_File();
                history.Print_History();
                
                Thread.Sleep(2500);
                goto GoBack;
            }

            else if (choice6 == 2)
            {
            GoBack3:
                Console.Clear();
                Console.WriteLine("0.Exit");
                foreach (var user in Users)
                {
                    Console.Write($"User Name: {user.Name}  ");
                    Console.Write($"User Surname: {user.Surname}  ");
                    Console.WriteLine($"User Birthday: {user.DateOfBirth}");
                }
                Console.WriteLine("Deyismek istediyiniz user-i secin:(reqem ile): ");
                int choice1 = Convert.ToInt32(Console.ReadLine());
                if (choice1 == 0)
                {
                    goto GoBack;
                }
                var Change_for_User = Users[choice1 - 1];

                Console.WriteLine(Change_for_User);
                Thread.Sleep(2500);

                Console.Clear();
            GoBack4:
                Console.WriteLine(Change_for_User);
                Console.WriteLine("Deyismek istediyiniz parametri secin:(0.Exit/1.Name/2.Surname/3.DateOfBirth ");

                int choice2 = Convert.ToInt32(Console.ReadLine());

                if (choice2 == 0)
                {
                    goto GoBack3;
                }
                else if (choice2 == 1)
                {
                GoBack5:
                    Console.Clear();
                    Console.WriteLine($"Old Name:{Change_for_User.Name}");
                    Console.Write($"New Name:");
                    string newName = Console.ReadLine();
                    if (Change_for_User.Name == newName)
                    {
                        Console.WriteLine("Kohne ad ile eynidi.Yeniden daxil edin: ");
                        Thread.Sleep(2500);
                        goto GoBack5;
                    }
                    Console.Clear();
                    Console.WriteLine($"Old Name:{Change_for_User.Name}");
                    Console.Write($"New Name");
                    Console.WriteLine($":{newName}");
                    Change_for_User.Name = newName;
                    Console.WriteLine("Ad deyisdirildi");
                    SaveUsersToFile();
                    LoadUsersFromFile();

                    Thread.Sleep(2700);
                    goto GoBack;



                }

                else if (choice2 == 2)
                {
                GoBack6:
                    Console.Clear();
                    Console.WriteLine($"Old Surname:{Change_for_User.Surname}");
                    Console.Write($"New Surname:");
                    string newSurname = Console.ReadLine();
                    if (Change_for_User.Surname == newSurname)
                    {
                        Console.WriteLine("Kohne soyad ile eynidi.Yeniden daxil edin: ");
                        Thread.Sleep(2500);
                        goto GoBack6;

                    }
                    Console.Clear();
                    Console.WriteLine($"Old Surname:{Change_for_User.Surname}");
                    Console.Write($"New Surname");
                    Console.WriteLine($":{newSurname}");
                    Change_for_User.Surname = newSurname;
                    Console.WriteLine("Soyad deyisdirildi");
                    SaveUsersToFile();
                    LoadUsersFromFile();

                    Thread.Sleep(2700);
                    goto GoBack;
                }

                else if (choice2 == 3)
                {
                GoBack6:
                    Console.Clear();
                    Console.WriteLine($"Old Birthday:{Change_for_User.DateOfBirth}");
                    Console.Write($"New Birthday:");

                    string date = Console.ReadLine();
                    var NewBirthday = DateOnly.ParseExact(date!, "dd.MM.yyyy");


                    if (Change_for_User.DateOfBirth == NewBirthday)
                    {
                        Console.WriteLine("Kohne Ad gunu ile eynidi.Yeniden daxil edin: ");
                        Thread.Sleep(2500);
                        goto GoBack6;

                    }
                    Console.Clear();
                    Console.WriteLine($"Old Birthday:{Change_for_User.DateOfBirth}");
                    Console.Write($"New Birthday");
                    Console.WriteLine($":{NewBirthday}");
                    Change_for_User.DateOfBirth = NewBirthday;
                    Console.WriteLine("Ad gunu deyisdirildi");
                    SaveUsersToFile();
                    LoadUsersFromFile();

                    Thread.Sleep(2700);
                    goto GoBack;
                }


                else
                {
                    Console.WriteLine("Seciminiz yanlisdir.Yeniden secim edin:");
                    Thread.Sleep(2500);
                    goto GoBack4;
                }


                Thread.Sleep(2500);
                goto GoBack;

            }
            else if (choice6 == 3)
            {
                Console.Clear();
                Console.WriteLine("0.Exit");

                foreach (var user in Users)
                {
                    Console.Write($"User Email: {user.Email} ");
                    Console.WriteLine($"User Password: {user.Password}");
                }
                Console.WriteLine("Deyismek istediyiniz user parolunu secin:(reqem ile): ");
                int choice1 = Convert.ToInt32(Console.ReadLine());
                if (choice1 == 0)
                {
                    goto GoBack;
                }


                var Change_for_pasword = Users[choice1 - 1];


                Console.Write($"User Email:{Change_for_pasword.Email}  ");
                Console.WriteLine($"User Password:{Change_for_pasword.Password}");
                Thread.Sleep(3000);
            GoBack2:
                Console.Clear();
                Console.WriteLine($"Old Password:{Change_for_pasword.Password}");
                Console.Write($"New Password:");

                string newPassword = Console.ReadLine();
                if (Change_for_pasword.Password == newPassword)
                {
                    Console.WriteLine("Kohne parol ile eynidi.Yeniden daxil edin: ");
                    Thread.Sleep(2500);
                    goto GoBack2;
                }
                Console.Clear();
                Console.WriteLine($"Old Password:{Change_for_pasword.Password}");
                Console.Write($"New Password");
                Console.WriteLine($":{newPassword}");
                Console.Write("Confirm Password:");
                string ConfirmPassword = Console.ReadLine();
                if (ConfirmPassword != newPassword)
                {
                    Console.WriteLine("Kod duzgun tesdiq olunmadi.Yeniden daxil edin: ");
                    Thread.Sleep(2500);
                    goto GoBack2;
                }

                Console.Clear();
                Console.WriteLine($"Old Password:{Change_for_pasword.Password}");
                Console.WriteLine($"New Password:{newPassword}");
                Console.WriteLine($"Confirm Password:{ConfirmPassword}");
                Console.WriteLine("Kod ugurla deyisdirildi");

                Change_for_pasword.Password = newPassword;
                SaveUsersToFile();
                LoadUsersFromFile();

                Thread.Sleep(3000);
                goto GoBack;

            }
            else
            {
                Console.WriteLine("Duzgun daxil edilmeyib.Yeniden daxil edin");
            }
           





        }
        public void LoginPage()
        {

            Console.Clear();

            Console.Write("Email-i daxil edin: ");
            string log_email = Console.ReadLine();

            Console.Write("Password-u daxil edin: ");
            string? log_password = Console.ReadLine();





            Login(log_email!, log_password!);


        }
    }
}
