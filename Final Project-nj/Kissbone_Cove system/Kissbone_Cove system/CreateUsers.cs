using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Kissbone_Cove_system
{
    public partial class CreateUsers : Form
    {
        Form1 uv = new Form1();
        public CreateUsers()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Form1 user = new Form1();
            user.Show();
            this.Hide();
        }
        private string HashPassword(string password)
        {
            const int iterations = 10000; // You can adjust this value based on your security requirements
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                byte[] hash = pbkdf2.GetBytes(20); // 20 is the size of the hash
                byte[] hashBytes = new byte[36];  // 16 for salt + 20 for hash
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                return Convert.ToBase64String(hashBytes);
            }
        }
        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (TxtPassword.Text != TxtConfirmPass.Text)
            {
                label8.Visible = true;
            }
            else if (TxtUsername.Text == "")
            {

            }
            else
            {
                string hashedPassword = HashPassword(TxtPassword.Text);
                //Operation.save(TxtName, TxtEmail, TxtAddress, TxtUsername, TxtPassword);
                OperationDB.saveUpdateDelete("INSERT INTO `user`(`Name`, `Email`, `Address`, `Username`, `password`) VALUES ('" + TxtName.Text + "','" + TxtEmail.Text + "','" + TxtAddress.Text + "','" + TxtUsername.Text + "','" + hashedPassword + "')", "Saved");
                Visible = false;
                uv.Show();
            }
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            label8.Visible = false;
        }
    }
}

