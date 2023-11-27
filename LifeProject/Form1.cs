using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace KorallGame
{
    public partial class Form1 : Form
    {
        public DataLife d;

        public Form1()
        {
            d = new DataLife(21, 21, 300);//за замовченням
            MaximizeBox = false;
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void стартToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fff = new Form2(d.getT(), d.getN(), d.getM());
            fff.ShowDialog();
        }
        
 
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a “Coral World: Virtual Aquarium” created by Yehor Medentsov 2023!");
        }
        
        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Korall Files (*.kf)|*.kf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String str1 = dlg.FileName;
                //Console.WriteLine("str1 =" + str1);
                
                Form2 fff = new Form2(str1);
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fff = new Form3(ref d);

            if (fff.ShowDialog() == DialogResult.OK)
            {
                int newT, newN, newM;

                if (int.TryParse(fff.getTextBox1(), out newT))
                {
                    d.setT(newT);
                }
                else
                {
                    MessageBox.Show("Введiть значення коректно!");
                    return;  
                }

                if (int.TryParse(fff.getTextBox2(), out newN))
                {
                    d.setN(newN);
                }
                else
                {
                    MessageBox.Show("Введiть значення коректно!");
                    return;
                }

                if (int.TryParse(fff.getTextBox3(), out newM))
                {
                    d.setM(newM);
                }
                else
                {
                    MessageBox.Show("Введiть значення коректно!");
                    return;
                }
            }
        }


        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
