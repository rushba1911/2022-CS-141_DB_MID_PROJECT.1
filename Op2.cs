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
    public partial class Op2 : Form
    {
        public Op2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op2a opa = new Op2a();
            opa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op2b opb = new Op2b();
            opb.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op2c opc = new Op2c();
            opc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op2d opd = new Op2d();
            opd.Show();
            this.Hide();
        }
    }
}
