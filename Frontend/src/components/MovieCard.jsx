// MovieCard.jsx
import { useNavigate } from "react-router-dom";
import Button from "./Button";

const MovieCard = ({ id, title, poster, year, variant = "default" }) => {
  const navigate = useNavigate();

  const handleDetails = () => {
    navigate(`/movies/${id}`); // 👈 Redirige a la ruta con el ID real
  };

  return (
    <div
      className={`relative h-[260px] w-32 shadow-lg rounded-lg bg-[#ececec] text-black flex flex-col sm:w-60 sm:h-[420px] 
    ${variant === "showtime" ? "hover:scale-105 cursor-pointer" : ""}`}
    >
      {/* Imagen */}
      <div className="rounded-t-lg h-4/5 overflow-hidden">
        <img src={poster} alt={title} className="w-full h-auto object-cover" />
      </div>

      {/* Hover con botón */}
      {variant === "showtime" && (
        <div className="absolute inset-0 bg-black/80 opacity-0 hover:opacity-100 flex items-center justify-center transition-opacity duration-300">
          <Button text="Ver Detalles" type="btn1" onClick={handleDetails} />
        </div>
      )}

      {/* Título y año */}
      <div className="flex-1 flex flex-col justify-start sm:justify-center">
        <strong className="block text-center font-serif sm:text-[19px] leading-none sm:leading-normal">
          {title}
        </strong>
        {variant === "default" && (
          <p className="text-sm text-gray-600 text-center">{year}</p>
        )}
      </div>
    </div>
  );
};

export default MovieCard;
