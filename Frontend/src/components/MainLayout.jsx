import { Outlet, useLocation } from "react-router-dom";
import Header from "./Header";
import Footer from "./Footer";

const MainLayout = () => {
    const location = useLocation();

  // Reglas según la ruta actual
  const isLoginPage = location.pathname === "/login";
  const isRegisterPage = location.pathname === "/register";
  return (
    <div>
      {/* Header con props condicionales */}
      <Header/>

      {/* Aquí se montan las páginas */}
      <main className="flex-grow">
        <Outlet />
      </main>

      {/* Footer condicional */}
      {!isLoginPage && !isRegisterPage && <Footer />}
    </div>
  )
}

export default MainLayout;