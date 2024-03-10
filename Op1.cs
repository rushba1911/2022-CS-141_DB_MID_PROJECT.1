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
    public partial class Op1 : Form
    {
        public Op1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op1a opa = new Op1a();
            opa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op1b opb = new Op1b();
            opb.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op1c opc = new Op1c();
            opc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op1d opd = new Op1d();
            opd.Show();
            this.Hide();
        }
    }
}
