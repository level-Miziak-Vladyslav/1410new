using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New1210.Domain
{
    #region Phonebook
    public class Phonebook
    {
        public static string[,] matrix = new string[100, 2];
        public static int LastIndexOf = 0;
        public void MainRun()
        {
            int keypress;
            try
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter task number");
                    Console.WriteLine("1 to add new phone number");
                    Console.WriteLine("2 to print list");
                    Console.WriteLine("3 to remove existing name or user by string equal");
                    Console.WriteLine("4 for quit");
                    Console.WriteLine();

                    keypress = int.Parse(Console.ReadLine()); // read keystrokes

                    //                    Console.WriteLine(" Your key is: " + keypress);
                    if (keypress == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter full name");
                        string a = Console.ReadLine();
                        Console.WriteLine("Enter phone number");
                        string b = Console.ReadLine();
                        matrix = AddNewNumber(a, b, matrix);
                        Console.WriteLine("User {0} was added", a);
                    }
                    if (keypress == 2)
                    {
                        DrawMatrix(matrix);
                    }
                    if (keypress == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter phone number or full name to remove");
                        string b = Console.ReadLine();
                        matrix = DelNumber(b, matrix);
                    }

                } while (keypress != 4);
                Console.WriteLine("Phonebook is closed");
            }
            catch (Exception exc)
            {
                Console.WriteLine();
                Console.WriteLine("Ошибка поймана" + exc);
                Console.WriteLine();
            }
        }
        public static string[,] AddNewNumber(string a, string b, string[,] m)
        {
            m[LastIndexOf, 0] = a;
            m[LastIndexOf, 1] = b;
            LastIndexOf++;
            return m;
        }
        public static void DrawMatrix(string[,] matrix)
        {
            for (int i = 0; i < LastIndexOf; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{(matrix[i, j].ToString().Length < 2 ? matrix[i, j].ToString() + "  |" : matrix[i, j].ToString() + " |")}");
                }
                Console.WriteLine();
            }
        }
        public static string[,] DelNumber(string b, string[,] m)
        {
            bool f = false;
            for (int i = 0; i < LastIndexOf; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (m[i, j] == b)
                    {
                        Console.WriteLine("User {0} founded and deleted", m[i, 0]);
                        f = true;
                        for (int z = i; z < LastIndexOf; z++)
                        {
                            m[z, 0] = m[z + 1, 0];
                            m[z, 1] = m[z + 1, 1];
                        }
                    }
                }
                Console.WriteLine();
            }
            if (f == false)
            {
                Console.WriteLine("User not found");
            }
            LastIndexOf--;
            return m;
        }
    }
    #endregion
    #region Car
    public interface IStoring
    {
        double GetStoringTerm();
    }
    public class Car : IStoring
    {
        public string Name
        {
            get; set;
        }
        private double _price;
        public Double Price
        {
            get
            {
                return Deal(_price);
            }
            set
            {
                _price = value;
            }
        }
        public virtual double Deal(double _price)
        {
            _price = _price * 0.8;
            return _price;
        }

        public virtual double GetStoringTerm()
        {

            return Deal(_price);
        }
    }
    public class Minivan : Car, IStoring
    {
        public int Capacity
        {
            get; set;
        }
        public override double Deal(double _price)
        {

            //           if (DateTime.Now.Month )
            _price = _price * 0.5;
            return _price;
        }

    }
    public class Truck : Car
    {
        public int Carrying
        {
            get; set;
        }
        public override double Deal(double _price)
        {
            _price = _price * 0.6;
            return _price;
        }

        public override double GetStoringTerm()
        {
            return Deal(Price);
        }
    }


    public class CarsMain
    {
        public void MainRun()
        {
            Car c1 = new Car();
            Console.WriteLine("Please input the name of car1");
            c1.Name = Console.ReadLine();
            Console.WriteLine("Please input price of car1");
            c1.Price = double.Parse(Console.ReadLine());

            var c2 = new Minivan();
            Console.WriteLine("Please input the name of car2");
            c2.Name = Console.ReadLine();
            c2.Capacity = 7;
            Console.WriteLine("Please input price of car2");
            string s2 = Console.ReadLine();
            double i2;
            double.TryParse(s2, out i2);
            c2.Price = i2;

            var c3 = new Truck();
            Console.WriteLine("Please input the name of car2");
            c3.Name = Console.ReadLine();
            c3.Carrying = 16;
            Console.WriteLine("Please input price of car2");
            string s3 = Console.ReadLine();
            double i3;
            double.TryParse(s3, out i3);
            c3.Price = i3;
            Car[] cars = new Car[3];
            cars[0] = c1;
            cars[1] = c2;
            cars[2] = c3;
            if (c1 is IStoring stored)
            {
                c1.Price = 1000;
            }
            if (c2 is IStoring stored1)
            {
                c2.Price = 1000;
            }
            if (c3 is IStoring stored2)
            {
                c3.Price = 1000;
            }


            //            foreach c in cars { }
            Console.WriteLine("Name of car 1 {0}, Price car 1 {1}", c1.Name, c1.Price);
            Console.WriteLine("Name of car 2 {0}, Price car 2 {1}", c2.Name, c2.Price);
            Console.WriteLine("Name of car 3 {0}, Price car 3 {1}", c3.Name, c3.Price);
        }
    }
    #endregion
    #region ITSchool
    public class ITSchool
    {
        static int Qp = 0;
        static string[,] BasePeople;
        public void MainRun()
        {
            Qp = 0;
            int s = 0;
            int dc = 0;
            int l = 0;
            int a = 0;

            BasePeople = new string[1000, 3];
            Console.WriteLine("Please input total number of student");
            s = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of professor assistant");
            dc = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of lecturer");
            l = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of assistant");
            a = int.Parse(Console.ReadLine());
            MakePerson(s, dc, l, a);
            Console.WriteLine("List of person. Name // Role");
            DrawMatrix(BasePeople);
            int fs = s;
            int fh = (dc + l + a);
            int i = 0;
            ITGroup[] g = new ITGroup[fh];
            while (fs > 0)
            {
                if (i == fh)
                {
                    Console.WriteLine("No free teachers, students without group: {}",fs);
                    break;
                }
                g[i] = new ITGroup(BasePeople[(Qp-i-1),1]);
                int rs = s - fs;
                for (int p = rs; p < (g[i].Qs + rs); p++)
                {
                     g[i].sl[p - rs] = BasePeople[p, 0];
                    BasePeople[p, 2] = g[i].HeadName;
                }
                fs = fs - g[i].Qs;
                i++;
            }
            Console.WriteLine("");
            DrawMatrix(BasePeople);
        }
        public static void DrawMatrix(string[,] matrix)
        {
            for (int i = 0; i < Qp; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{(matrix[i, j].ToString().Length < 2 ? matrix[i, j].ToString() + "  |" : matrix[i, j].ToString() + " |")}");
                }
                Console.WriteLine();
            }
        }

        void MakePerson(int s, int dc, int l, int a)
        {
            for (int i = 0; i < (s + dc + l + a); i++)
            {
                if (Qp < s)
                {
                    BasePeople[i, 0] = "Student # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "Student";
                    BasePeople[i, 2] = "0";
                }
                else if (Qp < s + dc)
                {
                    BasePeople[i, 0] = "professor assistant # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "professor assistant";
                    BasePeople[i, 2] = "0";
                }
                else if (Qp < s + dc + l)
                {
                    BasePeople[i, 0] = "lecturer # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "lecturer";
                    BasePeople[i, 2] = "0";
                }
                else
                {
                    BasePeople[i, 0] = "assistant # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "assistant";
                    BasePeople[i, 2] = "0";
                }

                Qp++;
            }
        }
        struct ITGroup
        {
            public string[] sl;
            public string HeadName;
            public int Qs;
            public ITGroup(string hn)
            {
                HeadName = hn;
                for (int i = 0; i < Qp; i++)
                {
                    if (BasePeople[i, 0] == hn)
                    {
                        string HeadType = BasePeople[i, 1];
                    }
                }
                if (hn == "professor assistant")
                {
                    Qs = 20;
                }
                else if (hn == "lecturer")
                {
                    Qs = 15;
                }
                else
                {
                    Qs = 5;
                }
                sl = new string[Qs];
            }
        }
    }








    #endregion
    public class Service
    {

    }
}
