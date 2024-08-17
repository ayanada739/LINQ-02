using System.Collections;

namespace LINQ_02
{
    internal class Program
    {
        static void Main()
        {
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

        }
    }
}
