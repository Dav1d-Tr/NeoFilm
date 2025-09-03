import React from "react";
import Button from "./Button";

const Header = () => {
  return (
    <header className="relative w-full h-screen bg-[url('../img/banner.png')] bg-cover bg-center flex justify-center">

      {/* Contenido */}
      <div className="fixed hidden left-1/2 z-10 bg-black min-w-screen px-6 py-4 sm:flex justify-around items-center rounded-xl -translate-x-1/2">
        
        {/* Logo */}
        <div className="flex items-center gap-2 text-white font-bold text-xl">
          <img src='/img/logo.png' alt="NeoFilm Logo" className="h-16" />
          <strong className="text-4xl font-serif">NeoFilm</strong>
        </div>

        {/* Navegación */}
        <nav className="flex gap-6 text-white font-medium">
          <a href="#" className="text-2xl font-serif hover:text-purple-400 transition">Películas</a>
          <a href="#" className="text-2xl font-serif hover:text-purple-400 transition">Alimentos</a>
        </nav>

        {/* Botones */}
        <div className="flex gap-3">
          <Button text="Login" type="btn"></Button>
          <Button text="Registrarse" type="btn1"></Button>
        </div>
      </div>

      <div className="flex flex-col sm:flex-row justify-center sm:justify-between items-center bottom-0 absolute w-full max-w-full px-4 sm:px-10 mx-auto gap-6">
        <strong className="text-2xl w-60 text-center sm:text-5xl font-serif text-white sm:w-[500px] text-shadow-lg text-shadow-[#be6eef]">Vive la magia del cine, donde cada historia cobra vida en la pantalla.</strong>
        <img src="/img/peopleBanner.png" alt="People Banner" className="w-60 sm:w-lg"/>

      </div>
    </header>
  );
};

export default Header;
