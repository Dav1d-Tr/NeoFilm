// Cartelera.jsx
import { useEffect, useState } from "react";
import MovieCard from "../components/MovieCard";

const Cartelera = () => {
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchMovies = async () => {
      try {
        const response = await fetch("http://localhost:5017/api/Film"); 
        if (!response.ok) {
          throw new Error("Error al cargar las películas");
        }
        const data = await response.json();
        setMovies(data);
      } catch (err) {
        setError(err.message);
      } finally {
        setLoading(false);
      }
    };

    fetchMovies();
  }, []);

  if (loading) return <p className="text-white">Cargando películas...</p>;
  if (error) return <p className="text-red-500">{error}</p>;

  return (
    <main className="flex items-center flex-col gap-8 sm:gap-20 overflow-hidden">
      <section className="text-white max-w-[1200px] w-full py-10">
        <div className="flex justify-center gap-6 p-2.5 sm:p-8 flex-wrap sm:mt-10">
          {movies.map((movie) => (
            <MovieCard
              key={movie.id}
              id={movie.id}
              title={movie.name}
              poster={movie.imageUrl}
              year={movie.releaseYear} 
              variant="showtime"
            />
          ))}
        </div>
      </section>
    </main>
  );
};

export default Cartelera;
