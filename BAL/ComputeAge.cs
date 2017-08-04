using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BusinessLogic
{
    public class ComputeAge
    {
        List<IYak> _Yaks;
        public ComputeAge(List<IYak> Yaks)
        {
            _Yaks = Yaks;
        }

    }
}
