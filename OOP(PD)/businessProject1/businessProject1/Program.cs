using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace businessProject1
{
    class Program
    {
        class credentials
        {
            public string username;
            public string password;
            public string role;
        }
        class products
        {
            public string productCategory;
            public string productName;
            public int productPrice;
            public int productQuantity;
        }
        class order
        {
            public string customerName;
            public string productCategory;
            public string productName;
            public int productPrice;
            public int productQuantity;
            public int bill;
        }
        static void Main(string[] args)
        {
            int choice;
            string logInPath = "D:\\2nd SEMESTER\\OOP LAB\\OOP(PD)\\businessProject1\\logInInfo.txt";
            string productPath = "D:\\2nd SEMESTER\\OOP LAB\\OOP(PD)\\businessProject1\\product.txt";
            string orderPath = "D:\\2nd SEMESTER\\OOP LAB\\OOP(PD)\\businessProject1\\orderInfo.txt";
            List<credentials> user = new List<credentials>();
            List<products> pro = new List<products>();
            List<order> orders = new List<order>();

            readLoginData(logInPath, user);
            readProductData(productPath, pro);
            do
            {
                choice = menu();
                if (choice == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    Console.WriteLine("Enter Role: ");
                    string r = Console.ReadLine();
                    signUp(logInPath, n, p, r);

                }
                string n1;
                if (choice == 2)
                {
                    Console.WriteLine("Enter Name: ");
                    n1 = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    string r = signIn(n1, p, user);

                    if (r == "admin")
                    {
                        int adminChoice;
                        do
                        {
                            adminChoice = adminMenu();
                            if (adminChoice == 1)
                            {
                                clearScreen();
                                viewProduct(pro);
                                Console.ReadKey();
                            }
                            else if (adminChoice == 2)
                            {
                                Console.WriteLine("Enter Product Category: ");
                                string pCat = Console.ReadLine();
                                Console.WriteLine("Enter Product Name: ");
                                string pName = Console.ReadLine();
                                Console.WriteLine("Enter Product Price: ");
                                int pPrice = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Product Quantity: ");
                                int pQuantity = int.Parse(Console.ReadLine());
                                addProduct(productPath, pCat, pName, pPrice, pQuantity);

                            }
                            else if (adminChoice == 3)
                            {
                                clearScreen();
                                viewProduct(pro);
                                updateproduct(pro);
                            }
                            else if (adminChoice == 4)
                            {
                                clearScreen();
                                viewProduct(pro);
                                deleteProduct(pro);
                            }
                            else if (adminChoice == 5)
                            {
                                viewOrders(orders);
                            }
                            else if (adminChoice == 6)
                            {
                                break;
                            }
                        }
                        while (adminChoice != 6);
                        clearScreen();

                    }
                    else if (r == "customer")
                    {
                        int customerChoice;
                        do
                        {
                            customerChoice = customerMenu();
                            if (customerChoice == 1)
                            {
                                viewProduct(pro);
                                Console.ReadKey();
                            }
                            else if (customerChoice == 2)
                            {
                                viewProduct(pro);
                                makeOrder(orders, pro, n1);
                            }
                            else if (customerChoice == 3)
                            {
                                viewCart(orders, n1);
                            }
                            else if (customerChoice == 4)
                            {
                                // giveFeedBack();
                            }
                            else if (customerChoice == 5)
                            {
                                break;
                            }
                        }
                        while (customerChoice != 5);

                    }
                    else if (r == "null")
                    {
                        Console.WriteLine(" > Invalid user!!");
                        Console.ReadKey();
                    }
                

                }
                if (choice == 3)
                {
                    break;
                }
            }
            while (choice != 3);
            clearScreen();
        }

        static int menu()
        {
            Console.Clear();
            int option;
            Console.WriteLine("1. SignUp ");
            Console.WriteLine("2. SignIn ");
            Console.WriteLine("3. Exit ");
            Console.WriteLine("Enter Your Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static int adminMenu()
        {
            Console.Clear();
            int option;
            Console.WriteLine("1. View List of Products");
            Console.WriteLine("2. Add Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. View Orders");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter Your Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static int customerMenu()
        {
            clearScreen();
            int option;
            Console.WriteLine("1. View List of Products");
            Console.WriteLine("2. Make Order");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Give FeedBack");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter Your Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void signUp(string path, string n, string p, string r)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + ',' + p + ',' + r);
            file.Flush();
            file.Close();
        }

        static void readLoginData(string path, List<credentials> user)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while ((record = file.ReadLine()) != null)
                {
                    credentials data = new credentials();
                    data.username = parseData(record, 1);
                    data.password = parseData(record, 2);
                    data.role = parseData(record, 3);
                    user.Add(data);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("File Does Not EXISTS!!");
            }
        }

        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for(int i = 0; i < record.Length; i++)
            {
                if (record[i] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[i];
                }
            }
            return item;
        }

        static string signIn(string n, string p, List<credentials> user)
        {
            string r = "";
            for (int x = 0; x < user.Count; x++)
            {
                if (n == user[x].username && p == user[x].password)
                {

                    r = user[x].role;
                    break;
                }
                else if (n != user[x].username || p != user[x].password)
                {

                    r = "null";
                }
            }
            return r;
            
        }

        static void viewProduct(List<products> pro)
        {
            for(int x = 0; x < pro.Count; x++)
            {
                Console.WriteLine("ProductCategory: {0}  ProductName: {1}  Product Price: {2}  ProductQuantuty: {3}", pro[x].productCategory, pro[x].productName, pro[x].productPrice, pro[x].productQuantity);
            }
        
        }

        static void addProduct(string path, string pCat, string pName, int pPrice, int pQuantity)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(pCat + ',' + pName + ',' + pPrice + ',' + pQuantity);
            file.Flush();
            file.Close();
        }

        static void readProductData(string path, List<products> pro)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string record;
                while((record = file.ReadLine()) != null)
                {
                    products info = new products();
                    info.productCategory = parseData(record, 1);
                    info.productName = parseData(record, 2);
                    info.productPrice = int.Parse(parseData(record, 3));
                    info.productQuantity = int.Parse(parseData(record, 4));
                    pro.Add(info);
                }
                file.Close();
            }
            else
            {
                Console.WriteLine("  File Does Not EXISTS!!");
            }
        }

        static void updateproduct(List<products> pro)
        {
            Console.WriteLine("Enter Name of Product You Want to update: ");
            string name = Console.ReadLine();
            for (int x = 0; x < pro.Count; x++)
            {
                if (name == pro[x].productName)
                {
                    Console.WriteLine("Enter Updated Price: ");
                    int price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Updated Quantity: ");
                    int quan = int.Parse(Console.ReadLine());

                    pro[x].productPrice = price;
                    pro[x].productQuantity = quan;
                }
                else
                {
                    Console.WriteLine(" > Product Not Found!!");
                }
            }
        }

        static void deleteProduct(List<products> pro)
        {
            Console.WriteLine("Enter Name of Product You Want to Delete: ");
            string name = Console.ReadLine();
            for (int x = 0; x < pro.Count; x++)
            {
                if ( name == pro[x].productName)
                {
                    pro[x].productCategory = pro[x + 1].productCategory;
                    pro[x].productName = pro[x + 1].productName;
                    pro[x].productPrice = pro[x + 1].productPrice;
                    pro[x].productQuantity = pro[x + 1].productQuantity;
                }
                else
                {
                    Console.WriteLine(" > Product Not Found!!");
                }
            }
        }

        static void makeOrder(List<order> orders, List<products> pro, string n1)
        {
            int bill = 0;
            order dat = new order();
            Console.WriteLine("Enter the name of product you want to buy: ");
            dat.productName = Console.ReadLine();
            Console.WriteLine("Enter the quantity you want: ");
            dat.productQuantity = int.Parse(Console.ReadLine());
            for (int x = 0; x < pro.Count; x++)
            {
                if (dat.productName == pro[x].productName)
                {
                    Console.WriteLine("Product Available...");
                    if (dat.productQuantity < pro[x].productQuantity)
                    {
                        Console.WriteLine("Quantity also Available...");
                        dat.customerName = n1;
                        dat.productPrice = pro[x].productPrice * dat.productQuantity;
                        dat.productCategory = pro[x].productCategory;
                        pro[x].productQuantity = pro[x].productQuantity - dat.productQuantity;
                    }
                    else if (dat.productQuantity > pro[x].productQuantity)
                    {
                        Console.WriteLine("Quantity not Available...");
                    }
                }
                else if (dat.productName != pro[x].productName)
                {
                    Console.WriteLine("Product not Available...");
                }
            }
            orders.Add(dat);
        }
        static void viewCart(List<order> orders, string n1)
        {
            int bill = 0;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].customerName == n1)
                {
                    bill = bill + orders[i].productPrice;
                    Console.WriteLine("ProductCategory: {0}  ProductName: {1}  Product Price: {2}  ProductQuantuty: {3}", orders[i].productCategory, orders[i].productName, orders[i].productPrice, orders[i].productQuantity);
                    Console.WriteLine(bill);
                }
            }
            
        }

        static void viewOrders(List<order> orders)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                Console.WriteLine("Customer Name: {0}  ProductCategory: {1}  ProductName: {2}  Product Price: {3}  ProductQuantuty: {4}  Bill: {5}", orders[i].customerName, orders[i].productCategory, orders[i].productName, orders[i].productPrice, orders[i].productQuantity, orders[i].bill);
            }
        }

        static void saveOrderInfo(List<order> orders, string path)
        {
            StreamWriter file = new StreamWriter(path, true);
            for (int x = 0; x < orders.Count; x++)
            {
                file.WriteLine(orders[x].customerName + ',' + orders[x].productCategory + ',' + orders[x].productName + ',' + orders[x].productPrice + ',' + orders[x].productQuantity + ',' + orders[x].bill);        
            }
            file.Flush();
            file.Close();
        }

        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
