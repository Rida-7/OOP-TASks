using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week2task2
{
    class Program
    {
        class products
        { 
            public string productID;
            public string productName;
            public string productCategory;
            public int productPrice;
            public string brandName;
            public string country;
        }
        static void Main(string[] args)
        {
            products[] s = new products[10];
            int option;
            int count = 0;
            do
            {
                option = menu();
                if (option == 1)
                {
                    s[count] = addProduct();
                    count = count + 1;
                }
                else if (option == 2)
                {
                    viewProduct(s, count);
                }
                else if (option == 3)
                {
                    int worth = totalStoreWorth(s, count);
                    Console.WriteLine("Store Total Worth: {0}", worth);
                    Console.ReadKey();
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            }
            while (option != 4);
            Console.WriteLine("Press Enter to Exit...");
            Console.ReadKey();
        }

        static int menu()
        {
            Console.Clear();
            int option;
            Console.WriteLine(" Press 1 for ADDING PRODUCT");
            Console.WriteLine(" Press 2 to VIEW PRODUCTS");
            Console.WriteLine(" Press 3 for STORE TOTAL WORTH");
            Console.WriteLine(" Press 4 to EXIT");
            Console.WriteLine("Enter your choice...");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static products addProduct()
        {
            Console.Clear();
            products s1 = new products();
            Console.WriteLine("Enter Product ID: ");
            s1.productID = Console.ReadLine();
            Console.WriteLine("Enter Product Name: ");
            s1.productName = Console.ReadLine();
            Console.WriteLine("Enter Product Category: ");
            s1.productCategory = Console.ReadLine();
            Console.WriteLine("Enter Product Price: ");
            s1.productPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Brand Name: ");
            s1.brandName = Console.ReadLine();
            Console.WriteLine("Enter Name of Country: ");
            s1.country = Console.ReadLine();
            return s1;
        }

        static void viewProduct(products[] s, int count)
        {
            Console.Clear();
            Console.WriteLine("ID \t\t Name \t\t Category \t\t Price \t\t BrandName \t\t Country");
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine(s[x].productID + "\t\t" + s[x].productName + "\t\t" + s[x].productCategory + "\t\t" + s[x].productPrice + "\t\t" + s[x].brandName + "\t\t" + s[x].country);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static int totalStoreWorth(products[] s, int count)
        {
            Console.Clear();
            int total = 0;
            for (int x = 0; x < count; x++)
            {
                total = total + s[x].productPrice;
            }
            return total;
        }
    }
}
