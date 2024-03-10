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
    public partial class Op7a : Form
    {
        public Op7a()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                if (string.IsNullOrWhiteSpace(textBox1.Text) || !int.TryParse(textBox2.Text, out int totalMarks) || !int.TryParse(textBox3.Text, out int totalWeightage))
                {
                    MessageBox.Show("Invalid input. Please provide valid values for evaluation name, total marks, and total weightage.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Evaluation (Name, TotalMarks, TotalWeightage) VALUES (@Name, @TotalMarks, @TotalWeightage); SELECT SCOPE_IDENTITY();", con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);
                cmd.Parameters.AddWithValue("@TotalWeightage", totalWeightage);

                int evaluationId = Convert.ToInt32(cmd.ExecuteScalar());

                MessageBox.Show($"Evaluation '{textBox1.Text}' created successfully with ID: {evaluationId}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op7 op7 = new Op7();
            op7.Show();
            this.Hide();
        }
    }
}
