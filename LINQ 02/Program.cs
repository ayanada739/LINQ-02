using System.Collections;

namespace LINQ_02
{
    internal class Program
    {
        static void Main()
        {
            #region Casting Operators - Immediate Execution

            //List<Product> Result = ProductsList.Where(P => P.UnitsInStock == 0).ToList(); //Casting To List
            //Product[] Result = ProductsList.Where(P => P.UnitsInStock == 0).ToArray(); //Casting To Array

            //Dictionary<long, Product> Result = ProductsList.Where(P => P.UnitsInStock == 0).ToDictionary(P => P.ProductID);

            //Dictionary<long, Product> Result = ProductsList.Where(P => P.UnitsInStock == 0)
            //                                               .ToDictionary(P => P.ProductID , P => P.ProductName);

            //HashSet<Product> Result = ProductList.Where(P => P.UnitsInStock == 0).ToHashSet();


            //ArrayList Obj = new ArrayList()
            //{
            //    "Omar" ,
            //    "Ahmed" ,
            //    "Mona" ,
            //    "Aliaa" ,
            //    1 ,
            //    2 ,
            //    3 

            //};

            //var Result = Obj.OfType<string>();
            //foreach (var item in Result)
            //{
            //    Console.WriteLine (item );
            //}

            #endregion

            #region Generation Operators - Deffered Execution

            // Valid Only With Fluent Syntax only
            // The Only Way To Call Then Is As Static Methods From  

            //var Result = Enumerable.Range(0, 100); //0..99

            //Result = Enumerable.Repeat(2, 100);
            // Return IEnumerable Of 100 Element Each One = 2

            //var Result = Enumerable.Repeat(new Product(), 100);
            // // Return IEnumerable Of 100  Product

            // var arrayProduct = Enumerable.Empty<Product>().ToArray();

            // Product[] Products = new Product[0];
            // //Both Will Generate an Empty Array of Products

            // var List = Enumerable.Empty<Product>().ToList();
            // List<Product> products02 = new List<Product>();
            // //Both Will Generate an Empty List of Products

            // foreach (var item in Result)
            // {
            //     Console.WriteLine($"item");
            // }

            #endregion

            #region Set Operators [Union Family] - Deffered Excution

            //var Seq01 = Enumerable.Range(0, 100); //0..99
            //var Seq02 = Enumerable.Range(50, 100); //50..149

            ////var Result = Seq01.Union(Seq02);
            ////var Result = Seq01.Concat(Seq02);

            ////Result = Result.Distinct(); //Remove Duplication

            ////var Result = Seq01.Intersect(Seq02); // 50 .. 90

            //var Result = Seq01.Except(Seq02); // 0..49


            //Console.WriteLine("\n========Seq01==========");


            //foreach (var item in Seq01)
            //{
            //    Console.WriteLine($"{item} , ");
            //}

            //Console.WriteLine("\n=========Seq02=========");


            //foreach (var item in Seq02)
            //{
            //    Console.WriteLine($"{item} , ");
            //}

            //Console.WriteLine("\n=========Concat=========");


            //foreach (var item in Result)
            //  {
            //      Console.WriteLine($"item");
            //  }



            #endregion

            #region  Quantifier Operators - Return Boolean


            //var Result = ProductsList.Any();
            //// If Sequence Contains At Least One Element True
            //Result = ProductsList.Any(P => P.UnitsInStock == 0);
            //// If Sequence Contains At Least One Element Match Condition => True
            //Result = ProductsList.Any(P => P.UnitsInStock > 1000); // False
            //Result = ProductsList.All(P => P.UnitsInStock == 1);
            //// If All Elements in Sequence Match Condition Return True

            //var Seq01 = Enumerable.Range(0, 100); // 9..99
            //var Seq02 = Enumerable.Range(50, 100); // 50..149

            //Result = Seq01.SequenceEqual(Seq02);
            //Console.WriteLine(Result);

            #endregion

            #region Zip Operator - ZIP

            //string[] Name = { "Omar", "Ahmed", " Amr", "May", "Aya" };
            //int[] Numbers = Enumerable.Range(1, 10).ToArray();
            //Char[] Chars = { 'a', 'b', 'c', 'd', 'e' };

            ////var Result = Name.Zip(Numbers);
            //// (Omar , 1)
            //// (Ahmed , 2)
            //// (Amr , 3)
            //// (May , 4)
            //// (Aya , 5)

            ////var Result = Name.Zip(Numbers , (Name , Number)=> new { index = Number , Name} );

            //var Result = Name.Zip(Numbers, Chars);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            #region Grouping Operators
            #region Get Products Grouped by Category
            // Query Syntax
            //var Result = from P in ProductsList
            //            group P by P.Category;

            // Fluent Syntax
            //var Result = ProductsList.GroupBy(P => P.Category);

            //foreach (var category in Result)
            //{
            //    Console.WriteLine(category.key); // Name of Category
            //    foreach (var Product in category)
            //        Console.WriteLine($"   {Product.ProductName} ");
            //}

            #endregion

            #region Get Products in Stock Grouped by Category

            //var Result = ProductsList.Where(P => P.UnitsInStock > 0)
            //                         .GroupBy(P => P.Category);

            //Query Syntax
            //var Result = from P in ProductsList
            //             where P.UnitsInStock > 0
            //             group P by P.Category;

            #endregion

            #region Get Products in Stock Grouped by Category That Contains More Than 10 Product

            //// Query Syntax

            //var Result = from P in ProductsList
            //             where P.UnitsInStock > 0
            //             group P by P.Category
            //             into Category
            //             where Category.Count() > 10
            //             select Category;

            //// FLuent Syntax

            //Result = ProductsList.Where(P => P.UnitsInStock > 0)
            //                    .GroupBy(P => P.Category)
            //                    .where(P => P.Count() > 10);



            #endregion

            #region Get Products in Stock Grouped by Category That Contains More Than 10 Product And Number Of Products

            //// Fluent Syntax

            //var Result = ProductsList.Where(P => P.UnitsInStock > 0)
            //                          .GroupBy(P => P.Category)
            //                          .Where(C => C.count() > 10)
            //                          .Select(X => new
            //                          {
            //                              CategoryName = X.Key,
            //                              Count =  X.Count()
            //                          });

            ////Query Syntax

            //Result = from P in ProductsList
            //         where P.UnitsInStock > 0
            //         group P by P.Category
            //         into Category
            //         where Category.Count() > 10
            //         select new
            //         {
            //             CategoryName = Category.Key,
            //             Count = Category.Count()
            //         };


            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}



            #endregion

            //foreach (var category in Result)
            //{
            //    Console.WriteLine(category.key); // Name of Category
            //    foreach (var Product in category)
            //        Console.WriteLine($"   {Product.ProductName} ");
            //}

            #endregion

            #region Partitioning Operators

            //var Result= ProductList.Take(10);
            //// Take Number Of Elements From First Only
            //Result = ProductsList.Where(P => P.UnitsInStock > 0) . Take(5);
            //Result =  ProductsList . Where(P=> P.UnitsInStock > 0) . TakeLast(10);
            //// TakeLast Take Number of Elements From Last Only

            //var Result = ProductsList.Where(P => P.UnitsInStock == 0).Skip(2);
            //Skip Number of Elements From First And Get Rest of Elements
            //Result = ProductsList.Where(P => P.UnitsInStock == 0).SkipLast(2);
            //Skip Number of Elements From First And Get Rest of Elements

            //var Result = ProductsList.Skip(10).Take(10);

            //int[] Numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2};

            ////var Result = Numbers.TakeWhile((Num, I )=> Num > I);

            //var Result = Numbers.SkipWhile(Num => Num % 3 != 0);

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

            #endregion
        }
    }
}
