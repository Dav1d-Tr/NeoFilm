import "./App.css";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import MainLayout from "./components/MainLayout";
import Home from "./pages/Home";
import Cartelera from "./pages/Cartelera";
import Login from "./pages/Login"

function App() {
  return (
    <Router>
      <Routes>
        {/* Rutas con Layout */}
        <Route element={<MainLayout />}>
          <Route path="/" element={<Home />} />
          <Route path="/cartelera" element={<Cartelera />} />
        </Route>

        {/* Rutas especiales sin Footer o con Header diferente */}
        <Route path="/login" element={<Login />} />
      </Routes>
    </Router>
  );
}

export default App;
