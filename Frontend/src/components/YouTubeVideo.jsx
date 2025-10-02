import React from "react";

const YouTubeVideo = ({ url }) => {
  const getEmbedUrl = (url) => {
    try {
      const parsedUrl = new URL(url);

      // Si es un enlace normal: https://www.youtube.com/watch?v=ID
      if (parsedUrl.hostname.includes("youtube.com")) {
        const videoId = parsedUrl.searchParams.get("v");
        return `https://www.youtube.com/embed/${videoId}`;
      }

      // Si es un enlace corto: https://youtu.be/ID
      if (parsedUrl.hostname === "youtu.be") {
        const videoId = parsedUrl.pathname.slice(1); // remove "/"
        return `https://www.youtube.com/embed/${videoId}`;
      }

      return ""; // No se pudo identificar
    } catch (error) {
      console.error("URL de YouTube inválida:", url);
      return "";
    }
  };

  const embedUrl = getEmbedUrl(url);

  if (!embedUrl) {
    return <p className="text-red-500">Video no disponible</p>;
  }

  return (
    <div className="w-full lg:max-w-[560px] max-w-80">
      <iframe
        src={embedUrl}
        title="YouTube video player"
        className="w-full aspect-video rounded-xl shadow-lg"
        frameBorder="0"
        allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
        referrerPolicy="strict-origin-when-cross-origin"
        allowFullScreen
      ></iframe>
    </div>
  );
};

export default YouTubeVideo;
