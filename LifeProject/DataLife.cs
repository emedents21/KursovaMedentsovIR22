using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KorallGame
{
    public class DataLife
    {
        
        private int N;
        private int M;
        private int T;

        public DataLife(int n, int m, int t)
        {
            N = n;
            M = m;
            T = t;
        }

        public DataLife(DataLife ddd)
        {
            N = ddd.N;
            M = ddd.M;
            T = ddd.T;
        }

        public int getN()
        {
            return N;
        }

        public int getM()
        {
            return M;
        }

        public int getT()
        {
            return T;
        }

        public void setT(int t)
        {
            T = t;
        }

        public void setM(int m)
        {
            M = m;
        }

        public void setN(int n)
        {
            N = n;
        }
    }
}
