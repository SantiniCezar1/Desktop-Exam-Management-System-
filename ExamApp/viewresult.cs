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

namespace ExamApp
{
    public partial class viewresult : Form
    {
        public viewresult()
        {
            InitializeComponent();
            GetSubjects();
            GetCandidate();
            DisplayResult();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\Documents\examapp.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetSubjects()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select SName from SubjectTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SName", typeof(string));
            dt.Load(rdr);
            SubjectCb.ValueMember = "SName";
            SubjectCb.DataSource = dt;
            con.Close();

        }
        private void GetCandidate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select CName from CandidateTbl", con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CName", typeof(string));
            dt.Load(rdr);
            Cb.ValueMember = "CName";
            Cb.DataSource = dt;
            con.Close();

        }

        private void DisplayResult()
        {
            con.Open();
            string Query = "select * from ResultTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }
        private void filtery()
        {
            
            string Query = "select * from ResultTbl where RSubject='"+SubjectCb.SelectedValue.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }
          private void filteryCd()
        {
            con.Open();
            string Query = "select * from ResultTbl where RCandidate='"+Cb.SelectedValue.ToString()+"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SubjectCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtery();
        }

        private void Cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filteryCd();
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            candidate m1 = new candidate();
            this.Hide();
            m1.Show();
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            Question m1 = new Question();
            this.Hide();
            m1.Show();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            subject m1 = new subject();
            this.Hide();
            m1.Show();
        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            about ob = new about();
            ob.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        

        private void ResetBtn_Click(object sender, EventArgs e)
        {
       
            
        }

     

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                RSubject.Text = row.Cells["RSubject"].Value.ToString();
                RCandidate.Text = row.Cells["RCandidate"].Value.ToString();
                RDate.Text = row.Cells["RDate"].Value.ToString();
                RTime.Text = row.Cells["RTime"].Value.ToString();
                RScore.Text = row.Cells["Rscore"].Value.ToString();
                // textBox2.Text = row.Cells["other_discription"].Value.ToString();

            }
        }

        private void presult_Paint(object sender, PaintEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        private void clearAll()
        { 
         RSubject.Clear();
         RCandidate.Text = "";
         RDate.Clear();
         RTime.Clear();
         RScore.Clear();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(RSubject.Text) || string.IsNullOrWhiteSpace(RCandidate.Text) || string.IsNullOrWhiteSpace(RDate.Text) || string.IsNullOrWhiteSpace(RTime.Text) || string.IsNullOrWhiteSpace(RScore.Text))
                {
                    MessageBox.Show("Select a Candidate to Delete Result");
                }
                else
                {
                    con.Open();

                    string query = " delete from ResultTbl where RCandidate='" + RCandidate.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Result Deleted Successfully!");
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
    }
}
