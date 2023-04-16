using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    class Program
    {
        class students
        {
            public string name;
            public int rollNo;
            public float cgpa;
            public char isHostelide;
            public string department;
        }
        
        static void Main(string[] args)
        {
            task4();
            Console.ReadKey();
        }

        static void task4()
        {
            students[] s = new students[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                if (option == '1')
                {
                    s[count] = addStudent();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewStudent(s, count);
                }
                else if (option == '3')
                {
                    topStudent(s, count);
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice");
                }
            }
            while (option != '4') ;
            Console.WriteLine("Press Enter to Exit...");
              
        }

        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press1 for Adding a Student: ");
            Console.WriteLine("Press2 for view Student: ");
            Console.WriteLine("Press3 for Top Three Students: ");
            Console.WriteLine("Press4 to EXIt: ");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }

        static students addStudent()
        {
            Console.Clear();
            students s1 = new students();
            Console.WriteLine("Enter Name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter Roll No.: ");
            s1.rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Department: ");
            s1.department = Console.ReadLine();
            Console.WriteLine("Is Hostelide (y || n):");
            s1.isHostelide = char.Parse(Console.ReadLine());
            return s1;
        }

        static void viewStudent(students[] s , int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Name: {0} Roll No.: {1} CGPA {2} Department: {3} IsHostelide: {4}", s[i].name, s[i].rollNo, s[i].cgpa, s[i].department, s[i].isHostelide);
            }
            Console.WriteLine("Press any key to Continue.... ");
            Console.ReadKey();
        }

        static void topStudent(students[] s, int count)
        {
            Console.Clear();
            if (count == 0)
            {
                Console.WriteLine("No Record Present");
            }
            else if (count == 1)
            {
                viewStudent(s, 1);
            }
            else if (count == 2)
            {
                for (int x = 0; x < 2; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 2);
            }
            else
            {
                for (int x = 0; x < 3; x++)
                {
                    int index = largest(s, x, count);
                    students temp = s[index];
                    s[index] = s[x];
                    s[x] = temp;
                }
                viewStudent(s, 3);
            }
        }

        static int largest(students[] s, int start, int end)
        {
            int index = start;
            float large = s[start].cgpa;
            for (int x = start; x < end; x++)
            {
                if (large < s[x].cgpa)
                {
                    large = s[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
        static void task1()
        {
            students s1 = new students();
            s1.name = "Ali";
            s1.rollNo = 12;
            s1.cgpa = 3.6F;
            Console.WriteLine("Name: {0}  Roll no.: {1}  CGPA: {2}", s1.name, s1.rollNo, s1.cgpa);
        }

        static void task2()
        {
            students s1 = new students();
            s1.name = "Ali";
            s1.rollNo = 12;
            s1.cgpa = 3.6F;
            Console.WriteLine("Name: {0}  Roll no.: {1}  CGPA: {2}", s1.name, s1.rollNo, s1.cgpa);

            students s2 = new students();
            s2.name = "Ahmad";
            s2.rollNo = 15;
            s2.cgpa = 3.0F;
            Console.WriteLine("Name: {0} Roll No.: {1} CGPA: {2}", s2.name, s2.rollNo, s2.cgpa);
        }

        static void task3()
        {
            students s3 = new students();
            Console.WriteLine("Enter Name: ");
            s3.name = Console.ReadLine();
            Console.WriteLine("Enter Roll No.: ");
            s3.rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA: ");
            s3.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name: {0} Roll No.: {1} CGPA: {2}", s3.name, s3.rollNo, s3.cgpa);
        }
    }
}
