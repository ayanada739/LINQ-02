﻿namespace Assignment
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


            //LINQ - Set Operators

            #region 1. Find the unique Category names from Product List

            var uniqueCategories = products.Select(p => p.Category).Distinct();

            Console.WriteLine("\nUnique Category Names:");
            foreach (var category in uniqueCategories)
            {
                Console.WriteLine($"Category: {category}");
            }
            #endregion

            #region 2. Produce a Sequence containing the unique first letter from both product and customer names.

            var uniqueFirstLetters = products.Select(p => p.ProductName[0])
                                        .Union(customers.Select(c => c.CustomerName[0]))
                                        .Distinct();

            Console.WriteLine("\nUnique First Letters from Product and Customer Names:");
            foreach (var letter in uniqueFirstLetters)
            {
                Console.WriteLine($"Letter: {letter}");
            }
            #endregion

            #region 3. Create one sequence that contains the common first letter from both product and customer names.

            var commonFirstLetters = products.Select(p => p.ProductName[0])
                                        .Intersect(customers.Select(c => c.CustomerName[0]));

            Console.WriteLine("\nCommon First Letters from Product and Customer Names:");
            foreach (var letter in commonFirstLetters)
            {
                Console.WriteLine($"Letter: {letter}");
            }
            #endregion

            #region 4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            var productFirstLettersNotInCustomers = products.Select(p => p.ProductName[0])
                                                      .Except(customers.Select(c => c.CustomerName[0]));

            Console.WriteLine("\nFirst Letters of Product Names Not in Customer Names:");
            foreach (var letter in productFirstLettersNotInCustomers)
            {
                Console.WriteLine($"Letter: {letter}");
            }
            #endregion

            #region 5. Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates

            var lastThreeChars = products.Select(p => p.ProductName.Length > 3 ? p.ProductName.Substring(p.ProductName.Length - 3) : p.ProductName)
                                    .Union(customers.Select(c => c.CustomerName.Length > 3 ? c.CustomerName.Substring(c.CustomerName.Length - 3) : c.CustomerName));

            Console.WriteLine("\nLast Three Characters in Product and Customer Names:");
            foreach (var chars in lastThreeChars)
            {
                Console.WriteLine($"Chars: {chars}");
            }
            #endregion


            //LINQ - Partitioning Operators

            #region 1. Get the first 3 orders from customers in Washington

            var firstThreeOrdersInWashington = customers.Where(c => c.Region == "Washington")
                                                   .SelectMany(c => c.Orders)
                                                   .Take(3);

            Console.WriteLine("\nFirst 3 Orders in Washington:");
            foreach (var order in firstThreeOrdersInWashington)
            {
                Console.WriteLine($"Order ID: {order.OrderID}, Order Date: {order.OrderDate}");
            }

            #endregion

            #region 2. Get all but the first 2 orders from customers in Washington.


            var allButFirstTwoOrdersInWashington = customers.Where(c => c.Region == "Washington")
                                                      .SelectMany(c => c.Orders)
                                                      .Skip(2);

            Console.WriteLine("\nAll But First 2 Orders in Washington:");
            foreach (var order in allButFirstTwoOrdersInWashington)
            {
                Console.WriteLine($"Order ID: {order.OrderID}, Order Date: {order.OrderDate}");
            }


            #endregion

            #region 3. Return elements starting from the beginning of the array until a number is hit that is less than its position in the array. 
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var elementsBeforePositionLessThanNumber = numbers.TakeWhile((n, index) => n >= index);

            Console.WriteLine("\nElements before hitting a number less than its position:");
            foreach (var number in elementsBeforePositionLessThanNumber)
            {
                Console.WriteLine($"Number: {number}");
            }



            #endregion

            #region  4. Get the elements of the array starting from the first element divisible by 3.

            var elementsFromFirstDivisibleBy3 = numbers.SkipWhile(n => n % 3 != 0);

            Console.WriteLine("\nElements starting from the first divisible by 3:");
            foreach (var number in elementsFromFirstDivisibleBy3)
            {
                Console.WriteLine($"Number: {number}");
            }
            #endregion

            #region  5. Get the elements of the array starting from the first element less than its position.

            var elementsFromFirstLessThanPosition = numbers.SkipWhile((n, index) => n >= index);

            Console.WriteLine("\nElements starting from the first element less than its position:");
            foreach (var number in elementsFromFirstLessThanPosition)
            {
                Console.WriteLine($"Number: {number}");
            }
            #endregion


            //LINQ - Quantifiers

            #region 1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.

            string[] dictionaryWords = System.IO.File.ReadAllLines("dictionary_english.txt");
            bool containsEi = dictionaryWords.Any(word => word.Contains("ei"));

            Console.WriteLine($"\nAny word contains 'ei': {containsEi}");

            #endregion

            #region 2. Return a grouped a list of products only for categories that have at least one product that is out of stock.

            var categoriesWithOutOfStockProducts = products
            .GroupBy(p => p.Category)
            .Where(g => g.Any(p => p.UnitsInStock == 0))
            .Select(g => new
            {
                Category = g.Key,
                Products = g.ToList()
            }
            );

            Console.WriteLine("\nCategories with at least one product out of stock:");
            foreach (var item in categoriesWithOutOfStockProducts)
            {
                Console.WriteLine($"Category: {item.Category}");
                foreach (var product in item.Products)
                {
                    Console.WriteLine($"    Product: {product.ProductName}, Units in Stock: {product.UnitsInStock}");
                }
            }
            #endregion

            #region 3. Return a grouped a list of products only for categories that have all of their products in stock.

            var categoriesWithAllProductsInStock = products
           .GroupBy(p => p.Category)
           .Where(g => g.All(p => p.UnitsInStock > 0))
           .Select(g => new
           {
               Category = g.Key,
               Products = g.ToList()
           }
           );

            Console.WriteLine("\nCategories with all products in stock:");
            foreach (var item in categoriesWithAllProductsInStock)
            {
                Console.WriteLine($"Category: {item.Category}");
                foreach (var product in item.Products)
                {
                    Console.WriteLine($"    Product: {product.ProductName}, Units in Stock: {product.UnitsInStock}");
                }
            }
            #endregion


            //LINQ – Grouping Operators

            #region 1. Use group by to partition a list of numbers by their remainder when divided by 5.
            List<int> numberList = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            var numbersGroupedByRemainder = numberList.GroupBy(n => n % 5);

            Console.WriteLine("\nNumbers grouped by remainder when divided by 5:");

            foreach (var group in numbersGroupedByRemainder)
            {
                Console.WriteLine($"\nRemainder {group.Key}:");
                foreach (var number in group)
                {
                    Console.WriteLine($"    {number}");
                }
            }

            #endregion

            #region 2. Use group by to partition a list of words by their first letter.

            var wordsGroupedByFirstLetter = dictionaryWords.GroupBy(word => word[0]);

            Console.WriteLine("\nWords grouped by their first letter:");
            foreach (var group in wordsGroupedByFirstLetter)
            {
                Console.WriteLine($"\nLetter {group.Key}:");
                foreach (var word in group)
                {
                    Console.WriteLine($"    {word}");
                }
            }
            #endregion

            #region 3. Group words that consist of the same characters together using a custom comparer.
            string[] wordArray = { "from", "salt", "earn", "last", "near", "form" };

            var wordsGroupedByAnagram = wordArray
           .GroupBy(word => String.Concat(word.OrderBy(c => c)));

            Console.WriteLine("\nWords grouped by anagrams:");
            foreach (var group in wordsGroupedByAnagram)
            {
                Console.WriteLine();
                foreach (var word in group)
                {
                    Console.WriteLine($"    {word}");
                }
            }
            #endregion



        }
    }
}
