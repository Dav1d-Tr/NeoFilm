import React from "react";

const Select = ({ text, name, options = [], value, onChange, required = true }) => {
  return (
    <div className="flex flex-col">
      <label className="text-white font-serif text-2xl my-1">{text}</label>
      <select
        name={name}
        required={required}
        value={value}
        onChange={onChange}
        className="h-12 text-base w-full sm:w-72 bg-[#09090b] text-[#ffffff] px-3 py-1 rounded-lg border border-[#4D2568] focus:outline-none focus:ring-2 focus:ring-[#4D2568] transition-all"
      >
        <option value="">Seleccione {text}</option>
        {options.map((opt, idx) => (
          <option key={idx} value={opt.value}>
            {opt.label}
          </option>
        ))}
      </select>
    </div>
  );
};

export default Select;
