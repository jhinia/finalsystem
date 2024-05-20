<?php 

function addroom() { 
    ?>
<div class="container-xxl flex-grow-1 container-p-y">
<h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Add Room </span> </h4>

    <div class="row">
        <div class="col-md-12">
            <hr class="my-0" />
            <div class="card">
                <div class="card-body">
                    <!-- Check for error messages -->
                    <!-- Booking form -->
                    <form id="bookingForm" class="mb-3" method="POST">
                        <div class="row">
                            <div class="mb-3 col-md-6">
                                <label for="customer_fname" class="form-label">Room Name</label>
                                <input class="form-control" type="text" id="roomname" name="roomname" placeholder="Enter room name" required />
                            </div>
                            <div class="mb-3 col-md-6">
                                <label for="capacity" class="form-label">Capacity</label>
                                <input class="form-control" type="number" id="capacity" name="capacity" placeholder="Enter capacity" required />
                            </div>
                            <div class="mb-3 col-md-12">
                                <label for="price" class="form-label">Price</label>
                                <input class="form-control" type="number" id="price" name="price" placeholder="Enter price" required />
                            </div>
                            <div class="mb-3 col-md-6">
                                <label for="date" class="form-label">Date Created</label>
                                <input class="form-control" type="date" id="date" name="date" placeholder="Enter date created" required />
                            </div>
                        </div>
                        <button type="submit" id="addRoomBtn" class="btn btn-primary me-2">Add</button>
                        <button type="reset" class="btn btn-outline-secondary">Reset</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    // Function to add room
    const addRoom = (roomDetails) => {
        const { roomname, capacity, price, date } = roomDetails;
        return fetch('http://localhost:3000/room/add', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: roomname,
                capacity: capacity,
                price: price,
                dateCreated: date
            })
        })
        .then(response => response.json())
        .then(data => {
            console.log(data); // Log response from the server
            alert(data.message); // Alert message from the server
            window.location.href=`home.php?tab=allroom`;
        })
        .catch(error => {
            console.error('Error adding new room:', error);
            alert('Error adding new room');
        });
    };

    // Event listener for form submission
    document.getElementById('bookingForm').addEventListener('submit', function(event) {
        event.preventDefault(); // Prevent default form submission
        
        // Get form data
        const roomname = document.getElementById('roomname').value;
        const capacity = document.getElementById('capacity').value;
        const price = document.getElementById('price').value;
        const date = document.getElementById('date').value;

        // Call addRoom function with form data
        addRoom({ roomname, capacity, price, date });
    });
</script>
<?php } ?>
