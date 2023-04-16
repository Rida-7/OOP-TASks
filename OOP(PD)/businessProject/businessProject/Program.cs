using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace businessProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string logInDataPath = "D:\\2nd SEMESTER\\OOP LAB\\OOP(PD)\\businessProject\\logInData.txt";
            string productDataPath = "D:\\2nd SEMESTER\\OOP LAB\\OOP(PD)\\businessProject\\productInfo.txt";
            int arrSize = 1000;
            int size = 500;
            int size1 = 1000;
            int productCount = 0;
            int userCount = 0;
            int buyProductCount = 0;
            string[] users = new string[arrSize];
            string[] passwords = new string[arrSize];
            string[] roles = new string[arrSize];
            string[] productName = new string[size];
            int[] productPrice = new int[size];
            int[] productQuantity = new int[size];
            string[] buyProduct = new string[size1];
            int[] buyProductPrice = new int[size1];
            int[] buyProductQuantity = new int[size1];

            int choice;
            readLogInData(logInDataPath, users, passwords, roles, ref userCount);
            readProductData(productDataPath, productQuantity, productName, productPrice, ref productCount);
            do
            {
                choice = menu();
                clearScreen();
                if (choice == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter Role: ");
                    string role = Console.ReadLine();

                    users[userCount] = name;
                    passwords[userCount] = password;
                    roles[userCount] = role;
                    userCount++;

                    signUp(logInDataPath, name, password, role);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    string rol = signIn(n, p, users, passwords, roles, ref userCount);

                    if (rol == "admin")
                    {
                        int adminChoice;
                        do
                        {
                            clearScreen();
                            adminChoice = adminMenu();
                            clearScreen();
                            if (adminChoice == 1)
                            {
                                viewProduct(productName, productPrice, productQuantity, ref productCount);
                            }
                            else if (adminChoice == 2)
                            {
                                Console.WriteLine("Enter Product Name: ");
                                string pName = Console.ReadLine();
                                Console.WriteLine("Enter Product Price: ");
                                int pPrice = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Quantity of Product: ");
                                int pQuantity = int.Parse(Console.ReadLine());
                                addProduct(pName, pPrice, pQuantity, productName, productPrice, productQuantity, ref productCount);
                                saveProductData(productDataPath, pName, pPrice, pQuantity);
                            }
                            else if (adminChoice == 3)
                            {
                                viewProduct(productName, productPrice, productQuantity, ref productCount);
                                deleteProduct(productName, productPrice, productQuantity, ref productCount);
                            }
                            else if (adminChoice == 4)
                            {
                                viewProduct(productName, productPrice, productQuantity, ref productCount);
                                updateProduct(productName, productPrice, productQuantity, ref productCount);
                            }
                            clearScreen();
                        }
                        while (adminChoice != 6);
                        clearScreen();

                    }
                    else if (rol == "customer")
                    {
                        int customerChoice;
                        do
                        {
                            customerChoice = customerMenu();
                            if (customerChoice == 1)
                            {
                                viewProduct(productName, productPrice, productQuantity, ref productCount);
                            }
                            else if (customerChoice == 2)
                            {
                                viewProduct(productName, productPrice, productQuantity, ref productCount);
                                Console.WriteLine("Enter the Product you want to Buy");
                                buyProduct[buyProductCount] = Console.ReadLine();
                                Console.WriteLine("Enter the quantity you want to Buy");
                                buyProductQuantity[buyProductCount] = int.Parse(Console.ReadLine());
                                for (int x = 0; x < productCount; x++)
                                {
                                    if ( buyProduct[buyProductCount] == productName[x])
                                    {
                                        Console.WriteLine("Product Available");
                                        if (buyProductQuantity[buyProductCount] < productQuantity[x])
                                        {
                                            Console.WriteLine("Quantity also Available");
                                            buyProductPrice[buyProductCount] = buyProductQuantity[buyProductCount] * productPrice[x];
                                            productQuantity[x] = productQuantity[x] - buyProductQuantity[buyProductCount];
                                            buyProductCount = buyProductCount + 1;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Quantity not Available");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Product Not Available");
                                    }
                                }
                            }
                            else if (customerChoice == 3)
                            {
                                int bill = 0;
                                viewProduct(buyProduct, buyProductPrice, buyProductQuantity, ref buyProductCount);
                                for (int x = 0; x < buyProductCount; x++)
                                {
                                    bill = bill + buyProductPrice[x];
                                }
                                Console.WriteLine("Total Price: ");
                                Console.WriteLine(bill);
                            }
                            clearScreen();

                        }
                        while (customerChoice != 4);
                        clearScreen();
                    }
                }
            }
            while (choice != 3);
            clearScreen();
            Console.ReadKey();
        }


        static int menu()
        {
            int option;
            Console.WriteLine("1. SignUp ");
            Console.WriteLine("2. SignIn ");
            Console.WriteLine("3. Exit ");
            Console.WriteLine("Enter Your Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }

        static void signUp(string path, string name, string password, string role)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(name + ',' + password + ',' + role);
            file.Flush();
            file.Close();
        }

        static string signIn(string n, string p, string[] users, string[] passwords, string[] roles, ref int userCount)
        {
            string r;
            for (int i = 0; i < userCount; i++)
            {
                if (n == users[i] && p == passwords[i])
                {
                    r = roles[i];
                    return r;
                }
            }
            return "userNotExists";

        }

        static void readLogInData(string path, string[] users, string[] passwords, string[] roles, ref int userCount)
        {

            StreamReader file = new StreamReader(path);
            string record;
            while ((record = file.ReadLine()) != null)
            {
                users[userCount] = parseData(record, 1);
                passwords[userCount] = parseData(record, 2);
                roles[userCount] = parseData(record, 3);
                userCount++;

            }
           
            file.Close();
        }

        static int adminMenu()
        {
            int option;
            Console.WriteLine("1. View List of Products");
            Console.WriteLine("2. Add Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter Your Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static int customerMenu()
        {
            int option;
            Console.WriteLine("1. View List of Products");
            Console.WriteLine("2. Make Order");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter Your Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void viewProduct(string[] productName, int[] productPrice, int[] productQuantity, ref int productCount)
        {
            Console.WriteLine("Product\t\tPrice\t\tQuantity");
            for (int x = 0; x < productCount; x++)
            {
                Console.WriteLine(productName[x] + "\t\t" + productPrice[x] + "\t\t" + productQuantity[x]);
            }

        }

        static void readProductData(string path, int[] productQuantity, string[] productName, int[] productPrice, ref int productCount)
        {

            StreamReader file = new StreamReader(path);
            string record;
            while ((record = file.ReadLine()) != null)
            {
                productName[productCount] = parseData(record, 1);
                productPrice[productCount] = int.Parse(parseData(record, 2));
                productQuantity[productCount] = int.Parse(parseData(record, 3));

                productCount++;
            }
            file.Close();

        }

        static void addProduct(string pName, int pPrice, int pQuantity, string[] productName, int[] productPrice, int[] productQuantity, ref int productCount)
        {
            productName[productCount] = pName;
            productPrice[productCount] = pPrice;
            productQuantity[productCount] = pQuantity;
            productCount++;
        }

        static void deleteProduct(string[] productName, int[] productPrice, int[] productQuantity, ref int productCount)
        {
            Console.WriteLine("Enter Product Name you want to DELETE: ");
            string product = Console.ReadLine();
            for (int x = 0; x < productCount; x++)
            {
                if (product == productName[x])
                {
                    for (int i = x; i < productCount - 1; i++)
                    {
                        productName[i] = productName[i + 1];
                        productPrice[i] = productPrice[i + 1];
                        productQuantity[i] = productQuantity[i + 1];
                    }
                    productCount = productCount - 1;
                }
            }
            Console.WriteLine("   > Product Deleted Successfully!!!");
        }

        static void updateProduct(string[] productName, int[] productPrice, int[] productQuantity, ref int productCount)
        {
            Console.WriteLine("Enter the name of product you want to update: ");
            string product = Console.ReadLine();
            for (int x = 0; x < productCount; x++)
            {
                if (product == productName[x])
                {
                    Console.WriteLine("Enter Updated Price: ");
                    int price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Updated Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    productPrice[x] = price;
                    productQuantity[x] = quantity;
                }
                else
                {
                    Console.WriteLine("Prdouct not found");
                }
            }
        }

        static void saveProductData(string path, string pName, int pPrice, int pQuantity)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(pName + ',' + pPrice + ',' + pQuantity);
            f.Flush();
            f.Close();
        }

        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
