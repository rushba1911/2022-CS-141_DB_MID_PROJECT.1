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
    public partial class Op6 : Form
    {
        public Op6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                int advisorRole = int.Parse(textBox3.Text);
                if (advisorRole != 11 && advisorRole != 12 && advisorRole != 14)
                {
                    MessageBox.Show("Invalid advisor role. Please enter 11 for Main Advisor, 12 for Co-Advisor, or 14 for Industry Advisor.");
                    return;
                }

                SqlCommand checkAdvisorCmd = new SqlCommand("SELECT COUNT(*) FROM Advisor WHERE Id = @AdvisorId", con);
                checkAdvisorCmd.Parameters.AddWithValue("@AdvisorId", int.Parse(textBox1.Text));
                int advisorCount = (int)checkAdvisorCmd.ExecuteScalar();

                SqlCommand checkProjectCmd = new SqlCommand("SELECT COUNT(*) FROM Project WHERE Id = @ProjectId", con);
                checkProjectCmd.Parameters.AddWithValue("@ProjectId", int.Parse(textBox2.Text));
                int projectCount = (int)checkProjectCmd.ExecuteScalar();

                if (advisorCount == 0 || projectCount == 0)
                {
                    MessageBox.Show("Advisor ID or Project ID does not exist in the system.");
                    return;
                }

                SqlCommand insertProjectAdvisorCmd = new SqlCommand("INSERT INTO ProjectAdvisor (AdvisorId, ProjectId, AdvisorRole, AssignmentDate) VALUES (@AdvisorId, @ProjectId, @AdvisorRole, @AssignmentDate)", con);
                insertProjectAdvisorCmd.Parameters.AddWithValue("@AdvisorId", int.Parse(textBox1.Text));
                insertProjectAdvisorCmd.Parameters.AddWithValue("@ProjectId", int.Parse(textBox2.Text));
                insertProjectAdvisorCmd.Parameters.AddWithValue("@AdvisorRole", advisorRole);
                insertProjectAdvisorCmd.Parameters.AddWithValue("@AssignmentDate", DateTime.Parse(textBox4.Text));
                int rowsAffected = insertProjectAdvisorCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Advisor assigned to project successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to assign advisor to project.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
