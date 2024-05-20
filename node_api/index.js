// index.js
const express = require('express');
const guestRoutes = require('./routes/guestRoutes');
const roomRoutes = require('./routes/roomRoutes');
const dashRoutes = require('./routes/dashboardRoutes');
const bodyParser = require('body-parser');
const cors = require('cors');

const app = express();
const port = 3000;

app.use(bodyParser.json());
app.use(cors());

// Corrected route setup
app.use('/api', guestRoutes);
app.use('/room', roomRoutes);
app.use('/board', dashRoutes);

app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
