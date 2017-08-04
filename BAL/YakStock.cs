using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public class YakStock: IYakStock
    {
        IYak _yak;
        public YakStock(IYak yak)
        {
            _yak = yak;
        }
        public double GetMilkquantitytPerDay(int day)
        {
            double milk= (50 - (_yak.Age * 100 + day) * .03);
            return milk;
        }
        public int GetSkinQuantityPerDay(int day)
        {
            if (day == 0)
            {
                _yak.AgeLastShaved = _yak.Age;
                return 1;
            }
            else if ((day) > 8 + (_yak.Age * 100 + day) * .01)
            {
                _yak.AgeLastShaved = (_yak.Age * 100 + day) * .01;
                return 1;
            }
            else
            {
                _yak.AgeLastShaved = _yak.Age;
                return 0;
            }
        }
    }
}
