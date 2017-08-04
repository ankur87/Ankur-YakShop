using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IYak
    {
        string Name { get; set; }
        double Age { get; set; }
        double AgeLastShaved { get; set; }
        string Sex { get; set; }
        int Skins { get; set; }
        double Milk { get; set; }
    }
}
