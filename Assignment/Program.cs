namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = ListGenerator.Products();
            List<Customer> customers = ListGenerator.Customers("Customers.xml");

            //LINQ - Aggregate Operators

            #region 1. Get the total units in stock for each product category.

            var totalUnitsInStockPerCategory = products.GroupBy(p => p.Category).Select(g => new
            {
                 Category = g.Key,
                 TotalUnitsInStock = g.Sum(p => p.UnitsInStock)
             });

            Console.WriteLine("Total Units in Stock Per Category:");
            foreach (var item in totalUnitsInStockPerCategory)
            {
                Console.WriteLine($"Category: {item.Category}, Total Units in Stock: {item.TotalUnitsInStock}");
            }

            #endregion

            #region 2. Get the cheapest price among each category's products

            var cheapestPricePerCategory = products.GroupBy(p => p.Category).Select(g => new
            {
                Category = g.Key,
                CheapestPrice = g.Min(p => p.UnitPrice)
            }
            );

            Console.WriteLine("\nCheapest Price Per Category:");
            foreach (var item in cheapestPricePerCategory)
            {
                Console.WriteLine($"Category: {item.Category}, Cheapest Price: {item.CheapestPrice}");
            }
            #endregion






        }
    }
}
