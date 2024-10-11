/* eslint-disable react-hooks/exhaustive-deps */
import { useState, useEffect } from "react";
import PropTypes from "prop-types";
import "../../styles/css/TaskDetail.css";
import { getUser } from "../../services/userService";

const TaskDetailModal = ({ isOpen, onClose, task, user, onDelete, onSave }) => {
  const [taskName, setTaskName] = useState("");
  const [taskDescription, setTaskDescription] = useState("");
  const [taskOwner, setTaskOwner] = useState("");

  useEffect(() => {
    const fetchUser = async () => {
      if (task) {
        setTaskName(task.name);
        setTaskDescription(task.description);
        if (task.userId === user.userId) {
          setTaskOwner(user.name);
        } else {
          try {
            const response = await getUser(task.userId);
            setTaskOwner(response.username);
          } catch (error) {
            console.error("Failed to fetch user:", error);
          }
        }
      }
    };

    fetchUser();
  }, [task, user]);

  const handleSave = () => {
    const updatedTask = {
      ...task,
      name: taskName,
      description: taskDescription,
    };
    onSave(updatedTask);
  };

  if (!isOpen || !task) return null;

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <p>Task Title</p>
        <input
          type="text"
          value={taskName}
          onChange={(e) => setTaskName(e.target.value)}
          disabled={task.userId !== user.userId}
        />
        <p>Task Description</p>
        <textarea
          value={taskDescription}
          onChange={(e) => setTaskDescription(e.target.value)}
          disabled={task.userId !== user.userId}
        />
        <p>Task Owner: {taskOwner}</p>
        <div className="button-container">
          <button className="button-delete" onClick={onDelete}>
            Delete
          </button>
          {task.userId === user.userId && (
            <button className="button-save" onClick={handleSave}>
              Save
            </button>
          )}
        </div>
        <button className="button-close" onClick={onClose}>
          Close
        </button>
      </div>
    </div>
  );
};

TaskDetailModal.propTypes = {
  isOpen: PropTypes.bool.isRequired,
  onClose: PropTypes.func.isRequired,
  task: PropTypes.object,
  user: PropTypes.object.isRequired,
  onDelete: PropTypes.func.isRequired,
  onSave: PropTypes.func.isRequired,
};

export default TaskDetailModal;
