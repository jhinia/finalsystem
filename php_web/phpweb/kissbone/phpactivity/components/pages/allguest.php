<?php 
function allguest() {
?>
<div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Booked /</span> All Book</h4>
    <form method="post" id="guestsForm">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
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
    <br><br>
</div>

<script>
    // Fetch data from API endpoint
    const getAllGuests = () => {
        return fetch('http://localhost:3000/api/all')
            .then(response => response.json())
            .then(data => {
                // Populate table with fetched data
                const tableBody = document.querySelector('#guestTable tbody');
                tableBody.innerHTML = ''; // Clear existing table rows
                data.forEach(guest => {
                    const row = `<tr>
                                    <td>${guest.Name}</td>
                                    <td>${guest['Contact Number']}</td>
                                    <td>${guest.Status}</td>
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
        getAllGuests();
    };
</script>
<?php 
}
?>
