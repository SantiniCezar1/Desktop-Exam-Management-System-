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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            GetSubjects();
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
        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //soundPlayer.Play();
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

        public void cezar()
        {
            UnameTb.Clear();
            PasswordTb.Clear();
           
        }
        private void label8_Click(object sender, EventArgs e)
        {
            cezar();
        }

        public static string CandName = "", SubName="";
        private void Button1_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PasswordTb.Text == "")
            {
                
                MessageBox.Show("Enter Candidate Name and Password");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count (*) from CandidateTbl where CPass='" + PasswordTb.Text + "' and CName='" + UnameTb.Text + "' ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    CandName = UnameTb.Text;
                    SubName = SubjectCb.SelectedValue.ToString(); 
                   
                    exam ex = new exam();
                    ex.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong Candidate name or Password");                                
                   
                    UnameTb.Text = "";
                    PasswordTb.Text = "";
                }
                con.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void SubjectCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            admin ad = new admin();
            ad.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            viewresult view = new viewresult();
            view.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {
           

        }

        private void label4_Click_2(object sender, EventArgs e)
        {
            viewresult view = new viewresult();
            view.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            viewresult view = new viewresult();
            view.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            revice re = new revice();
            re.Show();
            this.Hide();
        }
    }
}
