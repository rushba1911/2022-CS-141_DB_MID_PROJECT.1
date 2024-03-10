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
    public partial class Op7b : Form
    {
        public Op7b()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op7b1 opb1 = new Op7b1();
            opb1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op7b2 opb2 = new Op7b2();
            opb2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op7b3 opb3 = new Op7b3();
            opb3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op7 op7 = new Op7();
            op7.Show();
            this.Hide();
        }
    }
}
