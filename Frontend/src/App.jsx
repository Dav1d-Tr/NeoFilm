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
import AdminLayout from "./components/AdminLayout";
import AdminDashboard from "./pages/admin/AdminDashboard";
import ManageMovies from "./pages/admin/ManageMovies";
import ManageSnacks from "./pages/admin/ManageSnacks";
import NewSnacks from "./pages/admin/NewSnacks";
import AdminRegister from "./pages/admin/AdminRegister";
import AdminHome from "./pages/admin/AdminHome";
import AdminRoute from "./routes/AdminRoute";
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

          {/* Layout Admin */}
          {/* Rutas Admin protegidas */}
          <Route path="/admin" element={<AdminRoute><AdminLayout /></AdminRoute>}>
            <Route index element={<AdminHome />} />
            <Route path="adminDashboard" element={<AdminDashboard />} />
            <Route path="manageMovies" element={<ManageMovies />} />
            <Route path="manageSnacks" element={<ManageSnacks />} />
            <Route path="newSnacks" element={<NewSnacks />} />
            <Route path="adminRegister" element={<AdminRegister />} />
          </Route>
        </Routes>
      </Router>
    </UserProvider>
  );
}

export default App;
