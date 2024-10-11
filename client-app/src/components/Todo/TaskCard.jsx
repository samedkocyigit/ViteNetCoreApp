/* eslint-disable no-unused-vars */
/* eslint-disable react/prop-types */
import { useDrag } from "react-dnd";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faInfoCircle } from "@fortawesome/free-solid-svg-icons";

const TaskCard = ({ task, onDetailClick }) => {
  const [{ isDragging }, drag] = useDrag(() => ({
    type: "TASK",
    item: { id: task.id },
    collect: (monitor) => ({
      isDragging: !!monitor.isDragging(),
    }),
  }));

  return (
    <div
      ref={drag}
      style={{ opacity: isDragging ? 0.5 : 1 }}
      className="task-card"
    >
      <div style={{ display: "flex", alignItems: "center" }}>
        <span style={{ flexGrow: 1 }}>{task.name}</span>
        <FontAwesomeIcon
          icon={faInfoCircle}
          onClick={onDetailClick}
          style={{
            cursor: "pointer",
            marginLeft: "10px",
            color: "blue",
            fontSize: "1.2em",
          }}
          title="Details"
        />
      </div>
    </div>
  );
};

export default TaskCard;
