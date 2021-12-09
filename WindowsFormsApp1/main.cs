using System;
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
        private void button1_Click(object sender, EventArgs e)//3автосалон
        {
            _1avtosalon Avtosalon = new _1avtosalon();
            Avtosalon.ShowDialog();
        }
        private void button4_Click(object sender, EventArgs e)// reginas
        {
            _4avtosalon Avtosalon = new _4avtosalon();
            Avtosalon.ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)//бдшка
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        private void button3_Click(object sender, EventArgs e)//2автосалон
        {
            _3avtosalon Avtosalon = new _3avtosalon();
            Avtosalon.ShowDialog();
        }
        private void button2_Click(object sender, EventArgs e)//3автосалон
        {
            _2avtosalon Avtosalon = new _2avtosalon();
            Avtosalon.ShowDialog();
        }
    }
}
