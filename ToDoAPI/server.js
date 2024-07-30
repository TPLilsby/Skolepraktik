const express = require('express');
const cors = require('cors');
const sqlite3 = require('sqlite3').verbose();
const { v4: uuidv4 } = require('uuid');
const app = express();
const PORT = 3000;

// Forbind til SQLite database
const db = new sqlite3.Database('./database.sqlite', (err) => {
    if (err) {
        console.error('Could not connect to database', err);
    } else {
        console.log('Connected to SQLite database');
    }
});

// Opret en tasks tabel hvis den ikke eksisterer
db.serialize(() => {
    db.run(`CREATE TABLE IF NOT EXISTS tasks (
        id TEXT PRIMARY KEY,
        text TEXT,
        completed INTEGER
    )`);
});

app.use(cors());
app.use(express.json());

// Endpoint til at hente alle opgaver
app.get('/tasks', (req, res) => {
    db.all('SELECT * FROM tasks', (err, rows) => {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        }
        res.json(rows);
    });
    console.log('GET /tasks');
});

// Endpoint til at tilføje en ny opgave
app.post('/tasks', (req, res) => {
    const { text, completed } = req.body;
    const id = uuidv4();
    db.run('INSERT INTO tasks (id, text, completed) VALUES (?, ?, ?)', 
        [id, text, completed ? 1 : 0],
        function(err) {
            if (err) {
                res.status(500).json({ error: err.message });
                return;
            }
            res.status(201).json({ id, text, completed });
        });
});

// Endpoint til at opdatere en opgave
app.put('/tasks/:id', (req, res) => {
    const { id } = req.params;
    const { text, completed } = req.body;
    db.run(`UPDATE tasks SET text = ?, completed = ? WHERE id = ?`,
        [text, completed ? 1 : 0, id],
        function(err) {
            if (err) {
                res.status(500).json({ error: err.message });
                return;
            }
            res.json({ id, text, completed });
        });
});

// Endpoint til at slette en opgave
app.delete('/tasks/:id', (req, res) => {
    const { id } = req.params;
    db.run(`DELETE FROM tasks WHERE id = ?`, id, function(err) {
        if (err) {
            res.status(500).json({ error: err.message });
            return;
        }
        res.status(204).end();
    });
});

app.listen(PORT, () => {
    console.log(`Server running on http://localhost:${PORT}`);
});
