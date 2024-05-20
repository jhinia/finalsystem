const pool = require('../services/db');

// Fetch maximum customers registered on a specific date
const getMaxCustomers = (date) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT COUNT(Name) AS 'Max Customer' FROM Guest WHERE date_registered = ?";
    pool.query(query, [date], (err, results) => {
      if (err) {
        console.error("Error fetching max customers:", err);
        reject(err);
      } else {
        resolve(results[0]['Max Customer']);
      }
    });
  });
};

// Fetch available rooms count
const getAvailableRooms = () => {
  return new Promise((resolve, reject) => {
    const query = "SELECT COUNT(Availability) AS 'Available Room' FROM room WHERE Availability = 'Available'";
    pool.query(query, (err, results) => {
      if (err) {
        console.error("Error fetching available rooms:", err);
        reject(err);
      } else {
        resolve(results[0]['Available Room']);
      }
    });
  });
};

// Fetch max pre-registered customers
const getPreRegisteredCustomers = (date) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT COUNT(Name) AS 'Max Customer' FROM Guest WHERE date_registered = ? AND status = 'Pre-Registered'";
    pool.query(query, [date], (err, results) => {
      if (err) {
        console.error("Error fetching pre-registered customers:", err);
        reject(err);
      } else {
        resolve(results[0]['Max Customer']);
      }
    });
  });
};

// Fetch max checked-in customers
const getCheckedInCustomers = (date) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT COUNT(Name) AS 'Max Customer' FROM Guest WHERE date_registered = ? AND status = 'Checked-in'";
    pool.query(query, [date], (err, results) => {
      if (err) {
        console.error("Error fetching checked-in customers:", err);
        reject(err);
      } else {
        resolve(results[0]['Max Customer']);
      }
    });
  });
};

// Fetch total payments for a specific date
const getTotalPayments = (date) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT SUM(total_payment) AS 'Total Payment' FROM payment_transaction WHERE transaction_date = ?";
    pool.query(query, [date], (err, results) => {
      if (err) {
        console.error("Error fetching total payments:", err);
        reject(err);
      } else {
        // Since SUM() is already used in the SQL query, directly access the result
        resolve(results[0]['Total Payment']);
      }
    });
  });
};
// Fetch max cancelled registrations
const getCancelledRegistrations = (date) => {
  return new Promise((resolve, reject) => {
    const query = "SELECT COUNT(Name) AS 'Max Customer' FROM Guest WHERE date_registered = ? AND status = 'Cancelled Registration'";
    pool.query(query, [date], (err, results) => {
      if (err) {
        console.error("Error fetching cancelled registrations:", err);
        reject(err);
      } else {
        resolve(results[0]['Max Customer']);
      }
    });
  });
};

module.exports = {
  getMaxCustomers,
  getAvailableRooms,
  getPreRegisteredCustomers,
  getCheckedInCustomers,
  getTotalPayments,
  getCancelledRegistrations
};
