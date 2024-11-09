import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Header from "./components/Header";
import Footer from "./components/Footer";
import HomePage from "./components/HomePage";
import UsersPage from "./components/UserPage";
import UserForm from "./components/Form";

function App() {
  return (
    <Router>
      <Header />
      <Routes>
        <Route path="/" element={<HomePage />} />
        <Route path="/users" element={<UsersPage/>}/>
        <Route path="/users/create" element={<UserForm/>}/>
      </Routes>
      <Footer />
    </Router>
  );
}

export default App;
