const pool = require('../services/db');

// Fetch guest information by status
const getGuestsByStatus = (status) => {
  return new Promise((resolve, reject) => {
    const query = 'SELECT Name, `ContactNo.` as `Contact Number`, status as `Status` FROM guest WHERE status = ?';
    pool.query(query, [status], (err, results) => {
      if (err) {
        console.error("Error fetching guests by status:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

const getAllGuest = (status) => {
    return new Promise((resolve, reject) => {
      const query = 'SELECT Name, `ContactNo.` as `Contact Number`, status as `Status` FROM guest';
      pool.query(query, [status], (err, results) => {
        if (err) {
          console.error("Error fetching guests by status:", err);
          reject(err);
        } else {
          resolve(results);
        }
      });
    });
  };

// Fetch guest information by name and status
const getGuestsByNameAndStatus = (name, status) => {
  return new Promise((resolve, reject) => {
    const query = 'SELECT Name, `ContactNo.` as `Contact Number`, status as `Status` FROM guest WHERE Name LIKE ? AND status = ? ORDER BY room_id ASC';
    pool.query(query, [`%${name}%`, status], (err, results) => {
      if (err) {
        console.error("Error fetching guests by name and status:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Fetch guest information by name
const getGuestsByName = (name) => {
  return new Promise((resolve, reject) => {
    const query = 'SELECT Name, `ContactNo.` as `Contact Number`, status as `Status` FROM guest WHERE Name LIKE ? ORDER BY room_id ASC';
    pool.query(query, [`%${name}%`], (err, results) => {
      if (err) {
        console.error("Error fetching guests by name:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Insert a new payment transaction
const addPaymentTransaction = (paymentDetails) => {
  const { guestId, totalPayment, cash, change, transactionDate } = paymentDetails;
  return new Promise((resolve, reject) => {
    const query = 'INSERT INTO payment_transaction (guest_id, Total_Payment, Cash, `Change`, Transaction_date) VALUES (?, ?, ?, ?, ?)';
    pool.query(query, [guestId, totalPayment, cash, change, transactionDate], (err, results) => {
      if (err) {
        console.error("Error adding payment transaction:", err);
        reject(err);
      } else {
        resolve(results.insertId);
      }
    });
  });
};

// Fetch guest information by name
const getGuestByName = (name) => {
    return new Promise((resolve, reject) => {
      const query = "SELECT * FROM guest WHERE Name = ?";
      pool.query(query, [name], (err, results) => {
        if (err) {
          console.error("Error fetching guest by name:", err);
          reject(err);
        } else {
          resolve(results);
        }
      });
    });
  };
  
  // Fetch room and guest information by guest name
  const getRoomAndGuestInfoByName = (name) => {
    return new Promise((resolve, reject) => {
      const query = "SELECT room.Name as 'Room Name', guest.Name FROM guest INNER JOIN room ON room.room_id = guest.room_id WHERE guest.Name = ?";
      pool.query(query, [name], (err, results) => {
        if (err) {
          console.error("Error fetching room and guest info by name:", err);
          reject(err);
        } else {
          resolve(results);
        }
      });
    });
  };
  
  // Update guest payment status and general status by guest ID
  const updateGuestStatus = (guestId, paymentStatus, status) => {
    return new Promise((resolve, reject) => {
      const query = "UPDATE guest SET Payment_Status = ?, status = ? WHERE guest_id = ?";
      pool.query(query, [paymentStatus, status, guestId], (err, results) => {
        if (err) {
          console.error("Error updating guest status:", err);
          reject(err);
        } else {
          resolve(results);
        }
      });
    });
  };
  
  // Update guest status only by guest ID
  const updateGuestStatusOnly = (guestId, status) => {
    return new Promise((resolve, reject) => {
      const query = "UPDATE guest SET status = ? WHERE guest_id = ?";
      pool.query(query, [status, guestId], (err, results) => {
        if (err) {
          console.error("Error updating guest status only:", err);
          reject(err);
        } else {
          resolve(results);
        }
      });
    });
  };
  
  // Update room availability by room ID
  const updateRoomAvailability = (roomId, availability) => {
    return new Promise((resolve, reject) => {
      const query = "UPDATE room SET Availability = ? WHERE room_id = ?";
      pool.query(query, [availability, roomId], (err, results) => {
        if (err) {
          console.error("Error updating room availability:", err);
          reject(err);
        } else {
          resolve(results);
        }
      });
    });
  };


  const addGuest = (guestDetails) => {
    return new Promise((resolve, reject) => {
      const { name, contactNo, room_id, no_of_occupants, Overall_payment, date_registered } = guestDetails;
    
      // Validate required fields
      if (!name || !contactNo || !room_id || !no_of_occupants || !Overall_payment || !date_registered) {
        reject(new Error("Missing required fields"));
        return;
      }
    
      // Validate data types
      if (typeof name !== 'string' || typeof contactNo !== 'string' || typeof room_id !== 'number' || typeof no_of_occupants !== 'number' || typeof Overall_payment !== 'number') {
        reject(new Error("Invalid data types"));
        return;
      }
    
      // Convert date string to Date object
      const dateRegistered = new Date(date_registered);
    
      // Check if date conversion was successful
      if (!(dateRegistered instanceof Date && !isNaN(dateRegistered))) {
        reject(new Error("Invalid date format"));
        return;
      }
    
      // Format date as YYYY-MM-DD
      const formattedDate = dateRegistered.toISOString().split('T')[0];
    
      const query = "INSERT INTO `guest` (`Name`, `ContactNo.`, `room_id`, `no._of_occupants`, `Overall_payment`, `date_registered`) VALUES (?, ?, ?, ?, ?, ?)";
      pool.query(query, [name, contactNo, room_id, no_of_occupants, Overall_payment, formattedDate], (err, results) => {
        if (err) {
          console.error("Error adding new guest:", err);
          reject(err);
        } else {
          resolve("Guest saved successfully");
        }
      });
    });
  };
  


 
  const getAvailableRooms = () => {
    return new Promise((resolve, reject) => {
        const query = "SELECT * FROM room WHERE availability = 'Available'";
        pool.query(query, (err, results) => {
            if (err) {
                console.error("Error fetching available rooms:", err);
                reject(err);
            } else {
                resolve(results);
            }
        });
    });
};


module.exports = {
  getGuestsByStatus,
  getGuestsByNameAndStatus,
  getGuestsByName,
  addPaymentTransaction,
  getAllGuest,
  getGuestByName,
  getRoomAndGuestInfoByName,
  updateGuestStatus,
  updateGuestStatusOnly,
  updateRoomAvailability,
  addGuest,
  getAvailableRooms,
};
