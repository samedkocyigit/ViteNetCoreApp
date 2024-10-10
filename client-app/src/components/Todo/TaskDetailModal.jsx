import { useState, useEffect } from "react"; // Add useEffect
import PropTypes from "prop-types";
import "../../styles/css/TaskDetail.css";

const TaskDetailModal = ({ isOpen, onClose, task, user, onDelete, onSave }) => {
  const [taskName, setTaskName] = useState("");
  const [taskDescription, setTaskDescription] = useState("");

  useEffect(() => {
    if (task) {
      setTaskName(task.name);
      setTaskDescription(task.description);
    }
  }, [task]);

  const handleSave = () => {
    const updatedTask = {
      ...task,
      name: taskName,
      description: taskDescription,
    };
    onSave(updatedTask); // Pass the updated task to onSave
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
          disabled={task.userId !== user.userId} // Disable if not the owner
        />
        <p>Task Description</p>
        <textarea
          value={taskDescription}
          onChange={(e) => setTaskDescription(e.target.value)}
          disabled={task.userId !== user.userId} // Disable if not the owner
        />
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
  user: PropTypes.object.isRequired, // Add user prop validation
  onDelete: PropTypes.func.isRequired,
  onSave: PropTypes.func.isRequired, // Add onSave prop validation
};

export default TaskDetailModal;
