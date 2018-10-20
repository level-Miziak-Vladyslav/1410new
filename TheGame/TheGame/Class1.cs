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
        public static int start = 40, finish = 1400;
        public Game(int sp, int pn, int pu, int pc, int puc)
        {
            int[,] sg;
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
                for (int i = 0; i < 100;)
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
                            i++;
                            Console.WriteLine("  {0} overshot with number {1}", p.name, n);
                            if (i == 99)
                            {
                                Console.WriteLine("SuperGame");
                                int e = f.finish - f.start;
                                foreach (Player pp in pa)
                                {
                                    int d = f.finish - f.start;
                                    foreach (int j in pp.p)
                                    {
                                        d = f.SuperGame(j) < d ? (d = f.SuperGame(j)) : d;
                                        pp.bs = d;
                                    }
                                    if (d < e)
                                    {
                                        e = d;
                                    }
                                }
                                foreach (Player pp in pa)
                                {
                                    if (pp.bs == e)
                                    {
                                        Console.WriteLine("{0} win SuperGame won with an error {1}", pp.name, pp.bs);
                                    }
                                }
                                throw new Exception();
                            }
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
        protected int i = 0; //счетчик ходов
        public int[] p = new int[100];//проверенные им числа
        public int bs;
        public string name;
        public void PlayerNew(string n, int role)
        {
            name = n;
            int type = role;
        }
        public virtual int rolldice(Field f)
        {
            Random rand = new Random();
            i++;
            return (p[i-1] = rand.Next(f.start, f.finish));
        }
    }
    class PlayerNote : Player
    {

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
                i++;
                return (p[i-1] = x);
            }
            else
            {
                x = rand.Next(f.start, f.finish);
                fr = false;
                i++;
                return (p[i-1] = x);
            }
        }
    }
    class PlayerUber : Player
    {
        int l = 0; //последнее проверенное им число
        public override int rolldice(Field f)
        {
            i++;
            return (p[i - 1] = f.start + l++);
        }
    }
    class PlayerCheater : Player
    {
        bool y = true;
        int x;
        public override int rolldice(Field f)
        {
            int[,] pz = f.fi;
            Random rand = new Random();
            if (p.Length!=0)
            {
                do
                {
                    x = rand.Next(f.start, f.finish);
                    y = (pz[x - f.start, 1] == x) && (pz[x - f.start, 2] == 1);
                } while (y);
                i++;
                return (p[i-1] = x);
            }
            else
            {
                x = rand.Next(f.start, f.finish);
                i++;
                return (p[i-1] = x);
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
            int[,] pz = f.fi;
            x = l;
            if (p.Length != 0)
            {
                do
                {
                    x++;
                    y = (pz[x, 1] == x + f.start) && (pz[x, 2] == 1);
                } while (y);
                l = x;
                i++;
                return (p[i - 1] = x + f.start);
            }
            else
            {
                i++;
                return (p[i - 1] = x + f.start);
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
        public int SuperGame(int l)
        {
            return ((l - prize) > 0 ? (l - prize) : (-l + prize));
        }
         public bool isprize(int t)
        {
            fi[t - start, 2] = 1;
            Console.WriteLine("                                                prize "+prize+" t "+t);
            return t == prize;
        }
    }
}
