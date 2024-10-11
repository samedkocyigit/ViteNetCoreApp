/* eslint-disable no-useless-catch */
export const fetchTasks = async () => {
  try {
    const response = await fetch("http://localhost:5086/api/tasks");
    if (!response.ok) {
      throw new Error("Error fetching tasks");
    }
    return await response.json();
  } catch (error) {
    console.error("Error fetching tasks:", error);
    throw error;
  }
};

export const updateTask = async (taskId, updateTaskDto) => {
  try {
    const response = await fetch(`http://localhost:5086/api/tasks/${taskId}`, {
      method: "PUT",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updateTaskDto),
    });
    return await response.json();
  } catch (err) {
    throw err;
  }
};

export const createTask = async (newTask) => {
  try {
    const response = await fetch("http://localhost:5086/api/tasks", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newTask),
    });
    return await response.json();
  } catch (err) {
    throw err;
  }
};

export const deleteTask = async (id) => {
  try {
    await fetch(`http://localhost:5086/api/tasks/${id}`, {
      method: "DELETE",
    });
  } catch (err) {
    throw err;
  }
};
