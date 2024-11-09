import {
  Box,
  IconButton,
  Typography,
  Card,
  CardContent,
  CardActions,
  Button,
} from "@mui/material";
import PersonIcon from "@mui/icons-material/Person";

function UserCard({ initialName, initialLastName, initialOcupation }) {
  return (
    <Card className="flex flex-col justify-between items-center bg-white shadow-lg rounded-lg p-6 mb-4">
      <CardContent className="flex items-center w-full">
        <IconButton className="bg-blue-500 text-white rounded-full p-2 hover:bg-blue-600">
          <PersonIcon />
        </IconButton>
        <Box className="ml-4 flex flex-col">
          <Typography variant="h6" className="text-gray-900 font-semibold">
            {initialName}
          </Typography>
          <Typography variant="body1" className="text-gray-700">
            {initialLastName}
          </Typography>
          <Typography variant="body2" className="text-gray-500">
            {initialOcupation}
          </Typography>
        </Box>
      </CardContent>
      <CardActions className="w-full justify-end">
        <Button size="small" color="primary">
          Edit
        </Button>
        <Button size="small" color="secondary">
          Delete
        </Button>
      </CardActions>
    </Card>
  );
}

export default UserCard;
