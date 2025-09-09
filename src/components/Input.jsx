import React from "react";

const Input = ({ type, text }) => {
  return (
    <div className="flex flex-col">
      <span className="text-white font-serif text-2xl my-1">{text}</span>
      <input
        className="input h-12 text-base w-72 bg-[#09090b] text-[#ffffff] px-3 py-1 rounded-lg border border-[#4D2568] focus:outline-none focus:ring-2 focus:ring-[#4D2568] focus:ring-offset-2 focus:ring-offset-[#09090b] transition-all duration-150 ease-in-out"
        name="text"
        type={type}
        placeholder={`Enter your ${text}...`}
        required
      />
    </div>
  );
};

export default Input;
