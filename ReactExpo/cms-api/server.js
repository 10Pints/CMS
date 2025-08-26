const express = require('express');
const sql = require('mssql');
const app = express();

const dbConfig = {
  server: '127.0.0.1', // '192.168.254.103', // Your machine’s IP,  '127.0.0.1' is local host
  port: 1433,
  database: 'CMS', // Your database name
  user: 'sa',
  password: 'Noemi780619', // Set in SSMS
  options: {
//    trustedConnection: true,
    enableArithAbort: true,
//    encrypt: true,
    trustServerCertificate: true,
    connectTimeout: 30000,
  },
  
};

app.use(express.json());

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