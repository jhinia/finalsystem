using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Kissbone_Cove_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);

                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string query = "Select username, password from user where username = @user";
            MySqlConnection con = Connection.GetConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", TxtUsername.Text);
            MySqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                string storedHashedPassword = read["password"].ToString();
                if (VerifyPassword(TxtPassword.Text, storedHashedPassword))
                {
                    Mainform mf = new Mainform();
                    this.Hide();
                    mf.Show();

                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
                con.Close();
            }


        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            CreateUsers cr = new CreateUsers();
            this.Hide();
            cr.Show();
        }
    }
}
