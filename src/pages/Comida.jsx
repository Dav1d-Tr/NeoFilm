import CombosCard from "../components/CombosCard";
import combosMenu from "../data/combosMenu.json";

const Comida = () => {
  return (
    <main className="flex items-center flex-col gap-8 sm:gap-20 overflow-hidden relative top-20 mb-24">
      {Object.entries(combosMenu).map(([categoria, items]) => (
        <section
          key={categoria}
          className="text-white max-w-[1200px] w-full py-0.5 sm:py-8 flex flex-col justify-center gap-4"
        >
          {/* Título con líneas */}
          <div className="flex justify-center items-center gap-4 px-6">
            <div className="flex-1 h-0.5 sm:w-96 sm:h-1 rounded bg-amber-50"></div>
            <h2 className="text-white text-[20px] sm:text-3xl font-serif capitalize">
              {categoria}
            </h2>
            <div className="flex-1 h-0.5 sm:w-96 sm:h-1 rounded bg-amber-50"></div>
          </div>

          {/* Tarjetas */}
          <div className="flex justify-center gap-4 px-2.5 sm:px-8 flex-wrap sm:mt-10">
            {items.map((item) => (
              <CombosCard
                key={item.id}
                title={item.title}
                price={`$${item.price}`}
                image={item.image}
                descripcion={item.description}
              />
            ))}
          </div>
        </section>
      ))}
    </main>
  );
};

export default Comida;
