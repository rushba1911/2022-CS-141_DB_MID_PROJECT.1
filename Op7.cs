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
    public partial class Op7 : Form
    {
        public Op7()
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
            Op7a opa = new Op7a();
            opa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op7c opc = new Op7c();
            opc.Show();
            this.Hide();     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op7b opb = new Op7b();
            opb.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op7d opd = new Op7d();
            opd.Show();
            this.Hide();
        }
    }
}
