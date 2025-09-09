import Input from "../components/Input";
import Button from "../components/Button";

const Login = () => {
  return (
    <main className="flex items-center justify-center gap-8 sm:gap-20 overflow-hidden p-20 h-screen">
      <section className="flex flex-col-reverse sm:grid grid-cols-2 gap-6 sm:gap-10 items-center">
        <form action="" className="px-6 py-2 sm:p-20 flex flex-col items-center gap-4">
          <strong className="uppercase text-4xl font-serif text-white">
            Login
          </strong>
          <article className="flex flex-col items-center gap-2">
            <Input type="text" text="Username"></Input>
            <Input type="password" text="Password"></Input>
            <a href="#" className="text-white text-base font-light" >Forgot Password?</a>
            <Button text="Log In" type="btnLogin" />
          </article>
        </form>
        <div className="h-40 w-full sm:h-[490px]">
          <img
            src="/img/imageLogin.png"
            alt="Cine"
            className="w-full h-full object-contain"
          />
        </div>
      </section>
    </main>
  );
};

export default Login;
