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
using System.IO;

namespace ExamApp

{
    public partial class candidate : Form
    {
        public candidate()
        {
            InitializeComponent();
            DisplayCandidates();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\Documents\examapp.mdf;Integrated Security=True;Connect Timeout=30");

        private void DisplayCandidates()
        {
            con.Open();
            string Query = "select * from CandidateTbl";
            SqlDataAdapter sda = new SqlDataAdapter( Query , con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
            
        }



        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CNameTb.Text) || string.IsNullOrWhiteSpace(CAgeTb.Text) || string.IsNullOrWhiteSpace(AddressTb.Text) || string.IsNullOrWhiteSpace(PasswordTb.Text) || string.IsNullOrWhiteSpace(PhoneTb.Text))
            {
                MessageBox.Show("Missing information. Please enter a value in all TextBoxes.");
            }
            else
            {
                try
                {    int score = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CandidateTbl (CName,CAge,CPass,CScore,CAdd,Cphone) values(@Cn,@Ca,@Cp,@Cs,@Cad,@Cph)", con);
                    cmd.Parameters.AddWithValue("@Cn" , CNameTb.Text);
                    cmd.Parameters.AddWithValue("@Ca", CAgeTb.Text);
                    cmd.Parameters.AddWithValue("@Cp", PasswordTb.Text);
                    cmd.Parameters.AddWithValue("@Cs", score);
                    cmd.Parameters.AddWithValue("@Cad", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cph", PhoneTb.Text );
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Candidate Register Successfully");
                    con.Close();
                    clearAll();
                    DisplayCandidates();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }  
        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // selceting from the datagridview
            //if(CNameTb.Text == "")
            //{
            //    key = 0;
             //}
            //else{
            //key = convert.ToInt32(dataGridView1.Selected.Rows[0].Cells[0].Value.ToString());
            //}
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                CNameTb.Text = row.Cells["CName"].Value.ToString();
                CAgeTb.Text = row.Cells["CAge"].Value.ToString();
                PasswordTb.Text = row.Cells["CPass"].Value.ToString();
                AddressTb.Text = row.Cells["CAdd"].Value.ToString();
                PhoneTb.Text = row.Cells["Cphone"].Value.ToString();
                // textBox2.Text = row.Cells["other_discription"].Value.ToString();
            
            }
            //if (CNameTb.Text == "")
            //{
            //    key = 0;
            //}
            //else
            //{
            //    key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
           // }
        }
        public void clearAll()
        {// this  two method equally clear all what you type on the texboxs
            CNameTb.Clear();
            CAgeTb.Clear();
            AddressTb.Clear();
            PasswordTb.Clear();
            PhoneTb.Clear();

       //     CNameTb.Text = "";     all througt
        //    CAgeTb.Clear();
        //    AddressTl.Clear();
         //   PasswordTb.Clear();
         //   PhoneTb.Clear();
        }
        
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            // this code help to show a a message box button with a yes or a no
            if (MessageBox.Show("Unsave Data Will be Lost", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                //just calling the public void clearAll() above
                clearAll();
            }
            else
            {
                MessageBox.Show("No Data Wast Type");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == true)
            {
                 PasswordTb.PasswordChar = '\0';
                checkBox1.Text = "Hide Password";
            }
            else
            {
                PasswordTb.PasswordChar = '*';
                checkBox1.Text = "Show Password";
            }
        }
        // public string Key { get; set; }
      //  public string Key { get; private set; }
          int Key = 0;
        private void EditBtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(CNameTb.Text) || string.IsNullOrWhiteSpace(CAgeTb.Text) || string.IsNullOrWhiteSpace(AddressTb.Text) || string.IsNullOrWhiteSpace(PasswordTb.Text) || string.IsNullOrWhiteSpace(PhoneTb.Text))
            {
                MessageBox.Show("Missing information. Please enter a value in all TextBoxes.");
            }
            else
            {
                try
                {
                    int score = 0;
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update CandidateTbl set CName=@Cn,CAge=@Cn,CPass=@Cp,CAdd=@Cad, Cphone=@Cph where CId=@Ckey", con);
                    cmd.Parameters.AddWithValue("@Cn", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@Ca", CAgeTb.Text);
                    cmd.Parameters.AddWithValue("@Cp", PasswordTb.Text);
                   // cmd.Parameters.AddWithValue("@Cs", score);
                    cmd.Parameters.AddWithValue("@Cad", AddressTb.Text);
                    cmd.Parameters.AddWithValue("@Cph", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Ckey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Candidate Updated Successfully");
                    con.Close();
                    clearAll();
                    DisplayCandidates();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }  
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log Out", "🚨👂Information🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                login m1 = new login();
                this.Hide();
                m1.Show();
            }
        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            candidate can = new candidate();
            can.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
             candidate can = new candidate();
            can.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Show();
            this.Hide();
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Show();
            this.Hide();
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log Out", "🚨👂Information🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                login m1 = new login();
                this.Hide();
                m1.Show();
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

        private void label2_Click(object sender, EventArgs e)
        {
            Question quest = new Question();
            quest.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CNameTb.Text) || string.IsNullOrWhiteSpace(CAgeTb.Text) || string.IsNullOrWhiteSpace(PasswordTb.Text) || string.IsNullOrWhiteSpace(AddressTb.Text) || string.IsNullOrWhiteSpace(PhoneTb.Text) )
                {
                    MessageBox.Show("Select a Candidate to Delete");
                }
                else
                {
                    con.Open();

                    string query = " delete from CandidateTbl where CName='" + CNameTb.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Candidate Deleted Successfully!");
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

        private void CAgeTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            about ob = new about();
            ob.Show();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddressTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void CNameTb_TextChanged(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CSearch_TextChanged(object sender, EventArgs e)
        {

        }





    }
}
