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
    public partial class Op2c : Form
    {
        public Op2c()
        {
            InitializeComponent();
        }

        private void Op2c_Load(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand(@"SELECT Person.FirstName, Person.LastName, Person.Contact, Person.Email, 
                                          Person.DateOfBirth, Lookup.Value AS Gender, Advisor.Salary, 
                                          LookupDesignation.Value AS Designation
                                          FROM Person
                                          INNER JOIN Advisor ON Person.Id = Advisor.Id
                                          LEFT JOIN Lookup ON Person.Gender = Lookup.Id
                                          LEFT JOIN Lookup AS LookupDesignation ON Advisor.Designation = LookupDesignation.Id", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Advisor data retrieved successfully");
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No advisor records found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op2 op2 = new Op2();
            op2.Show();
            this.Hide();
        }
    }
}
