import SocialButtons from "./SocialButtons";

const Footer = () => {
    return(
        <footer className="max-w-[1200px] w-full px-2 flex item flex-col-reverse gap-4 sm:flex-row sm:justify-between sm:gap-20 mx-auto">
                <div className="flex flex-col items-center sm:items-start">
                  <SocialButtons></SocialButtons>
                  <div className="text-white py-4 flex flex-col text-center items-center sm:items-start gap-2">
                    <h3 className="text-4xl font-serif font-bold">
                      Comunícate con nosotros
                    </h3>
                    <h4 className="text-2xl font-serif font-bold">Ubicaciones</h4>
                    <p>Antioquia Centro Comercial Las Palmas, Medellín</p>
                    <p>Sincelejo Plaza Real Mall</p>
                    <p>Atlántico Buenavista Centro Comercial, Barranquilla</p>
                    <p>
                      <strong>Línea única: </strong>atencion@cineestelar.com
                    </p>
                    <p>
                      <strong>Horario de atención: </strong>Lunes a domingo: 9:00 a.m. –
                      9:00 p.m.
                    </p>
                  </div>
                </div>
                <div className="text-white py-4 flex flex-col gap-2 text-center sm:text-right">
                  <div className="flex justify-center sm:justify-end items-center gap-2.5 ">
                    <img src="/img/logo.png" alt="Logo" className="w-24" />
                    <strong className="text-4xl text-white">NeoFilm</strong>
                  </div>
                  <p>Términos y Condiciones de uso del sitio web</p>
                  <p>Términos y Condiciones de Cine Fans</p>
                  <p>Política de Privacidad de datos</p>
                  <p>Política de Sagrilaf</p>
                  <p className="sm:w-[500px]">
                    Términos y condiciones de negociación - Ventas Empresariales de
                    productos y servicios
                  </p>
                </div>
              </footer>
    );
};

export default Footer;