



namespace All_Category
{
    internal class Category
    {

        public string? Category_Name { get; set; }
        public string? Product_Name { get; set; }
        public int Product_Price { get; set; }

        public int Product_Count { get; set; }

        public List<Category> categories { get; set; }=new List<Category>();
  
        
        public void AddProducts(string categoryName, string productName, int productPrice,int productcount)
        {
            var newCategory = new Category
            {
                Category_Name = categoryName,
                Product_Name = productName,
                Product_Price = productPrice,
                Product_Count = productcount
            };
            categories.Add(newCategory);

            
        }



        public void AddProducts2()
        {



            AddProducts("Sud Mehsulu", "Qatiq", 4, 5);
            AddProducts("Yag Mehsulu", "Kere yagi", 3, 3);
        }

        public void ShowProducts()
        {

            foreach (var categoryss in categories)
            {
                Console.WriteLine($"Category: {categoryss.Category_Name}, Product: {categoryss.Product_Name}, Price: {categoryss.Product_Price}, Count: {categoryss.Product_Count}");

               
            }

            Console.WriteLine();

            


        }

        public override string ToString()
        {
            return $"Category: {Category_Name}, Product: {Product_Name}, Price: {Product_Price}, Count: {Product_Count}";
        }









    }



}
