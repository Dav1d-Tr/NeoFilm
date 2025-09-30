import React, { useState, useEffect, useContext } from "react";
import { NavLink, Link, useLocation } from "react-router-dom";
import Button from "./Button";
import { UserContext } from "../context/UserContext";

const Header = () => {
  const [menuOpen, setMenuOpen] = useState(false);
  const location = useLocation();
  const { user, logout } = useContext(UserContext);

  // Cerrar menú al cambiar de ruta
  useEffect(() => {
    setMenuOpen(false);
  }, [location]);

  return (
    <header className="w-full bg-black fixed top-0 z-20 sm:px-20 sm:py-0.5">
      <div className="w-full px-6 py-4 flex items-center justify-between">
        {/* Logo */}
        <Link to="/">
          <div className="flex items-center gap-2 text-white font-bold text-xl">
            <img src="/img/logo.png" alt="NeoFilm Logo" className="h-10 sm:h-16" />
            <strong className="text-2xl sm:text-4xl font-serif">NeoFilm</strong>
          </div>
        </Link>

        {/* Botón hamburguesa (solo móvil) */}
        <button
          className="sm:hidden text-white text-3xl"
          onClick={() => setMenuOpen(!menuOpen)}
        >
          {menuOpen ? "✕" : "☰"}
        </button>

        {/* Navegación y botones en PC */}
        <div className="hidden sm:flex flex-1 justify-center gap-6 text-white font-medium">
          <NavLink
            to="/cartelera"
            className={({ isActive }) =>
              `text-2xl font-serif transition ${
                isActive ? "text-purple-400" : "text-white hover:text-purple-400"
              }`
            }
          >
            Películas
          </NavLink>
          <NavLink
            to="/comida"
            className={({ isActive }) =>
              `text-2xl font-serif transition ${
                isActive ? "text-purple-400" : "text-white hover:text-purple-400"
              }`
            }
          >
            Alimentos
          </NavLink>
          <NavLink
            to="/movieinfo"
            className={({ isActive }) =>
              `text-2xl font-serif transition ${
                isActive ? "text-purple-400" : "text-white hover:text-purple-400"
              }`
            }
          >
            Info
          </NavLink>
        </div>

        {/* Botones o usuario logueado */}
        <div className="hidden sm:flex gap-3 items-center">
          {user ? (
            <div className="relative">
              <button
                onClick={() => setMenuOpen(prev => !prev)}
                className="px-4 py-2 bg-purple-700 rounded text-white"
              >
                {user.nombre} {user.apellido}
              </button>

              {menuOpen && (
                <div className="absolute right-0 mt-2 w-48 bg-white text-black rounded shadow-lg z-50">
                  <button
                    onClick={() => { logout(); setMenuOpen(false); }}
                    className="w-full text-left px-4 py-2 hover:bg-gray-200"
                  >
                    Cerrar sesión
                  </button>
                </div>
              )}
            </div>
          ) : (
            <>
              <Link to="/login">
                <Button text="Login" type="btn" />
              </Link>
              <Link to="/register">
                <Button text="Registrarse" type="btn1" />
              </Link>
            </>
          )}
        </div>
      </div>

      {/* MENÚ DESPLEGABLE EN MÓVIL */}
      {menuOpen && (
        <div className="fixed top-[72px] inset-x-0 h-[calc(100vh-72px)] bg-black flex flex-col items-center justify-center gap-4 z-10 sm:hidden">
          <nav className="flex flex-col gap-6 text-white font-medium text-center">
            <NavLink
              to="/cartelera"
              className={({ isActive }) =>
                `text-3xl font-serif transition ${
                  isActive ? "text-purple-400" : "text-white hover:text-purple-400"
                }`
              }
            >
              Películas
            </NavLink>
            <NavLink
              to="/comida"
              className={({ isActive }) =>
                `text-3xl font-serif transition ${
                  isActive ? "text-purple-400" : "text-white hover:text-purple-400"
                }`
              }
            >
              Alimentos
            </NavLink>
            {user && (
              <button
                onClick={() => logout()}
                className="text-3xl font-serif mt-6 bg-purple-700 px-4 py-2 rounded"
              >
                Cerrar sesión
              </button>
            )}
          </nav>

          {!user && (
            <div className="flex flex-col items-center gap-12 mt-6">
              <Link to="/login">
                <Button text="Login" type="btn" />
              </Link>
              <Link to="/register">
                <Button text="Registrarse" type="btn1" />
              </Link>
            </div>
          )}
        </div>
      )}
    </header>
  );
};

export default Header;
