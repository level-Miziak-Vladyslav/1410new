using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Game
    {
        Player[] pa;
        public static int start = 40, finish = 140;
        public Game(int sp, int pn, int pu, int pc, int puc)
        {

            Field f = new Field(start, finish);
            pa = new Player[sp + pn + pu + pc + puc];
            for (int i = 0; i < (sp + pn + pu + pc + puc); i++)
            {
                if (i < sp)
                {
                    pa[i] = new Player();
                    pa[i].PlayerNew("Player # " + (i + 1).ToString(), 1);
                }else if (i < (sp+pn))
                {
                    pa[i] = new PlayerNote();
                    pa[i].PlayerNew("PlayerNote # " + (i + 1).ToString(), 2);
                }else if (i < (sp + pn + pu))
                {
                    pa[i] = new PlayerUber();
                    pa[i].PlayerNew("PlayerUber # " + (i + 1).ToString(), 3);
                }else if (i < (sp + pn + pu +pc))
                {
                    pa[i] = new PlayerCheater();
                    pa[i].PlayerNew("PlayerCheater # " + (i + 1).ToString(), 4);
                }
                else
                {
                    pa[i] = new PlayerUberCheater();
                    pa[i].PlayerNew("PlayerUberCheater # " + (i + 1).ToString(), 5);
                }
            }
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine("Turn " + i);
                    foreach (Player p in pa)
                    {
                        System.Threading.Thread.Sleep(100);
                        int n = 0;
                        if (f.isprize(n = p.rolldice(f)) == true)
                        {
                            Console.WriteLine("Victory {0} with number {1}", p.name, n);
                            throw new Exception();
                        }
                        else
                        {
                            Console.WriteLine("        {0} overshot with number {1} ", p.name, n);
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
    class Player
    {
        public string name;
        public void PlayerNew(string n, int role)
        {
            name = n;
            int type = role;
        }
        public virtual int rolldice(Field f)
        {
            Random rand = new Random();
            return rand.Next(f.start, f.finish);
        }
    }
    class PlayerNote : Player
    {
        int[] p = new int[100];//проверенные им числа
        int i = 0; //счетчик ходов
        bool y = true;
        bool fr = true;
        int x;
        public override int rolldice(Field f)
        {
            Random rand = new Random();
            if (!fr)
            {
                do
                {
                    x = rand.Next(f.start, f.finish);

                    for (int ii = 0; ii < i; ii++)
                    {
                        if (p[ii] != x)
                        {
                            y = ii + 1 != i;
                        }
                    }

                } while (y);
                p[i] = x;
                i++;
                return x;
            }
            else
            {
                x = rand.Next(f.start, f.finish);
                fr = false;
                p[i] = x;
                i++;
                return x;
            }
        }
    }
    class PlayerUber : Player
    {
        int l = 0; //последнее проверенное им число
        public override int rolldice(Field f)
        {
            return f.start + l++;
        }
    }
    class PlayerCheater : Player
    {
        bool y = true;
        int x;
        public override int rolldice(Field f)
        {
            int[,] p = f.fi;
            Random rand = new Random();
            if (p.Length!=0)
            {
                do
                {
                    x = rand.Next(f.start, f.finish);
                    y = (p[x - f.start, 1] == x) && (p[x - f.start, 2] == 1);
                } while (y);
                return x;
            }
            else
            {
                x = rand.Next(f.start, f.finish);
                return x;
            }
        }
    }
    class PlayerUberCheater : Player
    {
        int l = 0; //последнее проверенное им число
        bool y = true;
        int x;
        public override int rolldice(Field f)
        {
            int[,] p = f.fi;
            x = l;
            if (p.Length != 0)
            {
                do
                {
                    x++;
                    y = (p[x, 1] == x + f.start) && (p[x, 2] == 1);
                } while (y);
                l = x;
                return x + f.start;
            }
            else
            {
                return x + f.start;
            }
        }
    }
    struct Field
    {
        public int[,] fi;
        int prize;
        public int length;
        public int start;
        public int finish;
        public Field(int s, int f)
        {
            start = s;
            finish = f;
            length = f - s;
            fi = new int[length, 3];
            for (int i = 0; i < length; i++)
            {
                fi[i, 0] = i; //порядковый
                fi[i, 1] = i + s;//номер
                fi[i, 2] = 0;//признак для читера
            }
            Random rand = new Random();
            prize = rand.Next(s, f);
            System.Threading.Thread.Sleep(1000);
        }
         public bool isprize(int t)
        {
            fi[t - start, 2] = 1;
            Console.WriteLine("                                                prize "+prize+" t "+t);
            return t == prize;
        }
    }
}
