// src/pages/admin/NewSnacks.jsx
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Input from "../../components/Input";
import Button from "../../components/Button";
import Select from "../../components/Select";

const NewSnacks = () => {
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    nombre: "",
    descripcion: "",
    precio: "",
    estado: "true",
    imagen: "",
    tipoSnack: "",
  });

  const [snackCategories, setSnackCategories] = useState([]);
  const API_BASE = "http://localhost:5017";

  useEffect(() => {
    const fetchSnackCategories = async () => {
      try {
        const res = await fetch(`${API_BASE}/api/CategorieSnacks`);
        if (!res.ok) throw new Error(res.statusText);
        const data = await res.json();
        setSnackCategories(
          (Array.isArray(data) ? data : []).map((cat) => ({
            value: cat.id,
            label: cat.name,
          }))
        );
      } catch (err) {
        console.error("Error fetching snack categories:", err);
        setSnackCategories([]);
      }
    };

    fetchSnackCategories();
  }, []);

  const handleChange = (field, value) => {
    setFormData((prev) => ({ ...prev, [field]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validaciones
    if (!formData.nombre || !formData.descripcion || !formData.precio) {
      alert("Todos los campos son obligatorios ❌");
      return;
    }

    if (!formData.tipoSnack) {
      alert("Selecciona una categoría de snack ❌");
      return;
    }

    const payload = {
      name: formData.nombre,
      description: formData.descripcion,
      unitValue: parseFloat(formData.precio),
      state: formData.estado === "true",
      imageUrl: formData.imagen,
      categorieSnacksId: Number(formData.tipoSnack),
    };

    try {
      const res = await fetch(`${API_BASE}/api/Snacks`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      });

      if (res.ok) {
        alert("Snack agregado con éxito");
        navigate("/admin");
      } else {
        const err = await res.text();
        console.error("Error:", err);
        alert("Error al agregar snack");
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
          Añadir un nuevo Snack
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
              text="Descripción"
              value={formData.descripcion}
              onChange={(e) => handleChange("descripcion", e.target.value)}
            />
            <Input
              type="number"
              text="Precio"
              value={formData.precio}
              onChange={(e) => handleChange("precio", e.target.value)}
            />
            <Select
              text="Categoría"
              name="tipoSnack"
              value={formData.tipoSnack}
              options={snackCategories}
              onChange={(e) => handleChange("tipoSnack", e.target.value)}
            />
            <Select
              text="Estado"
              name="estado"
              value={formData.estado}
              options={[
                { value: "true", label: "Activo" },
                { value: "false", label: "Inactivo" },
              ]}
              onChange={(e) => handleChange("estado", e.target.value)}
            />
            <Input
              type="text"
              text="Imagen (URL)"
              value={formData.imagen}
              onChange={(e) => handleChange("imagen", e.target.value)}
            />
          </div>
          <div className="flex justify-center mt-4">
            <Button text="Agregar Snack" type="submit" />
          </div>
        </form>
      </section>
    </main>
  );
};

export default NewSnacks;