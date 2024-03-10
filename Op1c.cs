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
    public partial class Op1c : Form
    {
        public Op1c()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Op1 op1 = new Op1();
            op1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Op1c_Load(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("SELECT Student.RegistrationNo, Person.FirstName, Person.LastName, Person.Contact, Person.Email, Person.DateOfBirth, Lookup.Value AS Gender " +
                                                 "FROM Student " +
                                                 "INNER JOIN Person ON Student.Id = Person.Id " +
                                                 "LEFT JOIN Lookup ON Person.Gender = Lookup.id", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Student data retrieved successfully");
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No student records found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
