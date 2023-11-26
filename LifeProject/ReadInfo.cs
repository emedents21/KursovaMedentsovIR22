using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorallGame
{
    public class ReadInfo
    {
        private bool[,] array_init;
        public ReadInfo(String str1, ref bool[,] array1, int N, int M)
        {
            FileStream fs;
            array1 = new bool[N, M];

            array_init = new bool[N, M];

            //BinaryWriter br;
            try
            {
                fs = new FileStream(str1, FileMode.Open, FileAccess.Read, FileShare.Read);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        array1[i, j] = (fs.ReadByte() == 1) ? true : false;//читання байтов из файла и преобразование в буллевое значение
                    }
                }
                //br = new BinaryWriter(fs);
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("Error reading!");
                return;
            }

            array_init = array1;

            fs.Close();

        }
    }
}
