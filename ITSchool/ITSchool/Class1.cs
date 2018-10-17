using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSchool
{
    struct MainPerson
    {
        public void MakePersonP(int s, int dc, int l, int a)
        {
            Student[] sa = new Student[s];
            for (int i = 0; i < s; i++)
            {
                sa[i] = new Student("Student # " + (i+1).ToString());
//                Console.WriteLine(sa[i].n);
            }
            Head[] ha = new Head[dc + l + a];
            for (int i = 0; i < (dc + l + a); i++)
            {
                if (i < dc)
                {
                    ha[i] = new Head(20, "professor assistant # " + (i + 1).ToString());
//                    Console.WriteLine("professor assistant # " + (i + 1).ToString());
                }
                else if (i < (dc + l))
                {
                    ha[i] = new Head(15, "lecturer # " + (i + 1 - dc).ToString());
//                    Console.WriteLine("lecturer # " + (i + 1 - dc).ToString());
                }else
                {
                    ha[i] = new Head(5, "assistant # " + (i + 1 - dc - l).ToString());
//                    Console.WriteLine("assistant # " + (i + 1 - dc - l).ToString());
                }

            }
            group[] g = Dispenser(sa, ha, out int gqg);
            Console.WriteLine("name of Head // name of student");
            int qg = 0;
            foreach (group h in g)
            {
                if (qg == gqg)
                {
                    break;
                }
                Console.WriteLine("name of Head {0}", h.headname.name);
                int q = 0;
                foreach (Student z in h.sag)
                {
                    if (q==h.ns)
                    {
                        break;
                    }
                    Console.WriteLine("name of student - {0}", h.sag[q].n);
                    q++;
                }
                qg++;

            }
        }
        group[] Dispenser(Student[] sa, Head[] ha, out int gqg)
        {
            int q = 0;
            int rs = sa.Length;
            group[] g = new group[ha.Length];
            foreach (Head h in ha)
            {
                g[q] = new group(h);

                for (int i = 0; i < h.type; i++)
                {
//                    Console.WriteLine("sa[rs-1]; " + sa[rs-1].n + " rs-1" + (rs-1) + "i" + i);
                    g[q].sag[i] = sa[rs-1];
                    g[q].ns = i+1;
                    rs--;
                    if (rs == 0)
                    {
//                        Console.WriteLine("all students are distributed");
                        break;
                    }
                }
                q++;
                if (rs == 0)
                {
                    Console.WriteLine("all students are distributed");
                    break;
                }
            }
             if(rs > 0)
            {
                Console.WriteLine("{0} left without a group", rs);
            }
            gqg = q;
            return g;
        }
    }
    struct Student
    {
        public string n;
        public Student(string name)
        {
            n = name;
            Head h = new Head( 0, "not assigned");
        }
    }
    struct Head
    {
        public int type;
        public string name;
        public Head(int t, string n)
        {
            type = t;
            name = n;
        }
    }
    struct group
    {
        public Student[] sag;
        public Head headname;
        public int ns;
        public group(Head h)
        {
            headname = h;
            sag = new Student[h.type];
            ns = h.type;
        }
 
        
    }

}
