using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KorallGame
{
    public class Main
    {
        public Main() { }
    
        public void stepCorall(ref bool [,]array1, int N, int M) //алгоритм который делает развитие жизни кораллов (один шаг) согласно условию
        {
            bool[,] temp1 = new bool[N, M];// новый массив для обновленной ситуации на поле развития
            for (int i = 0; i < N; i++)//бежим по каждой ячейке
            {
                for (int j = 0; j < M; j++)
                {
                    int count1 = 0;
                    bool b1 = array1[i, j];
                    bool[] temp2 = new bool[8];//8 соседей у каждой клеточки для проверки

                    if ((i == 0) || (j == 0))
                    {
                        temp2[0] = false;
                    }
                    else
                    {
                        temp2[0] = array1[i - 1, j - 1];
                    }

                    if (i == 0)
                    {
                        temp2[1] = false;
                    }
                    else
                    {
                        temp2[1] = array1[i - 1, j];
                    }

                    if ((i == 0) || (j == M - 1))
                    {
                        temp2[2] = false;
                    }
                    else
                    {
                        temp2[2] = array1[i - 1, j + 1];
                    }

                    if (j == M - 1)
                    {
                        temp2[3] = false;
                    }
                    else
                    {
                        temp2[3] = array1[i, j + 1];
                    }

                    if ((i == N - 1) || (j == M - 1))
                    {
                        temp2[4] = false;
                    }
                    else
                    {
                        temp2[4] = array1[i + 1, j + 1];
                    }

                    if (i == N - 1)
                    {
                        temp2[5] = false;
                    }
                    else
                    {
                        temp2[5] = array1[i + 1, j];
                    }

                    if ((i == N - 1) || (j == 0))
                    {
                        temp2[6] = false;
                    }
                    else
                    {
                        temp2[6] = array1[i + 1, j - 1];
                    }

                    if ((i == 0) || (j == 0))
                    {
                        temp2[7] = false;
                    }
                    else
                    {
                        temp2[7] = array1[i, j - 1];
                    }

                    for (int iii = 0; iii < 8; iii++)
                    {
                        if (temp2[iii])
                            count1++;
                    }
                    if (b1)
                    {
                        temp1[i, j] = false;
                        if ((count1 == 2) || (count1 == 3)) //если два или три соседа то коралл жив
                        {
                            temp1[i, j] = true;
                        }
                    }
                    else
                    {
                        temp1[i, j] = array1[i, j];
                        if (count1 == 3)//если мертвый коралл имеет три соседа то он возрождается
                        {
                            temp1[i, j] = true;
                        }
                    }

                }
            }
            array1 = temp1;
        }

        public void Zapolnenije(ref bool[,] array1, int N, int M) //заполняем пле кораллами 
        {
            Random r = new Random();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (r.Next() % 2 == 0)
                    {
                        array1[i, j] = false;
                    }
                    else
                    {
                        array1[i, j] = true;
                    }
                }
            }
        }

        public void Init(ref bool[,] array1, ref bool[,] array_init, int N, int M) //создаем игровое поле
        {
            array1 = new bool[N, M];
            array_init = new bool[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    array1[i, j] = false;
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    array_init[i, j] = false;
                }
            }
        }
    }
}
