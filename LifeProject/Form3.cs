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
        public String getTextBox2()
        {
            return textBox2.Text;
        }
        public String getTextBox3()
        {
            return textBox3.Text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "" + ddd.getT();
            textBox2.Text = "" + ddd.getN();
            textBox3.Text = "" + ddd.getM();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ddd.T =   textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
