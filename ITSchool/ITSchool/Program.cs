using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSchool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please input total number of professor assistant");
            int dc = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of lecturer");
            int l = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of assistant");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of student");
            int s = int.Parse(Console.ReadLine());
            MainPerson m = new MainPerson();
            m.MakePersonP(s, dc, l, a);
        }
    }
}
