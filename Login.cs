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

namespace Group_Project
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            String user = txtUsername.Text;
            String pass = txtPassword.Text;
            if (user != string.Empty || pass != string.Empty)
            {
                string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Sem-5\.NET\Project\Group_Project\Database1.mdf;Integrated Security=True";
                SqlConnection con = new SqlConnection(constr);
                con.Open();


                string query = "select * from [Login] where username=@username and password=@password";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username",txtUsername.Text);
                cmd.Parameters.AddWithValue("@password",txtPassword.Text);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                { 
                    dr.Close();
                    this.Hide();
                    Dashboard dashboard = new Dashboard();
                    dashboard.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
          
            
        }
    }
}
