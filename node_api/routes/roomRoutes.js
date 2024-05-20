const express = require('express');
const router = express.Router();
const roomController = require('../controllers/roomsControllers');

router.get('/rooms', roomController.getAllRooms);
router.get('/rooms/search', roomController.getRoomsByName);
router.put('/rooms/update', roomController.updateRoom);
router.delete('/rooms/:roomId', roomController.deleteRoom);
router.post('/add', roomController.addRoom);

module.exports = router;
