using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public interface IYakStock
    {
        double GetMilkquantitytPerDay(int day);
        int GetSkinQuantityPerDay(int day);
    }
}
