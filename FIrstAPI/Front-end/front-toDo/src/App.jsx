import "./App.css";
import ToDo from "../components/ToDo";
import Header from "../components/Header";

function App() {
  return (
    <>
      <div>
        <Header />
        <h1>Aplicación de Consumo de API</h1> 
        <ToDo />
      </div>
    </>
  );
}

export default App;
