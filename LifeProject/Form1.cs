using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LifeProject
{
    public partial class Form1 : Form
    {
        public DataLife d;

        public Form1()
        {
            d = new DataLife(21, 21, 300);

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
            dlg.Filter = "Life files (*.lf)|*.lf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String str1 = dlg.FileName;
                Console.WriteLine("str1 =" + str1);
                
                Form2 fff = new Form2(str1);
            }
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("1DataLife =" + d);

            Form3 fff = new Form3(ref d);

            if (fff.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("OK Input");
                
                d.setT(System.Int32.Parse(fff.getTextBox1()));
                d.setN(System.Int32.Parse(fff.getTextBox2()));
                d.setM(System.Int32.Parse(fff.getTextBox3()));
            
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
