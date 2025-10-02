import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import YouTubeVideo from "../components/YouTubeVideo";
import Button from "../components/Button";
import Date from "../components/Date";

const MovieInfo = () => {
  const { id } = useParams();
  const [movie, setMovie] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchMovie = async () => {
      try {
        const res = await fetch(`http://localhost:5017/api/Film/${id}`);
        if (!res.ok) throw new Error("Error al cargar la película");
        const data = await res.json();
        setMovie(data);
      } catch (err) {
        console.error(err);
      } finally {
        setLoading(false);
      }
    };
    fetchMovie();
  }, [id]);

  if (loading) return <p className="text-white">Cargando...</p>;
  if (!movie) return <p className="text-red-500">Película no encontrada</p>;

  return (
    <main className="flex items-center flex-col gap-8 lg:gap-16 pt-16 lg:pt-28 mb-10 lg:mb-16">
      <article className="flex flex-col lg:flex-row max-w-5xl h-auto lg:h-[450px] items-center p-5">
        <img
          src={movie.imageUrl}
          alt={movie.name}
          className="w-3/4 relative top-5 lg:static object-cover lg:h-full lg:w-auto rounded-2xl lg:shadow-xl shadow-lg shadow-gray-100"
        />
        <div className="bg-white font-serif p-5 gap-2 flex flex-col rounded-2xl lg:rounded-r-2xl lg:rounded-l-none lg:shadow-xl shadow-lg shadow-gray-100">
          <h1 className="lg:text-3xl text-[20px] font-bold text-center lg:text-start">{movie.name} </h1>
          <div className="flex gap-1">
            <strong>Genero</strong>
            <em>{movie.categorieFilms?.name || "No especificado"}</em>
          </div>
          <div className="flex gap-1">
            <strong>Duracion</strong>
            <em>{movie.duration} Minutos</em>
          </div>
          <p className="text-justify">
            {movie.description}
          </p>
          <div className="flex gap-1 lg:flex-row flex-col">
            <strong>Reparto</strong>
            <em>
              {movie.distribution}
            </em>
          </div>
        </div>
      </article>
      <section className="flex flex-col lg:flex-row items-center lg:justify-around w-full lg:max-w-5xl gap-6">
        <article className="h-auto lg:w-96 w-80 bg-white p-5 items-center text-center rounded-2xl flex flex-col gap-5">
          <h3 className="font-serif font-bold lg:text-2xl text-[20px]">Fechas y Horas Disponibles</h3 >
          <section className="flex flex-col gap-3 justify-center">
            {movie.functions?.map((func) => (
              <Date key={func.id} date={func.fecha} time={func.hora} />
            ))}
          </section>
          <Button text="Comprar Entradas" type="btn1"></Button>
        </article>
        <YouTubeVideo url={movie.trailer} />       
      </section>
    </main>
  );
};

export default MovieInfo;
