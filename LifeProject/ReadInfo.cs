using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeProject
{
    public class ReadInfo
    {
        private bool[,] array_init;
        public ReadInfo(String str1, ref bool[,] array1, int N, int M)
        {
            FileStream fs;
            //N = 16;
            //M = 16

            array1 = new bool[N, M];

            array_init = new bool[N, M];

            //BinaryWriter br;

            //Console.WriteLine("sizeof=" + sizeof(bool [,]));

            try
            {
                fs = new FileStream(str1, FileMode.Open, FileAccess.Read, FileShare.Read);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        array1[i, j] = (fs.ReadByte() == 1) ? true : false;
                    }
                }
                //br = new BinaryWriter(fs);
            }
            catch (System.IO.IOException)
            {
                Console.Write("Erroe System IO");
                return;
            }

            array_init = array1;

            fs.Close();

        }
    }
}
