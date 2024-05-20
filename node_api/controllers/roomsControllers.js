const roomModel = require('../models/room');

// Controller to fetch all rooms
const getAllRooms = async (req, res) => {
  try {
    const rooms = await roomModel.getAllRooms();
    res.status(200).json(rooms);
  } catch (err) {
    console.error("Error fetching all rooms:", err);
    res.status(500).json({ error: 'Failed to fetch all rooms' });
  }
};

// Controller to fetch rooms by name
const getRoomsByName = async (req, res) => {
  const { name } = req.query;
  try {
    const rooms = await roomModel.getRoomsByName(name);
    res.status(200).json(rooms);
  } catch (err) {
    console.error("Error fetching rooms by name:", err);
    res.status(500).json({ error: 'Failed to fetch rooms by name' });
  }
};

// Controller to update room details
const updateRoom = async (req, res) => {
  const { name, price, capacity, availability, roomId } = req.body;
  try {
    await roomModel.updateRoom({ name, price, capacity, availability, roomId });
    res.status(200).json({ message: 'Room details updated successfully' });
  } catch (err) {
    console.error("Error updating room details:", err);
    res.status(500).json({ error: 'Failed to update room details' });
  }
};

// Controller to delete room by ID
const deleteRoom = async (req, res) => {
  const { roomId } = req.params;
  try {
    await roomModel.deleteRoom(roomId);
    res.status(200).json({ message: 'Room deleted successfully' });
  } catch (err) {
    console.error("Error deleting room:", err);
    res.status(500).json({ error: 'Failed to delete room' });
  }
};

const addRoom = async (req, res) => {
  const { name, capacity, price, dateCreated } = req.body;
  try {
    await roomModel.addRoom({ name, capacity, price, dateCreated });
    res.status(201).json({ message: 'Room added successfully' });
  } catch (err) {
    console.error("Error adding room:", err);
    res.status(500).json({ error: 'Failed to add room' });
  }
};

module.exports = {
  getAllRooms,
  getRoomsByName,
  updateRoom,
  deleteRoom,
  addRoom
};
