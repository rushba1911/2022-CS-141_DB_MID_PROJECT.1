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
    public partial class Op1a : Form
    {
        public Op1a()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op1 op1 = new Op1();
            op1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                int genderValue = 0;
                if (!int.TryParse(textBox7.Text, out genderValue) || (genderValue != 1 && genderValue != 2))
                {
                    MessageBox.Show("Invalid gender value. Please enter 1 for male or 2 for female.");
                    return;
                }

                SqlCommand cmdPerson = new SqlCommand("INSERT INTO Person (FirstName, LastName, Contact, Email, DateOfBirth, Gender) " +
                                                      "VALUES (@FirstName, @LastName, @Contact, @Email, @DateOfBirth, @Gender); SELECT SCOPE_IDENTITY();", con);
                cmdPerson.Parameters.AddWithValue("@FirstName", textBox2.Text);
                cmdPerson.Parameters.AddWithValue("@LastName", textBox3.Text);
                cmdPerson.Parameters.AddWithValue("@Contact", textBox4.Text);
                cmdPerson.Parameters.AddWithValue("@Email", textBox5.Text);
                cmdPerson.Parameters.AddWithValue("@DateOfBirth", DateTime.Parse(textBox6.Text));
                cmdPerson.Parameters.AddWithValue("@Gender", genderValue);

                int personId = Convert.ToInt32(cmdPerson.ExecuteScalar());

                SqlCommand cmdStudent = new SqlCommand("INSERT INTO Student (Id, RegistrationNo) " +
                                                       "VALUES (@Id, @RegistrationNo)", con);
                cmdStudent.Parameters.AddWithValue("@Id", personId);
                cmdStudent.Parameters.AddWithValue("@RegistrationNo", textBox1.Text);

                cmdStudent.ExecuteNonQuery();

                MessageBox.Show("Student Added Successfully with ID:" + personId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
