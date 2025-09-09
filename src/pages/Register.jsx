import Input from "../components/Input";
import Button from "../components/Button";

const Register = () => {
  return (
    <main className="flex items-center justify-center gap-8 sm:gap-10 overflow-hidden p-20 sm:h-screen">
      <section className="flex flex-col gap-2 py-10 items-center">
        <strong className="uppercase text-4xl font-serif text-white">
          Registro!
        </strong>
        <form action="" className="flex flex-col gap-4 items-center">
          <article className="px-6 py-2 flex flex-col items-center gap-4 sm:grid grid-cols-3">
            <Input type="text" text="Nombre"></Input>
            <Input type="text" text="Apellido"></Input>
            <Input type="email" text="E-mail"></Input>
            <Input type="email" text="Confirmar el E-mail"></Input>
            <Input type="password" text="Password"></Input>
            <Input type="text" text="Tipo de Documento"></Input>
            <Input type="number" text="Número De Documento"></Input>
            <Input type="number" text="Número De Celular"></Input>
          </article>
          <div className="flex justify-center items-center gap-2 text-base text-white font-light">
            <input type="checkbox" name="" id="" />
            <a href="#">Terminos y Condiciones</a>
          </div>
          <Button text="Unirme" type="btnLogin" />
        </form>
      </section>
    </main>
  );
};

export default Register;