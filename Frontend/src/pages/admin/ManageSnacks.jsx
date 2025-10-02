import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ManageCombosCard from "../../components/ManageCombosCard";

const ManageSnacks = () => {
  const [categorias, setCategorias] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();
  const API_BASE = "http://localhost:5017";

  const fetchCategorias = async () => {
    try {
      const response = await fetch(`${API_BASE}/api/CategorieSnacks`);
      if (!response.ok) throw new Error("Error al obtener categorías");
      const data = await response.json();

    
      const categoriasConSnacks = data.filter(
        (categoria) => categoria.snacks && categoria.snacks.length > 0
      );

      setCategorias(categoriasConSnacks);
    } catch (err) {
      console.error(err);
      setError("No se pudieron cargar las categorías");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchCategorias();
  }, []);

  const handleDelete = async (snackId) => {
    if (!window.confirm("¿Deseas eliminar este snack?")) return;
    try {
      const res = await fetch(`${API_BASE}/api/Snacks/${snackId}`, {
        method: "DELETE",
      });
      if (!res.ok) throw new Error("Error al eliminar el snack");
      fetchCategorias();
    } catch (err) {
      console.error(err);
      alert("No se pudo eliminar el snack");
    }
  };

  const handleEdit = (snackId) => {
    navigate(`/admin/snacks/edit/${snackId}`);
  };

  if (loading) return <p className="text-white text-xl mt-32 text-center">Cargando categorías...</p>;
  if (error) return <p className="text-red-500 mt-20">{error}</p>;

  return (
    <main className="flex flex-col items-center gap-8 sm:gap-20 overflow-hidden relative top-20 mb-24">
      {categorias.map((categoria) => (
        <section
          key={categoria.id}
          className="text-white max-w-[1200px] w-full py-0.5 sm:py-8 flex flex-col justify-center gap-4"
        >
          {/* Título con líneas */}
          <div className="flex justify-center items-center gap-4 px-6">
            <div className="flex-1 h-0.5 sm:w-96 sm:h-1 rounded bg-amber-50"></div>
            <h2 className="text-white text-[20px] sm:text-3xl font-serif capitalize">
              {categoria.name}
            </h2>
            <div className="flex-1 h-0.5 sm:w-96 sm:h-1 rounded bg-amber-50"></div>
          </div>

          {/* Tarjetas de Snacks */}
          <div className="flex justify-center gap-4 px-2.5 sm:px-8 flex-wrap sm:mt-10">
            {categoria.snacks?.map((snack) => (
              <ManageCombosCard
                key={snack.id}
                title={snack.name}
                price={`$${snack.unitValue}`}
                image={snack.imageUrl}
                descripcion={snack.description}
                onDelete={() => handleDelete(snack.id)}
                onEdit={() => handleEdit(snack.id)}
              />
            ))}
          </div>
        </section>
      ))}
    </main>
  );
};

export default ManageSnacks;
