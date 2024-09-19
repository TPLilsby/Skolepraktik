document.getElementById('register-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const username = document.getElementById('register-username').value;
    const password = document.getElementById('register-password').value;

    const response = await fetch('http://localhost:3000/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ username, password })
    });

    const data = await response.json();
    console.log('Register response:', data);
});

document.getElementById('login-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const username = document.getElementById('login-username').value;
    const password = document.getElementById('login-password').value;

    const response = await fetch('http://localhost:3000/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ username, password })
    });

    const data = await response.json();
    console.log('Login response:', data);

    if (data.token) {
        localStorage.setItem('token', data.token);
        showTaskForm();
    } else {
        alert('Login failed');
    }
});

document.getElementById('task-form').addEventListener('submit', async (e) => {
    e.preventDefault();
    const text = document.getElementById('task-text').value;
    const token = localStorage.getItem('token');

    const response = await fetch('http://localhost:3000/tasks', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
        body: JSON.stringify({ text, completed: false })
    });

    const data = await response.json();
    console.log('Add task response:', data);
    loadTasks();
});

async function loadTasks() {
    const token = localStorage.getItem('token');

    const response = await fetch('http://localhost:3000/tasks', {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });

    const tasks = await response.json();
    const taskList = document.getElementById('task-list');
    taskList.innerHTML = '';

    tasks.forEach(task => {
        const li = document.createElement('li');
        li.textContent = task.text;
        taskList.appendChild(li);
    });
}

function showTaskForm() {
    document.getElementById('register-form-container').style.display = 'none';
    document.getElementById('login-form-container').style.display = 'none';
    document.getElementById('task-form-container').style.display = 'block';
    loadTasks();
}

// Load tasks on page load if token exists
document.addEventListener('DOMContentLoaded', () => {
    if (localStorage.getItem('token')) {
        showTaskForm();
    }
});
