﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Four
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.IsMdiContainer=true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();   
            frm4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
        }
    }
}
