using _Basket;
using All_Category;
using System.Text.Json;

namespace _History
{
    internal class History
    {
        public List<Basket1> Buy_History { get; set; } = new List<Basket1>();

        public void Add_History(Basket1 basket)
        {

            Buy_History.Add(basket);
        }

     

    public void Print_History()
    {
        foreach (var history in Buy_History)
        {
            Console.WriteLine("Buy History:");
            history.Print2();
            Console.WriteLine($"Total Price: {history.PrintTotalPrice()}");
            Console.WriteLine("-------------------------------------");
        }
    }
    public void Print_History2()
        {
            foreach (var history in Buy_History)
            {
                Console.WriteLine("Hesabat:");
                history.Print2();
                Console.WriteLine($"Total Price: {history.PrintTotalPrice()}");
                Console.WriteLine("-------------------------------------");
            }
        }
    public void Write_History_To_File()
    {
        var json = JsonSerializer.Serialize(Buy_History);
        File.WriteAllText("history.json", json);
    }
    public void Read_History_From_File()
    {
        if (File.Exists("history.json"))
        {
            string json = File.ReadAllText("history.json");
            Buy_History = JsonSerializer.Deserialize<List<Basket1>>(json);
        }
        else
        {
            Console.WriteLine("History file does not exist.");
        }
    }

}
}
