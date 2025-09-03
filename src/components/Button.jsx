import React from "react";

const Button = ({ text, type }) => {
  const style  = type === "btn" 
  ? "border-4 border-[#be6eef] text-[#be6eef] px-5 py-2.5 font-bold rounded-lg bg-transparent hover:bg-[#5d55626d]"
  : "bg-[#be6eef] border-4 border-[#be6eef] px-5 py-2.5 font-bold rounded-lg text-white hover:bg-transparent hover:text-[#be6eef]"
  return (
    <a href="#" className={style}>
      {text}
    </a>
  );
};

export default Button;
