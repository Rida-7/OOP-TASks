using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EZInput;

namespace gameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int spikeX = 18;
            int spikeY = 4;
            char[,] spike = new char [3, 11] {
                                             {' ', ' ', ' ', '.', '-', '`', '-', '.', ' ', ' ', ' '},
                                             {'.', '-', '=', '`', '=', ' ', '=', '`', '=', '-', '.'},
                                             {'(', 'O', '_', 'o', '_', '-', '_', 'o', '_', 'O', ')'}};

            int steelThunderX = 4;
            int steelThunderY = 4;

            char[,] steelThunder = new char [3, 7] {
                                                     { ' ', '_', '[', '`', ']', '_', ' '},
                                                     { '|', '_', '_', '_', '_', '_', '|'},
                                                     { '(', 'O', '_', 'o', '_', 'O', ')' } };
            string steelThunderDirection = "Down";

            int crusherX = 23;
            int crusherY = 12;

            char[,] crusher = new char [3, 9] {
                                                { ' ', ' ', '/', '"', '"', '"', '"', '\\', ' '},
                                                { '/', '"', '"', '"', '"', '"', '"', '"', '\\'},
                                                { '\\', '_', '@', '_', '@', '_', '@', '_', '/'}};
            string crusherDirection = "Down";

            int blazeX = 15;
            int blazeY = 24;

            char[,] blaze = new char[3, 9] {
                                            { ' ', '_', '(', '`', '`', ')', '=', '>', ' '},
                                            { '/', '~', '~', '~', '~', '~', '~', '~', '\\'},
                                            { '\\', 'O', '.', 'O', '.', 'O', '.', 'O', '/'}};
            string blazeDirection = "Right";

            int[] bulletX = new int[1000];
            int[] bulletY = new int[1000];
            int bulletCount = 0;
            int timer1 = 0;
            int timer2 = 0;
            int timer3 = 0;

            int score = 0;
            int crusher_Health = 7;
            int steelThunder_Health = 5;
            int blaze_Health = 9;
            int spike_Health = 19;

            int blazeBulletX = blazeX;
            int blazeBulletY = blazeY - 1;

            while (true)
            {
                int choice;
                do
                {
                    choice = menu();
                    clearScreen();
                    if (choice == 1)
                    {
                        bool game = true;
                        maze();
                        showSpike(spike,ref spikeX, ref spikeY);
                        while (game == true)
                        {
                            if (Keyboard.IsKeyPressed(Key.UpArrow))
                            {
                                moveSpikeUp(spike, ref spikeX, ref spikeY);
                            }
                            if (Keyboard.IsKeyPressed(Key.DownArrow))
                            {
                                moveSpikeDown(spike, ref spikeX, ref spikeY);
                            }
                            if (Keyboard.IsKeyPressed(Key.LeftArrow))
                            {
                                moveSpikeLeft(spike, ref spikeX, ref spikeY);
                            }
                            if (Keyboard.IsKeyPressed(Key.RightArrow))
                            {
                                moveSpikeRight(spike, ref spikeX, ref spikeY);
                            }
                            if (Keyboard.IsKeyPressed(Key.Space))
                            {
                                generateBullet(bulletX, bulletY, ref spikeX, ref spikeY, ref bulletCount);
                            }
                        }
                        


                    }
                    if (choice == 2)
                    {
                        keys();
                        clearScreen();
                    }
                }
                while (choice != 3);
                Console.Clear();
            }


        }
        static int menu()
        {
            int option;
            Console.WriteLine("1. Start");
            Console.WriteLine("2. Keys");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter Your Choice: ");
            option = int.Parse(Console.ReadLine());
            return option;
        }

        static void keys()
        {
            Console.WriteLine("KEYS");
            Console.WriteLine("  Up               Go Up");
            Console.WriteLine("  Down             Go Down");
            Console.WriteLine("  Left             Go Left");
            Console.WriteLine("  Right            Go Right");
            Console.WriteLine("  Space            Fire Bullet");
            Console.WriteLine("  Esc.             Exit");
        }

        static void maze()
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?    _____                                                                                                                                         _____     ?");
            Console.WriteLine("?   |     |                                                                                                                                       |     |    ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?   |_____|                                                                                                                                       |_____|    ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("?                                                                                                                                                            ?");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static void showSpike(char[,] spike, ref int spikeX, ref int spikeY)
        {
            Console.SetCursorPosition(spikeX, spikeY);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(spike [i, j]);
                }
                Console.SetCursorPosition(spikeX, spikeY + 1);
            }

        }

        static void moveSpikeLeft(char[,] spike, ref int spikeX, ref int spikeY)
        {
            if (spikeX - 1 == ' ' && spikeY == ' ')
            {
                eraseSpike(spike, ref spikeX, ref spikeY);
                spikeX = spikeX - 1;
                showSpike(spike, ref spikeX, ref spikeY);
            }
        }

        static void moveSpikeRight(char[,] spike, ref int spikeX, ref int spikeY)
        {
            if (spikeX + 11 == ' ' && spikeY == ' ')
            {
                eraseSpike(spike, ref spikeX, ref spikeY);
                spikeX = spikeX + 1;
                showSpike(spike, ref spikeX, ref spikeY);
            }
        }

        static void moveSpikeUp(char[,] spike, ref int spikeX, ref int spikeY)
        {
            if (spikeX == ' ' && spikeY - 1 == ' ')
            {
                eraseSpike(spike, ref spikeX, ref spikeY);
                spikeY = spikeY - 1;
                showSpike(spike, ref spikeX, ref spikeY);
            }
        }

        static void moveSpikeDown(char[,] spike, ref int spikeX, ref int spikeY)
        {
            if (spikeX == ' ' && spikeY + 1 == ' ')
            {
                eraseSpike(spike, ref spikeX, ref spikeY);
                spikeY = spikeY + 1;
                showSpike(spike, ref spikeX, ref spikeY);
            }
        }

        static void eraseSpike(char[,] spike, ref int spikeX, ref int spikeY)
        {
            Console.SetCursorPosition(spikeX, spikeY);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(" ");
                }
                Console.SetCursorPosition(spikeX, spikeY + 1);
            }
        }

        static void generateBullet(int [] bulletX, int[] bulletY, ref int spikeX, ref int spikeY, ref int bulletCount)
        {
            bulletX[bulletCount] = spikeX + 12;
            bulletY[bulletCount] = spikeY;
            Console.SetCursorPosition(spikeX + 14, spikeY);
            Console.WriteLine(".");
            bulletCount++;
        }


    }
}
