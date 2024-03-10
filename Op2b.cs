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
    public partial class Op2b : Form
    {
        public Op2b()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Op2b_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Op2 op2 = new Op2();
            op2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op2b1 opb1 = new Op2b1();
            opb1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op2b2 opb2 = new Op2b2();
            opb2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op2b3 opb3 = new Op2b3();
            opb3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op2b4 opb4 = new Op2b4();
            opb4.Show();
            this.Hide();
        }
    }
}
