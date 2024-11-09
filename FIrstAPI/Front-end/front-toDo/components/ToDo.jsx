import { useEffect, useState } from "react";

const ToDo = () => {
  const [toDos, setToDos] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5113/api/v1/ToDo")
      .then(response => {
        if (!response.ok) {
          throw new Error("Error fetching data");
        }
        return response.json();
      })
      .then(data => setToDos(data))
      .catch(error => console.error("Fetch error:", error));
  }, []);

  return (
    <div>
      <h1>To Dos</h1>
      <ul>
        {toDos.map((toDo) => (
          <li key={toDo.id}>
            {toDo.title} - {toDo.description}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default ToDo;
