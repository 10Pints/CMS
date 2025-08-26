const express = require('express');
const sql = require('mssql');
const app = express();

const dbConfig = {
  server: '192.168.254.103', // Changed from 127.0.0.1 to match Android
  port: 1433,
  database: 'CMS',
  user: 'sa',
  password: 'Noemi780619',
  options: {
    enableArithAbort: true,
    connectTimeout: 30000,
    encrypt: true, // Explicitly enable encryption
    trustServerCertificate: true, // Trust self-signed certificate (dev only)
  },
};

app.use(express.json());

// Enable CORS
app.use((req, res, next) => {
  res.header('Access-Control-Allow-Origin', '*'); // Allow all origins (restrict in production)
  res.header('Access-Control-Allow-Methods', 'GET, POST, OPTIONS');
  res.header('Access-Control-Allow-Headers', 'Content-Type');
  next();
});

app.get('/api/customers', async (req, res) => {
  try {
    console.log('Attempting to connect to SQL Server with user:', process.env.USERNAME);
    let pool = await sql.connect(dbConfig);
    console.log('Connected successfully.');
    let result = await pool.request().query('EXEC sp_GetAllCustomers');
    console.log('Query executed:', result.recordset);
    res.json(result.recordset);
  } catch (err) {
    console.error('SQL Error:', err.message);
    res.status(500).send(err.message);
  }
});

app.listen(3000, '0.0.0.0', () => console.log('API running on port 3000'));