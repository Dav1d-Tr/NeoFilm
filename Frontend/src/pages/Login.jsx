// src/pages/Login.jsx
import { useState, useContext } from "react";
import { useNavigate } from "react-router-dom";
import Input from "../components/Input";
import Button from "../components/Button";
import { UserContext } from "../context/UserContext";

const Login = () => {
  const [formData, setFormData] = useState({ email: "", password: "" });
  const [loading, setLoading] = useState(false);
  const { login } = useContext(UserContext);
  const navigate = useNavigate();
  const API_BASE = "http://localhost:5017";

  const handleChange = (field, value) => {
    setFormData((prev) => ({ ...prev, [field]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!formData.email || !formData.password) {
      alert("Todos los campos son obligatorios");
      return;
    }

    setLoading(true);
    try {
      // Traemos todos los usuarios
      const res = await fetch(`${API_BASE}/api/User`);
      if (!res.ok) throw new Error("Error al traer usuarios");
      const users = await res.json();

      // Buscamos el usuario que coincida con email y password
      const user = users.find(
        (u) =>
          u.email.toLowerCase() === formData.email.toLowerCase() &&
          u.password === formData.password
      );

      if (user) {
        // Guardamos sesión (incluyendo rol)
        login({
          id: user.id,
          nombre: user.name,
          apellido: user.lastName,
          email: user.email,
          roleId: user.roleId, // 👈 Guardamos el rol también
        });

        // Redirigir según rol
        if (user.roleId === 1) {
          navigate("/"); // Cliente
        } else {
          navigate("/admin"); // Admin
        }
      } else {
        alert("Email o contraseña incorrectos ❌");
      }
    } catch (err) {
      console.error("Error de conexión:", err);
      alert("Error en la conexión con el servidor");
    } finally {
      setLoading(false);
    }
  };

  return (
    <main className="flex items-center justify-center gap-8 sm:gap-20 overflow-hidden p-20 sm:h-screen">
      <section className="flex flex-col-reverse sm:grid grid-cols-2 gap-6 sm:gap-10 items-center">
        <form
          onSubmit={handleSubmit}
          className="px-6 py-2 sm:p-20 flex flex-col items-center gap-4"
        >
          <strong className="uppercase text-4xl font-serif text-white">Login</strong>
          <article className="flex flex-col items-center gap-2 w-full">
            <Input
              type="email"
              text="E-mail"
              value={formData.email}
              onChange={(e) => handleChange("email", e.target.value)}
            />
            <Input
              type="password"
              text="Password"
              value={formData.password}
              onChange={(e) => handleChange("password", e.target.value)}
            />
            <a href="#" className="text-white text-base font-light self-start">
              Forgot Password?
            </a>
            <Button text={loading ? "Cargando..." : "Log In"} type="submit" />
          </article>
        </form>
        <div className="h-40 w-full sm:h-[490px]">
          <img
            src="/img/imageLogin.png"
            alt="Cine"
            className="w-full h-full object-contain"
          />
        </div>
      </section>
    </main>
  );
};

export default Login;
