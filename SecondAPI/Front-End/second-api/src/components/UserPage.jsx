import useFetchUsers from "../hooks/GetAllUsers";
import UserCard from "./UserCard";
import Layout from "./Layout";
import { Container, Typography } from "@mui/material";
import PrimaryButton from "./PrimaryButton";
import { Link } from "react-router-dom";

function UsersPage() {
  const users = useFetchUsers();

  return (
    <Layout>
      <Container className="flex justify-between py-6">
        <Typography variant="h5">Users View</Typography>
        <Link to="/users/create">
          <PrimaryButton>Add User</PrimaryButton>
        </Link>
      </Container>
      <Container className="flex justify-between flex-col">
        {users.map((user) => (
          <UserCard
            key={user.id}
            initialName={user.name}
            initialLastName={user.lastName}
            initialOcupation={user.ocupation}
          />
        ))}
      </Container>
    </Layout>
  );
}

export default UsersPage;
