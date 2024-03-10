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
    public partial class Op4c : Form
    {
        public Op4c()
        {
            InitializeComponent();
        }

        private void Op4c_Load(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("SELECT g.id AS GroupId, g.created_on AS CreationDate, gs.StudentId, gs.AssignmentDate, " +
                                                 "l.Value AS Status " +
                                                 "FROM [group] g " +
                                                 "INNER JOIN g=GroupStudent gs ON g.id = gs.GroupId " +
                                                 "LEFT JOIN Lookup l ON gs.Status = l.id", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                    MessageBox.Show("Group details retrieved successfully");
                }
                else
                {
                    dataGridView1.DataSource = null;
                    MessageBox.Show("No group records found.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op4 op4 = new Op4();
            op4.Show();
            this.Hide();
        }
    }
}
