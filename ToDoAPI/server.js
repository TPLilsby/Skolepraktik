const express = require('express');
const cors = require('cors');
const sqlite3 = require('sqlite3').verbose();
const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const { v4: uuidv4 } = require('uuid');
const app = express();
const PORT = 3000;
const SECRET_KEY = 'your_secret_key';

// Forbind til SQLite database
const db = new sqlite3.Database(':memory:');

db.serialize(() => {
    db.run("CREATE TABLE users (id TEXT PRIMARY KEY, username TEXT UNIQUE, password TEXT)");
    db.run("CREATE TABLE tasks (id TEXT PRIMARY KEY, user_id TEXT, text TEXT, completed BOOLEAN, FOREIGN KEY(user_id) REFERENCES users(id))");
});

app.use(cors());
app.use(express.json());

app.post('/register', (req, res) => {
    const { username, password } = req.body;
    const userId = uuidv4();
    const hashedPassword = bcrypt.hashSync(password, 10);

    db.run("INSERT INTO users (id, username, password) VALUES (?, ?, ?)", [userId, username, hashedPassword], function(err) {
        if (err) {
            res.status(400).json({ error: 'Username already exists' });
        } else {
            res.json({ message: 'User registered successfully' });
        }
    });
});

app.post('/login', (req, res) => {
    const { username, password } = req.body;

    db.get("SELECT * FROM users WHERE username = ?", [username], (err, user) => {
        if (err) {
            res.status(500).json({ error: 'Internal server error' });
        } else if (!user || !bcrypt.compareSync(password, user.password)) {
            res.status(401).json({ error: 'Invalid credentials' });
        } else {
            const token = jwt.sign({ id: user.id }, SECRET_KEY, { expiresIn: '1h' });
            res.json({ token });
        }
    });
});

app.post('/tasks', authenticateToken, (req, res) => {
    const { text, completed } = req.body;
    const taskId = uuidv4();
    const userId = req.user.id;

    db.run("INSERT INTO tasks (id, user_id, text, completed) VALUES (?, ?, ?, ?)", [taskId, userId, text, completed], function(err) {
        if (err) {
            res.status(500).json({ error: 'Failed to add task' });
        } else {
            res.json({ message: 'Task added successfully' });
        }
    });
});

app.get('/tasks', authenticateToken, (req, res) => {
    const userId = req.user.id;

    db.all("SELECT * FROM tasks WHERE user_id = ?", [userId], (err, tasks) => {
        if (err) {
            res.status(500).json({ error: 'Failed to fetch tasks' });
        } else {
            res.json(tasks);
        }
    });
});

function authenticateToken(req, res, next) {
    const authHeader = req.headers['authorization'];
    const token = authHeader && authHeader.split(' ')[1];

    if (token == null) return res.sendStatus(401);

    jwt.verify(token, SECRET_KEY, (err, user) => {
        if (err) return res.sendStatus(403);
        req.user = user;
        next();
    });
}

app.listen(PORT, () => {
    console.log(`Server running on http://localhost:${PORT}`);
});
