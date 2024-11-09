import { useState } from "react";

const useUpdateUser = () => {
  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);

  const updateUser = async (id, updatedUser) => {
    try {
      const res = await fetch(`http://localhost:5016/api/User/${id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updatedUser),
      });
      if (!res.ok) {
        throw new Error("Error updating user");
      }
      const data = await res.json();
      setResponse(data);
    } catch (err) {
      setError(err.message);
    }
  };

  return { updateUser, response, error };
};

export default useUpdateUser;
