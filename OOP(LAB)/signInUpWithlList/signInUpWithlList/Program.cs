using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace signInUpWithlList
{
    class Program
    {
        class credentials
        {
            public string username;
            public string password;
        }
        static void Main(string[] args)
        {
            string path = "D:\\2nd SEMESTER\\OOP LAB\\OOP(LAB)\\signInUpWithlList\\text.txt";
            List<credentials> data = new List<credentials>();
            int option;
            readLogInData(path, data);

            do
            {

                option = menu();
                if (option == 1)
                {
                    credentials s1 = new credentials();
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);

                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter Name: ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string pin = Console.ReadLine();
                    bool flag = signIn(data, user, pin);
                    if (flag == true)
                    {
                        Console.WriteLine("Signed In Successfully..");
                    }
                    else
                    {
                        Console.WriteLine("You Have Entered Wrong Credentials..");
                    }
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    break;
                }
            }
            while (option != 3);
            Console.WriteLine("Press enter to exit....");
            Console.ReadKey();
        }

        static int menu()
        {
            Console.Clear();
            int option;
            Console.WriteLine(" Press 1 to SignUp");
            Console.WriteLine(" Press 2 to signIn");
            Console.WriteLine(" Press 3 to Exit");
            Console.WriteLine("Enter your choice....");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + ',' + p);
            file.Flush();
            file.Close();
        }

        static void readLogInData(string path, List<credentials> data)
        {
            StreamReader file = new StreamReader(path);
            string record;
            while ((record = file.ReadLine()) != null)
            {
                credentials s1 = new credentials();
                s1.username = parseData(record, 1);
                s1.password = parseData(record, 2);
                data.Add(s1);
            }
            file.Close();
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

        static bool signIn(List<credentials> data ,string user, string pin)
        {
            bool flag = false;

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].username == user && data[i].password == pin)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}
