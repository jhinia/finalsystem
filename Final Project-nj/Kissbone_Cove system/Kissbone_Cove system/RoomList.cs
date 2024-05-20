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
using System.Xml.Linq;
using static Kissbone_Cove_system.AddRoom;

namespace Kissbone_Cove_system
{
    public partial class RoomList : Form
    {
        public RoomList()
        {
            InitializeComponent();
        }
        private HttpClient client = new HttpClient();

        private async Task AddRoom()
        {
            var apiUrl = "http://localhost:3000/room/add"; // API endpoint for adding rooms

            var roomDetails = new
            {
                name = TxtName.Text,
                capacity = int.Parse(TxtCapacity.Text),
                price = decimal.Parse(TxtPrice.Text),
                dateCreated = DateTime.Now // or you can use another suitable date
            };

            var json = JsonConvert.SerializeObject(roomDetails);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    // Assume response body just confirms addition, adjust as necessary if the response includes more details
                    MessageBox.Show("Room added successfully!");

                    TxtName.Clear();
                    TxtCapacity.Clear();
                    TxtPrice.Clear();

                    
                }
                else
                {
                    MessageBox.Show($"Failed to add room. Status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("An error occurred while sending the request: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private async void ConfirmBtn_Click(object sender, EventArgs e)
        {
            await AddRoom();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
