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
    public partial class Op4b : Form
    {
        public Op4b()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op4 op4 = new Op4();
            op4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmdCheckGroup = new SqlCommand("SELECT COUNT(*) FROM [Group] WHERE Id = @GroupId", con);
                cmdCheckGroup.Parameters.AddWithValue("@GroupId", textBox1.Text);
                int groupCount = Convert.ToInt32(cmdCheckGroup.ExecuteScalar());

                if (groupCount == 0)
                {
                    MessageBox.Show("Group with the specified ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmdCheckStudent = new SqlCommand("SELECT COUNT(*) FROM student WHERE Id = @StudentId", con);
                cmdCheckStudent.Parameters.AddWithValue("@StudentId", textBox2.Text);
                int studentCount = Convert.ToInt32(cmdCheckStudent.ExecuteScalar());

                if (studentCount == 0)
                {
                    MessageBox.Show("Student with the specified ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO GroupStudent (GroupId, StudentId, status, AssignmentDate) VALUES (@GroupId, @StudentId, @Status, @AssignmentDate)", con);
                cmd.Parameters.AddWithValue("@GroupId", textBox1.Text);
                cmd.Parameters.AddWithValue("@StudentId", textBox2.Text);
                cmd.Parameters.AddWithValue("@Status", textBox3.Text);
                cmd.Parameters.AddWithValue("@AssignmentDate", DateTime.Parse(textBox4.Text));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Student added to group successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add student to group.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
