const express = require('express');
const router = express.Router();
const dashboard = require('../controllers/dashboardController');

router.get('/max-customers', dashboard.getMaxCustomers);
router.get('/available-rooms', dashboard.getAvailableRooms);
router.get('/pre-registered-customers', dashboard.getPreRegisteredCustomers);
router.get('/checked-in-customers', dashboard.getCheckedInCustomers);
router.get('/total-payments', dashboard.getTotalPayments);
router.get('/cancelled-registrations', dashboard.getCancelledRegistrations);

module.exports = router;
