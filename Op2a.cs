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
    public partial class Op2a : Form
    {
        public Op2a()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                int genderValue = 0;
                int.TryParse(textBox6.Text, out genderValue);
                if (genderValue != 1 && genderValue != 2)
                {
                    MessageBox.Show("Invalid gender value. Please enter 1 for male or 2 for female.");
                    return;
                }

                int designationValue = 0;
                int.TryParse(textBox7.Text, out designationValue);
                if (designationValue != 6 && designationValue != 7 && designationValue != 8 && designationValue != 9 && designationValue != 10)
                {
                    MessageBox.Show("Invalid designation value. Please enter 6 for Professor, 7 for Associate Professor, 8 for Assistant Professor, 9 for Lecturer, or 10 for Industry Professional.");
                    return;
                }

                SqlCommand cmdPerson = new SqlCommand("INSERT INTO Person (FirstName, LastName, Contact, Email, DateOfBirth, Gender) " +
                                                      "VALUES (@FirstName, @LastName, @Contact, @Email, @DateOfBirth, @Gender); SELECT SCOPE_IDENTITY();", con);
                cmdPerson.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmdPerson.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmdPerson.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmdPerson.Parameters.AddWithValue("@Email", textBox4.Text);
                cmdPerson.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(textBox5.Text));
                cmdPerson.Parameters.AddWithValue("@Gender", genderValue);

                int personId = Convert.ToInt32(cmdPerson.ExecuteScalar());

                SqlCommand cmdAdvisor = new SqlCommand("INSERT INTO Advisor (Id, Designation, Salary) " +
                                                       "VALUES (@Id, @Designation, @Salary)", con);
                cmdAdvisor.Parameters.AddWithValue("@Id", personId);
                cmdAdvisor.Parameters.AddWithValue("@Designation", designationValue);
                cmdAdvisor.Parameters.AddWithValue("@Salary", decimal.Parse(textBox8.Text));

                cmdAdvisor.ExecuteNonQuery();

                MessageBox.Show("New advisor added successfully with ID:" + personId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
