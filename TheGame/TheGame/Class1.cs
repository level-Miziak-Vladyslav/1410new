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
        public Game(int sp, int pn, int pu, int pc, int puc)
        {
            Field f = new Field(0, 100);
            pa = new Player[sp + pn + pu + pc + puc];
            for (int i = 0; i < (sp + pn + pu + pc + puc); i++)
            {
                if (i < sp)
                {
                    pa[i] = new Player();
                    pa[i].PlayerNew("Player type Player # " + (i + 1).ToString(), 1);
                }
                if (i < (sp+pn))
                {
                    pa[i] = new PlayerNote();
                    pa[i].PlayerNew("Player type PlayerNote # " + (i + 1).ToString(), 2);
                }
                if (i < (sp + pn + pu))
                {
                    pa[i] = new PlayerUber();
                    pa[i].PlayerNew("Player type PlayerUber # " + (i + 1).ToString(), 3);
                }
                if (i < (sp + pn + pu +pc))
                {
                    pa[i] = new PlayerCheater();
                    pa[i].PlayerNew("Player type PlayerCheater # " + (i + 1).ToString(), 4);
                }
                else
                {
                    pa[i] = new PlayerUberCheater();
                    pa[i].PlayerNew("Player type PlayerUberCheater # " + (i + 1).ToString(), 5);
                }
            }
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Turn " + i);
                foreach (Player p in pa)
                {
                    int n = 0;
                    if (f.isprize(n = p.rolldice(f)) == true)
                    {
                        Console.WriteLine("Victory player {0} with number {1}", p.name, n);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Player {0} overshot with number {1} ", p.name, n);
                    }
                 }
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
            return rand.Next(0, f.fi.Length);
        }
    }
    class PlayerNote : Player
    {
        int[] p = new int[51];//проверенные им числа
        public override int rolldice(Field f)
        {
            Random rand = new Random();
            return rand.Next(0, f.fi.Length);
        }
    }
    class PlayerUber : Player
    {
        int l = 0; //последнее проверенное им число
        public override int rolldice(Field f)
        {
            Random rand = new Random();
            return rand.Next(0, f.fi.Length);
        }
    }
    class PlayerCheater : Player
    {
        public override int rolldice(Field f)
        {
            Random rand = new Random();
            return rand.Next(0, f.fi.Length);
        }
    }
    class PlayerUberCheater : Player
    {
        int l = 0; //последнее проверенное им число
        public override int rolldice(Field f)
        {
            Random rand = new Random();
            return rand.Next(0, f.fi.Length);
        }
    }
    struct Field
    {
        public int[,] fi;
        int prize;
        public int length;
        public Field(int s, int f)
        {
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
        }
        public bool isprize(int t)
        {
            Console.WriteLine(t);
            fi[t - length, 2] = 1;
            return t == prize;
        }
    }
}
