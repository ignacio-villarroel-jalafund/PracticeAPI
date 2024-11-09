import { useState } from "react";

const useDeleteUser = () => {
  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);

  const deleteUser = async (id) => {
    try {
      const res = await fetch(`http://localhost:5016/api/User/${id}`, {
        method: "DELETE",
      });
      if (!res.ok) {
        throw new Error("Error deleting user");
      }
      const data = await res.json();
      setResponse(data);
    } catch (err) {
      setError(err.message);
    }
  };

  return { deleteUser, response, error };
};

export default useDeleteUser;
