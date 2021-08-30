using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PowerMode
{
    class BaseAndPwer
    {
        public BigInteger @base;
        public BigInteger power;
        public BaseAndPwer(BigInteger @base, BigInteger power)
        {
            this.@base = @base;
            this.power = power;
        }
    }
}
