const guestModel = require('../models/guest');  // Update the path if necessary

const getGuestsByStatus = async (req, res) => {
  const { status } = req.params;
  try {
    const guests = await guestModel.getGuestsByStatus(status);
    res.status(200).json(guests);
  } catch (err) {
    console.error("Error getting guests by status:", err);
    res.status(500).json({ error: 'Failed to fetch guests by status' });
  }
};

const getAllGuest = async (req, res) => {
    try {
      const guests = await guestModel.getAllGuest();
      res.status(200).json(guests);
    } catch (err) {
      console.error("Error getting all guests:", err);
      res.status(500).json({ error: 'Failed to fetch all guests' });
    }
  };

const getGuestsByNameAndStatus = async (req, res) => {
  const { name, status } = req.query;
  try {
    const guests = await guestModel.getGuestsByNameAndStatus(name, status);
    res.status(200).json(guests);
  } catch (err) {
    console.error("Error getting guests by name and status:", err);
    res.status(500).json({ error: 'Failed to fetch guests by name and status' });
  }
};

const getGuestsByName = async (req, res) => {
  const { name } = req.query;
  try {
    const guests = await guestModel.getGuestsByName(name);
    res.status(200).json(guests);
  } catch (err) {
    console.error("Error getting guests by name:", err);
    res.status(500).json({ error: 'Failed to fetch guests by name' });
  }
};

const addPaymentTransaction = async (req, res) => {
  const { guestId, totalPayment, cash, change, transactionDate } = req.body;
  try {
    const transactionId = await guestModel.addPaymentTransaction({
      guestId,
      totalPayment,
      cash,
      change,
      transactionDate
    });
    res.status(201).json({ transactionId });
  } catch (err) {
    console.error("Error adding payment transaction:", err);
    res.status(500).json({ error: 'Failed to add payment transaction' });
  }
};

const getGuestByName = async (req, res) => {
    const { name } = req.params;
    try {
      const guest = await guestModel.getGuestByName(name);
      res.status(200).json(guest);
    } catch (err) {
      console.error("Error fetching guest by name:", err);
      res.status(500).json({ error: 'Failed to fetch guest by name' });
    }
  };
  
  const getRoomAndGuestInfoByName = async (req, res) => {
    const { name } = req.params;
    try {
      const roomAndGuestInfo = await guestModel.getRoomAndGuestInfoByName(name);
      res.status(200).json(roomAndGuestInfo);
    } catch (err) {
      console.error("Error fetching room and guest info by name:", err);
      res.status(500).json({ error: 'Failed to fetch room and guest info by name' });
    }
  };
  
  const updateGuestStatus = async (req, res) => {
    const { id } = req.params;
    const { paymentStatus, status } = req.body;
    try {
      await guestModel.updateGuestStatus(id, paymentStatus, status);
      res.status(200).json({ message: 'Guest status updated successfully' });
    } catch (err) {
      console.error("Error updating guest status:", err);
      res.status(500).json({ error: 'Failed to update guest status' });
    }
  };
  
  const updateGuestStatusOnly = async (req, res) => {
    const { id } = req.params;
    const { status } = req.body;
    try {
      await guestModel.updateGuestStatusOnly(id, status);
      res.status(200).json({ message: 'Guest status updated successfully' });
    } catch (err) {
      console.error("Error updating guest status only:", err);
      res.status(500).json({ error: 'Failed to update guest status' });
    }
  };
  
  const updateRoomAvailability = async (req, res) => {
    const { id } = req.params;
    const { availability } = req.body;
    try {
      await guestModel.updateRoomAvailability(id, availability);
      res.status(200).json({ message: 'Room availability updated successfully' });
    } catch (err) {
      console.error("Error updating room availability:", err);
      res.status(500).json({ error: 'Failed to update room availability' });
    }
  };

  const addGuest = async (req, res) => {
    try {
      // Extract data from the request body
      const { name, contactNo, room_id, no_of_occupants, Overall_payment, date_registered } = req.body;
  
      // Call the service function to add the guest
      const result = await guestModel.addGuest({ name, contactNo, room_id, no_of_occupants, Overall_payment, date_registered });
  
      // Send success response
      res.status(200).json({ message: result });
    } catch (error) {
      // Send error response
      res.status(500).json({ error: error.message });
    }
  };

  const fetchAvailableRooms = async (req, res) => {
    try {
        // Call the service function to fetch available rooms
        const rooms = await guestModel.getAvailableRooms();

        // Send success response
        res.status(200).json(rooms);
    } catch (error) {
        // Send error response
        res.status(500).json({ error: 'Internal server error' });
    }
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
  fetchAvailableRooms,
};
