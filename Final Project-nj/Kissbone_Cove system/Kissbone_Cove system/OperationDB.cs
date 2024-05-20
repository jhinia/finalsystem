using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kissbone_Cove_system
{
    class OperationDB
    {
        public static void Login(string query)
        {
            //   query = "Select * from staff_info where username = '" + user + "' and password ='" + pass + "'";

        }
        public static void saveUpdateDelete(string sql, string action)
        {

            MySqlConnection con = Connection.GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            try
            {
                cmd.ExecuteNonQuery();
                // control.VoiceOutput(action);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error!!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void AddForm(Form f, Panel panel)
        {
            panel.Controls.Clear();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            panel.Controls.Add(f);
            f.Show();
        }

        class DataChecker
        {
            public static double totAmount { get; set; }
            public static chk dcheker = new chk();
            public static customerdata cd = new customerdata();
            public static roomdata ct = new roomdata();
            public static Reportsys rp = new Reportsys();
        }

        class chk
        {
            public Boolean chkr { get; set; }
            public string opt { get; set; }
        }
        class customerdata
        {
            public double todreven { get; set; }
            public int maxcustomer { get; set; }
            public int guestid { get; set; }
            public string paystatus { get; set; }
            public string name { get; set; }
            public string status { get; set; }
            public string room { get; set; }
            public DateTime dateregistered { get; set; }
            public string contact_no { get; set; }
            public double totpayment { get; set; }
            public int totoccu { get; set; }
            public int room_id { get; set; }
            public int occupants { get; set; }
        }
        class roomdata
        {
            public int roomid { get; set; }
            public double price { get; set; }
            public string availability { get; set; }
            public DateTime date { get; set; }
            public int Capacity { get; set; }
        }
        class Reportsys
        {
            public int first { get; set; }
            public string firstName { get; set; }
            public int second { get; set; }
            public string secondName { get; set; }
            public int third { get; set; }
            public string thirdName { get; set; }

        }

        public static void getcustid(DataGridViewRow clickedrow)
        {
            if (clickedrow.Index >= 0)
            {
                string name = clickedrow.Cells["Name"].Value.ToString();
                string query = "Select * from guest where Name = '" + name + "'";
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DataChecker.cd.guestid = int.Parse((read["guest_id"] + "").ToString());
                    DataChecker.cd.contact_no = (read["ContactNo."] + "").ToString();
                    DataChecker.cd.totoccu = int.Parse((read["no._of_occupants"] + "").ToString());
                    DataChecker.cd.totpayment = int.Parse((read["Overall_payment"] + "").ToString());
                    DataChecker.cd.paystatus = (read["Payment_Status"] + "").ToString();
                    DataChecker.cd.dateregistered = DateTime.Parse((read["date_registered"] + "").ToString());
                    DataChecker.cd.status = (read["status"] + "").ToString();
                    DataChecker.cd.name = (read["Name"] + "").ToString();
                    DataChecker.cd.room_id = int.Parse((read["room_id"]).ToString());
                }
                read.Close();
                con.Close();
            }
        }

        public static void Todayguest(string sqlQuery, Label lbl, string choice)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DataChecker.cd.maxcustomer = int.Parse((reader[choice]).ToString());
                    lbl.Text = DataChecker.cd.maxcustomer.ToString();
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                lbl.Text = "0";
            }
        }
       
        public static void dgvViewing(string sqlQuery, DataGridView dgv)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tbl = new DataTable();
                adp.Fill(tbl);
                dgv.DataSource = tbl;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void LoadComboBox(string sqlQuery, ComboBox comboBox)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    comboBox.Items.Add(reader["Name"] + "").ToString();
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void GetroomData(ComboBox cbx)
        {
            MySqlConnection con = Connection.GetConnection();
            string query = "Select room_id from room where Name = '" + cbx.SelectedItem.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                DataChecker.ct.roomid = int.Parse((read["room_id"] + "").ToString());
                // Instance.getcatdata.catid = read.GetInt32(0);
                // Instance.getcatdata.searchChkr = true;
                //Instance.getdata.catid = int.Parse((read["category_id"] + "").ToString());
            }
            read.Close();
            con.Close();
        }
        public static void GetroomPrice(ComboBox cbx, Label lbl)
        {
            MySqlConnection con = Connection.GetConnection();
            string query = "Select * from room where Name = '" + cbx.SelectedItem.ToString() + "'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                DataChecker.ct.price = int.Parse((read["Price"] + "").ToString());
                DataChecker.ct.Capacity = int.Parse((read["Capacity"] + "").ToString());
                lbl.Text = DataChecker.ct.price.ToString();
                // Instance.getcatdata.catid = read.GetInt32(0);
                // Instance.getcatdata.searchChkr = true;
                //Instance.getdata.catid = int.Parse((read["category_id"] + "").ToString());
            }
            read.Close();
            con.Close();
        }
        public static void updatecottageavAilability(ComboBox cbx)
        {
            try
            {

                string availability = "Unavailable";
                MySqlConnection con = Connection.GetConnection();
                string query = "UPDATE room set Availability ='" + availability + "'where room_id ='" + DataChecker.ct.roomid.ToString() + "'";
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    DataChecker.ct.availability = "Unavailable";
                }
                read.Close();
                con.Close();
            }
            catch
            {

            }
        }
        public static void TodayRevenue(string sqlQuery, Label lbl)
        {
            try
            {
                string sql = sqlQuery;
                MySqlConnection con = Connection.GetConnection();
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    DataChecker.cd.todreven = double.Parse((reader["sum(Overall_Payment)"] + "").ToString());
                    lbl.Text = DataChecker.cd.todreven.ToString("N2");
                    //  comboBox.Items.Add(reader.GetString(1));
                }
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                lbl.Text = "0.00";
            }
        }
        public static void MaxTransactionDate()
        {
            MySqlConnection con = Connection.GetConnection();
            string query = "Select room.Name, Max(Guest.date_registered) as 'Date Occupied', room.Availability FROM room Inner JOIN guest on room.room_id = guest.room_id where room.Availability = 'Unavailable' GROUP by room.Name ";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                DataChecker.ct.date = DateTime.Parse((read["Date Occupied"] + "").ToString());
                // DataChecker.ct.price = int.Parse((read["Price"] + "").ToString());
                //  lbl.Text = DataChecker.ct.price.ToString();
                // Instance.getcatdata.catid = read.GetInt32(0);
                // Instance.getcatdata.searchChkr = true;
                //Instance.getdata.catid = int.Parse((read["category_id"] + "").ToString());
                //SELECT All(cottage.Name), max(guest.date_registered) as 'Date Occupied', cottage.Availability from guest
                //  Inner JOIN cottage on cottage.cott_id = guest.cott_id where cottage.Availability = 'Unavailable';
            }
            read.Close();
            con.Close();
        }


    }
}
