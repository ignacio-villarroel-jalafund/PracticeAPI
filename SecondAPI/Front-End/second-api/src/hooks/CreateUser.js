import { useState } from "react";

const useCreateUser = () => {
  const [response, setResponse] = useState(null);
  const [error, setError] = useState(null);

  const createUser = async (user) => {
    try {
      const res = await fetch("http://localhost:5016/api/User", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(user),
      });
      if (!res.ok) {
        throw new Error("Error creating user");
      }
      const data = await res.json();
      setResponse(data);
    } catch (err) {
      setError(err.message);
    }
  };

  return { createUser, response, error };
};

export default useCreateUser;
