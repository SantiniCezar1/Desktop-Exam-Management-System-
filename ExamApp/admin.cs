using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamApp
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (PasswordTb.Text == "")
            {
                MessageBox.Show("Enter the password");
            }
            else if (PasswordTb.Text == "12345")
            {
                Question ob = new Question();
                ob.Show();
                this.Hide();
            }else
            {   MessageBox.Show("Wrong Password");
                PasswordTb.Text ="";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit App", "🚨👂Warning🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

            
                login log = new login();
                log.Show();
                this.Hide();
            
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Do you want to go back", "🚨👂information🤔🩸", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                login log = new login();
                log.Show();
                this.Hide();
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

        private void label8_Click(object sender, EventArgs e)
        {
            PasswordTb.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            viewresult view = new viewresult();
            view.Show();
            this.Hide();
        }
    }
}
