using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEK01
{
    class Program
    {
        static void Main(string[] args)
        {
            task14();
        }

        static void task1()
        {
            Console.Write("Hello World");
            Console.Write("Hello World");
            Console.ReadKey();
        }

        static void task2()
        {
            Console.WriteLine("Hello World");
            Console.WriteLine("Hello World");
            Console.ReadKey();
        }

        static void task3()
        {
            float length;
            float area;
            string str;
            Console.WriteLine("Enter Length: ");
            str = Console.ReadLine();
            length = float.Parse(str);
            area = length * length;
            Console.Write("Area is {0}", area);
            Console.ReadKey();
        }

        static void task4()
        {
            string input;
            float marks;
            Console.Write("Enter Marks: ");
            input = Console.ReadLine();
            marks = float.Parse(input);

            if (marks > 50)
            {
                Console.Write("You are Passed");
            }
            else
            {
                Console.Write("You are Failed");
            }
            Console.ReadKey();
        }

        static void task5()
        {
            for (int x = 0; x < 5; x++)
            {
                Console.WriteLine("Welcome Jack");
            }
            Console.ReadKey();
        }

        static void task6()
        {
            int num;
            int sum = 0;
            Console.Write("Enter Number: ");
            num = int.Parse(Console.ReadLine());
            while(num != -1)
            {
                sum = sum + num;
                Console.Write("Enter Number: ");
                num = int.Parse(Console.ReadLine());
            }

            Console.Write("Total Sum is {0}", sum);
            Console.ReadKey();
      
        }

        static void task7()
        {
            int num;
            int sum = 0;
            do
            {
                Console.Write("Enter Number: ");
                num = int.Parse(Console.ReadLine());
                sum = sum + num;
            }
            while (num != -1);
            sum = sum + 1;
            Console.WriteLine("Total Sum is {0}", sum);
            Console.ReadKey();
        }

        static void task8()
        {
            int[] number = new int[3];
            for (int idx = 0; idx < 3; idx++)
            {
                Console.Write("Enter Number {0} ", idx);
                number[idx] = int.Parse(Console.ReadLine());
            }

            int large = -1;
            for (int idx = 0; idx < 3; idx++)
            {
                if (number[idx] > large)
                {
                    large = number[idx];
                }
            }

            Console.WriteLine("Largest Number is {0} ", large);
            Console.ReadKey();
        }

        static void task9()
        {
            int age;
            int toyPrice;
            float machinePrice;
            int saved = 0;
            int money = 0;
            int toys = 0;
            int toysprice;
            int totalSaved;
            float left;
            int count = 0;

            Console.Write("Enter Lily's Age: ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Unit price of each Toy: ");
            toyPrice = int.Parse(Console.ReadLine());
            Console.Write("Enter price of Washing Machine: ");
            machinePrice = float.Parse(Console.ReadLine());

            for (int x = 1; x <= age; x++)
            {
                if (x % 2 == 0)
                {
                    money = money + 10;
                    saved = saved + money;
                    count++;
                }
                if ( x % 2 != 0 )
                {
                   toys++;
                }
            }

            toysprice = toys * toyPrice;
            totalSaved = toysprice + saved - count;

            if (totalSaved > machinePrice)
            {
                left = totalSaved - machinePrice;
                Console.Write("YES!! {0} ", left);
            }
            else if (totalSaved < machinePrice)
            {
                left = machinePrice - totalSaved;
                Console.Write("No!! {0} ", left);
            }

            Console.ReadKey();
        }

        static void task10()
        {
            int num1;
            int num2;
            Console.Write("Enter First Number: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number: ");
            num2 = int.Parse(Console.ReadLine());

            int result = addition(num1, num2);
            Console.Write("Sum is {0} ", result);
            Console.ReadKey();
        }
        static int addition(int num1, int num2)
        {
            int sum;
            sum = num1 + num2;
            return sum;
        }

        static void task11()
        {
            string path = "D:\\2nd SEMESTER\\OOP LAB\\WEEK01\\file.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null )
                {
                    Console.WriteLine(record);
                }
                fileVariable.Close();
            }
            else
            {
                Console.Write("File does not exists");
            }

            Console.ReadKey();

        }
        static void task12()
        {
            string path = "D:\\2nd SEMESTER\\OOP LAB\\WEEK01\\file.txt";
            StreamWriter fileVariable = new StreamWriter(path, true);
            fileVariable.WriteLine("Hello");
            fileVariable.Flush();
            fileVariable.Close();

            Console.ReadKey();
        }

        static void task13()
        {
            string path = "D:\\2nd SEMESTER\\OOP LAB\\OOP(LAB)\\WEEK01\\text.txt";
            string[] names = new string[5];
            string[] password = new string[5];
            int option;
            do
            {
                readData(path, names, password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    signIn(n, p, names, password);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
            }
            while (option < 3);
            Console.ReadKey();
        }

        static int menu()
        {
            int option;
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. signUp");
            Console.WriteLine("Enter Option: ");
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

        static void readData(string path, string[] names, string [] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] =parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }

        static void signIn(string n, string p, string [] names, string [] password)
        {
            bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == names[x] && p == password[x])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }

        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }

        static void task14()
        {
            string path = "D:\\2nd SEMESTER\\OOP LAB\\OOP(LAB)\\WEEK01\\customer.txt";
            pizzaPoint(path, 5, 20);

            Console.ReadKey();
            
        }

        static void pizzaPoint(string path, int order, int price)
        {
            if (File.Exists(path))
            {
                StreamReader file = new StreamReader(path);
                string name;
                string nOrder;
                int noOrder;
                string data;
                string orders;
                while((data = file.ReadLine()) != null)
                {
                    name = parsing(data, 1);
                    nOrder = parsing(data, 2);
                    noOrder = int.Parse(nOrder);
                    orders = parsing(data, 3);

                   

                    if (noOrder >= order)
                    {   
                        int count = 0;
                        for (int x = 1; x <= noOrder; x++)
                        {
                            int noOfPrice = getParse(orders, x);
                            if (noOfPrice >= price)
                            {
                                count++;
                            }
                        }
                        if (count >= order)
                        {
                            Console.WriteLine(name);
                        }
                    }
                }
            }
        }

        static int getParse(string record, int field)
        {
            int comma = 1;
            string item = "";
            int digit = 0;
            for (int x = 1; x < record.Length - 1; x++)
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
            
            digit = int.Parse(item);
            return digit;
        }

        static string parsing(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ' ')
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

  
    }
}
