﻿using System;
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
    public partial class Op7b2 : Form
    {
        public Op7b2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var con = Configuration.getInstance().getConnection();

                SqlCommand cmd = new SqlCommand("UPDATE Evaluation SET TotalMarks = @TotalMarks WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Total marks updated successfully.");
                }
                else
                {
                    MessageBox.Show("No matching record found for the given evaluation Id.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Op7b opb = new Op7b();
            opb.Show();
            this.Hide();
        }
    }
}
