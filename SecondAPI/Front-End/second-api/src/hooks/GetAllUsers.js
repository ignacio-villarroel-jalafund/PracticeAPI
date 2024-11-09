import { useEffect, useState } from "react";

const useFetchUsers = () => {
  const [users, setUsers] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5016/api/User")
      .then(response => {
        if (!response.ok) {
          throw new Error("Error fetching data");
        }
        return response.json();
      })
      .then(data => setUsers(data))
      .catch(error => console.error("Fetch error:", error));
  }, []);

  return users;
};

export default useFetchUsers;
