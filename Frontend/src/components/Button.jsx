import React from "react";

const Button = ({ text, type, onClick }) => {
  const isSubmit = type === "submit";
  const style = isSubmit
    ? "bg-[#be6eef] border-4 border-[#be6eef] px-6 py-2 font-bold rounded-lg text-white hover:bg-transparent hover:text-[#be6eef] w-48"
    : type === "btn"
    ? "border-4 border-[#be6eef] text-[#be6eef] px-8 py-2 font-bold rounded-lg bg-transparent hover:bg-[#5d55626d]"
    : "bg-[#be6eef] border-4 border-[#be6eef] px-6 py-2 font-bold rounded-lg text-white hover:bg-transparent hover:text-[#be6eef] w-48";

  return (
    <button
      type={isSubmit ? "submit" : "button"}
      className={style}
      onClick={onClick} 
    >
      {text}
    </button>
  );
};

export default Button;
