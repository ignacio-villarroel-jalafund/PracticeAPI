import { Button } from "@mui/material";

function SecondaryButton({ onClick, children }) {
  return (
    <Button
      variant="outlined"
      onClick={onClick}
      className="bg-white rounded-2xl font-bold text-green-500 border-green-500 px-10"
    >
      {children}
    </Button>
  );
}

export default SecondaryButton;
