using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input number of Player Simple");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input number of PlayerNote");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input number of PlayerUber");
            int d = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input number of PlayerCheater");
            int e = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input number of PlayerUberCheater");
            int f = int.Parse(Console.ReadLine());
            Game a = new Game(b, c, d, e, f);
        }
    }
}
