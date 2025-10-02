import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import Input from "../../components/Input";
import Button from "../../components/Button";
import Select from "../../components/Select";

const NewFilm = () => {
  const navigate = useNavigate();

  const [formData, setFormData] = useState({
    nombre: "",
    descripcion: "",
    duracion: "",
    distribucion: "",
    imagen: "",
    trailer: "",
    tipoFilm: "",
  });

  const [filmCategories, setFilmCategories] = useState([]);
  const API_BASE = "http://localhost:5017";

  useEffect(() => {
    const fetchFilmCategories = async () => {
      try {
        const res = await fetch(`${API_BASE}/api/CategorieFilms`);
        if (!res.ok) throw new Error(res.statusText);
        const data = await res.json();
        setFilmCategories(
          (Array.isArray(data) ? data : []).map((cat) => ({
            value: cat.id,
            label: cat.name,
          }))
        );
      } catch (err) {
        console.error("Error fetching film categories:", err);
        setFilmCategories([]);
      }
    };

    fetchFilmCategories();
  }, []);

  const handleChange = (field, value) => {
    setFormData((prev) => ({ ...prev, [field]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    // Validaciones
    if (
      !formData.nombre ||
      !formData.descripcion ||
      !formData.duracion ||
      !formData.distribucion ||
      !formData.imagen ||
      !formData.trailer
    ) {
      alert("Todos los campos son obligatorios ❌");
      return;
    }

    if (!formData.tipoFilm) {
      alert("Selecciona una categoría de película ❌");
      return;
    }

    const payload = {
      name: formData.nombre,
      description: formData.descripcion,
      duration: parseInt(formData.duracion, 10),
      distribution: formData.distribucion,
      imageUrl: formData.imagen,
      trailer: formData.trailer,
      categorieFilmsId: Number(formData.tipoFilm),
    };

    try {
      const res = await fetch(`${API_BASE}/api/Film`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(payload),
      });

      if (res.ok) {
        alert("Película agregada con éxito");
        navigate("/admin");
      } else {
        const err = await res.text();
        console.error("Error:", err);
        alert("Error al agregar película");
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
          Añadir una nueva Película
        </h1>

        <form onSubmit={handleSubmit} className="grid gap-4 justify-center">
          <div className="grid grid-cols-1 sm:grid-cols-2 gap-4 ">
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
              text="Duración (min)"
              value={formData.duracion}
              onChange={(e) => handleChange("duracion", e.target.value)}
            />
            <Input
              type="text"
              text="Distribución"
              value={formData.distribucion}
              onChange={(e) => handleChange("distribucion", e.target.value)}
            />
            <Input
              type="text"
              text="Imagen (URL)"
              value={formData.imagen}
              onChange={(e) => handleChange("imagen", e.target.value)}
            />
            <Input
              type="text"
              text="Trailer (URL)"
              value={formData.trailer}
              onChange={(e) => handleChange("trailer", e.target.value)}
            />
            <Select
              text="Categoría"
              name="tipoFilm"
              value={formData.tipoFilm}
              options={filmCategories}
              onChange={(e) => handleChange("tipoFilm", e.target.value)}
            />
          </div>
          <div className="flex justify-center mt-4">
            <Button text="Agregar Película" type="submit" />
          </div>
        </form>
      </section>
    </main>
  );
};

export default NewFilm;
