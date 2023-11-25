using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace LifeProject
{
    // This delegate enables asynchronous calls for setting
    // the text property on a TextBox control.
    delegate void SetTextCallback(string text);
    
    public partial class Form2 : Form
    {
        private Thread oThread;
        private bool isGo;
        private int x;
        private int y;
        private Image image1;
        //private Image image2;

        public int N;
        public int M;
        private const int SIZE = 16;
        
        private bool [,]array1;
        private bool [,]array_init;
        private int timeDelay;
        
        public Form2(int T, int N, int M)
        {
            this.N = N;
            this.M = M;
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

            // Create image.
            image1 = Image.FromFile("C:\\Users\\Yehor Medentsov\\source\\repos\\LifeProject\\LifeProject\\coral.png");
            //image2 = Image.FromFile("C:\\Images\\image2.bmp");

            InitCommonData(T);
        }

        public Form2(String str1)
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
                        array1[i, j] = (fs.ReadByte() == 1 ) ? true : false;
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
            
            InitCommonData(400);
        }

        public void InitCommonData(int T)
        {

            isGo = true;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
            timeDelay = T;

            InitializeComponent();
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Поле " + N + " на " + M;            
        }

        private void Form2_FormClosing(object sender, EventArgs e)
        {
            Console.Write("FormClosed()");
            
            isGo = false;

            /*
            if (isGo)
            {
                isGo = false;
                oThread.Abort();
            }
             */
        }
        
        private void setText(string text)
        {
            //label1.Text = str1;
            if (this.label1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.label1.Text = text;
            }

        }

        protected override void OnMouseDown (MouseEventArgs e)
        {
            //this.Text = "Mouse Down " + e.X + " " + e.Y;
            //Console.WriteLine("Mouse Down " + e.X + " "  + e.Y + "\n");
            //this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            int j = e.Y / SIZE;
            int i = e.X / SIZE;
            
            j = (e.Y - j)/ SIZE;
            i = (e.X - i)/ SIZE;

            Console.WriteLine("Mouse Up " + e.X + " " + e.Y);
            Console.WriteLine("(i,j)= (" + i + "," + j + ")");

            if((i < N) && (j < M))
            {
                array1[i, j] = !array1[i, j];
                //this.Text = "Mouse Up " + e.X + " " + e.Y;
                //Console.WriteLine("Mouse Up " + e.X + " " + e.Y);
                //Console.WriteLine("(i,j)= (" + i + "," + j + ")");
               
                this.Invalidate();
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            //Point p1[4] = new Point[4];
            Graphics g = e.Graphics;
            //Pen green = new Pen(Color.Green, 3);
            //Pen blue = new Pen(Color.Blue, 3);
            Brush white = new SolidBrush(Color.LightBlue);
            Brush blue = new SolidBrush(Color.Green);
          
            //g.DrawEllipse(green, x, y, 30, 40;
            //g.DrawLine(blue, new Point(0, 0), new Point(x, y));

            //g.FillRectangle(red, 50, 50, 21, 21);
            
            
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Point p = new Point(SIZE * i + i, SIZE * j + j);
                    
                    if (array1[i,j])
                    {
                        g.FillRectangle(white, SIZE * i + i, SIZE * j + j, SIZE, SIZE);
                        g.DrawImage(image1, p);

                    }
                    else
                    {
                        //g.DrawImage(image2, p);
                        g.FillRectangle(white, SIZE * i + i, SIZE * j + j, SIZE, SIZE);
                    }
                }
            }
            
            //g.DrawPolygon(blue, new Point[] )
            base.OnPaint(e);
        }

        private void stepLife()
        {
            bool [,] temp1 = new bool[N,M];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    int count1 = 0;
                    bool b1 = array1[i, j];
                    bool []temp2 = new bool[8];

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
                        temp1[i,j] = false;
                        if((count1 == 2) || (count1 == 3))
                        {
                            temp1[i, j] = true;
                        }
                    }
                    else
                    {
                        temp1[i,j] = array1[i,j];
                        if (count1 == 3)
                        {
                            temp1[i, j] = true;
                        }
                    }

                }
            }
            array1 = temp1;
        }


        private void Loop()
        {
            while (isGo)
            {
                Console.WriteLine("Loop alive " + DateTime.UtcNow);
                //setText("" + DateTime.Now);
                x++;
                y++;
                if (x == 10) 
                    x = 0;
                if (y == 10) 
                    y = 0;
                stepLife();
                this.Invalidate();
                Thread.Sleep(timeDelay);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isGo = true;
            array_init = array1;
            //setText("Поток запущен");
            oThread = new Thread(new ThreadStart(Loop));
            oThread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //setText("Поток остановлен");
            isGo = false;
        }

        private void button3_Click(object sender, EventArgs e)
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
            
            array_init = array1;

            this.Invalidate();
        }
        
        private void button4_Click(object sender, EventArgs e)
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
