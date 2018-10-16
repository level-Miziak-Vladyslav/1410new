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
    public class Car
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
                return _price;
            }
            set
            {
                _price = Deal(value);
            }
        }
        double Deal(double _price)
        {
            _price = _price / 2;
            return _price;
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


            Car c2 = new Car();
            Console.WriteLine("Please input the name of car2");
            c2.Name = Console.ReadLine();
            Console.WriteLine("Please input price of car2");
            string s2 = Console.ReadLine();
            double i2;
            double.TryParse(s2, out i2);
            c2.Price = i2;

            Console.WriteLine("Name of car 1 {0}, Price car 1 {1}", c1.Name, c1.Price);
            Console.WriteLine("Name of car 2 {0}, Price car 2 {1}", c2.Name, c2.Price);
        }
    }
    #endregion
    #region ITSchool
    public class ITSchool
    {
        public static int Qp = 0;
        public void MainRun()
        {
            Qp = 0;
            int s = 0;
            int d = 0;
            int dc = 0;
            int l = 0;
            int a = 0;

            string[,] BasePeople = new string[1000, 2];
            Console.WriteLine("Please input total number of student");
            s = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of Ph.D");
            d = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of professor assistant");
            dc = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of lecturer");
            l = int.Parse(Console.ReadLine());
            Console.WriteLine("Please input total number of assistant");
            a = int.Parse(Console.ReadLine());
            BasePeople = MakePerson(s,d,dc,l,a, BasePeople);
            DrawMatrix(BasePeople);

        }
        public static void DrawMatrix(string[,] matrix)
        {
            for (int i = 0; i < Qp; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{(matrix[i, j].ToString().Length < 2 ? matrix[i, j].ToString() + "  |" : matrix[i, j].ToString() + " |")}");
                }
                Console.WriteLine();
            }
        }

        string[,] MakePerson(int s, int d, int dc, int l, int a, string[,] BasePeople)
        {
            for (int i = 0; i < (s+d+dc+l+a); i++)
            {
                if(Qp < s)
                {
                    BasePeople[i, 0] = "Student # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "Student";
                }
                else if(Qp < s + d)
                {
                    BasePeople[i, 0] = "Ph.D # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "Ph.D";
                }
                else if (Qp < s + d + dc)
                {
                    BasePeople[i, 0] = "professor assistant # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "professor assistant";
                }
                else if (Qp < s + d + dc + l)
                {
                    BasePeople[i, 0] = "lecturer # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "lecturer";
                }
                else 
                {
                    BasePeople[i, 0] = "assistant # " + (Qp + 1).ToString();
                    BasePeople[i, 1] = "assistant";
                }

                Qp++;
            }
            return BasePeople;
        }        
    }

    

    

    

    
    #endregion
    public class Service
    {

    }
}
