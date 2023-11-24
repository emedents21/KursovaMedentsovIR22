using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LifeProject
{
    public partial class Form3 : Form
    {
        public DataLife ddd;

        public Form3(ref DataLife d)
        {
            
            Console.WriteLine("2 DataLife =" + d);
            Console.WriteLine("2 DataLife =" + d.getT());

            
            ddd = new DataLife(d);

            MaximizeBox = false;

            FormBorderStyle = FormBorderStyle.FixedSingle;

            this.Load += new System.EventHandler(this.Form3_Load);



            InitializeComponent();
        }

        public String getTextBox1()
        {
            return textBox1.Text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "" + ddd.getT();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ddd.T =   textBox1.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
