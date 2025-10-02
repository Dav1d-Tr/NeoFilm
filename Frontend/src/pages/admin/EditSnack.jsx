// src/pages/admin/EditSnack.jsx
import { useEffect, useState, useContext } from "react";
import { useParams, useNavigate } from "react-router-dom";
import { UserContext } from "../../context/UserContext";
import Button from "../../components/Button";
import Select from "../../components/Select";
import Input from "../../components/Input";

const API_BASE = "http://localhost:5017";

const EditSnack = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const { user } = useContext(UserContext);

    const [snack, setSnack] = useState({
        id: 0,
        name: "",
        description: "",
        unitValue: "",
        imageUrl: "",
        state: true,
        categorieSnacksId: "",
    });

    const [snackCategories, setSnackCategories] = useState([]);
    const [loading, setLoading] = useState(true);

    // 🚨 Solo admins
    useEffect(() => {
        if (!user || user.roleId !== 2) {
            alert("No tienes permisos ❌");
            navigate("/login");
        }
    }, [user, navigate]);

    // Obtener snack
    useEffect(() => {
        const fetchSnack = async () => {
            try {
                const res = await fetch(`${API_BASE}/api/Snacks/${id}`);
                if (!res.ok) throw new Error("Error snack");
                const data = await res.json();
                setSnack({
                    id: data.id,
                    name: data.name || "",
                    description: data.description || "",
                    unitValue: data.unitValue || 0,
                    imageUrl: data.imageUrl || "",
                    state: data.state ?? true,
                    categorieSnacksId: data.categorieSnacksId || "",
                });
            } catch (err) {
                console.error(err);
                alert("Error cargando snack");
            } finally {
                setLoading(false);
            }
        };
        fetchSnack();
    }, [id]);

    // Obtener categorías
    useEffect(() => {
        const fetchSnackCategories = async () => {
            try {
                const res = await fetch(`${API_BASE}/api/CategorieSnacks`);
                if (!res.ok) throw new Error(res.statusText);
                const data = await res.json();
                setSnackCategories(
                    (Array.isArray(data) ? data : []).map((cat) => ({
                        value: cat.id,
                        label: cat.name,
                    }))
                );
            } catch (err) {
                console.error("Error fetching snack categories:", err);
                setSnackCategories([]);
            }
        };
        fetchSnackCategories();
    }, []);

    const handleChange = (field, value) => {
        setSnack((prev) => ({ ...prev, [field]: value }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const res = await fetch(`${API_BASE}/api/Snacks`, {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    ...snack,
                    unitValue: Number(snack.unitValue),
                    state: snack.state === "true" || snack.state === true,
                    categorieSnacksId: Number(snack.categorieSnacksId),
                }),
            });
            if (!res.ok) throw new Error("Error al actualizar snack");
            alert("Snack actualizado ✅");
            navigate("/admin/manageSnacks");
        } catch (err) {
            console.error(err);
            alert("No se pudo actualizar ❌");
        }
    };

    if (loading) return <p className="text-white">Cargando...</p>;

    return (
        <main className="flex justify-center items-center min-h-screen text-white pt-20">
            <form
                onSubmit={handleSubmit}
                className="bg-[#090909]/70 shadow-[#be6eef] p-6 rounded-lg shadow-lg flex flex-col gap-8 py-10"
            >
                <h2 className="text-3xl font-serif text-center">Editar Snack</h2>

                <section className="grid lg:grid-cols-3 sm:grid-cols-1 w-5xl">
                    <div className="flex flex-col items-center">
                        <Input
                            type="text"
                            text="Nombre"
                            value={snack.name}
                            onChange={(e) => handleChange("name", e.target.value)}
                        />
                        <Input
                            type="text"
                            text="Descripción"
                            value={snack.description}
                            onChange={(e) => handleChange("description", e.target.value)}
                        />
                        <Input
                            type="number"
                            text="Precio"
                            value={snack.unitValue}
                            onChange={(e) => handleChange("unitValue", e.target.value)}
                        />
                    </div>
                    <div className="flex flex-col items-center">
                        {/* Categoría */}
                        <Select
                            text="Categoría"
                            name="tipoSnack"
                            value={snack.categorieSnacksId}
                            options={snackCategories}
                            onChange={(e) =>
                                handleChange("categorieSnacksId", e.target.value)
                            }
                        />

                        <Select
                            text="Estado"
                            name="estado"
                            value={String(snack.state)}
                            options={[
                                { value: "true", label: "Activo" },
                                { value: "false", label: "Inactivo" },
                            ]}
                            onChange={(e) => handleChange("state", e.target.value)}
                        />

                        <Input
                            type="text"
                            text="URL de la imagen"
                            value={snack.imageUrl}
                            onChange={(e) => handleChange("imageUrl", e.target.value)}
                        />
                    </div>
                    <div className="flex justify-center items-center">
                        {/* Preview */}
                        {snack.imageUrl && (
                            <img
                                src={snack.imageUrl}
                                alt="Vista previa"
                                className="w-full h-56 object-contain"
                            />
                        )}
                    </div>
                </section>
                <div className="flex justify-center">
                    <Button type="submit" text="Guardar cambios" />
                </div>
            </form>
        </main>
    );
};

export default EditSnack;
