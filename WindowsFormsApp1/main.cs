﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)//БД автосалона
        {
            _1avtosalon Avtosalon = new _1avtosalon();
            Avtosalon.Show();
        }

        private void button5_Click(object sender, EventArgs e)// Запрос 
        {
            DobavAuto form2 = new DobavAuto();
            form2.Show();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            TechHelp techHelp = new TechHelp();
            techHelp.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            test test = new test();
            test.Show();
        }
    }
}
