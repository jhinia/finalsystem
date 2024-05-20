using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kissbone_Cove_system
{
    public partial class CostumerList : Form
    {
        public CostumerList()
        {
            InitializeComponent();
        }
        private static readonly HttpClient client = new HttpClient();


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            new AddCostumer().ShowDialog();
            this.Hide();
        }

        private async Task LoadGuestData()
        {
            try
            {
                // Replace with your API endpoint URL
                string url = "http://localhost:3000/api/all";
                var response = await client.GetStringAsync(url);

                // Deserialize JSON response to a list of guests
                var guests = JsonConvert.DeserializeObject<List<Guest>>(response);

                // Bind the list of guests to the DataGridView
                DgvCustomer.DataSource = guests;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        // Define the Guest class to match the JSON structure
        public class Guest
        {
            public string Name { get; set; }
            [JsonProperty("Contact Number")]
            public string ContactNumber { get; set; }
            public string status { get; set; }
        }

        private async Task LoadGuestDataStatus(string status)
        {
            try
            {
                // Replace with your API endpoint URL
                string url = $"http://localhost:3000/api/status/{status}";
                var response = await client.GetStringAsync(url);

                // Deserialize JSON response to a list of guests
                var guests = JsonConvert.DeserializeObject<List<Guest>>(response);

                // Bind the list of guests to the DataGridView
                DgvCustomer.DataSource = guests;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        private async void CostumerList_Load_1(object sender, EventArgs e)
        {
            await LoadGuestData();
        }

        private async void btnShowAll_Click(object sender, EventArgs e)
        {
            DgvCustomer.Columns.Clear();
            await LoadGuestData();

        }

        private async void BtnPre_Click(object sender, EventArgs e)
        {
           DgvCustomer.Columns.Clear();
           await LoadGuestDataStatus("Pre-Registered");
        }

        private async void BtnCin_Click(object sender, EventArgs e)
        {
            DgvCustomer.Columns.Clear();
            await LoadGuestDataStatus("Checked-in");
        }

        private async void BtnCout_Click(object sender, EventArgs e)
        {
            DgvCustomer.Columns.Clear();
            await LoadGuestDataStatus("Checked-out");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void DgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow clickedrow = DgvCustomer.Rows[e.RowIndex];
        }
    }
}
