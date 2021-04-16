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
using Tulpep.NotificationWindow;
using System.Data.Sql;



namespace bugs_report_page_final
{
    public partial class Form1 : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = Userid;
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Nametxt.Text == "")
                MessageBox.Show("Please Enter your name");
            else if (Emailtxt.Text == "")
                MessageBox.Show("Please Enter your Email");
            else if (Userid.Text == "")
                MessageBox.Show("Please Enter your User id");
            else if (Subtxt.Text == "")
                MessageBox.Show("Please Enter your problem");
            {
                con = new SqlConnection(@"Data Source=LAPTOP-UNKNOWN\TEW_SQLEXPRESS;Initial Catalog=bugs_data;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand("Insert into bugs_tbl(Username,mail,Sub,Details,user_id) Values(@name,@mail,@sub,@details,@u)", con);
                cmd.Parameters.AddWithValue(@"name", Nametxt.Text);
                cmd.Parameters.AddWithValue(@"mail", Emailtxt.Text);
                cmd.Parameters.AddWithValue(@"sub", Subtxt.Text);
                cmd.Parameters.AddWithValue(@"details", Desctxt.Text);
                cmd.Parameters.AddWithValue(@"u", Userid.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Submitted Successfully!!!");
                    {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.info;
                    popup.TitleText = "\\Foodzilla\\";
                    popup.ContentText = "submitted succeffully! Sit back and relax!!!";
                    popup.Popup();
                    }
                Clear();

            }
            void Clear ()
            {
                Nametxt.Text = Emailtxt.Text = Subtxt.Text = Desctxt.Text = Userid.Text = "";
            }


        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
