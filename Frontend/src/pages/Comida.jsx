import { useEffect, useState } from "react";
import CombosCard from "../components/CombosCard";

const Comida = () => {
  const [categorias, setCategorias] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchCategorias = async () => {
      try {
        const response = await fetch(
          "http://localhost:5017/api/CategorieSnacks"
        );
        if (!response.ok) throw new Error("Error al obtener categorías");

        const data = await response.json();
        const categoriasConSnacks = data.filter(
          (categoria) => categoria.snacks && categoria.snacks.length > 0
        );

        setCategorias(categoriasConSnacks);
      } catch (error) {
        console.error("Error:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchCategorias();
  }, []);

  if (loading) {
    return <p className="text-white text-xl mt-36 text-center">Cargando categorías...</p>;
  }

  return (
    <main className="flex items-center flex-col gap-8 sm:gap-20 overflow-hidden relative top-20 mb-24">
      {categorias.map((categoria) => (
        <section
          key={categoria.id}
          className="text-white max-w-[1200px] w-full py-0.5 sm:py-8 flex flex-col justify-center gap-4"
        >
          {/* Título con líneas */}
          <div className="flex justify-center items-center gap-4 px-6">
            <div className="flex-1 h-0.5 sm:w-96 sm:h-1 rounded bg-amber-50"></div>
            <h2 className="text-white text-[20px] sm:text-3xl font-serif capitalize">
              {categoria.name}
            </h2>
            <div className="flex-1 h-0.5 sm:w-96 sm:h-1 rounded bg-amber-50"></div>
          </div>

          {/* Tarjetas de Snacks */}
          <div className="flex justify-center gap-4 px-2.5 sm:px-8 flex-wrap sm:mt-10">
            {categoria.snacks?.map((snack) => (
              <CombosCard
                key={snack.id}
                title={snack.name}
                price={`$${snack.unitValue}`}
                image={snack.imageUrl}
                descripcion={snack.description}
              />
            ))}
          </div>
        </section>
      ))}
    </main>
  );
};

export default Comida;
