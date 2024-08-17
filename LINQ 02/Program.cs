﻿using System.Collections;

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


        }
    }
}
