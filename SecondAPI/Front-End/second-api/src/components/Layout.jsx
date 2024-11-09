import { Box } from "@mui/material";

function Layout({ children }) {
  return (
    <Box className="flex flex-col justify-center items-center min-h-[calc(100vh-4rem)] bg-gray-200">
      {children}
    </Box>
  );
}

export default Layout;
