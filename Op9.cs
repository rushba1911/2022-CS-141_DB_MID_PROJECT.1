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
    public partial class Op9 : Form
    {
        public Op9()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm m = new MainForm();
            m.Show();
            this.Hide();
        }

        private void Op9_Load(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                // Retrieve data from GroupStudent table
                SqlDataAdapter groupStudentAdapter = new SqlDataAdapter("SELECT gs.GroupId, gs.StudentId, l1.Value AS Status, gs.AssignmentDate " +
                                                                          "FROM GroupStudent gs " +
                                                                          "INNER JOIN Lookup l1 ON gs.Status = l1.Id", con);
                DataTable groupStudentTable = new DataTable();
                groupStudentAdapter.Fill(groupStudentTable);

                // Retrieve data from GroupProject table
                SqlDataAdapter groupProjectAdapter = new SqlDataAdapter("SELECT gp.GroupId, gp.ProjectId, gp.AssignmentDate " +
                                                                          "FROM GroupProject gp", con);
                DataTable groupProjectTable = new DataTable();
                groupProjectAdapter.Fill(groupProjectTable);

                // Retrieve data from ProjectAdvisor table
                SqlDataAdapter projectAdvisorAdapter = new SqlDataAdapter("SELECT pa.ProjectId, pa.AdvisorId, l2.Value AS AdvisorRole, pa.AssignmentDate " +
                                                                           "FROM ProjectAdvisor pa " +
                                                                           "INNER JOIN Lookup l2 ON pa.AdvisorRole = l2.Id", con);
                DataTable projectAdvisorTable = new DataTable();
                projectAdvisorAdapter.Fill(projectAdvisorTable);

                // Retrieve data from GroupEvaluation table
                SqlDataAdapter groupEvaluationAdapter = new SqlDataAdapter("SELECT ge.GroupId, ge.EvaluationId, ge.ObtainedMarks, ge.EvaluationDate " +
                                                                             "FROM GroupEvaluation ge", con);
                DataTable groupEvaluationTable = new DataTable();
                groupEvaluationAdapter.Fill(groupEvaluationTable);

                // Merge all tables to remove repeating columns
                DataTable mergedTable = new DataTable();
                mergedTable.Merge(groupStudentTable, false, MissingSchemaAction.Add);
                mergedTable.Merge(groupProjectTable, false, MissingSchemaAction.Add);
                mergedTable.Merge(projectAdvisorTable, false, MissingSchemaAction.Add);
                mergedTable.Merge(groupEvaluationTable, false, MissingSchemaAction.Add);

                // Display data in DataGridView
                dataGridView1.DataSource = mergedTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
