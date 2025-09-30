// src/pages/Register.jsx
import { useState, useEffect, useContext } from "react";
import { useNavigate } from "react-router-dom";
import Input from "../components/Input";
import Button from "../components/Button";
import Select from "../components/Select";
import { UserContext } from "../context/UserContext";

const Register = () => {
  const { login } = useContext(UserContext); // Contexto para sesión
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    nombre: "",
    apellido: "",
    email: "",
    confirmEmail: "",
    password: "",
    confirmPassword: "",
    tipoDocumento: "", // id como string
    numeroDocumento: "",
    celular: "",
    roleId: "1", // RoleId fijo en 1 (Cliente)
  });

  const [documentTypes, setDocumentTypes] = useState([]);
  const API_BASE = "http://localhost:5017";

  useEffect(() => {
    const fetchDocumentTypes = async () => {
      try {
        const res = await fetch(`${API_BASE}/api/DocumentType`);
        if (!res.ok) throw new Error(res.statusText);
        const data = await res.json();
        const normalized = (Array.isArray(data) ? data : [])
          .map((dt) => ({
            id: dt.id ?? dt.Id,
            name: dt.name ?? dt.Name,
          }))
          .filter((dt) => dt.id !== undefined);
        setDocumentTypes(normalized);
      } catch (err) {
        console.error("Error fetching document types:", err);
        setDocumentTypes([]);
      }
    };

    fetchDocumentTypes();
  }, []);

  const handleChange = (field, value) => {
    setFormData((prev) => ({ ...prev, [field]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validaciones
    if (formData.password !== formData.confirmPassword) {
      alert("Las contraseñas no coinciden");
      return;
    }
    if (formData.email !== formData.confirmEmail) {
      alert("Los correos no coinciden");
      return;
    }
    if (!formData.numeroDocumento || !formData.tipoDocumento) {
      alert("Todos los campos son obligatorios");
      return;
    }

    const payload = {
      Id: formData.numeroDocumento,
      Name: formData.nombre,
      LastName: formData.apellido,
      Email: formData.email,
      ValidateEmail: formData.confirmEmail,
      Password: formData.password,
      ValidatePassword: formData.confirmPassword,
      PhoneNumber: formData.celular,
      DocumentTypeId: Number(formData.tipoDocumento),
      RoleId: 1, // Cliente
    };

    try {
      const res = await fetch(`${API_BASE}/api/User`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      });

      if (res.ok) {
        // Guardamos sesión en contexto y localStorage
        login({
          nombre: formData.nombre,
          apellido: formData.apellido,
          email: formData.email,
        });

        alert("Usuario registrado con éxito ✅");

        // Redirigir a página inicial
        navigate("/");

        // Limpiar formulario
        setFormData({
          nombre: "",
          apellido: "",
          email: "",
          confirmEmail: "",
          password: "",
          confirmPassword: "",
          tipoDocumento: "",
          numeroDocumento: "",
          celular: "",
          roleId: "1",
        });
      } else {
        const err = await res.json().catch(() => ({ status: res.status }));
        console.error("Error del servidor:", err);
        alert("Error al registrar usuario ❌");
      }
    } catch (err) {
      console.error("Error de conexión:", err);
      alert("Error en la conexión con el servidor");
    }
  };

  return (
    <main className="flex items-center justify-center px-8 pt-14 sm:h-screen">
      <section className="w-full max-w-4xl">
        <h1 className="text-3xl text-white font-serif mb-4 text-center">
          Registro
        </h1>

        <form onSubmit={handleSubmit} className="grid gap-4">
          <div className="grid grid-cols-1 sm:grid-cols-3 gap-4">
            <Input
              type="text"
              text="Nombre"
              value={formData.nombre}
              onChange={(e) => handleChange("nombre", e.target.value)}
            />
            <Input
              type="text"
              text="Apellido"
              value={formData.apellido}
              onChange={(e) => handleChange("apellido", e.target.value)}
            />
            <Input
              type="email"
              text="E-mail"
              value={formData.email}
              onChange={(e) => handleChange("email", e.target.value)}
            />
            <Input
              type="email"
              text="Confirmar el E-mail"
              value={formData.confirmEmail}
              onChange={(e) => handleChange("confirmEmail", e.target.value)}
            />
            <Input
              type="password"
              text="Password"
              value={formData.password}
              onChange={(e) => handleChange("password", e.target.value)}
            />
            <Input
              type="password"
              text="Confirmar Password"
              value={formData.confirmPassword}
              onChange={(e) => handleChange("confirmPassword", e.target.value)}
            />
            <Select
              text="Tipo de Documento"
              name="tipoDocumento"
              value={formData.tipoDocumento}
              options={documentTypes.map((dt) => ({
                value: String(dt.id),
                label: dt.name,
              }))}
              onChange={(e) => handleChange("tipoDocumento", e.target.value)}
            />
            <Input
              type="text"
              text="Número De Documento"
              value={formData.numeroDocumento}
              onChange={(e) => handleChange("numeroDocumento", e.target.value)}
            />
            <Input
              type="text"
              text="Número De Celular"
              value={formData.celular}
              onChange={(e) => handleChange("celular", e.target.value)}
            />

            {/* Input oculto para RoleId fijo */}
            <Input type="hidden" name="roleId" value="1" />
          </div>

          <div className="flex items-center gap-2 justify-center">
            <input type="checkbox" required />
            <span className="text-white">Acepto términos y condiciones</span>
          </div>

          <div className="text-center">
            <Button text="Unirme" type="submit" />
          </div>
        </form>
      </section>
    </main>
  );
};

export default Register;
