const express = require('express');
const router = express.Router();
const guestController = require('../controllers/guestController');

// Routes
router.get('/status/:status', guestController.getGuestsByStatus);
router.get('/all', guestController.getAllGuest);
router.get('/search', guestController.getGuestsByNameAndStatus);
router.get('/name', guestController.getGuestsByName);
router.post('/payment', guestController.addPaymentTransaction);
router.get('/guest/:name', guestController.getGuestByName);
router.get('/room-and-guest/:name', guestController.getRoomAndGuestInfoByName);
router.put('/guest/:id/update-status', guestController.updateGuestStatus);
router.put('/guest/:id/update-status-only', guestController.updateGuestStatusOnly);
router.put('/room/:id/update-availability', guestController.updateRoomAvailability);
router.get('/rooms/available', guestController.fetchAvailableRooms);
router.post('/guests/add', guestController.addGuest);

module.exports = router;
