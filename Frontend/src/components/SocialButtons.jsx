import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { 
  faInstagram, 
  faYoutube, 
  faTwitter, 
  faFacebook 
} from "@fortawesome/free-brands-svg-icons";

const SocialButtons = () => {
  const buttons = [
    { icon: faInstagram, bg: "bg-gradient-to-tr from-[#f58529] via-[#dd2a7b] to-[#8134af]" },
    { icon: faYoutube, bg: "bg-red-500" },
    { icon: faTwitter, bg: "bg-blue-400" },
    { icon: faFacebook, bg: "bg-blue-600" },
  ];

  return (
    <div className="flex gap-4">
      {buttons.map((btn, i) => (
        <a
          key={i}
          href="#"
          className={`p-8 h-6 w-6 rounded-full text-white text-3xl flex items-center justify-center ${btn.bg} transition-all duration-300 hover:scale-110`}
        >
          <FontAwesomeIcon icon={btn.icon} />
        </a>
      ))}
    </div>
  );
}

export default SocialButtons;