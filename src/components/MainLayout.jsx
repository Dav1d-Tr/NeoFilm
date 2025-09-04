import { Outlet, useLocation } from "react-router-dom";
import Header from "./Header";
import Footer from "./Footer";

const MainLayout = () => {
    const location = useLocation();

  // Reglas según la ruta actual
  const isLoginPage = location.pathname === "/login";
  const isRegisterPage = location.pathname === "/register";
  return (
    <div className="bg-[linear-gradient(to_bottom,_#000000_0%,_#000000_45%,_rgba(119,38,173,0.2)_65%,_#7726ad_100%)]">
      {/* Header con props condicionales */}
      <Header/>

      {/* Aquí se montan las páginas */}
      <main className="flex-grow">
        <Outlet />
      </main>

      {/* Footer condicional */}
      <Footer></Footer>
    </div>
  )
}

export default MainLayout;