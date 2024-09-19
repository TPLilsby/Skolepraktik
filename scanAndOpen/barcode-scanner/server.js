const express = require('express');
const bodyParser = require('body-parser');
const fs = require('fs');
const cors = require('cors');
const path = require('path');

const app = express();
const PORT = 3000;
const CONFIG_FILE = 'barcode_folders.txt';

// Middleware
app.use(bodyParser.json());
app.use(cors());

// Read barcodes and folders from the configuration file
app.get('/barcode/:code', (req, res) => {
    const barcode = req.params.code;
    if (fs.existsSync(CONFIG_FILE)) {
        const lines = fs.readFileSync(CONFIG_FILE, 'utf-8').split('\n');
        const entry = lines.find(line => line.startsWith(barcode));
        if (entry) {
            const folder = entry.split('|')[1];
            return res.json({ folder });
        }
    }
    res.status(404).json({ message: 'Barcode not found' });
});

// Add or update barcode entry
app.post('/barcode', (req, res) => {
    const { barcode, folder } = req.body;
    if (fs.existsSync(CONFIG_FILE)) {
        const lines = fs.readFileSync(CONFIG_FILE, 'utf-8').split('\n');
        const existingEntryIndex = lines.findIndex(line => line.startsWith(barcode));
        if (existingEntryIndex !== -1) {
            lines[existingEntryIndex] = `${barcode}|${folder}`;
        } else {
            lines.push(`${barcode}|${folder}`);
        }
        fs.writeFileSync(CONFIG_FILE, lines.join('\n'));
    } else {
        fs.writeFileSync(CONFIG_FILE, `${barcode}|${folder}`);
    }
    res.json({ message: 'Barcode added or updated' });
});

// Serve static files (frontend)
app.use(express.static(path.join(__dirname, 'public')));

app.listen(PORT, () => {
    console.log(`Server running on http://localhost:${PORT}`);
});
