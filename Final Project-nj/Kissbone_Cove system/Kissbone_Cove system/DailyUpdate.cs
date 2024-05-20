using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class DailyUpdate : Form
    {
        public DailyUpdate()
        {
            InitializeComponent();
        }

        private static readonly HttpClient client = new HttpClient();

        private async Task<decimal?> GetTotalPayments(int year, int month, int day)
        {
            var apiUrl = "http://localhost:3000/board/total-payments";  // API endpoint for fetching total payments
            var queryString = $"?date={year}-{month:D2}-{day:D2}"; // Construct query string with date parameter

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl + queryString);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    decimal totalPayments = JsonConvert.DeserializeObject<decimal>(jsonResponse);
                    return totalPayments;
                }
                else
                {
                    // Handle unsuccessful response
                    MessageBox.Show($"Failed to fetch total payments. Status code: {response.StatusCode}");
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request error
                MessageBox.Show("An error occurred while sending the request: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                // Handle other errors
                MessageBox.Show("An error occurred: " + ex.Message);
                return null;
            }
        }

        private async void DailyUpdate_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now; // or any other date you want to query
            int year = date.Year;
            int day = date.Day;
            int month = date.Month;

            decimal? totalPayments = await GetTotalPayments(year, month, day);
            if (totalPayments.HasValue)
            {
                MessageBox.Show($"Total payments for {date.ToShortDateString()}: {totalPayments.Value.ToString("C")}");
            }
        }


    }
}
