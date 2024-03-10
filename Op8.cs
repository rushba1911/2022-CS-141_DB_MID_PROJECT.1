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
    public partial class Op8 : Form
    {
        public Op8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                int groupId = int.Parse(textBox1.Text);
                int evaluationId = int.Parse(textBox2.Text);
                int obtainedMarks = int.Parse(textBox3.Text);
                DateTime evaluationDate = DateTime.Parse(textBox4.Text);

                SqlCommand checkGroupCmd = new SqlCommand("SELECT COUNT(*) FROM [Group] WHERE Id = @GroupId", con);
                checkGroupCmd.Parameters.AddWithValue("@GroupId", groupId);
                int groupCount = (int)checkGroupCmd.ExecuteScalar();

                SqlCommand checkEvaluationCmd = new SqlCommand("SELECT COUNT(*) FROM Evaluation WHERE Id = @EvaluationId", con);
                checkEvaluationCmd.Parameters.AddWithValue("@EvaluationId", evaluationId);
                int evaluationCount = (int)checkEvaluationCmd.ExecuteScalar();

                if (groupCount == 0 || evaluationCount == 0)
                {
                    MessageBox.Show("Group ID or Evaluation ID does not exist.");
                    return;
                }

                SqlCommand checkTotalMarksCmd = new SqlCommand("SELECT TotalMarks FROM Evaluation WHERE Id = @EvaluationId", con);
                checkTotalMarksCmd.Parameters.AddWithValue("@EvaluationId", evaluationId);
                int totalMarks = (int)checkTotalMarksCmd.ExecuteScalar();

                if (obtainedMarks > totalMarks)
                {
                    MessageBox.Show("Obtained marks cannot exceed total marks for the evaluation.");
                    return;
                }

                SqlCommand insertCmd = new SqlCommand("INSERT INTO GroupEvaluation (GroupId, EvaluationId, ObtainedMarks, EvaluationDate) " +
                                                       "VALUES (@GroupId, @EvaluationId, @ObtainedMarks, @EvaluationDate)", con);
                insertCmd.Parameters.AddWithValue("@GroupId", groupId);
                insertCmd.Parameters.AddWithValue("@EvaluationId", evaluationId);
                insertCmd.Parameters.AddWithValue("@ObtainedMarks", obtainedMarks);
                insertCmd.Parameters.AddWithValue("@EvaluationDate", evaluationDate);
                insertCmd.ExecuteNonQuery();

                MessageBox.Show("Group evaluation added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }
    }
}
