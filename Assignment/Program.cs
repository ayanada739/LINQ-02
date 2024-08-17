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

            #region 3. Get the products with the cheapest price in each category (Use Let)

            var cheapestProductsPerCategory = products.GroupBy(p => p.Category).Select(g =>
            {
                var cheapestPrice = g.Min(p => p.UnitPrice);
                return new
                {
                    Category = g.Key,
                    Products = g.Where(p => p.UnitPrice == cheapestPrice).ToList()
                };
            }
            );

            Console.WriteLine("\nCheapest Products Per Category:");
            foreach (var item in cheapestProductsPerCategory)
            {
                Console.WriteLine($"Category: {item.Category}");
                foreach (var product in item.Products)
                {
                    Console.WriteLine($"    Product: {product.ProductName}, Price: {product.UnitPrice}");
                }
            }

            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            var mostExpensivePricePerCategory = products.GroupBy(p => p.Category).Select(g => new
            {
               Category = g.Key,
               MostExpensivePrice = g.Max(p => p.UnitPrice)
            } 
            );

            Console.WriteLine("\nMost Expensive Price Per Category:");
            foreach (var item in mostExpensivePricePerCategory)
            {
                Console.WriteLine($"Category: {item.Category}, Most Expensive Price: {item.MostExpensivePrice}");
            }
            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

            var mostExpensiveProductsPerCategory = products.GroupBy(p => p.Category).Select(g =>
            {
                var mostExpensivePrice = g.Max(p => p.UnitPrice);
                  return new
                  {
                     Category = g.Key,
                     Products = g.Where(p => p.UnitPrice == mostExpensivePrice).ToList()
                  };
            }
            );

            Console.WriteLine("\nMost Expensive Products Per Category:");
            foreach (var item in mostExpensiveProductsPerCategory)
            {
                Console.WriteLine($"Category: {item.Category}");
                foreach (var product in item.Products)
                {
                    Console.WriteLine($"    Product: {product.ProductName}, Price: {product.UnitPrice}");
                }
            }
            #endregion

            #region 6. Get the average price of each category's products.

            var averagePricePerCategory = products.GroupBy(p => p.Category).Select(g => new
            {
              Category = g.Key,
              AveragePrice = g.Average(p => p.UnitPrice)
            }
            );

            Console.WriteLine("\nAverage Price Per Category:");
            foreach (var item in averagePricePerCategory)
            {
                Console.WriteLine($"Category: {item.Category}, Average Price: {item.AveragePrice}");
            }

            #endregion


        }
    }
}
