import { useEffect, useState, useContext } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { UserContext } from "../../context/UserContext";
import Button from "../../components/Button";
import Select from "../../components/Select";
import Input from "../../components/Input";

const API_BASE = "http://localhost:5017";

const EditFilm = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const { user } = useContext(UserContext);

  const [film, setFilm] = useState({
    id: 0,
    name: "",
    description: "",
    duration: "",
    distribution: "",
    imageUrl: "",
    trailer: "",
    categorieFilmsId: "",
  });

  const [filmCategories, setFilmCategories] = useState([]);
  const [loading, setLoading] = useState(true);

  // Solo admins
  useEffect(() => {
    if (!user || user.roleId !== 2) {
      alert("No tienes permisos ❌");
      navigate("/login");
    }
  }, [user, navigate]);

  // Obtener película
  useEffect(() => {
    const fetchFilm = async () => {
      try {
        const res = await fetch(`${API_BASE}/api/Film/${id}`);
        if (!res.ok) throw new Error("Error al obtener película");
        const data = await res.json();
        setFilm({
          id: data.id,
          name: data.name || "",
          description: data.description || "",
          duration: data.duration || 0,
          distribution: data.distribution || "",
          imageUrl: data.imageUrl || "",
          trailer: data.trailer || "",
          categorieFilmsId: data.categorieFilmsId || "",
        });
      } catch (err) {
        console.error(err);
        alert("Error cargando película");
      } finally {
        setLoading(false);
      }
    };
    fetchFilm();
  }, [id]);

  // Obtener categorías
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
    setFilm((prev) => ({ ...prev, [field]: value }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const res = await fetch(`${API_BASE}/api/Film`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          ...film,
          duration: Number(film.duration),
          categorieFilmsId: Number(film.categorieFilmsId),
        }),
      });
      if (!res.ok) throw new Error("Error al actualizar película");
      alert("Película actualizada");
      navigate("/admin/manageMovies");
    } catch (err) {
      console.error(err);
      alert("No se pudo actualizar");
    }
  };

  if (loading) return <p className="text-white">Cargando...</p>;

  return (
    <main className="flex justify-center items-center min-h-screen text-white pt-20">
      <form
        onSubmit={handleSubmit}
        className="bg-[#090909]/70 shadow-[#be6eef] p-6 rounded-lg shadow-lg flex flex-col gap-8 py-10"
      >
        <h2 className="text-3xl font-serif text-center">Editar Película</h2>

        <section className="grid lg:grid-cols-3 sm:grid-cols-1 w-5xl">
          <div className="flex flex-col items-center">
            <Input
              type="text"
              text="Nombre"
              value={film.name}
              onChange={(e) => handleChange("name", e.target.value)}
            />
            <Input
              type="text"
              text="Descripción"
              value={film.description}
              onChange={(e) => handleChange("description", e.target.value)}
            />
            <Input
              type="number"
              text="Duración (min)"
              value={film.duration}
              onChange={(e) => handleChange("duration", e.target.value)}
            />
            <Input
              type="text"
              text="Distribución"
              value={film.distribution}
              onChange={(e) => handleChange("distribution", e.target.value)}
            />
          </div>

          <div className="flex flex-col items-center">
            <Input
              type="text"
              text="URL de la Imagen"
              value={film.imageUrl}
              onChange={(e) => handleChange("imageUrl", e.target.value)}
            />
            <Input
              type="text"
              text="URL del Tráiler"
              value={film.trailer}
              onChange={(e) => handleChange("trailer", e.target.value)}
            />

            {/* Categoría */}
            <Select
              text="Categoría"
              name="tipoFilm"
              value={film.categorieFilmsId}
              options={filmCategories}
              onChange={(e) => handleChange("categorieFilmsId", e.target.value)}
            />
          </div>

          <div className="flex justify-center items-center">
            {/* Preview Imagen */}
            {film.imageUrl && (
              <img
                src={film.imageUrl}
                alt="Vista previa"
                className="w-full h-56 object-contain"
              />
            )}
          </div>
        </section>

        <div className="flex justify-center">
          <Button type="submit" text="Guardar cambios" />
        </div>
      </form>
    </main>
  );
};

export default EditFilm;
