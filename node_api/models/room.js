const pool = require('../services/db');

// Fetch all rooms
const getAllRooms = () => {
  return new Promise((resolve, reject) => {
    const query = "SELECT `room_id`,`Name`, `Capacity`, `Availability`, `Price` FROM `room`";
    pool.query(query, (err, results) => {
      if (err) {
        console.error("Error fetching all rooms:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Fetch rooms by name
const getRoomsByName = (name) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT `Name`, `Capacity`, `Availability`, `Price` FROM `room` WHERE `Name` LIKE ?";
    pool.query(query, [`%${name}%`], (err, results) => {
      if (err) {
        console.error("Error fetching rooms by name:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Update room details
const updateRoom = (roomDetails) => {
  const { name, price, capacity, availability, roomId } = roomDetails;
  return new Promise((resolve, reject) => {
    const query = "UPDATE `room` SET `Name` = ?, `Price` = ?, `Capacity` = ?, `Availability` = ? WHERE `room_id` = ?";
    pool.query(query, [name, price, capacity, availability, roomId], (err, results) => {
      if (err) {
        console.error("Error updating room details:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Delete room by room ID
const deleteRoom = (roomId) => {
  return new Promise((resolve, reject) => {
    const query = "DELETE FROM `room` WHERE `room_id` = ?";
    pool.query(query, [roomId], (err, results) => {
      if (err) {
        console.error("Error deleting room:", err);
        reject(err);
      } else {
        resolve(results);
      }
    });
  });
};

// Get room ID by name
const getRoomIdByName = (name) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT `room_id` FROM `room` WHERE `Name` = ?";
    pool.query(query, [name], (err, results) => {
      if (err) {
        console.error("Error fetching room ID by name:", err);
        reject(err);
      } else {
        resolve(results[0].room_id);
      }
    });
  });
};

const addRoom = (roomDetails) => {
    const { name, capacity, price, dateCreated } = roomDetails;
    return new Promise((resolve, reject) => {
      const query = "INSERT INTO room(Name, Capacity, Price, date_created) VALUES (?, ?, ?, ?)";
      pool.query(query, [name, capacity, price, dateCreated], (err, results) => {
        if (err) {
          console.error("Error adding new room:", err);
          reject(err);
        } else {
          resolve("Room saved successfully");
        }
      });
    });
  };

module.exports = {
  getAllRooms,
  getRoomsByName,
  updateRoom,
  deleteRoom,
  getRoomIdByName,
  addRoom
};
