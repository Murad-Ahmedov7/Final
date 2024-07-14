


using All_Category;



namespace _Basket
{
    internal class Basket1
    {
        public List<Category> Products_In_Basket { get; set; } = new List<Category>();

        public void Add_prod_basket(Category generalCategory)
        {

            Products_In_Basket.Add(generalCategory);

        }
        public void Delete_prod_basket(Category generalCategory)
        {
            Products_In_Basket.Remove(generalCategory);
        }

        public void Print()
        {
            foreach (var prod in Products_In_Basket)
            {
                Console.WriteLine(prod.ToString());
                
            }
        }
        public void Print2()
        {

            foreach (var prod2 in Products_In_Basket)
            {
                var Temp = prod2.Product_Count;

                Console.WriteLine($"Category:{prod2.Category_Name}, Product: {prod2.Product_Name},Price: {prod2.Product_Price},Count: {prod2.Product_Count=1}");
                prod2.Product_Count = Temp;
            }
           


        }

        public int PrintTotalPrice()
        {
            int totalPrice = 0;

            foreach (var product in Products_In_Basket)
            {
                totalPrice += product.Product_Price;
            }
          
            return  totalPrice;
        }

        public int PrintTotalPrice2()
        {
            int totalPrice = 0;
            return totalPrice;
        }



    }
}

