<?php 
function allroom() {
?>
<div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Booked /</span> All Book</h4>
    <form method="post" id="workersForm">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <table class="table" id="roomTable">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Room Name</th>
                                    <th>Capacity</th>
                                    <th>Availability</th>
                                    <th>Price</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <br><br>
</div>

<script>
    // Fetch data from API endpoint
    const getAllRooms = () => {
        return fetch('http://localhost:3000/room/rooms')
            .then(response => response.json())
            .then(data => {
                // Populate table with fetched data
                const tableBody = document.querySelector('#roomTable tbody');
                tableBody.innerHTML = ''; // Clear existing table rows
                data.forEach(room => {
                    const row = `<tr>
                                    <td>${room.room_id}</td>
                                    <td>${room.Name}</td>
                                    <td>${room.Capacity}</td>
                                    <td>${room.Availability}</td>
                                    <td>${room.Price}</td>
                                </tr>`;
                    tableBody.innerHTML += row;
                });
            })
            .catch(error => {
                console.error('Error fetching data:', error);
            });
    };

    // Call the function to fetch and populate data when the page loads
    window.onload = function() {
        getAllRooms();
    };
</script>
<?php 
}
?>
