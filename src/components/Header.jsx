import React from "react";
import { NavLink, Link } from "react-router-dom";
import Button from "./Button";

const Header = () => {
  return (
    <header className="relative w-full flex justify-center">
      {/* Contenido */}
      <div className="fixed hidden left-1/2 z-10 bg-black min-w-screen px-6 py-4 sm:flex justify-around items-center rounded-xl -translate-x-1/2">
        {/* Logo */}
        <Link to="/">
          <div className="flex items-center gap-2 text-white font-bold text-xl">
            <img src="/img/logo.png" alt="NeoFilm Logo" className="h-16" />
            <strong className="text-4xl font-serif">NeoFilm</strong>
          </div>
        </Link>

        {/* Navegación */}
        <nav className="flex gap-6 text-white font-medium">
          <NavLink
            to="/cartelera"
            className={({ isActive }) =>
              `text-2xl font-serif transition ${
                isActive
                  ? "text-purple-400"
                  : "text-white hover:text-purple-400"
              }`
            }
          >
            Películas
          </NavLink>
          <NavLink
            to="/login"
            className={({ isActive }) =>
              `text-2xl font-serif transition ${
                isActive
                  ? "text-purple-400"
                  : "text-white hover:text-purple-400"
              }`
            }
          >
            Alimentos
          </NavLink>
        </nav>

        {/* Botones */}
        <div className="flex gap-3">
          <Link to="/login">
            <Button text="Login" type="btn"></Button>
          </Link>
          <Link to="/login">
            <Button text="Registrarse" type="btn1"></Button>
          </Link>
        </div>
      </div>
    </header>
  );
};

export default Header;
