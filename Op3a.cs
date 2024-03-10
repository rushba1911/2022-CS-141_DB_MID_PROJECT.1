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
    public partial class Op3a : Form
    {
        public Op3a()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("INSERT INTO Project (Title, Description) VALUES (@Title, @Description); SELECT SCOPE_IDENTITY();", con);

                cmd.Parameters.AddWithValue("@Title", textBox2.Text);
                cmd.Parameters.AddWithValue("@Description", textBox1.Text);

                int projectId = Convert.ToInt32(cmd.ExecuteScalar());

                if (projectId > 0)
                {
                    MessageBox.Show("Project added successfully with ID: " + projectId);
                }
                else
                {
                    MessageBox.Show("Failed to add project.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op3 op3 = new Op3();
            op3.Show();
            this.Hide();
        }
    }
}
