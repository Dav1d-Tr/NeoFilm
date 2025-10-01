const ButtonCardManage = ({ text, type, onClick }) => {
  const isSubmit = type === "submit";
  const style = isSubmit
    ? "bg-[#be6eef] border-4 border-[#be6eef] px-6 py-2 font-bold rounded-lg text-white hover:bg-transparent hover:text-[#be6eef] w-48"
    : type === "btn"
    ? "border-4 border-red-500 text-white px-6 py-2 font-bold rounded-r-lg bg-red-500 hover:bg-transparent hover:text-red-500"
    : "bg-blue-500 border-4 border-blue-500 px-6 py-2 font-bold rounded-l-lg text-white hover:bg-transparent hover:text-blue-500 w-48";

  return (
    <button type={isSubmit ? "submit" : "button"} className={style} onClick={onClick}>
      {text}
    </button>
  );
};

export default ButtonCardManage;
