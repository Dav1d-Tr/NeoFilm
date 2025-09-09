import React from "react";

const CombosCard = ({ title, price, image, descripcion }) => {
  return (
    <div className="relative h-[240px] w-32 shadow-lg rounded-lg bg-[#ececec] text-black flex flex-col sm:w-60 sm:h-[350px]">
      <div className="rounded-t-lg h-[64%] overflow-hidden">
        <img src={image} alt={title} className="w-full h-full object-cover" />
      </div>

        <div className="flex-1 flex flex-col justify-start text-center p-1 sm:p-2">
          <strong className="block leading-none font-serif text-[14px] sm:text-2xl">{title}</strong>
          <p className="text-[12px] sm:text-[16px] leading-tight sm:leading-normal text-gray-600">{descripcion}</p>
          <span className="text-[12px] sm:text-2xl font-serif">{price}</span>
        </div>
      
    </div>
  );
};

export default CombosCard;
