import { Button } from "@mui/material";

function PrimaryButton({ variant, onClick, children }) {
  return (
    <Button
      variant="contained"
      onClick={onClick}
      className="bg-green-600 rounded-2xl font-bold px-10"
    >
      {children}
    </Button>
  );
}

export default PrimaryButton;
