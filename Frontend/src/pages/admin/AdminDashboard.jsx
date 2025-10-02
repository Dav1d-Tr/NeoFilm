import { useState } from "react";
import { faPhotoFilm, faCookieBite, faFileVideo, faPizzaSlice } from "@fortawesome/free-solid-svg-icons";
import GuideCard from "../../components/GuideCard";

const AdminDashboard = () => {
  return (
    <main className="flex items-center flex-col gap-8 sm:gap-20 overflow-hidden pt-28">
      {/* Guía Rápida */}
      <section className="max-w-[1200px] w-full flex flex-col items-center gap-y-5 sm:gap-x-10 justify-around py-2 sm:py-2">
        <div className="text-center px-5 sm:text-start flex justify-center-center sm:items-start gap-2 sm:gap-4 justify-center">
          <GuideCard
          title="Manage Movies"
          text="Administra La Sección De Películas"
          infoButton="Ver Movies"
          icono={faPhotoFilm}
          link="manageMovies"
        ></GuideCard>
        <GuideCard
          title="Manage Snacks"
          text="Administra La Sección De Snacks"
          infoButton="Ver Snacks"
          icono={faCookieBite}
          link="manageSnacks"
        ></GuideCard>
        </div>
        <div className="text-center px-5 sm:text-start flex justify-center-center sm:items-start gap-2 sm:gap-4 justify-center">
          <GuideCard
          title="New Movie"
          text="Agregar Una Nueva Movie"
          infoButton="Add Movie"
          icono={faFileVideo}
          link="manageMovies"
        ></GuideCard>
        <GuideCard
          title="New Snacks"
          text="Agregar Un Nuevo Snack"
          infoButton="Add Snack"
          icono={faPizzaSlice}
          link="newSnacks"
        ></GuideCard>
        </div>
      </section>
    </main>
  );
};

export default AdminDashboard;
