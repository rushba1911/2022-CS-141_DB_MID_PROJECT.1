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
    public partial class Op5 : Form
    {
        public Op5()
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

                SqlCommand checkGroupCmd = new SqlCommand("SELECT COUNT(*) FROM [Group] WHERE Id = @GroupId", con);
                checkGroupCmd.Parameters.AddWithValue("@GroupId", int.Parse(textBox1.Text));
                int groupCount = (int)checkGroupCmd.ExecuteScalar();

                SqlCommand checkProjectCmd = new SqlCommand("SELECT COUNT(*) FROM Project WHERE Id = @ProjectId", con);
                checkProjectCmd.Parameters.AddWithValue("@ProjectId", int.Parse(textBox2.Text));
                int projectCount = (int)checkProjectCmd.ExecuteScalar();

                if (groupCount == 0 || projectCount == 0)
                {
                    MessageBox.Show("Group ID or Project ID does not exist in the system.");
                    return;
                }

                SqlCommand updateGroupStudentCmd = new SqlCommand("UPDATE GroupStudent SET AssignmentDate = @AssignmentDate WHERE GroupId = @GroupId", con);
                updateGroupStudentCmd.Parameters.AddWithValue("@AssignmentDate", DateTime.Parse(textBox3.Text));
                updateGroupStudentCmd.Parameters.AddWithValue("@GroupId", int.Parse(textBox1.Text));
                int groupStudentRowsAffected = updateGroupStudentCmd.ExecuteNonQuery();

                SqlCommand insertGroupProjectCmd = new SqlCommand("INSERT INTO GroupProject (ProjectId, GroupId, AssignmentDate) VALUES (@ProjectId, @GroupId, @AssignmentDate)", con);
                insertGroupProjectCmd.Parameters.AddWithValue("@ProjectId", int.Parse(textBox2.Text));
                insertGroupProjectCmd.Parameters.AddWithValue("@GroupId", int.Parse(textBox1.Text));
                insertGroupProjectCmd.Parameters.AddWithValue("@AssignmentDate", DateTime.Parse(textBox3.Text));
                int groupProjectRowsAffected = insertGroupProjectCmd.ExecuteNonQuery();

                if (groupStudentRowsAffected > 0 && groupProjectRowsAffected > 0)
                {
                    MessageBox.Show("Project assigned to group successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to assign project to group.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
