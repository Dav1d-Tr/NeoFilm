import React from "react";
import YouTubeVideo from "../components/YouTubeVideo";
import Button from "../components/Button";
import Date from "../components/Date";

const MovieInfo = () => {
  return (
    <main className="flex items-center flex-col gap-8 lg:gap-16 pt-16 lg:pt-28 mb-10 lg:mb-16">
      <article className="flex flex-col lg:flex-row max-w-5xl h-auto lg:h-[450px] items-center p-5">
        <img
          src="https://image.tmdb.org/t/p/original/y2JRa7An1qdJvTayi7jjda9rwxs.jpg"
          alt="movie"
          className="w-3/4 relative top-5 lg:static object-cover lg:h-full lg:w-full rounded-2xl lg:shadow-xl shadow-lg shadow-gray-100"
        />
        <div className="bg-white font-serif p-5 gap-2 flex flex-col rounded-2xl lg:rounded-r-2xl lg:rounded-l-none lg:shadow-xl shadow-lg shadow-gray-100">
          <h1 className="lg:text-3xl text-[20px] font-bold text-center lg:text-start">Como entrenar a tu dragon </h1>
          <div className="flex gap-1">
            <strong>Genero</strong>
            <em>Aventura</em>
          </div>
          <div className="flex gap-1">
            <strong>Duracion</strong>
            <em>125 Minutos</em>
          </div>
          <p className="text-justify">
            Lorem ipsum dolor sit amet consectetur adipisicing elit. Repudiandae
            quaerat, veritatis minus repellat omnis porro perferendis! Dolorum
            facilis quisquam architecto! Quos saepe soluta eum ea voluptatem id
            recusandae quia labore. Placeat ipsam fugiat vero dolore rerum
            saepe? Porro praesentium repellat neque quis, voluptatum cupiditate
            quae perferendis, nobis doloremque, laborum accusantium non.
            Suscipit beatae fuga officiis? Tenetur, unde labore! Provident,
            incidunt?
          </p>
          <div className="flex gap-1 lg:flex-row flex-col">
            <strong>Reparto</strong>
            <em>
              Mason Thames, Gerard Butler, Nico Parker, Nick Frost, Julian
              Dennison, Gabriel Howell, Bronwyn James, Harry Trevaldwyn, Ruth
              Codd, Peter Serafinowicz, Murray McArthur
            </em>
          </div>
        </div>
      </article>
      <section className="flex flex-col lg:flex-row items-center lg:justify-around w-full lg:max-w-5xl gap-6">
        <article className="h-auto lg:w-96 w-80 bg-white p-5 items-center text-center rounded-2xl flex flex-col gap-5">
          <h3 className="font-serif font-bold lg:text-2xl text-[20px]">Fechas y Horas Disponibles</h3 >
          <section className="flex flex-col gap-3 justify-center">
            <Date></Date>
            <Date></Date>
            <Date></Date> 
          </section>
          <Button text="Comprar Entradas" type="btn1"></Button>
        </article>
        <YouTubeVideo />        
      </section>
    </main>
  );
};

export default MovieInfo;
