import React from "react";
import Button from "../../components/Button";
import { NavLink, Link, useLocation } from "react-router-dom";

const AdminHome = () => {
  return (
    <main className="flex justify-center h-screen items-center">
      <article className="bg-[#090909]/70 shadow-2xl shadow-[#be6eef] w-[500px] h-80 flex flex-col items-center justify-around rounded-lg py-4">
        <strong className="text-3xl text-white font-bold font-serif">
          Bienvenido !!
        </strong>
        <div className="flex flex-col gap-8 items-center">
          <Link to="/login">
            <Button text="Login" type="btn" />
          </Link>
          <Link to="/admin/adminRegister">
            <Button text="Registrarse" type="btn1" />
          </Link>
        </div>
      </article>
    </main>
  );
};

export default AdminHome;
