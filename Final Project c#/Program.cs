//UserPanel və AdminPaneldən ibarət Market programı yazmalı.

//UserPanel:
//1)User Register və Login edə bilməli.
//2)User giriş etdikdən sonra ekranda kateqoriyalar, səbətə bax, profil, çıxış et bölməsi qarşılayır. 
//3)Kateqoriyalardan birini seçdikdə həmin kateqoriyaya aid produktları görür və onları səbətə atır. Əgər həmin produkt stokda yoxdursa istifadəçi görmür.
//4)Səbətə daxil olduqda səbətə əlavə etdi produktları görür və cəmi qiymət sonda olur.Səbət təsdiqləndikdə istifadəçi pul daxil edir, və qalıq pul qaytarılır. İstifadəçi səbəbdən element silə bilir.
//5)User Profil səhifəsinə baxa bilir.
//6)User İndiyə qədər etdiyi alış-verişlərə baxa bilir.
//7)User şəxsi məlumatlarını yeniliyə bilir.
//8)User şifrəsini dəyişə bilir.

//AdminPanel
//1)Admin login edə bilir.
//2)Admin stoka nəzarət edir.Stoka element elavə edə bilir.Produktların məlumatlarını yeniliyə bilir. 
//3)Yeni kateqoriya əlavə edə bilir.Əgər yeni kateqoriya əlavə edilsə.User yeni kateqoriyanı görə bilməlidir.
//4)Admin hesabatlara baxa bilir.
//5)Statistikaya baxa biler(yazilmasa da olar)


using Users.Services;


namespace Final_Project.Services
{
    internal class Program
    {
        public void MainChoice()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Seciminizi edin(Reqem ile):");
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.User");
                Console.WriteLine("2.Admin");

                int choice;
                choice = Convert.ToInt32(Console.ReadLine());



                switch (choice)
                {
                    case 0:

                        System.Environment.Exit(0);
                        break;

                    case 1:
                        Console.WriteLine();
                        UserChoice();
                        break;
                    case 2:
                        Console.WriteLine();
                        AdminChoice();
                        break;

                    default:
                        Console.WriteLine("Seciminiz yanlisdir.Yeniden daxil edin: ");
                        Thread.Sleep(1500);
                        break;

                }
            }


        }
        public void UserChoice()
        {
            Console.Clear();
            int choice;
        Choice:
            Console.Clear();
            Console.WriteLine("     ----------------User-------------------");
            Console.WriteLine("Seciminizi edin(Reqem ile): ");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Register");
            Console.WriteLine("2.Login");
      
            choice = Convert.ToInt32(Console.ReadLine());


            UserPanel user_panel = new UserPanel();


            

            switch (choice)
            {
                case 0:
                    MainChoice();
                    break;

                case 1:
                    Console.Clear();
                    user_panel.RegisterPage();
                    break;
                case 2:
                    Console.WriteLine();
                    user_panel.LoginPage();
                    user_panel.AfterLoginPage();
                    break;

                default:
                 
                    Console.WriteLine("Seciminiz yanlisdir.Yeniden daxil edin: ");
                    Thread.Sleep(1700);
                    goto Choice;
                    

            }
        }

        public void AdminChoice()
        {
            BackToStart:
            Console.Clear();
            Console.WriteLine("     ----------------Admin-------------------");
            Console.WriteLine("Seciminizi edin(Reqem ile): ");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Login");
            int choice = Convert.ToInt32(Console.ReadLine());
            Admins.Services.AdminPanel adminPanel=new Admins.Services.AdminPanel(); 

            if (choice == 0)
            {
                MainChoice();
            }
            else if (choice == 1)
            {
                
                adminPanel.LoadProductFromFile();
                adminPanel.LoginPage2();
                adminPanel.AfterLoginPage2();
              
               

            }
            else
            {
                Console.WriteLine("Seciminiz yanlisdir.Yeniden daxil edin: ");
                Thread.Sleep(2500);
                goto BackToStart;
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.MainChoice();
            program.UserChoice();








        }
    }
}
