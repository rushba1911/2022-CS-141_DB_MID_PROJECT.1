using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Mid_Project
{
    public partial class Op4a : Form
    {
        public Op4a()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("INSERT INTO [Group] (Created_On) VALUES (@CreationDate); SELECT SCOPE_IDENTITY();", con);
                cmd.Parameters.AddWithValue("@CreationDate", DateTime.Parse(textBox1.Text));

                int groupId = Convert.ToInt32(cmd.ExecuteScalar());

                MessageBox.Show("Group created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op4 op4 = new Op4();
            op4.Show();
            this.Hide();
        }
    }
}
