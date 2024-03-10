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
    public partial class Op4 : Form
    {
        public Op4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op4a opa = new Op4a();
            opa.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op4b opb = new Op4b();
            opb.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Op4c opc = new Op4c();
            opc.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Op4d opd = new Op4d();
            opd.Show();
            this.Hide();
        }
    }
}
