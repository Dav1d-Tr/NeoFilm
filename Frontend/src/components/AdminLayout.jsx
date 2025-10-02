// src/components/AdminLayout.jsx
import { Outlet, useLocation } from "react-router-dom";
import AdminHeader from "./AdminHeader";

const AdminLayout = () => {
  const location = useLocation();

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
