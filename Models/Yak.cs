using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Yak: IYak
    {
        public string Name { get; set; }
        public double Age { get; set; }
        public string Sex { get; set; }
        public int Skins { get; set; }
        public double Milk { get; set; }

        public double AgeLastShaved
             { get; set; }
    }
}
