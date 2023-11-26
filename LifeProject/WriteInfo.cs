using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorallGame
{
    public class WriteInfo
    {
        public WriteInfo(ref bool[,] array_init, int N, int M) 
        {
            SaveFileDialog sv = new SaveFileDialog();

            sv.Filter = "Life files (*.lf)|*.lf";

            if (sv.ShowDialog() == DialogResult.OK)
            {
                FileStream fs;

                //BinaryWriter br;

                //Console.WriteLine("sizeof=" + sizeof(bool [,]));

                try
                {
                    fs = new FileStream(sv.FileName, FileMode.CreateNew, FileAccess.Write, FileShare.Write);

                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            fs.WriteByte((array_init[i, j]) ? (byte)1 : (byte)0);
                        }
                    }

                    //br = new BinaryWriter(fs);
                }
                catch (System.IO.IOException)
                {

                    return;
                }
                

                //br.Write(array_init, 0, 16);

                fs.Close();
            }
        }
       
    }
}
