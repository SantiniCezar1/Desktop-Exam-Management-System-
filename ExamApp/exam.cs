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
    public partial class exam : Form
    {
        public exam()
        {
            InitializeComponent();
            
             
           
            Cnamelbl.Text = login.CandName;
            Subjectlbl.Text = login.SubName;
          // multirandom(); 
            FetchQuestions();
            savehighest();

          
         
          
        }
    
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\DELL\Documents\examapp.mdf;Integrated Security=True;Connect Timeout=30");
        string a1, a2, a3, a4, a5, a6, a7, a8, a9, a10;

      private int GenerateRand()
        {
            Random rd = new Random();
            int x = rd.Next(7, 29);
            int y = rd.Next(7, 29);
            int z = rd.Next(7, 29);
            MessageBox.Show(""+x+ "and" + y+ "and"+z);
            return x ;
        }

      private void savehighest()
      { 
          con.Open();
      SqlDataAdapter sda2 = new SqlDataAdapter("select max(RScore) from ResultTbl where RCandidate = '"+Cnamelbl.Text+"' ",con);
        DataTable dt2 = new DataTable();
          sda2.Fill(dt2);

        //  int BestScore = Convert.ToInt32(dt2.Rows[0][0].ToString());
          int BestScore = dt2.Rows[0][0] == DBNull.Value ? 0 : Convert.ToInt32(dt2.Rows[0][0].ToString());

          try
          {
           
              
              SqlCommand cmd = new SqlCommand("update CandidateTbl set CScore=@Cs where CName = @Cn", con);
              cmd.Parameters.AddWithValue("@Cn", Cnamelbl.Text);
              cmd.Parameters.AddWithValue("@Cs", BestScore);
             
              cmd.ExecuteNonQuery();
              MessageBox.Show("Candidate Updated Successfully");
              con.Close();
            
          }
          catch (Exception Ex)
          {
              MessageBox.Show(Ex.Message);
          }
        con.Close();

      }
        //random question generate
        int[] keys = new int[10];
        private void multirandom()
        {
            HashSet<int> numbers = new HashSet<int>();
            var rnd = new Random();
            while (numbers.Count < 10)
            {                        //1,4
                numbers.Add(rnd.Next(7, 29));
            }
            for (int i = 0; i < 10; i++)
            {
                keys[i] = numbers.ElementAt(i);
            }
        }
         /*  for (int y = 0; y < 10; y++)
            {
                MessageBox.Show("" + keys[y]);
            }*/
        // generate 10 random number
     



        //random question generate
        private void FetchQuestions()
         {
             try
             {
                  //int Qnum = GenerateRand();
                 //GenerateRand();
                 multirandom();
                 con.Open();
                 string query = "select * from QuestionTbl where QId ="+keys[0]+" ";
                 SqlCommand cmd = new SqlCommand(query, con);
                 DataTable dt = new DataTable();
                 SqlDataAdapter sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q1.Text = dr["QDesc"].ToString();
                     Q101.Text = dr["QO1"].ToString();
                     Q102.Text = dr["QO2"].ToString();
                     Q103.Text = dr["QO3"].ToString();
                     Q104.Text = dr["QO4"].ToString();
                     a1 = dr["QA"].ToString();
                 }

                // //quetion 2
                 string query1 = "select * from QuestionTbl where QId =" + keys[1] + " ";
                  cmd = new SqlCommand(query1, con);
                  dt = new DataTable();
                  sda = new SqlDataAdapter(cmd);
                  sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q2.Text = dr["QDesc"].ToString();
                     Q201.Text = dr["QO1"].ToString();
                     Q202.Text = dr["QO2"].ToString();
                     Q203.Text = dr["QO3"].ToString();
                     Q204.Text = dr["QO4"].ToString();
                     a2 = dr["QA"].ToString();
                 }
              ////
                 // question 3
                 string query2 = "select * from QuestionTbl where QId =" + keys[2] + " ";
                 cmd = new SqlCommand(query2, con);
                 dt = new DataTable();
                 sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q3.Text = dr["QDesc"].ToString();
                     Q301.Text = dr["QO1"].ToString();
                     Q302.Text = dr["QO2"].ToString();
                     Q303.Text = dr["QO3"].ToString();
                     Q304.Text = dr["QO4"].ToString();
                     a3 = dr["QA"].ToString();
                 }
                 ///
                 //question 4
                 string query3 = "select * from QuestionTbl where QId =" + keys[3] + " ";
                 cmd = new SqlCommand(query3, con);
                 dt = new DataTable();
                 sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q4.Text = dr["QDesc"].ToString();
                     Q401.Text = dr["QO1"].ToString();
                     Q402.Text = dr["QO2"].ToString();
                     Q403.Text = dr["QO3"].ToString();
                     Q404.Text = dr["QO4"].ToString();
                     a4 = dr["QA"].ToString();
                 }
                 //question5
                 string query4 = "select * from QuestionTbl where QId =" + keys[4] + " ";
                 cmd = new SqlCommand(query4, con);
                 dt = new DataTable();
                 sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q5.Text = dr["QDesc"].ToString();
                     Q501.Text = dr["QO1"].ToString();
                     Q502.Text = dr["QO2"].ToString();
                     Q503.Text = dr["QO3"].ToString();
                     Q504.Text = dr["QO4"].ToString();
                     a5 = dr["QA"].ToString();
                 }
                 //question 6
                 string query5 = "select * from QuestionTbl where QId =" + keys[5] + " ";
                 cmd = new SqlCommand(query5, con);
                 dt = new DataTable();
                 sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q6.Text = dr["QDesc"].ToString();
                     Q601.Text = dr["QO1"].ToString();
                     Q602.Text = dr["QO2"].ToString();
                     Q603.Text = dr["QO3"].ToString();
                     Q604.Text = dr["QO4"].ToString();
                     a6 = dr["QA"].ToString();
                 }
                 //question 7
                 string query6 = "select * from QuestionTbl where QId =" + keys[6] + " ";
                 cmd = new SqlCommand(query6, con);
                 dt = new DataTable();
                 sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q7.Text = dr["QDesc"].ToString();
                     Q701.Text = dr["QO1"].ToString();
                     Q702.Text = dr["QO2"].ToString();
                     Q703.Text = dr["QO3"].ToString();
                     Q704.Text = dr["QO4"].ToString();
                     a7 = dr["QA"].ToString();
                 }
                 //
                 //question 8
                 string query7 = "select * from QuestionTbl where QId =" + keys[7] + " ";
                 cmd = new SqlCommand(query7, con);
                 dt = new DataTable();
                 sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q8.Text = dr["QDesc"].ToString();
                     Q801.Text = dr["QO1"].ToString();
                     Q802.Text = dr["QO2"].ToString();
                     Q803.Text = dr["QO3"].ToString();
                     Q804.Text = dr["QO4"].ToString();
                     a8 = dr["QA"].ToString();
                 }
                 //
                 //question 9
                 string query8 = "select * from QuestionTbl where QId =" + keys[8] + " ";
                 cmd = new SqlCommand(query8, con);
                 dt = new DataTable();
                 sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q9.Text = dr["QDesc"].ToString();
                     Q901.Text = dr["QO1"].ToString();
                     Q902.Text = dr["QO2"].ToString();
                     Q903.Text = dr["QO3"].ToString();
                     Q904.Text = dr["QO4"].ToString();
                     a9 = dr["QA"].ToString();
                 }
                 //
                 //question 9
                 string query9 = "select * from QuestionTbl where QId =" + keys[9] + " ";
                 cmd = new SqlCommand(query9, con);
                 dt = new DataTable();
                 sda = new SqlDataAdapter(cmd);
                 sda.Fill(dt);

                 foreach (DataRow dr in dt.Rows)
                 {
                     Q10.Text = dr["QDesc"].ToString();
                     Q1001.Text = dr["QO1"].ToString();
                     Q1002.Text = dr["QO2"].ToString();
                     Q1003.Text = dr["QO3"].ToString();
                     Q1004.Text = dr["QO4"].ToString();
                     a10 = dr["QA"].ToString();
                 }
                 //
                 //
                 con.Close();
             }
             catch(Exception Ex)
             {
                // MessageBox.Show(Ex.Message);
             }
         }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log Out", "🚨👂Information🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                login m1 = new login();
                this.Hide();
                m1.Show();
            }
        }

        private void checkQ1()
        {

            if (Q101.Checked)
            {
                ua[0] = "";
                ua[0] = Q101.Text;
            }
            else if (Q102.Checked)
            {
                ua[0] = "";
                ua[0] = Q102.Text;
            }
            else if (Q103.Checked)
            {
                ua[0] = "";
                ua[0] = Q103.Text;
            }
            else if (Q104.Checked)
            {
                ua[0] = "";
                ua[0] = Q104.Text;
            }
            if (ua[0] == a1)
            {
                score  = score + 1;
            }
            else 
            {
                score = score;
            }
        }
        private void checkQ2()
        {

            if (Q201.Checked)
            {
                ua[1] = "";
                ua[1] = Q201.Text;
            }
            else if (Q202.Checked)
            {
                ua[1] = "";
                ua[1] = Q202.Text;
            }
            else if (Q203.Checked)
            {
                ua[1] = "";
                ua[1] = Q203.Text;
            }
            else if (Q204.Checked)
            {
                ua[1] = "";
                ua[1] = Q204.Text;
            }
            if (ua[1] == a2)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
         //checking answer 3
        private void checkQ3()
        {

            if (Q301.Checked)
            {
                ua[2] = "";
                ua[2] = Q301.Text;
            }
            else if (Q302.Checked)
            {
                ua[2] = "";
                ua[2] = Q302.Text;
            }
            else if (Q303.Checked)
            {
                ua[2] = "";
                ua[2] = Q303.Text;
            }
            else if (Q304.Checked)
            {
                ua[2] = "";
                ua[2] = Q304.Text;
            }
            if (ua[2] == a3)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        //checking answer 4
        private void checkQ4()
        {

            if (Q401.Checked)
            {
                ua[3] = "";
                ua[3] = Q401.Text;
            }
            else if (Q402.Checked)
            {
                ua[3] = "";
                ua[3] = Q402.Text;
            }
            else if (Q403.Checked)
            {
                ua[3] = "";
                ua[3] = Q403.Text;
            }
            else if (Q404.Checked)
            {
                ua[3] = "";
                ua[3] = Q404.Text;
            }
            if (ua[3] == a4)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        //checking answer 5
        private void checkQ5()
        {

            if (Q501.Checked)
            {
                ua[4] = "";
                ua[4] = Q501.Text;
            }
            else if (Q502.Checked)
            {
                ua[4] = "";
                ua[4] = Q502.Text;
            }
            else if (Q503.Checked)
            {
                ua[4] = "";
                ua[4] = Q503.Text;
            }
            else if (Q504.Checked)
            {
                ua[4] = "";
                ua[4] = Q504.Text;
            }
            if (ua[4] == a5)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        //checking answer 6
        private void checkQ6()
        {

            if (Q601.Checked)
            {
                ua[5] = "";
                ua[5] = Q601.Text;
            }
            else if (Q602.Checked)
            {
                ua[5] = "";
                ua[5] = Q602.Text;
            }
            else if (Q603.Checked)
            {
                ua[5] = "";
                ua[5] = Q603.Text;
            }
            else if (Q604.Checked)
            {
                ua[5] = "";
                ua[5] = Q604.Text;
            }
            if (ua[5] == a6)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        //checking answer 7
        private void checkQ7()
        {

            if (Q701.Checked)
            {
                ua[6] = "";
                ua[6] = Q701.Text;
            }
            else if (Q702.Checked)
            {
                ua[6] = "";
                ua[6] = Q702.Text;
            }
            else if (Q703.Checked)
            {
                ua[6] = "";
                ua[6] = Q703.Text;
            }
            else if (Q704.Checked)
            {
                ua[6] = "";
                ua[6] = Q704.Text;
            }
            if (ua[6] == a7)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        //checking answer 8
        private void checkQ8()
        {

            if (Q801.Checked)
            {
                ua[7] = "";
                ua[7] = Q801.Text;
            }
            else if (Q802.Checked)
            {
                ua[7] = "";
                ua[7] = Q802.Text;
            }
            else if (Q803.Checked)
            {
                ua[7] = "";
                ua[7] = Q803.Text;
            }
            else if (Q804.Checked)
            {
                ua[7] = "";
                ua[7] = Q804.Text;
            }
            if (ua[7] == a8)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        //checking answer 9
        private void checkQ9()
        {

            if (Q901.Checked)
            {
                ua[8] = "";
                ua[8] = Q901.Text;
            }
            else if (Q902.Checked)
            {
                ua[8] = "";
                ua[8] = Q902.Text;
            }
            else if (Q903.Checked)
            {
                ua[8] = "";
                ua[8] = Q903.Text;
            }
            else if (Q904.Checked)
            {
                ua[8] = "";
                ua[8] = Q904.Text;
            }
            if (ua[8] == a9)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }
        //checking answer 10
        private void checkQ10()
        {

            if (Q1001.Checked)
            {
                ua[9] = "";
                ua[9] = Q1001.Text;
            }
            else if (Q1002.Checked)
            {
                ua[9] = "";
                ua[9] = Q1002.Text;
            }
            else if (Q1003.Checked)
            {
                ua[9] = "";
                ua[9] = Q1003.Text;
            }
            else if (Q1004.Checked)
            {
                ua[9] = "";
                ua[9] = Q1004.Text;
            }
            if (ua[9] == a10)
            {
                score = score + 1;
            }
            else
            {
                //score = score;
            }
        }

        private void InsertResult()
        {
            try
            {
                
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ResultTbl (RSubject,RCandidate,RDate,RTime,RScore) values(@RS,@RC,@RD,@RT,@RSc)", con);
                cmd.Parameters.AddWithValue("@RS", Subjectlbl.Text);
                cmd.Parameters.AddWithValue("@RC", Cnamelbl.Text);
                cmd.Parameters.AddWithValue("@RD", QDateP.Value.Date);
                cmd.Parameters.AddWithValue("@RT", QTimep.Text);
                cmd.Parameters.AddWithValue("@RSc", score);
               
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Result Saved Successfully");
                con.Close();

               // clearAll();
          
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void Reset()
        {
          
        }
        int score = 0;
        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            score = 0;
            checkQ1();
            checkQ2();
            checkQ3();
            checkQ4();
            checkQ5();
            checkQ6();
            checkQ7();
            checkQ8();
            checkQ9();
            checkQ10();
            MessageBox.Show(""+score);
            InsertResult();
            savehighest();
            login log = new login();
            this.Hide();
            log.Show();
            
        }
        int chrono = 500;
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            chrono -= 1;
            count += 1;
            TimingBar.Value = count;
            TimeLbl.Text = "" + chrono;
            if (TimingBar.Value == 500)
            {
                TimingBar.Value = 0;
                timer1.Stop();
                MessageBox.Show("Time Over🚀");
                this.Hide();
                login log = new login();
                this.Hide();
                log.Show();
            }
        }

        private void exam_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void Q6_Enter(object sender, EventArgs e)
        {

        }
        string[] ua = new string[10];
        private void Q101_CheckedChanged(object sender, EventArgs e)
        {
            //ua[0] = Q101.Text;
            //MessageBox.Show("Selected Answer is :" + ua[0]);
        }

        private void Q102_CheckedChanged(object sender, EventArgs e)
        {
            //ua[0] = Q102.Text;
            //MessageBox.Show("Selected Answer is :" + ua[0]);
        
        }

        private void TimingBar_Click(object sender, EventArgs e)
        {

        }

        private void gunaPictureBox4_Click(object sender, EventArgs e)
        {
            about ob = new about();
            ob.Show();
        }

        private void gunaPictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
