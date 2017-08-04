using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IHerd
    {
        string Name { get; set; }
        IList<IYak> yaks { get; set; }

        double MilkStock { get; set; }

        int Skins { get; set; }
    }
}
