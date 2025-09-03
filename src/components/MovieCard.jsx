const MovieCard = ({ title, poster, year }) => {
  return (
    <div className="h-[260px] w-32 shadow-lg rounded-lg bg-[#ececec] text-black flex flex-col sm:w-60 sm:h-[420px]">
      <div className="rounded-t-lg h-4/5 overflow-hidden">
        <img src={poster} alt={title} className="w-full h-auto object-cover" />
      </div>
      <div className="flex-1 flex flex-col justify-center">
        <strong className="block text-center font-serif sm:text-[19px]">
          {title}
        </strong>
        <p className="text-sm text-gray-600 text-center">{year}</p>
      </div>
    </div>
  );
};

export default MovieCard;
