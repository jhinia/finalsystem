const guestModel = require('../models/dashboard');

// Controller to fetch max customers on a specific date
const getMaxCustomers = async (req, res) => {
  const { date } = req.query;
  try {
    const maxCustomers = await guestModel.getMaxCustomers(date);
    res.status(200).json({ maxCustomers });
  } catch (err) {
    console.error("Error fetching max customers:", err);
    res.status(500).json({ error: 'Failed to fetch max customers' });
  }
};

// Controller to fetch available rooms
const getAvailableRooms = async (req, res) => {
  try {
    const availableRooms = await guestModel.getAvailableRooms();
    res.status(200).json({ availableRooms });
  } catch (err) {
    console.error("Error fetching available rooms:", err);
    res.status(500).json({ error: 'Failed to fetch available rooms' });
  }
};

// Controller to fetch pre-registered customers on a specific date
const getPreRegisteredCustomers = async (req, res) => {
  const { date } = req.query;
  try {
    const preRegisteredCustomers = await guestModel.getPreRegisteredCustomers(date);
    res.status(200).json({ preRegisteredCustomers });
  } catch (err) {
    console.error("Error fetching pre-registered customers:", err);
    res.status(500).json({ error: 'Failed to fetch pre-registered customers' });
  }
};

// Controller to fetch checked-in customers on a specific date
const getCheckedInCustomers = async (req, res) => {
  const { date } = req.query;
  try {
    const checkedInCustomers = await guestModel.getCheckedInCustomers(date);
    res.status(200).json({ checkedInCustomers });
  } catch (err) {
    console.error("Error fetching checked-in customers:", err);
    res.status(500).json({ error: 'Failed to fetch checked-in customers' });
  }
};

// Controller to fetch total payments on a specific date
const getTotalPayments = async (req, res) => {
  const { date } = req.query;
  try {
    const totalPayments = await guestModel.getTotalPayments(date);
    res.status(200).json({ totalPayments });
  } catch (err) {
    console.error("Error fetching total payments:", err);
    res.status(500).json({ error: 'Failed to fetch total payments' });
  }
};

// Controller to fetch cancelled registrations on a specific date
const getCancelledRegistrations = async (req, res) => {
  const { date } = req.query;
  try {
    const cancelledRegistrations = await guestModel.getCancelledRegistrations(date);
    res.status(200).json({ cancelledRegistrations });
  } catch (err) {
    console.error("Error fetching cancelled registrations:", err);
    res.status(500).json({ error: 'Failed to fetch cancelled registrations' });
  }
};


module.exports = {
  getMaxCustomers,
  getAvailableRooms,
  getPreRegisteredCustomers,
  getCheckedInCustomers,
  getTotalPayments,
  getCancelledRegistrations
};
