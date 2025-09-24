import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import MainLayout from "./components/MainLayout";
import Home from "./pages/Home";
import Cartelera from "./pages/Cartelera";
import Comida from "./pages/Comida";
import Login from "./pages/Login";
import Register from "./pages/Register";
import MovieInfo from "./pages/MovieInfo";

function App() {
  return (
    <Router>
      <Routes>
        {/* Rutas con Layout */}
        <Route element={<MainLayout />}>
          <Route path="/" element={<Home />} />
          <Route path="/cartelera" element={<Cartelera />} />
          <Route path="/comida" element={<Comida />} />
          <Route path="/movieinfo" element={<MovieInfo />} />
          {/* Rutas especiales sin Footer o con Header diferente */}
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Route>
      </Routes>
    </Router>
  );
}

export default App;
