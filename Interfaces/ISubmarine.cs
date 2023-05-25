using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E07_Vehicle.Interfaces
{
    internal interface ISubmarine
    {
        int FullTankQuantity { get; }
        void Dive();
    }
}
