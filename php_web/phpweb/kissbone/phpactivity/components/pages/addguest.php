<?php 
function addguest() {
?>
<div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Booked /</span> All Book</h4>
    <form method="post" id="guestsForm">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Add New Guest</h5>
                        <div class="mb-3">
                            <label for="name" class="form-label">Name</label>
                            <input type="text" class="form-control" id="name" name="name" required>
                        </div>
                        <div class="mb-3">
                            <label for="contactNo" class="form-label">Contact Number</label>
                            <input type="text" class="form-control" id="contactNo" name="contactNo" required>
                        </div>
                        <div class="mb-3">
                            <label for="room_id" class="form-label">Room</label>
                            <select class="form-select" id="room_id" name="room_id" required>
                                <!-- Options will be populated by JavaScript -->
                            </select>
                        </div>
                        <div class="mb-3">
                            <label for="no_of_occupants" class="form-label">Number of Occupants</label>
                            <input type="number" class="form-control" id="no_of_occupants" name="no_of_occupants" required>
                        </div>
                        <div class="mb-3">
                            <label for="Overall_payment" class="form-label">Overall Payment</label>
                            <input type="number" class="form-control" id="Overall_payment" name="Overall_payment" required>
                        </div>
                        <div class="mb-3">
                            <label for="date_registered" class="form-label">Date Registered</label>
                            <input type="date" class="form-control" id="date_registered" name="date_registered" required>
                        </div>
                        <button type="submit" class="btn btn-primary">Add Guest</button>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Guest List</h5>
                        <table class="table" id="guestTable">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Contact Number</th>
                                    <th>Status</th>
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
</div>

<script>
    // Fetch available rooms from API endpoint
    const fetchAvailableRooms = () => {
        return fetch('http://localhost:3000/api/rooms/available')
            .then(response => response.json())
            .then(data => {
                const roomSelect = document.getElementById('room_id');
                roomSelect.innerHTML = ''; // Clear existing options
                data.forEach(room => {
                    const option = document.createElement('option');
                    option.value = room.room_id; // Store room ID
                    option.textContent = room.Name; // Display room name
                    roomSelect.appendChild(option);
                });
            })
            .catch(error => {
                console.error('Error fetching rooms:', error);
            });
    };

    // Fetch data from API endpoint
    const getAllGuests = () => {
        return fetch('http://localhost:3000/api/guests')
            .then(response => response.json())
            .then(data => {
                // Populate table with fetched data
                const tableBody = document.querySelector('#guestTable tbody');
                tableBody.innerHTML = ''; // Clear existing table rows
                data.forEach(guest => {
                    const row = `<tr>
                                    <td>${guest.name}</td>
                                    <td>${guest.contactNo}</td>
                                    <td>${guest.status}</td>
                                </tr>`;
                    tableBody.innerHTML += row;
                });
            })
            .catch(error => {
                console.error('Error fetching guests:', error);
            });
    };

    // Call the function to fetch and populate data when the page loads
    window.onload = function() {
        fetchAvailableRooms();
        getAllGuests();
    };

    // Handle form submission
    document.getElementById('guestsForm').addEventListener('submit', function(event) {
        event.preventDefault();
        
        const formData = new FormData(this);
        const guestData = {};
        formData.forEach((value, key) => {
            guestData[key] = value;
        });
        
        // Send guest data to API
        fetch('http://localhost:3000/api/guest/add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(guestData)
        })
        .then(response => response.json())
        .then(data => {
            console.log('Response:', data);
            // Refresh guest list after adding new guest
            getAllGuests();
        })
        .catch(error => {
            console.error('Error adding guest:', error);
        });
    });
</script>
<?php 
}
?>
