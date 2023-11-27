using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeProject
{
    public class PainterYehor
    {
        private Image image1;
        private Image image2;
        private int nn;
        private int mm;
        private int sise;
        public PainterYehor(int N, int M, int sise) 
        {
            this.nn = N;
            this.mm = M;
            this.sise = sise;
        }
        public void Paint(PaintEventArgs e, ref bool[,] array1)
        {
            Graphics g = e.Graphics;
            Brush white = new SolidBrush(Color.LightBlue);
            Brush white1 = new SolidBrush(Color.LightBlue);
            Brush blue = new SolidBrush(Color.Green);

            image1 = Image.FromFile("C:\\Users\\Yehor Medentsov\\source\\repos\\LifeProject\\LifeProject\\coral.png");
            image2 = Image.FromFile("C:\\Users\\Yehor Medentsov\\source\\repos\\LifeProject\\LifeProject\\waterr.png");


            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < mm; j++)
                {
                    Point p = new Point(sise * i + i, sise * j + j);

                    if (array1[i, j])//проверка состояния клеточки 
                    {
                        g.FillRectangle(white, sise * i + i, sise * j + j, sise, sise);
                        //g.DrawImage(image2, p);
                        g.DrawImage(image1, p);

                    }
                    else
                    {
                        g.FillRectangle(white, sise * i + i, sise * j + j, sise, sise);
                        //g.DrawImage(image2, p);

                    }
                }
            }
        }
    }
}
