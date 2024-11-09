import { AppBar, Box, Toolbar, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import SecondaryButton from "./SecondaryButton";

function Header() {
  return (
    <AppBar position="static">
      <Toolbar variant="dense" className="bg-black flex justify-between">
        <Link to="/">
          <Typography variant="h5" className="text-white">
            Exam Api
          </Typography>
        </Link>
        <Box>
          <Link to="/users">
            <SecondaryButton>Users</SecondaryButton>
          </Link>
          <Link to="/">
            <SecondaryButton>XD</SecondaryButton>
          </Link>
        </Box>
      </Toolbar>
    </AppBar>
  );
}

export default Header;
