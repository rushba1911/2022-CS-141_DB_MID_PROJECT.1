using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Mid_Project
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op2 op2 = new Op2();
            op2.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op1 op1 = new Op1();
            op1.Show();
            this.Hide();           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op3 op3 = new Op3();
            op3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op4 op4 = new Op4();
            op4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Op5 op5 = new Op5();
            op5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Op6 op6 = new Op6();
            op6.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Op7 op7 = new Op7();
            op7.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Op8 op8 = new Op8();
            op8.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Op9 op9 = new Op9();
            op9.Show();
            this.Hide();
        }
    }
}
