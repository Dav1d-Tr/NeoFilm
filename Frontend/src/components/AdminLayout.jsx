// src/components/AdminLayout.jsx
import { Outlet, useLocation } from "react-router-dom";
import AdminHeader from "./AdminHeader";

const AdminLayout = () => {
  const location = useLocation();

  // Reglas según la ruta actual

  return (
    <div>
      {/* Header del admin */}
      <AdminHeader />

      {/* Contenido del panel admin */}
      <main className="flex-grow">
        <Outlet />
      </main>
    </div>
  );
};

export default AdminLayout;
