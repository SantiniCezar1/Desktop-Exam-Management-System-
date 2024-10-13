using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace ExamApp
{
    public partial class subject : Form
    {
        public subject()
        {
            InitializeComponent();
            DisplaySubjects();
        }
        int Key = 0;
        public void clearAll()
        {// this  two method equally clear all what you type on the texboxs
            SNameTb.Clear();
            Key = 0;
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\Documents\examapp.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplaySubjects()
        {
            con.Open();
            string Query = "select * from SubjectTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SNameTb.Text)  )
            {
                MessageBox.Show("Missing information. Please enter a value To be Save!");
            }
            else
            {
                try
                {
                 
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SubjectTbl (SName) values(@Sn)", con);
                    cmd.Parameters.AddWithValue("@Sn", SNameTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subjecct Register Successfully");
                    con.Close();
                    clearAll();
                    DisplaySubjects();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }  
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SNameTb.Text))
            {
                MessageBox.Show("Nothing has been type!");
            }
            else
            {
                clearAll();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // selceting from the datagridview
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                SNameTb.Text = row.Cells["SName"].Value.ToString();
              
                // textBox2.Text = row.Cells["other_discription"].Value.ToString();
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SNameTb.Text))
            {
                MessageBox.Show("Missing information. Please enter a value to Edit!");
            }
            else
            {
                try
                {
                    int score = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update SubjectTbl set SName=@Sn where SId=@Skey", con);
                    cmd.Parameters.AddWithValue("@Sn", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@Skey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject Updated Successfully");
                    con.Close();
                    clearAll();
                    DisplaySubjects();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }  
        }

        private void label4_Click(object sender, EventArgs e)
        {
            candidate can = new candidate();
            can.Show();
            this.Hide();
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            candidate can = new candidate();
            can.Show();
            this.Hide();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Question ques = new Question();
            ques.Show();
            this.Hide();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log Out", "🚨👂Information🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                login m1 = new login();
                this.Hide();
                m1.Show();
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if ( string.IsNullOrWhiteSpace(SNameTb.Text))
                {
                    MessageBox.Show(" Select the Subject to Delete!");
                }
                else
                {
                    con.Open();

                    string query = " delete from SubjectTbl where SName='" + SNameTb.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Subject Deleted Successfully!");
                    con.Close();
                    // populate();
                    clearAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            about ob = new about();
            ob.Show();
        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            viewresult view = new viewresult();
            view.Show();
            this.Hide();
        }

        private void gunaPictureBox1_Click_1(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Hide();
            this.Show();
        }
    }
}
