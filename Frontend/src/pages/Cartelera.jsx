import MovieCard from "../components/MovieCard";
import moviesCartelera from "../data/moviesCartelera.json";

const Cartelera = () => {
  return (
    <main className="flex items-center flex-col gap-8 sm:gap-20 overflow-hidden">
      {/* Películas */}
      <section className="text-white max-w-[1200px] w-full py-10">
        <div className="flex justify-center gap-6 p-2.5 sm:p-8 flex-wrap sm:mt-10">
          {moviesCartelera.map((movie) => (
            <MovieCard
              key={movie.id}
              title={movie.titulo}
              poster={movie.imagen}
              variant="showtime"
            ></MovieCard>
          ))}
        </div>
      </section>
    </main>
  );
};

export default Cartelera;
