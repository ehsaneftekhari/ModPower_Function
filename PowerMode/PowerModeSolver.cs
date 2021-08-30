using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PowerMode
{
    class PowerModeSolver
    {
        List<BaseAndPwer> BaseAndPwers;
        private List<string> solvStrinng;

        BigInteger mod;

        public string solvstrinng
        {
            get
            {
                string temp = "";
                int i = 1;
                int D = solvStrinng.Count.ToString().Length;
                foreach (string p in solvStrinng)
                {
                    temp += $"Line {String.Format("{0, 0:D" + D + "}", i++)}_ " + p + "\n";
                }
                return temp;
            }
        }
        public PowerModeSolver(BigInteger @base, BigInteger power, BigInteger mod)
        {
            BaseAndPwers = new List<BaseAndPwer>();
            solvStrinng = new List<string>();

            solvStrinng.Add($"{@base}^{power} mood {mod}");

            this.mod = mod;

            string temp = "";

            while (power > 0)
            {
                BigInteger p = 1;

                while (p * 2 <= power)
                {
                    p *= 2;
                }

                BaseAndPwers.Add(new BaseAndPwer(@base, p));
                temp += $"({@base}^{p})";

                power -= p;

                if (power > 0)
                    temp += " × ";
            }

            temp += $" mod {mod}";

            solvStrinng.Add(temp);
        }
        public BigInteger solve(BigInteger baseLimit)
        {
            if (baseLimit < mod)
                throw new Exception();
            BaseAndPwer first = null;
            BaseAndPwer secound = null;

            while (BaseAndPwers.Count > 1 || BaseAndPwers.ElementAt(0).power > 1 || BaseAndPwers.ElementAt(0).@base > mod)
            {
                first = BaseAndPwers.ElementAt(0);

                if (first.@base == 0)
                    return 0;

                if (first.@base >= baseLimit)
                {
                    createstring(true);
                    first.@base %= mod;
                }
                else
                {
                    if (BaseAndPwers.Count > 1)
                    {
                        secound = BaseAndPwers.ElementAt(1);

                        if (first.power > secound.power)
                        {
                            first.power /= 2;
                            first.@base *= first.@base;
                        }
                        else
                        if (first.power == secound.power)
                        {
                            first.@base *= secound.@base;
                            int i = 1;
                            BaseAndPwer temp;
                            for (; i < BaseAndPwers.LongCount() - 1; i++)
                            {
                                temp = BaseAndPwers.ElementAt(i);
                                temp.power = BaseAndPwers.ElementAt(i + 1).power;
                                temp.@base = BaseAndPwers.ElementAt(i + 1).@base;
                            }
                            BaseAndPwers.RemoveAt(i);
                        }

                    }
                    else
                    {
                        if (first.power > 1)
                        {
                            first.power /= 2;
                            first.@base *= first.@base;
                        }
                        else
                        if (first.@base > mod)
                        {
                            first.@base %= mod;
                        }
                    }
                }
                createstring(false);
            }
            return first.@base;
            //while (BaseAndPwers.ElementAt(0).power > 1)
            //{
            //    first = BaseAndPwers.ElementAt(0);
            //    if (first.@base == 0)
            //        return 0;
            //    if (BaseAndPwers.Count > 1)
            //    {
            //        secound = BaseAndPwers.ElementAt(1);
            //        if (first.@base > baseLimit)
            //        {
            //            createstring(true);
            //            first.@base %= mod;
            //        }
            //        else
            //            if (first.power > secound.power)
            //        {
            //            first.power /= 2;
            //            first.@base *= first.@base;
            //        }
            //        else
            //        if (first.@base < mod && first.power == secound.power)
            //        {
            //            first.@base *= secound.@base;
            //            int i = 1;
            //            BaseAndPwer temp;
            //            for (; i < BaseAndPwers.LongCount() - 1; i++)
            //            {
            //                temp = BaseAndPwers.ElementAt(i);
            //                temp.power = BaseAndPwers.ElementAt(i + 1).power;
            //                temp.@base = BaseAndPwers.ElementAt(i + 1).@base;
            //            }
            //            BaseAndPwers.RemoveAt(i);
            //        }
            //        else
            //        {
            //            createstring(true);
            //            first.@base = first.@base % mod;
            //        }
            //    }
            //    else
            //    {
            //        if(first.@base > baseLimit)
            //        {
            //            createstring(true);
            //            first.@base = first.@base % mod;
            //        }
            //        else
            //        {
            //            first.@base *= first.@base;
            //            first.power /= 2;
            //        }
            //    }
            //    createstring(false);
            //}
            //if (first.@base >= mod)
            //{
            //    createstring(true);
            //    first.@base %= mod;
            //    createstring(false);
            //    if (BaseAndPwers.FirstOrDefault(x => x.Equals(secound)) != null)
            //    {
            //        first.@base *= secound.@base;
            //        BaseAndPwers.Remove(secound);
            //        createstring(false);
            //    }
            //}
            //return first.@base % mod;
        }
        public void createstring(bool mod)
        {
            string temp = "";
            for (int i = 0; i < BaseAndPwers.Count; i++)
            {
                BaseAndPwer n = BaseAndPwers.ElementAt(i);
                if (mod && i == 0)
                    temp += $"({n.@base} mod {this.mod})^{n.power}";
                else
                    temp += $"({n.@base}^{n.power})";

                if (!BaseAndPwers.Last().Equals(n))
                    temp += " × ";
            }
            temp += $" mood {this.mod}";
            solvStrinng.Add(temp);
        }
    }
}
