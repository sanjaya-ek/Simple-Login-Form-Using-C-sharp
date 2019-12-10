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

namespace Login_Form
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\C# Projects\Login Form\Login Form\loginDatabase.mdf;Integrated Security=True");
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Authentication WHERE userName='" + txtuserName.Text + "'AND password='" + txtuserPassword.Text + "' ", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    MainForm mf = new MainForm();
                    mf.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password is Incorrect");
                }
            }
            catch(Exception e01)
            {
                MessageBox.Show("ERROR" + e01);
            }
        }

    }
}
