using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ProductManagement
{
    class ProductUI
    {
        internal static int Options()
        {

            Console.WriteLine("Enter the Choice");
            Console.WriteLine("\t1.Show All Products \n\t2.Product Details\n\t3.Add Product\n\t4.Update Product\n\t5.Quit");
            int choice1 = int.Parse(Console.ReadLine());
            return choice1;
           
        }
        internal static void Test()
        {
           int choice = Options();

            ProductProcess process = new ProductProcess();
            
            //Invalid Input From the user
                if (choice >= 6)
                {
                    Console.WriteLine("Entered Invalid choice Press Any key to continue");
                Console.Clear();
                Options();
                }

              //Show all the products  
                if (choice == 1)
                {
                    try
                    {
                        string criteria = "";
                        var list = process.GetProducts(criteria);
                        foreach (var item in list)
                        {
                            Console.WriteLine("{0},{1},{2},{3},{4}",
                            item.ProductId, item.ProductName, item.UnitPrice, item.UnitsInStock, item.Discontinued);
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }
                Options();

                }
//Show particular Product Details by taking ID
                if (choice == 2)
                {
                    try
                    {
                        Product p = new Product();
                        Console.WriteLine("Enter the ProductId");

                        int id = int.Parse(Console.ReadLine());

                        p = process.GetProductsDetails(id);

                        Console.WriteLine($"{p.ProductId}, {p.ProductName}, {p.UnitPrice}, {p.UnitsInStock}, {p.Discontinued}");
                        Console.ForegroundColor = ConsoleColor.Red;


                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);

                    }

                }
                //Add the new Product Details for the product Details table
                if (choice == 3)
                {

                    Console.WriteLine();
                    Console.WriteLine("*************CREATE NEW PRODUCT*************");
                    Console.WriteLine();
                    Product obj = new Product();

                    Console.WriteLine("Product Name");
                    obj.ProductName = Console.ReadLine();
                    Console.WriteLine("Unit Price:");
                    obj.UnitPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Units In Stock:");
                    obj.UnitsInStock = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Discontinued:");
                    obj.Discontinued = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("Category ID[between 1 and 8:");
                    obj.CategoryId = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        ProductProcess process1 = new ProductProcess();
                        process1.CreateProduct(obj);
                        Console.WriteLine("\nProduct Succesfully added.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
                //Update the Existing product
            if (choice == 4)
            {

                Console.WriteLine();
                Console.WriteLine("*************Update PRODUCT*************");
                Console.WriteLine();
                Product obj = new Product();

            
                try
                {
                    ProductProcess process1 = new ProductProcess();
                    Console.WriteLine("Enter the product Id");
                     obj.ProductId=int.Parse( Console.ReadLine());
                    //if(id==obj.ProductId.)
                    //{
                    //    process1.GetProductsDetails(obj.ProductId);
                    //}
                    Console.WriteLine("Product Name");
                    obj.ProductName = Console.ReadLine();
                    Console.WriteLine("Unit Price:");
                    obj.UnitPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Units In Stock:");
                    obj.UnitsInStock = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Discontinued:");
                    obj.Discontinued = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("Category ID[between 1 and 8:");
                    obj.CategoryId = Convert.ToInt32(Console.ReadLine());


                    process1.UpdateProduct(obj);
                    Console.WriteLine("\nProduct Succesfully added.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            //Quit from the application
            if(choice==5)
            {
                Environment.Exit(0);
            }
        }
    }

    }

        
   
