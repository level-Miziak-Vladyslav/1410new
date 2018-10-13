using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New1210.Domain
{
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
    public class Service
    {

    }
}
