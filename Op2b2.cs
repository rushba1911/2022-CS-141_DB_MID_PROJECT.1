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
    public partial class Op2b2 : Form
    {
        public Op2b2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("UPDATE Person " +
                                                  "SET Email = @Email " +
                                                  "WHERE Id = @Id", con);

                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@Email", textBox2.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Email details updated successfully");
                else
                    MessageBox.Show("No matching record found for the given advisor ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op2b opb = new Op2b();
            opb.Show();
            this.Hide();
        }
    }
}
