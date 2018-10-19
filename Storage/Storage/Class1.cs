using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    abstract public class ProductTime
    {
        public int CalcTime(int ds, int tp)
        {
            return ds + tp;
        }
      
    }
    class Product : ProductTime, IProduct
    {
        string IProduct.Name { get => "One"; set ; }
        double IProduct.Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        int IProduct.ShelfLife { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
    class MaineStorage
    {
        public int Capacity { get; set; }
        public int InStock { get; set; }
        public MaineStorage(int a)
        {
            Capacity = a;
        }
    }
    class Load
    {
        MaineStorage Sload(MaineStorage a, int b)
        {
            a.InStock = b;
            return a;
        }
        private ProductTime a = new Product();

    }

}
