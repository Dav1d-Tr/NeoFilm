// src/App.jsx
import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import MainLayout from "./components/MainLayout";
import Home from "./pages/Home";
import Cartelera from "./pages/Cartelera";
import Comida from "./pages/Comida";
import Login from "./pages/Login";
import Register from "./pages/Register";
import MovieInfo from "./pages/MovieInfo";
import { UserProvider } from "./context/UserContext";

function App() {
  return (
    <UserProvider>
      <Router>
        <Routes>
          <Route element={<MainLayout />}>
            <Route path="/" element={<Home />} />
            <Route path="/cartelera" element={<Cartelera />} />
            <Route path="/comida" element={<Comida />} />
            <Route path="/movieinfo" element={<MovieInfo />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
          </Route>
        </Routes>
      </Router>
    </UserProvider>
  );
}

export default App;
