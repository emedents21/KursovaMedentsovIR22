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

namespace KorallGame
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
        private Image image2;

        public int N = 21;
        public int M = 21;
        private const int SIZE = 16;
        
        private bool [,]array1;
        private bool [,]array_init;
        private int timeDelay;
        Main maine = new Main();


        public Form2(int T, int N, int M)
        {
            this.N = N;
            this.M = M;
            maine.Init(ref array1, ref array_init, N, M);
            image1 = Image.FromFile("C:\\Users\\Yehor Medentsov\\source\\repos\\LifeProject\\LifeProject\\coral.png");
            image2 = Image.FromFile("C:\\Users\\Yehor Medentsov\\source\\repos\\LifeProject\\LifeProject\\waterr.png");

            InitCommonData(T);
        }

        public Form2(String str1)
        {
            ReadInfo r = new ReadInfo(str1,ref array1, N, M);
            InitCommonData(400);
            ShowDialog();
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
            this.Text = "Акварiум " + N + " на " + M;            
        }

        private void Form2_FormClosing(object sender, EventArgs e)
        {
            Console.Write("FormClosed()"); 
            isGo = false;
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

        protected override void OnMouseUp(MouseEventArgs e)
        {
            int j = e.Y / SIZE;
            int i = e.X / SIZE;
            
            j = (e.Y - j)/ SIZE;
            i = (e.X - i)/ SIZE;

            if((i < N) && (j < M))
            {
                array1[i, j] = !array1[i, j];
                this.Invalidate(); //перемалювання
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)//малювання на форме кординат та корал
        {
            Graphics g = e.Graphics;
            Brush white = new SolidBrush(Color.LightBlue);
            Brush white1 = new SolidBrush(Color.LightBlue);
            Brush blue = new SolidBrush(Color.Green);

            image1 = Image.FromFile("C:\\Users\\Yehor Medentsov\\source\\repos\\LifeProject\\LifeProject\\coral.png");
            image2 = Image.FromFile("C:\\Users\\Yehor Medentsov\\source\\repos\\LifeProject\\LifeProject\\waterr.png");


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Point p = new Point(SIZE * i + i, SIZE * j + j);
                    
                    if (array1[i,j])
                    {
                        g.FillRectangle(white, SIZE * i + i, SIZE * j + j, SIZE, SIZE);
                        //g.DrawImage(image2, p);
                        g.DrawImage(image1, p);

                    }
                    else
                    {
                        g.FillRectangle(white, SIZE * i + i, SIZE * j + j, SIZE, SIZE);
                        //g.DrawImage(image2, p);

                    }
                }
            }
            base.OnPaint(e);
        }

        private void Loop()//виклик головного алгоритму
        {
            while (isGo)
            {
                //setText("" + DateTime.Now);
                x++;
                y++;
                if (x == 10) 
                    x = 0;
                if (y == 10) 
                    y = 0;
                maine.stepCorall(ref array1, N, M);
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
            maine.Zapolnenije(ref array1, N, M);
            array_init = array1;
            
            this.Invalidate();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            WriteInfo WF = new WriteInfo(ref array_init, N, M);
        }
    }   
}
