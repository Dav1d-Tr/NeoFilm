import ButtonCardMange from "./ButtonCardManage";

const ManageMovieCard = ({ title, poster, descripcion, onDelete, onEdit }) => {
  return (
    <div className="relative h-[260px] w-32 shadow-lg rounded-lg bg-[#ececec] text-black flex flex-col sm:w-60 sm:h-[420px]">
      <div className="rounded-t-lg h-4/5 overflow-hidden">
        <img src={poster} alt={title} className="w-full h-auto object-cover" />
      </div>

      <div className="flex-1 flex flex-col justify-start sm:justify-center px-1">
        <strong className="block text-center font-serif sm:text-[19px] leading-none sm:leading-normal">
          {title}
        </strong>
        <p className="text-xs sm:text-sm text-center text-gray-700 line-clamp-2">
          {descripcion}
        </p>
      </div>

      <div className="flex gap-0.5">
        <ButtonCardMange text="Editar" type="btn1" onClick={onEdit} />
        <ButtonCardMange text="Eliminar" type="btn" onClick={onDelete} />
      </div>
    </div>
  );
};

export default ManageMovieCard;
