using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public interface IComputeStock
    {

        void GetMilkStock(int days);
        void GetSkinStock(int days);
    }
}
