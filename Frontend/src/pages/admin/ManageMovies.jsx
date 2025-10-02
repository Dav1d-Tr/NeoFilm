import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import ManageMovieCard from "../../components/ManageMovieCard";

const ManageMovies = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const navigate = useNavigate();
  const API_BASE = "http://localhost:5017";

  const fetchMovies = async () => {
    try {
      const response = await fetch(`${API_BASE}/api/Film`);
      if (!response.ok) throw new Error("Error al obtener películas");
      const data = await response.json();
      setMovies(data);
    } catch (err) {
      console.error(err);
      setError("No se pudieron cargar las películas");
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchMovies();
  }, []);

  const handleDelete = async (movieId) => {
    if (!window.confirm("¿Deseas eliminar esta película?")) return;
    try {
      const res = await fetch(`${API_BASE}/api/Film/${movieId}`, {
        method: "DELETE",
      });
      if (!res.ok) throw new Error("Error al eliminar la película");
      fetchMovies();
    } catch (err) {
      console.error(err);
      alert("No se pudo eliminar la película");
    }
  };

  const handleEdit = (movieId) => {
    navigate(`/admin/movies/edit/${movieId}`);
  };

  if (loading) return <p className="text-white">Cargando películas...</p>;
  if (error) return <p className="text-red-500">⚠ {error}</p>;

  return (
    <main className="flex items-center flex-col gap-8 sm:gap-20 overflow-hidden">
      {/* Películas */}
      <section className="text-white max-w-[1200px] w-full py-10">
        <div className="flex justify-center gap-6 p-2.5 sm:p-8 flex-wrap sm:mt-10">
          {movies.map((movie) => (
            <ManageMovieCard
              key={movie.id}
              title={movie.name}
              poster={movie.imageUrl}
              onDelete={() => handleDelete(movie.id)}
              onEdit={() => handleEdit(movie.id)}
            />
          ))}
        </div>
      </section>
    </main>
  );
};

export default ManageMovies;
