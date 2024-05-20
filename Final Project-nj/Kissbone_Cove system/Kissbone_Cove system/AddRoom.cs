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
using static Kissbone_Cove_system.CostumerList;

namespace Kissbone_Cove_system
{
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
        }
        private static readonly HttpClient client = new HttpClient();


        public class Room
        {
            [JsonProperty("room_id")]
            public int Id { get; set; }
            public string Name { get; set; }
            public int Capacity { get; set; }
            public string Availability { get; set; }
            public decimal Price { get; set; }
        }

        public class Rooms
        {
            public string name { get; set; }
            public int capacity { get; set; }
            public string availability { get; set; }
            public decimal price { get; set; }

            [JsonProperty("room_id")]
            public int roomId { get; set; }
        }

        private async Task LoadRoomData()
        {
            try
            {
                // Replace with your API endpoint URL
                string url = "http://localhost:3000/room/rooms";
                var response = await client.GetStringAsync(url);

                // Deserialize JSON response to a list of guests
                var room = JsonConvert.DeserializeObject<List<Room>>(response);

                // Bind the list of guests to the DataGridView
                DgvRoom.DataSource = room;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching data: {ex.Message}");
            }
        }

        private async  void AddRoom_Load(object sender, EventArgs e)
        {
            await LoadRoomData();
            lblid.Visible=false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            new RoomList().ShowDialog();
            this.Hide();
        }

        private void DgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == DgvRoom.Columns["Name"].Index)
            {
                var roomid = DgvRoom.Rows[e.RowIndex].Cells[0].Value.ToString();
                var roomname = DgvRoom.Rows[e.RowIndex].Cells[1].Value.ToString();
                var roomcapa = DgvRoom.Rows[e.RowIndex].Cells[2].Value.ToString();
                var roomprice = DgvRoom.Rows[e.RowIndex].Cells[4].Value.ToString();
                var roomstatus = DgvRoom.Rows[e.RowIndex].Cells[3].Value.ToString();

                try
                {
                    TxtName.Text = roomname;
                    TxtPrice.Text = roomprice;
                    TxtCapacity.Text = roomcapa;
                    Lblavail.Text = roomstatus;
                    lblid.Text = roomid;

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
        }

        private async Task UpdateRoom()
        {
            var apiUrl = "http://localhost:3000/room/rooms/update";  // API endpoint for updating rooms, assuming roomId is known

            var roomDetails = new
            {
                name = TxtName.Text,
                price = decimal.Parse(TxtPrice.Text),
                capacity = int.Parse(TxtCapacity.Text),
                availability = Lblavail.Text,
                roomId = int.Parse(lblid.Text)
            };

            var json = JsonConvert.SerializeObject(roomDetails);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PutAsync(apiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Room updated successfully!");
                    TxtName.Clear();
                    TxtCapacity.Clear();
                    TxtPrice.Clear();
                    Lblavail.ResetText();
                    DgvRoom.Columns.Clear();
                    await LoadRoomData();

                }
                else
                {
                    MessageBox.Show($"Failed to update room. Status code: {response.StatusCode}");
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
        private async void BtnUpdate_Click_1(object sender, EventArgs e)
        {
            await UpdateRoom();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            TxtName.Clear();
            TxtCapacity.Clear();
            TxtPrice.Clear();
            Lblavail.ResetText();
            lblid.ResetText();
        }

        private async Task DeleteRoom(int roomId)
        {
            var apiUrl = $"http://localhost:3000/room/rooms/{roomId}";  // API endpoint for deleting rooms

            try
            {
                HttpResponseMessage response = await client.DeleteAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Room deleted successfully!");

                    TxtName.Clear();
                    TxtCapacity.Clear();
                    TxtPrice.Clear();
                    Lblavail.ResetText();
                    DgvRoom.Columns.Clear();
                    await LoadRoomData();

                }
                else
                {
                    MessageBox.Show($"Failed to delete room. Status code: {response.StatusCode}");
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


        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            int roomId = int.Parse(lblid.Text); 
            await DeleteRoom(roomId);
        }
    }
}
