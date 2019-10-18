using System;
using System.Timers;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            Timer SnakeTimer = new Timer();
            SnakeTimer.Interval = 1000;
            Random r = new Random();
            int left = 50;
            int top = 20;
            object locker = 0;

            SnakeTimer.Elapsed += delegate
            {
                int i = r.Next(1, 9);
                switch (i)
                {
                    case 1:
                        top--;
                       break;
                    case 2:
                        left++;
                        top--;
                        break;
                    case 3:
                        left++;
                        break;
                    case 4:
                        left++;
                        top++;
                        break;
                    case 5:
                        top++;
                        break;
                    case 6:
                        left--;
                        top++;
                        break;
                    case 7:
                        left--;
                        break;
                    case 8:
                        left--;
                        top--;
                        break;
                    default:
                        break;
                }
                lock (locker)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(left, top);
                    Console.WriteLine("+");
                };
            };
   
            Timer clock = new Timer();
            clock.Interval = 1000;
            Random r2 = new Random();
            int Color = 1;

            clock.Elapsed += delegate
            {
                int ClockLeft = r2.Next(1, 120);
                int ClockTop = r2.Next(1, 30);
                lock (locker)
                {
                    ColorSelector(Color);
                    Console.SetCursorPosition(ClockLeft, ClockTop);
                    Console.WriteLine(DateTime.Now.ToLongTimeString());
                    Color++;
                };
            };

            void ColorSelector(int i)
            {
                switch (i)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Color = 1;
                        break;

                    default:
                        break;
                }
            };

            clock.Start();
            SnakeTimer.Start();
            Console.ReadLine();
            
        }
    }
}
