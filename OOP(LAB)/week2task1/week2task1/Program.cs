using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week2task1
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
            string path = "D:\\2nd SEMESTER\\OOP LAB\\OOP(LAB)\\week2task1\\logInData.txt";
            credentials[] s = new credentials[10];
            int option;
            int count = 0;
            count = readLogInData(path, s);

            do
            {
               
                option = menu();
                if (option == 1)
                {
                    s[count] = signUp();
                    count++;
                    saveLogInData(path, s, count);

                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter Name: ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string pin = Console.ReadLine();
                    bool flag = signIn(s, count, user, pin);
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
        static credentials signUp()
        {
            credentials s1 = new credentials(); 
            Console.WriteLine("Enter Name: ");
            s1.username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            s1.password = Console.ReadLine();
            return s1;
            
        }
        static void saveLogInData(string path, credentials[] s, int count)
        {
            StreamWriter file = new StreamWriter(path, true);
            for (int i = 0; i < count; i++)
            {
                file.WriteLine(s[i].username + ',' + s[i].password);
            }
            file.Flush();
            file.Close();
        }

        static int  readLogInData(string path, credentials[] s)
        {
            int x = 0;
            StreamReader file = new StreamReader(path);
            string record;
            while((record = file.ReadLine()) != null)
            {
                credentials s1 = new credentials();
                s1.username = parseData(record, 1);
                s1.password = parseData(record, 2);
              //  x = x + 1;
                s[x++] = s1;
            }
            file.Close();
            return x;
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

        static bool signIn(credentials[] s, int count, string user, string pin)
        {
            bool flag = false;

            for (int i = 0; i < count; i++)
            {
                if (s[i].username == user && s[i].password == pin)
                {
                    flag = true;
                }
            }
            return flag;
        }
    }
}
