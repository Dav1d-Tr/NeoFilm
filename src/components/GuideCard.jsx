import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Button from "./Button";
import {Link} from "react-router-dom";

const GuideCard = ({title, text, infoButton, icono, link}) => {
  return (
    <article className="bg-[#1f1f1c] rounded-xl w-[250px] sm:w-[470px] p-4 sm:p-8 flex items-center flex-col gap-3 shadow-lg shadow-purple-950">
      <div className="flex flex-col items-center sm:flex-row gap-2 mb-2">
        <FontAwesomeIcon icon={icono} className="text-amber-50 text-5xl sm:text-8xl" />
        <div className="flex flex-col items-center sm:items-start">
          <strong className="text-white text-2xl sm:text-3xl font-serif">
            {title}
          </strong>
          <small className="text-neutral-50 text-[16px] font-light">
            {text}
          </small>
        </div>
      </div>

      <Link to={link}>
        <Button text={infoButton} type="btn1"></Button>
      </Link>
    </article>
  );
};

export default GuideCard;
