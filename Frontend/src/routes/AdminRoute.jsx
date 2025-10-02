// src/routes/AdminRoute.jsx
import { useContext } from "react";
import { Navigate } from "react-router-dom";
import { UserContext } from "../context/UserContext";

const AdminRoute = ({ children }) => {
  const { user } = useContext(UserContext);

  // Si no hay sesión, va al login
  if (!user) return <Navigate to="/login" replace />;

  // Si no es admin, lo mandamos al home
  if (user.rol !== "administrador") return <Navigate to="/" replace />;

  return children;
};

export default AdminRoute;
