document.addEventListener('DOMContentLoaded', loadTasks);

function loadTasks() {
    fetch('http://localhost:3000/tasks')
        .then(response => response.json())
        .then(tasks => {
            tasks.forEach(task => addTaskToDOM(task));
        })
        .catch(error => console.error('Error: ', error));
}

document.querySelector('#new-task-form').addEventListener('submit', event => {
    event.preventDefault();
    const taskText = document.querySelector('#new-task').value.trim();
    if (taskText) {
        const task = { text: taskText, completed: false };
        fetch('http://localhost:3000/tasks', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(task)
        })
        .then(response => response.json())
        .then(savedTask => {
            addTaskToDOM(savedTask);
            document.querySelector('#new-task').value = '';
        })
        .catch(error => console.error('Error: ', error));
    }
});

function addTaskToDOM(task) {
    const taskList = document.querySelector('#task-list');
    const taskItem = document.createElement('li');
    taskItem.textContent = task.text;
    taskItem.dataset.id = task.id;
    updateTaskClass(taskItem, task.completed);

    const deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', () => {
        deleteTask(task.id, taskItem);
    });

    const toggleButton = document.createElement('button');
    toggleButton.textContent = task.completed ? 'Undo' : 'Complete';
    toggleButton.addEventListener('click', () => {
        toggleTask(task, taskItem, toggleButton);
    });

    const editButton = document.createElement('button');
    editButton.textContent = 'Edit';
    editButton.addEventListener('click', () => {
        editTask(task, taskItem, editButton);
    });

    taskItem.appendChild(toggleButton);
    taskItem.appendChild(editButton);
    taskItem.appendChild(deleteButton);
    taskList.appendChild(taskItem);
}

function updateTaskClass(taskItem, completed) {
    if (completed) {
        taskItem.classList.add('completed');
        taskItem.classList.remove('incomplete');
    } else {
        taskItem.classList.add('incomplete');
        taskItem.classList.remove('completed');
    }
}

function deleteTask(id, taskItem) {
    fetch(`http://localhost:3000/tasks/${id}`, {
        method: 'DELETE'
    })
    .then(() => {
        taskItem.remove();
    })
    .catch(error => console.error('Error: ', error));
}

function toggleTask(task, taskItem, toggleButton) {
    task.completed = !task.completed;
    fetch(`http://localhost:3000/tasks/${task.id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(task)
    })
    .then(response => response.json())
    .then(updatedTask => {
        // Clear existing content and recreate item
        taskItem.innerHTML = '';

        // Add updated text and class
        taskItem.textContent = updatedTask.text;
        taskItem.dataset.id = updatedTask.id;
        updateTaskClass(taskItem, updatedTask.completed);

        // Recreate buttons
        const toggleButton = document.createElement('button');
        toggleButton.textContent = updatedTask.completed ? 'Undo' : 'Complete';
        toggleButton.addEventListener('click', () => {
            toggleTask(updatedTask, taskItem, toggleButton);
        });

        const editButton = document.createElement('button');
        editButton.textContent = 'Edit';
        editButton.addEventListener('click', () => {
            editTask(updatedTask, taskItem, editButton);
        });

        const deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', () => {
            deleteTask(updatedTask.id, taskItem);
        });

        // Append buttons to taskItem
        taskItem.appendChild(toggleButton);
        taskItem.appendChild(editButton);
        taskItem.appendChild(deleteButton);
    })
    .catch(error => console.error('Error: ', error));
}

function editTask(task, taskItem, editButton) {
    // Create input field for editing
    const inputField = document.createElement('input');
    inputField.type = 'text';
    inputField.value = task.text;

    // Create save button
    const saveButton = document.createElement('button');
    saveButton.textContent = 'Save';
    saveButton.addEventListener('click', () => {
        const updatedText = inputField.value.trim();
        if (updatedText) {
            task.text = updatedText;
            fetch(`http://localhost:3000/tasks/${task.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(task)
            })
            .then(response => response.json())
            .then(updatedTask => {
                // Clear existing content and recreate item
                taskItem.innerHTML = '';

                // Add updated text and class
                taskItem.textContent = updatedTask.text;
                taskItem.dataset.id = updatedTask.id;
                updateTaskClass(taskItem, updatedTask.completed);

                // Recreate buttons
                const toggleButton = document.createElement('button');
                toggleButton.textContent = updatedTask.completed ? 'Undo' : 'Complete';
                toggleButton.addEventListener('click', () => {
                    toggleTask(updatedTask, taskItem, toggleButton);
                });

                const editButton = document.createElement('button');
                editButton.textContent = 'Edit';
                editButton.addEventListener('click', () => {
                    editTask(updatedTask, taskItem, editButton);
                });

                const deleteButton = document.createElement('button');
                deleteButton.textContent = 'Delete';
                deleteButton.addEventListener('click', () => {
                    deleteTask(updatedTask.id, taskItem);
                });

                // Append buttons to taskItem
                taskItem.appendChild(toggleButton);
                taskItem.appendChild(editButton);
                taskItem.appendChild(deleteButton);
            })
            .catch(error => console.error('Error: ', error));
        }
    });

    // Clear existing content and add input field and save button
    taskItem.innerHTML = '';
    taskItem.appendChild(inputField);
    taskItem.appendChild(saveButton);
}
