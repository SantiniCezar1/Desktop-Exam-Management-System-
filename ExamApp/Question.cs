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
    public partial class Question : Form
    {
        public Question()
        {
            InitializeComponent();
            DisplayQuestions();
            GetSubjects();
            
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\Documents\examapp.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetSubjects()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand( "select SName from SubjectTbl",con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SName", typeof(string));
            dt.Load(rdr);
            SubjectCb.ValueMember = "SName";
            SubjectCb.DataSource = dt;
            con.Close();
           
        }

        public void clearAll()
        {// this  two method equally clear all what you type on the texboxs
            QuestTb.Clear();
            Op1Tb.Clear();
            Op2Tb.Clear();
            Op3Tb.Clear();
            Op4Tb.Clear();
            AnswerTb.Clear();
            SubjectCb.SelectedIndex = 0;
        }
        private void DisplayQuestions()
        {
            con.Open();
            string Query = "select * from QuestionTbl";
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        int Key = 0;
        private void Button2_Click(object sender, EventArgs e)
        {
         /*    if (string.IsNullOrWhiteSpace(QuestTb.Text) || string.IsNullOrWhiteSpace(Op1Tb.Text) || string.IsNullOrWhiteSpace(Op2Tb.Text) || string.IsNullOrWhiteSpace(Op3Tb.Text) || string.IsNullOrWhiteSpace(Op4Tb.Text) || string.IsNullOrWhiteSpace(AnswerTb.Text))

            {
                MessageBox.Show("Missing information. Please enter a value in all TextBoxes.");
            }
            else
            {
                try
                {
                  
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update QuestionTbl set QDesc=@Qd,QO1=@O1,QO2=@O2,QO3=@O3, QO4=@O4,QA=@Qan,QS=@Qsu     where QId=@QKey", con);
                    cmd.Parameters.AddWithValue("@Qd", QuestTb.Text);
                    cmd.Parameters.AddWithValue("@O1", Op1Tb.Text);
                    cmd.Parameters.AddWithValue("@O2", Op2Tb.Text);
                    cmd.Parameters.AddWithValue("@O3", Op3Tb.Text);
                    cmd.Parameters.AddWithValue("@O4", Op4Tb.Text);
                    cmd.Parameters.AddWithValue("@Qan", AnswerTb.Text);
                    cmd.Parameters.AddWithValue("@Qsu", SubjectCb.SelectedValue != null ? SubjectCb.SelectedValue.ToString() : string.Empty);
                    cmd.Parameters.AddWithValue("@Qkey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Question Updated Successfully");
                    con.Close();

                    clearAll();
                    DisplayQuestions();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }  */

            if (string.IsNullOrWhiteSpace(QuestTb.Text) || string.IsNullOrWhiteSpace(Op1Tb.Text) || string.IsNullOrWhiteSpace(Op2Tb.Text) || string.IsNullOrWhiteSpace(Op3Tb.Text) || string.IsNullOrWhiteSpace(Op4Tb.Text) || string.IsNullOrWhiteSpace(AnswerTb.Text))
            {
                MessageBox.Show("Missing information. Please enter a value in all TextBoxes.");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("update QuestionTbl set QDesc=@QDesc, QO1=@QO1, QO2=@QO2, QO3=@QO3, QO4=@QO4, QA=@QA, QS=@QS where QId=@key", con);
                    cmd.Parameters.AddWithValue("@QDesc", QuestTb.Text);
                    cmd.Parameters.AddWithValue("@QO1", Op1Tb.Text);
                    cmd.Parameters.AddWithValue("@QO2", Op2Tb.Text);
                    cmd.Parameters.AddWithValue("@QO3", Op3Tb.Text);
                    cmd.Parameters.AddWithValue("@QO4", Op4Tb.Text);
                    cmd.Parameters.AddWithValue("@QA", AnswerTb.Text);
                    cmd.Parameters.AddWithValue("@QS", SubjectCb.SelectedValue != null ? SubjectCb.SelectedValue.ToString() : string.Empty);
                    cmd.Parameters.AddWithValue("@QId", key);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Question Updated Successfully");
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated. Please check the QId value.");
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                finally
                {
                    con.Close(); // Close the connection in the finally block to ensure it gets closed  
                }
                clearAll();
                DisplayQuestions();
            }



        }

        private void gunaPictureBox3_Click(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Show();
            this.Hide();
        }

        private void gunaPictureBox2_Click(object sender, EventArgs e)
        {
            candidate can = new candidate();
            can.Show();
            this.Hide();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(QuestTb.Text) || string.IsNullOrWhiteSpace(Op1Tb.Text) || string.IsNullOrWhiteSpace(Op2Tb.Text) || string.IsNullOrWhiteSpace(Op3Tb.Text) || string.IsNullOrWhiteSpace(Op4Tb.Text) || string.IsNullOrWhiteSpace(AnswerTb.Text))
            {
                MessageBox.Show("Missing information. Please enter a value in all TextBoxes.");
            }
            else
            {
                try
                {
                  
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into QuestionTbl (QDesc,QO1,QO2,QO3,QO4,QA,QS) values(@Qd,@O1,@O2,@O3,@O4,@Qan,@Qsu)", con);
                    cmd.Parameters.AddWithValue("@Qd", QuestTb.Text);
                    cmd.Parameters.AddWithValue("@O1", Op1Tb.Text);
                    cmd.Parameters.AddWithValue("@O2", Op2Tb.Text);
                    cmd.Parameters.AddWithValue("@O3", Op3Tb.Text);
                    cmd.Parameters.AddWithValue("@O4", Op4Tb.Text);
                    cmd.Parameters.AddWithValue("@Qan", AnswerTb.Text);
                    cmd.Parameters.AddWithValue("@Qsu", SubjectCb.SelectedValue != null ? SubjectCb.SelectedValue.ToString() : string.Empty);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Question Added Successfully");
                    con.Close();

                    clearAll();
                    DisplayQuestions();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }  
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
                MessageBox.Show("Your Choose was Aprouve Successfully");
            }
        }

        private void Op3Tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {

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
        int key = 0;
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                QuestTb.Text = row.Cells["QDesc"].Value.ToString();
                Op1Tb.Text = row.Cells["QO1"].Value.ToString();
                Op2Tb.Text = row.Cells["QO2"].Value.ToString();
                Op3Tb.Text = row.Cells["QO3"].Value.ToString();
                Op4Tb.Text = row.Cells["QO4"].Value.ToString();
                AnswerTb.Text = row.Cells["QA"].Value.ToString();
                SubjectCb.SelectedValue = row.Cells["QS"].Value.ToString();
                // textBox2.Text = row.Cells["other_discription"].Value.ToString();
               
                //if (QuestTb.Text == "")
               // {
              //      key = 0;
             //   }
                //else
                //{
                 //   key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
               // }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            candidate can = new candidate();
            can.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Question quest = new Question();
            quest.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Show();
            this.Hide();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(QuestTb.Text) || string.IsNullOrWhiteSpace(Op1Tb.Text) || string.IsNullOrWhiteSpace(Op2Tb.Text) || string.IsNullOrWhiteSpace(Op3Tb.Text) || string.IsNullOrWhiteSpace(Op4Tb.Text) || string.IsNullOrWhiteSpace(AnswerTb.Text))
                {
                    MessageBox.Show("Select The Question to Delete");
                }
                else
                {
                    con.Open();
                  
                    string query = " delete from QuestionTbl where QDesc='" + QuestTb.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();                                      
                    MessageBox.Show("Question Deleted Successfully!");
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Question_Load(object sender, EventArgs e)
        {
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void SubjectCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            about ob = new about();
            ob.Show();
        }

        private void label11_Click(object sender, EventArgs e)
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

        private void gunaPictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AnswerTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Op4Tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Op2Tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Op1Tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void QuestTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {
            subject sub = new subject();
            sub.Show();
            this.Hide();
        }

        private void CSearch_TextChanged(object sender, EventArgs e)
        {
          string searchValue = CSearch.Text;  
if (string.IsNullOrWhiteSpace(searchValue))  
{  
   BindingSource bs = new BindingSource();  
   bs.DataSource = dataGridView1.DataSource;  
   bs.Filter = "";  
   dataGridView1.DataSource = bs;  
}  
else  
{  
   BindingSource bs = new BindingSource();  
   bs.DataSource = dataGridView1.DataSource;  
   bs.Filter = "QDesc LIKE '%{searchValue}%'";  
   dataGridView1.DataSource = bs;  
}

        }

      
    }
}
