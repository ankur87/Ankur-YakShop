using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public class ComputeStock: IComputeStock
    {
        IHerd herd;
        public ComputeStock(IHerd herd)
        {
            this.herd = herd;
        }
        public void GetMilkStock(int days)
        {
            IYakStock yakstock;
            foreach (var yak in herd.yaks)
            {
                yakstock = new YakStock(yak);
                for (int i = 0; i < days; i++)
                {
                    yak.Milk += yakstock.GetMilkquantitytPerDay(i);
                }
            }
            herd.MilkStock= herd.yaks.Sum(i => i.Milk);
        }
        public void GetSkinStock(int days)
        {
            IYakStock yakstock;
            foreach (var yak in herd.yaks)
            {
                yakstock = new YakStock(yak);
                for (int i = 0; i < days; i++)
                {
                    yak.Skins += yakstock.GetSkinQuantityPerDay(i);
                }
            }
            herd.Skins = herd.yaks.Sum(i => i.Skins);
        }
    }
}
