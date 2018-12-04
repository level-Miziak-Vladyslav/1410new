using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        string name;
        int type;
        int[] p = new int[51];//проверенные им числа
        int l = 0; //последнее проверенное им число
        public virtual void rolldice()
        {

        }
    }
    class PlayerNote:Player
    {
        int[] p = new int[51];//проверенные им числа
        public override void rolldice()
        {

        }
    }
    class PlayerUber:Player
    {
        int l = 0; //последнее проверенное им число
        public override void rolldice()
        {

        }
    }
    class PlayerCheater:Player
    {
        public override void rolldice()
        {

        }
    }
    class PlayerUberCheater:Player
    {
        int l = 0; //последнее проверенное им число
        public override void rolldice()
        {

        }
    }




    struct Field
    {
        public int[,] fi;
        int prize;
        public Field(int s, int f)
        {
            int length = f - s;
            fi = new int[length,3];
            for (int i = 0;i< length; i++)
            {
                fi[i, 0] = i; //порядковый
                fi[i, 1] = i+s;//номер
                fi[i, 2] = 0;//признак для читера
            }
            Random rand = new Random();
            prize = rand.Next(s,f);
        }
        public bool isprize(int t)
        {
            return t == prize;
        }
    }
}
