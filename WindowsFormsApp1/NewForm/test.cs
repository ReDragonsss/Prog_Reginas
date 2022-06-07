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
    public partial class test : MetroFramework.Forms.MetroForm
    {
        public test()
        {
            InitializeComponent();
        }
        public int name;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Test;
            Test =comboBox1.SelectedIndex;
            name = Test;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{name}");
        }

        private void test_Load(object sender, EventArgs e)
        {

        }
    }
}
