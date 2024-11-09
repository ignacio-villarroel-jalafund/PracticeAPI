import { AppBar, Toolbar } from "@mui/material";

function Footer() {
  return (
    <AppBar position="static" className="fixed bottom-0 w-full">
      <Toolbar variant="dense" className="bg-black flex justify-between">
      </Toolbar>
    </AppBar>
  );
}

export default Footer;
