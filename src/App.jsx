import React, { Fragment } from "react";
import Header from "./components/HeaderMain";
import "./App.css";
import MovieCard from "./components/MovieCard";
import movies from "./data/movies.json";
import GuideCard from "./components/GuideCard";
import SocialButtons from "./components/SocialButtons";
import { faBurger, faFilm } from "@fortawesome/free-solid-svg-icons";

function App() {
  return (
    <div className="min-h-screen">
      {/*bg-gradient-to-b via-80% via-[#7726ad]/30 to-[#7726ad]*/}
      <Header/>
      <main className="bg-[linear-gradient(to_bottom,_#000000_0%,_#000000_45%,_rgba(119,38,173,0.2)_65%,_#7726ad_100%)] flex items-center flex-col py-10 gap-8 sm:gap-20">
        <section className="text-white max-w-[1200px] w-full py-8">
          <h2 className="font-bold text-[20px] w-full px-2.5 text-center sm:text-[28px] font-serif">
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
          ></GuideCard>
          <GuideCard
            title="Snacks Y Bebidas"
            text="Ver Sección De Comidas"
            infoButton="Ver Combos"
            icono={faBurger}
          ></GuideCard>
        </section>
        <section className="sm:max-w-[1200px] w-full items-center text-white flex flex-col gap-4 sm:flex-row justify-between py-8">
          <div className="sm:w-[600px] text-center px-5 sm:text-start flex flex-col items-center sm:items-start gap-2 sm:gap-4 justify-center">
            <h2 className="font-bold text-3xl sm:text-4xl font-serif mb-4">About Us</h2>
            <p className="sm:text-[20px] text-[12px]">
              En Cine Estelar creemos que cada película es una experiencia que
              merece vivirse en grande. Desde nuestras primeras funciones,
              nuestro propósito ha sido ofrecer más que una sala: un espacio
              donde las historias se sientan, se escuchen y se disfruten al
              máximo.
            </p>
            <p className="sm:text-[20px] text-[12px]">
              Con pantallas de última tecnología, sonido envolvente y la
              comodidad que te mereces, queremos que cada visita sea
              inolvidable. Amamos el cine tanto como tú, y trabajamos cada día
              para que siempre encuentres aquí un lugar para reír, emocionarte y
              soñar.
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
        <footer className="max-w-[1200px] w-full px-2 flex flex-col-reverse gap-4 sm:flex-row sm:justify-between">
          <div className="flex flex-col items-center sm:items-start">
            <SocialButtons></SocialButtons>
            <div className="text-white py-4 flex flex-col text-center items-center sm:items-start gap-2">
              <h3 className="text-4xl font-serif font-bold">
                Comunícate con nosotros
              </h3>
              <h4 className="text-2xl font-serif font-bold">Ubicaciones</h4>
              <p>Antioquia Centro Comercial Las Palmas, Medellín</p>
              <p>Sincelejo Plaza Real Mall</p>
              <p>Atlántico Buenavista Centro Comercial, Barranquilla</p>
              <p>
                <strong>Línea única: </strong>atencion@cineestelar.com
              </p>
              <p>
                <strong>Horario de atención: </strong>Lunes a domingo: 9:00 a.m.
                – 9:00 p.m.
              </p>
            </div>
          </div>
          <div className="text-white py-4 flex flex-col gap-2 text-center sm:text-right">
            <div className="flex justify-center sm:justify-end items-center gap-2.5 ">
              <img src="/img/logo.png" alt="Logo" className="w-24" />
              <strong className="text-4xl text-white">NeoFilm</strong>
            </div>
            <p>Términos y Condiciones de uso del sitio web</p>
            <p>Términos y Condiciones de Cine Fans</p>
            <p>Política de Privacidad de datos</p>
            <p>Política de Sagrilaf</p>
            <p className="sm:w-[500px]">
              Términos y condiciones de negociación - Ventas Empresariales de
              productos y servicios
            </p>
          </div>
        </footer>
      </main>
    </div>
  );
}

export default App;
