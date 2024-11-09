import { useState } from "react";
import { Box, Container, TextField, Typography } from "@mui/material";
import SecondaryButton from "./SecondaryButton";
import PrimaryButton from "./PrimaryButton";
import Layout from "./Layout";
import useCreateUser from "../hooks/CreateUser";

function UserForm() {
  const [name, setName] = useState("");
  const [lastName, setLastName] = useState("");
  const [occupation, setOccupation] = useState("");
  const {
    createUser,
    response: createResponse,
    error: createError,
  } = useCreateUser();

  const handleSubmit = async () => {
    const user = { name, lastName, occupation };
    console.log("User data:", user);
    await createUser(user);
    
    if (createError) {
        console.log("Create user error:", createError);
    }      
  };
  

  return (
    <Layout>
      <Container className="w-full max-w-screen bg-white rounded-lg shadow-md p-6 space-y-6">
        <Typography
          className="text-center text-2xl font-bold text-gray-800"
          variant="h5"
        >
          User Form
        </Typography>
        <TextField
          label="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
          variant="outlined"
          fullWidth
          className="mb-4"
        />
        <TextField
          label="Last Name"
          value={lastName}
          onChange={(e) => setLastName(e.target.value)}
          variant="outlined"
          fullWidth
          className="mb-4"
        />
        <TextField
          label="Occupation"
          value={occupation}
          onChange={(e) => setOccupation(e.target.value)}
          variant="outlined"
          fullWidth
          className="mb-4"
        />
        <Box className="flex justify-between">
          <SecondaryButton className="w-1/2 mr-2">Cancel</SecondaryButton>
          <PrimaryButton className="w-1/2 ml-2" onClick={handleSubmit}>
            Submit
          </PrimaryButton>
        </Box>
        {createResponse && (
          <Typography color="primary" className="text-center mt-4">
            User created successfully!
          </Typography>
        )}
        {createError && (
          <Typography color="error" className="text-center mt-4">
            {createError}
          </Typography>
        )}
      </Container>
    </Layout>
  );
}

export default UserForm;
