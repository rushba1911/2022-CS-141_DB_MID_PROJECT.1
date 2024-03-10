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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DB_Mid_Project
{
    public partial class Op1b : Form
    {
        public Op1b()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("UPDATE Student " +
                                                  "SET RegistrationNo = @RegistrationNumber " +
                                                  "WHERE Id = (SELECT Id FROM Person WHERE FirstName = @FirstName AND LastName = @LastName)", con);

                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);

                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox3.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    MessageBox.Show("Successfully updated");
                else
                    MessageBox.Show("No matching record found for the given name");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
