import MovieCard from "../components/MovieCard";
import movies from "../data/movies.json";
import GuideCard from "../components/GuideCard";
import { faBurger, faFilm } from "@fortawesome/free-solid-svg-icons";

const Home = () => {
  return (
    <main className="flex items-center flex-col gap-8 sm:gap-20 overflow-hidden">
      {/* Sección Banner */}
      <section className="relative w-screen h-screen bg-[url('../img/banner.png')] bg-cover bg-center flex justify-center overflow-hidden">
        <div className="absolute bottom-0 flex flex-col sm:flex-row justify-center items-center w-full max-w-[1200px] px-4 sm:px-8 gap-6">
          
          <strong className="text-3xl sm:text-5xl font-serif text-white text-center sm:text-left w-full sm:w-1/2 max-w-full text-shadow-lg text-shadow-[#be6eef]">
            Vive la magia del cine, donde cada historia cobra vida en la pantalla.
          </strong>

          <img
            src="/img/peopleBanner.png"
            alt="People Banner"
            className="w-72 sm:w-1/2 sm:h-[550px] object-contain max-w-full"
          />
        </div>
      </section>

      {/* Películas */}
      <section className="text-white max-w-[1200px] w-full py-8">
        <h2 className="font-bold text-[20px] w-full px-2.5 text-center sm:text-[28px] font-serif sm:text-start">
          Peliculas Más Taquilleras Actualmente
        </h2>
        <div className="flex justify-center gap-4 sm:justify-between p-2.5 sm:p-8 flex-wrap">
          {movies.map((movie) => (
            <MovieCard
              key={movie.id}
              title={movie.title}
              poster={movie.poster}
              year={movie.year}
            ></MovieCard>
          ))}
        </div>
      </section>
      <section className="max-w-[1200px] w-full flex flex-col items-center gap-10 sm:flex-row justify-around py-2 sm:py-8">
        <GuideCard
          title="Buy Tickets"
          text="Seleccionar Una funcion"
          infoButton="Ver Cartelara"
          icono={faFilm}
          link="cartelera"
        ></GuideCard>
        <GuideCard
          title="Snacks Y Bebidas"
          text="Ver Sección De Comidas"
          infoButton="Ver Combos"
          icono={faBurger}
          link="comida"
        ></GuideCard>
      </section>
      <section className="sm:max-w-[1200px] w-full items-center text-white flex flex-col gap-4 sm:flex-row justify-between py-8">
        <div className="sm:w-[600px] text-center px-5 sm:text-start flex flex-col items-center sm:items-start gap-2 sm:gap-4 justify-center">
          <h2 className="font-bold text-3xl sm:text-4xl font-serif mb-4">
            About Us
          </h2>
          <p className="sm:text-[20px] text-[12px]">
            En Cine Estelar creemos que cada película es una experiencia que
            merece vivirse en grande. Desde nuestras primeras funciones, nuestro
            propósito ha sido ofrecer más que una sala: un espacio donde las
            historias se sientan, se escuchen y se disfruten al máximo.
          </p>
          <p className="sm:text-[20px] text-[12px]">
            Con pantallas de última tecnología, sonido envolvente y la comodidad
            que te mereces, queremos que cada visita sea inolvidable. Amamos el
            cine tanto como tú, y trabajamos cada día para que siempre
            encuentres aquí un lugar para reír, emocionarte y soñar.
          </p>
          <p className="sm:text-[20px] text-[12px]">
            Porque para nosotros, el cine no es solo entretenimiento: es magia
            compartida.
          </p>
        </div>
        <img
          src="/img/aboutUs.png"
          alt="About Us"
          className="w-48 sm:h-[500px] sm:w-auto"
        />
      </section>
    </main>
  );
};

export default Home;
