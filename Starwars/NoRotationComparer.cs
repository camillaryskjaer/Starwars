using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starwars
{
    class NameComparer : IEqualityComparer<Planet>
    {
        public bool Equals(Planet x, Planet y)
        {
            if (string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Planet obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    //comparer to check
    class RotationComparer : IEqualityComparer<Planet> //fiks mig
    {
        public bool Equals(Planet x, Planet y)
        {
            if (x.RotationPeriod > 0)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Planet obj)
        {
            return obj.RotationPeriod.GetHashCode();
        }
    }
}
